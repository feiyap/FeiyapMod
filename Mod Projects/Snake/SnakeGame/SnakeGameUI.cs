using System.Collections.Generic;
using ChronoArkMod;
using GameDataEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    /// <summary>
    /// 运行时创建的贪吃蛇小游戏界面与逻辑。
    /// </summary>
    public class SnakeGameUI : MonoBehaviour
    {
        private const int GridWidth = 20;
        private const int GridHeight = 15;
        private const float CellSize = 28f;
        private const float TickInterval = 0.14f;
        private const int GoldPerScore = 100;

        private static SnakeGameUI _instance;
        private static Sprite _whiteSprite;

        private enum GameState
        {
            Playing,
            Ended
        }

        private readonly LinkedList<Vector2Int> _snake = new LinkedList<Vector2Int>();
        private readonly HashSet<Vector2Int> _snakeSet = new HashSet<Vector2Int>();
        private Vector2Int _direction = Vector2Int.right;
        private Vector2Int _pendingDirection = Vector2Int.right;
        private Vector2Int _food;
        private int _score;
        private float _tickTimer;
        private GameState _state = GameState.Playing;
        private bool _rewardGranted;

        private RectTransform _boardRoot;
        private Image[,] _cells;
        private Text _scoreText;
        private GameObject _resultPanel;
        private Text _resultText;

        public static bool IsOpen => _instance != null;

        public static bool Open()
        {
            if (_instance != null)
            {
                return false;
            }

            GameObject root = new GameObject("SnakeGameUI");
            Canvas canvas = root.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 9000;

            CanvasScaler scaler = root.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            scaler.matchWidthOrHeight = 0.5f;

            root.AddComponent<GraphicRaycaster>();

            // 启用原版 PlayerStop：禁用场上 PlayerController，避免 WASD/方向键穿透移动
            PlayerStop playerStop = root.AddComponent<PlayerStop>();
            playerStop.Blur = false;
            playerStop.CanStatOpen = false;

            _instance = root.AddComponent<SnakeGameUI>();
            _instance.BuildUI();
            _instance.ResetGame();
            Object.DontDestroyOnLoad(root);
            return true;
        }

        private static string Loc(string key)
        {
            try
            {
                return ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate(key);
            }
            catch
            {
                return key;
            }
        }

        private static Sprite WhiteSprite()
        {
            if (_whiteSprite != null)
            {
                return _whiteSprite;
            }

            Texture2D tex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            tex.SetPixel(0, 0, Color.white);
            tex.Apply();
            _whiteSprite = Sprite.Create(tex, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f), 1f);
            return _whiteSprite;
        }

        private void BuildUI()
        {
            // 半透明遮罩（拦截鼠标射线，避免点击穿透到下层 UI）
            Image overlay = CreateImage(transform, "Overlay", new Color(0f, 0f, 0f, 0.82f));
            overlay.raycastTarget = true;
            StretchFull(overlay.rectTransform);

            // 标题与得分
            Text title = CreateText(transform, "Title", Loc("SnakeGame/Title"), 36, TextAnchor.MiddleCenter);
            RectTransform titleRt = title.rectTransform;
            titleRt.anchorMin = new Vector2(0.5f, 1f);
            titleRt.anchorMax = new Vector2(0.5f, 1f);
            titleRt.pivot = new Vector2(0.5f, 1f);
            titleRt.anchoredPosition = new Vector2(0f, -40f);
            titleRt.sizeDelta = new Vector2(800f, 50f);

            _scoreText = CreateText(transform, "Score", "", 28, TextAnchor.MiddleCenter);
            RectTransform scoreRt = _scoreText.rectTransform;
            scoreRt.anchorMin = new Vector2(0.5f, 1f);
            scoreRt.anchorMax = new Vector2(0.5f, 1f);
            scoreRt.pivot = new Vector2(0.5f, 1f);
            scoreRt.anchoredPosition = new Vector2(0f, -95f);
            scoreRt.sizeDelta = new Vector2(800f, 40f);

            Text hint = CreateText(transform, "Hint", Loc("SnakeGame/Hint"), 20, TextAnchor.MiddleCenter);
            RectTransform hintRt = hint.rectTransform;
            hintRt.anchorMin = new Vector2(0.5f, 0f);
            hintRt.anchorMax = new Vector2(0.5f, 0f);
            hintRt.pivot = new Vector2(0.5f, 0f);
            hintRt.anchoredPosition = new Vector2(0f, 36f);
            hintRt.sizeDelta = new Vector2(900f, 30f);
            hint.color = new Color(0.8f, 0.8f, 0.8f, 1f);

            // 棋盘
            float boardW = GridWidth * CellSize;
            float boardH = GridHeight * CellSize;
            GameObject boardGo = new GameObject("Board", typeof(RectTransform));
            boardGo.transform.SetParent(transform, false);
            _boardRoot = boardGo.GetComponent<RectTransform>();
            _boardRoot.anchorMin = new Vector2(0.5f, 0.5f);
            _boardRoot.anchorMax = new Vector2(0.5f, 0.5f);
            _boardRoot.pivot = new Vector2(0.5f, 0.5f);
            _boardRoot.sizeDelta = new Vector2(boardW + 8f, boardH + 8f);
            _boardRoot.anchoredPosition = new Vector2(0f, -10f);

            Image boardBg = boardGo.AddComponent<Image>();
            boardBg.sprite = WhiteSprite();
            boardBg.color = new Color(0.12f, 0.12f, 0.14f, 1f);

            _cells = new Image[GridWidth, GridHeight];
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Image cell = CreateImage(_boardRoot, "Cell_" + x + "_" + y, new Color(0.18f, 0.18f, 0.22f, 1f));
                    RectTransform rt = cell.rectTransform;
                    rt.anchorMin = new Vector2(0f, 0f);
                    rt.anchorMax = new Vector2(0f, 0f);
                    rt.pivot = new Vector2(0f, 0f);
                    rt.sizeDelta = new Vector2(CellSize - 2f, CellSize - 2f);
                    rt.anchoredPosition = new Vector2(4f + x * CellSize, 4f + y * CellSize);
                    _cells[x, y] = cell;
                }
            }

            // 结算面板
            _resultPanel = new GameObject("ResultPanel", typeof(RectTransform), typeof(Image));
            _resultPanel.transform.SetParent(transform, false);
            RectTransform resultRt = _resultPanel.GetComponent<RectTransform>();
            resultRt.anchorMin = new Vector2(0.5f, 0.5f);
            resultRt.anchorMax = new Vector2(0.5f, 0.5f);
            resultRt.sizeDelta = new Vector2(520f, 260f);
            resultRt.anchoredPosition = Vector2.zero;
            Image resultBg = _resultPanel.GetComponent<Image>();
            resultBg.sprite = WhiteSprite();
            resultBg.color = new Color(0.1f, 0.1f, 0.12f, 0.95f);

            _resultText = CreateText(_resultPanel.transform, "ResultText", "", 26, TextAnchor.MiddleCenter);
            RectTransform resultTextRt = _resultText.rectTransform;
            resultTextRt.anchorMin = new Vector2(0.5f, 0.55f);
            resultTextRt.anchorMax = new Vector2(0.5f, 0.55f);
            resultTextRt.sizeDelta = new Vector2(460f, 120f);

            Button closeBtn = CreateButton(_resultPanel.transform, "CloseButton", Loc("SnakeGame/Close"), OnCloseClicked);
            RectTransform btnRt = closeBtn.GetComponent<RectTransform>();
            btnRt.anchorMin = new Vector2(0.5f, 0.18f);
            btnRt.anchorMax = new Vector2(0.5f, 0.18f);
            btnRt.sizeDelta = new Vector2(180f, 48f);

            _resultPanel.SetActive(false);
            RefreshScoreText();
        }

        private void ResetGame()
        {
            _snake.Clear();
            _snakeSet.Clear();
            _score = 0;
            _tickTimer = 0f;
            _state = GameState.Playing;
            _rewardGranted = false;
            _direction = Vector2Int.right;
            _pendingDirection = Vector2Int.right;

            Vector2Int start = new Vector2Int(GridWidth / 2, GridHeight / 2);
            for (int i = 2; i >= 0; i--)
            {
                Vector2Int p = new Vector2Int(start.x - i, start.y);
                _snake.AddLast(p);
                _snakeSet.Add(p);
            }

            SpawnFood();
            if (_resultPanel != null)
            {
                _resultPanel.SetActive(false);
            }

            RefreshScoreText();
            RedrawBoard();
        }

        private void Update()
        {
            if (_state == GameState.Playing)
            {
                ReadInput();
                _tickTimer += Time.unscaledDeltaTime;
                if (_tickTimer >= TickInterval)
                {
                    _tickTimer -= TickInterval;
                    Step();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Escape))
            {
                OnCloseClicked();
            }
        }

        private void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EndGame();
                return;
            }

            Vector2Int next = _pendingDirection;
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                next = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                next = Vector2Int.down;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                next = Vector2Int.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                next = Vector2Int.right;
            }

            // 禁止 180° 掉头
            if (next + _direction != Vector2Int.zero)
            {
                _pendingDirection = next;
            }
        }

        private void Step()
        {
            _direction = _pendingDirection;
            Vector2Int head = _snake.Last.Value;
            Vector2Int next = head + _direction;

            if (next.x < 0 || next.x >= GridWidth || next.y < 0 || next.y >= GridHeight || _snakeSet.Contains(next))
            {
                EndGame();
                return;
            }

            _snake.AddLast(next);
            _snakeSet.Add(next);

            if (next == _food)
            {
                _score++;
                RefreshScoreText();
                SpawnFood();
            }
            else
            {
                Vector2Int tail = _snake.First.Value;
                _snake.RemoveFirst();
                _snakeSet.Remove(tail);
            }

            RedrawBoard();
        }

        private void SpawnFood()
        {
            List<Vector2Int> empty = new List<Vector2Int>(GridWidth * GridHeight - _snakeSet.Count);
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Vector2Int p = new Vector2Int(x, y);
                    if (!_snakeSet.Contains(p))
                    {
                        empty.Add(p);
                    }
                }
            }

            if (empty.Count == 0)
            {
                EndGame();
                return;
            }

            _food = empty[Random.Range(0, empty.Count)];
        }

        private void RedrawBoard()
        {
            Color emptyColor = new Color(0.18f, 0.18f, 0.22f, 1f);
            Color snakeColor = new Color(0.35f, 0.85f, 0.45f, 1f);
            Color headColor = new Color(0.55f, 1f, 0.55f, 1f);
            Color foodColor = new Color(0.95f, 0.35f, 0.35f, 1f);

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    _cells[x, y].color = emptyColor;
                }
            }

            _cells[_food.x, _food.y].color = foodColor;

            LinkedListNode<Vector2Int> node = _snake.First;
            while (node != null)
            {
                bool isHead = node == _snake.Last;
                _cells[node.Value.x, node.Value.y].color = isHead ? headColor : snakeColor;
                node = node.Next;
            }
        }

        private void RefreshScoreText()
        {
            if (_scoreText != null)
            {
                _scoreText.text = string.Format(Loc("SnakeGame/Score"), _score);
            }
        }

        private void EndGame()
        {
            if (_state == GameState.Ended)
            {
                return;
            }

            _state = GameState.Ended;
            int gold = _score * GoldPerScore;
            string resultFmt = Loc("SnakeGame/Result").Replace('|', '\n');
            _resultText.text = string.Format(resultFmt, _score, gold);
            _resultPanel.SetActive(true);
        }

        private void OnCloseClicked()
        {
            if (_state != GameState.Ended)
            {
                EndGame();
            }

            GrantReward();
            Close();
        }

        private void GrantReward()
        {
            if (_rewardGranted)
            {
                return;
            }

            _rewardGranted = true;
            int gold = _score * GoldPerScore;
            if (gold > 0)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, gold));
            }
        }

        private void Close()
        {
            if (_instance == this)
            {
                _instance = null;
            }

            Destroy(gameObject);
        }

        private static Image CreateImage(Transform parent, string name, Color color)
        {
            GameObject go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            Image img = go.GetComponent<Image>();
            img.sprite = WhiteSprite();
            img.color = color;
            return img;
        }

        private static Text CreateText(Transform parent, string name, string content, int fontSize, TextAnchor align)
        {
            GameObject go = new GameObject(name, typeof(RectTransform), typeof(Text));
            go.transform.SetParent(parent, false);
            Text text = go.GetComponent<Text>();
            text.text = content;
            text.fontSize = fontSize;
            text.alignment = align;
            text.color = Color.white;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.font = ResolveFont(fontSize);
            return text;
        }

        private static Button CreateButton(Transform parent, string name, string label, UnityEngine.Events.UnityAction onClick)
        {
            Image bg = CreateImage(parent, name, new Color(0.25f, 0.55f, 0.35f, 1f));
            Button btn = bg.gameObject.AddComponent<Button>();
            ColorBlock colors = btn.colors;
            colors.highlightedColor = new Color(0.35f, 0.7f, 0.45f, 1f);
            colors.pressedColor = new Color(0.2f, 0.45f, 0.3f, 1f);
            btn.colors = colors;
            btn.onClick.AddListener(onClick);

            Text text = CreateText(bg.transform, "Label", label, 22, TextAnchor.MiddleCenter);
            StretchFull(text.rectTransform);
            return btn;
        }

        private static void StretchFull(RectTransform rt)
        {
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }

        private static Font _cachedFont;

        private static Font ResolveFont(int fontSize)
        {
            if (_cachedFont != null)
            {
                return _cachedFont;
            }

            // 优先复用场景中已有 Text 字体，避免内置字体路径因 Unity 版本差异失效。
            Text existing = Object.FindObjectOfType<Text>();
            if (existing != null && existing.font != null)
            {
                _cachedFont = existing.font;
                return _cachedFont;
            }

            _cachedFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
            if (_cachedFont == null)
            {
                _cachedFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            }

            if (_cachedFont == null)
            {
                _cachedFont = Font.CreateDynamicFontFromOSFont(new[] { "Microsoft YaHei", "SimHei", "Arial" }, fontSize);
            }

            return _cachedFont;
        }
    }
}
