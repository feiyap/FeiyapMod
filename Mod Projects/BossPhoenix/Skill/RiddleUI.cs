using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BossPhoenix
{
    /// <summary>
    /// 猜谜游戏界面：挡住下层输入，正则搜技能，Wordle 式对照。
    /// </summary>
    public class RiddleUI : MonoBehaviour
    {
        public enum Result
        {
            None,
            Won,
            Lost
        }

        private const int PreviewLimit = 8;
        private const int ColCount = 9;
        private const float CellWidth = 136f;
        private const float CellHeight = 42f;
        private const float DropdownRowHeight = 36f;
        private const float DropdownRowGap = 2f;
        private const float DropdownPad = 6f;
        private const float DropdownBottom = 84f;

        private static readonly Color ColorExact = new Color(0.35f, 0.72f, 0.38f, 1f);
        private static readonly Color ColorClose = new Color(0.93f, 0.78f, 0.28f, 1f);
        private static readonly Color ColorNone = new Color(0.88f, 0.88f, 0.90f, 1f);
        private static readonly Color ColorHeader = new Color(0.12f, 0.24f, 0.40f, 1f);
        private static readonly Color ColorTextDark = new Color(0.12f, 0.12f, 0.14f, 1f);

        private static RiddleUI instance;
        private static Sprite whiteSprite;
        private static Font cachedFont;

        public static bool IsOpen
        {
            get { return instance != null; }
        }

        public static Result LastResult = Result.None;

        private B_BossPhoenix_P state;
        private BattleChar phoenix;
        private bool casual;
        private string casualImaginedKey = "";
        private int casualWrong;
        private bool submitted;
        private bool finished;
        private bool ignoreConfirmKey;

        private InputField input;
        private Text statusText;
        private Button giveUpButton;
        private RectTransform tableRoot;
        private RectTransform dropdownRoot;
        private RectTransform tipPanel;
        private Text tipText;
        private bool waitingConfirm;
        private readonly List<GDESkillData> previewHits = new List<GDESkillData>();
        private readonly List<Image> dropdownRows = new List<Image>();
        private readonly List<Text> dropdownLabels = new List<Text>();
        private int dropdownIndex;

        public static void Open(B_BossPhoenix_P state, BattleChar phoenix)
        {
            Spawn(state, phoenix, false);
        }

        /// <summary>
        /// 城镇闲聊：只猜 1 次，无奖励无惩罚。
        /// </summary>
        public static void OpenCasual()
        {
            Spawn(null, null, true);
        }

        private static void Spawn(B_BossPhoenix_P state, BattleChar phoenix, bool casual)
        {
            if (instance != null)
            {
                Object.Destroy(instance.gameObject);
            }

            LastResult = Result.None;
            GameObject root = new GameObject("BossPhoenix_RiddleUI");
            Canvas canvas = root.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 12000;
            canvas.overrideSorting = true;

            CanvasScaler scaler = root.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            scaler.matchWidthOrHeight = 0.5f;
            root.AddComponent<GraphicRaycaster>();

            PlayerStop playerStop = root.AddComponent<PlayerStop>();
            playerStop.Blur = false;
            playerStop.CanStatOpen = false;

            instance = root.AddComponent<RiddleUI>();
            instance.state = state;
            instance.phoenix = phoenix;
            instance.casual = casual;
            if (casual)
            {
                instance.casualImaginedKey = PhoenixSkillUtil.PickRandomImaginedKey();
                instance.casualWrong = 0;
            }
            instance.BuildUI();
            Object.DontDestroyOnLoad(root);
        }

        private void BuildUI()
        {
            Image overlay = CreateImage(this.transform, "Overlay", new Color(0f, 0f, 0f, 0.78f));
            overlay.raycastTarget = true;
            StretchFull(overlay.rectTransform);

            Text title = CreateText(this.transform, "Title", PhoenixLoc.Loc("Riddle/UiTitle"), 34, TextAnchor.MiddleCenter);
            title.color = Color.white;
            RectTransform titleRt = title.rectTransform;
            titleRt.anchorMin = new Vector2(0.5f, 1f);
            titleRt.anchorMax = new Vector2(0.5f, 1f);
            titleRt.pivot = new Vector2(0.5f, 1f);
            titleRt.anchoredPosition = new Vector2(0f, -18f);
            titleRt.sizeDelta = new Vector2(1400f, 46f);

            GameObject tableGo = new GameObject("Table", typeof(RectTransform));
            tableGo.transform.SetParent(this.transform, false);
            this.tableRoot = tableGo.GetComponent<RectTransform>();
            this.tableRoot.anchorMin = new Vector2(0.5f, 1f);
            this.tableRoot.anchorMax = new Vector2(0.5f, 1f);
            this.tableRoot.pivot = new Vector2(0.5f, 1f);
            this.tableRoot.anchoredPosition = new Vector2(0f, -72f);
            this.tableRoot.sizeDelta = new Vector2(CellWidth * ColCount + 16f, CellHeight * 10f);

            VerticalLayoutGroup vlg = tableGo.AddComponent<VerticalLayoutGroup>();
            vlg.spacing = 4f;
            vlg.childAlignment = TextAnchor.UpperCenter;
            vlg.childControlHeight = false;
            vlg.childControlWidth = false;
            vlg.childForceExpandHeight = false;
            vlg.childForceExpandWidth = false;

            this.AddRow(this.tableRoot, true, null, null);

            this.statusText = CreateText(this.transform, "Status", PhoenixLoc.Loc("Riddle/InputHint"), 20, TextAnchor.MiddleCenter);
            this.statusText.color = new Color(0.85f, 0.85f, 0.85f, 1f);
            RectTransform statusRt = this.statusText.rectTransform;
            statusRt.anchorMin = new Vector2(0.5f, 0f);
            statusRt.anchorMax = new Vector2(0.5f, 0f);
            statusRt.pivot = new Vector2(0.5f, 0f);
            statusRt.anchoredPosition = new Vector2(0f, DropdownBottom);
            statusRt.sizeDelta = new Vector2(1400f, 28f);

            this.BuildDropdown();

            this.input = CreateInput(this.transform, "Input", new Vector2(-60f, 28f), new Vector2(720f, 48f));
            this.input.onValueChanged.AddListener(this.OnInputChanged);
            this.input.onEndEdit.AddListener(this.OnEndEdit);

            Button ok = CreateButton(this.transform, "OkButton", PhoenixLoc.Loc("Riddle/Confirm"), this.OnConfirmClicked);
            RectTransform okRt = ok.GetComponent<RectTransform>();
            okRt.anchorMin = new Vector2(0.5f, 0f);
            okRt.anchorMax = new Vector2(0.5f, 0f);
            okRt.pivot = new Vector2(0.5f, 0f);
            okRt.anchoredPosition = new Vector2(370f, 28f);
            okRt.sizeDelta = new Vector2(140f, 48f);

            this.giveUpButton = CreateButton(this.transform, "GiveUpButton", PhoenixLoc.Loc("Riddle/GiveUp"), this.OnGiveUpClicked);
            Image giveUpImg = this.giveUpButton.GetComponent<Image>();
            if (giveUpImg != null)
            {
                giveUpImg.color = new Color(0.72f, 0.28f, 0.26f, 1f);
            }
            RectTransform giveUpRt = this.giveUpButton.GetComponent<RectTransform>();
            giveUpRt.anchorMin = new Vector2(0.5f, 0f);
            giveUpRt.anchorMax = new Vector2(0.5f, 0f);
            giveUpRt.pivot = new Vector2(0.5f, 0f);
            giveUpRt.anchoredPosition = new Vector2(530f, 28f);
            giveUpRt.sizeDelta = new Vector2(140f, 48f);

            this.BuildTip();
            this.input.ActivateInputField();
            this.input.Select();
        }

        private void Update()
        {
            this.MoveTipToMouse();
            if (this.waitingConfirm)
            {
                if (this.ignoreConfirmKey)
                {
                    if (!Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.KeypadEnter))
                    {
                        this.ignoreConfirmKey = false;
                    }
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    this.CloseAfterWait();
                }
                return;
            }
            if (this.finished)
            {
                return;
            }

            if (this.previewHits.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    this.dropdownIndex = (this.dropdownIndex - 1 + this.previewHits.Count) % this.previewHits.Count;
                    this.RefreshDropdownHighlight();
                    this.KeepCaret();
                    return;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    this.dropdownIndex = (this.dropdownIndex + 1) % this.previewHits.Count;
                    this.RefreshDropdownHighlight();
                    this.KeepCaret();
                    return;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                this.submitted = true;
                if (this.previewHits.Count > 0 && this.dropdownIndex >= 0 && this.dropdownIndex < this.previewHits.Count)
                {
                    this.AcceptGuess(this.previewHits[this.dropdownIndex]);
                }
                else
                {
                    this.TrySubmit(this.input != null ? this.input.text : "");
                }
            }
        }

        private void OnEndEdit(string value)
        {
            if (this.finished)
            {
                return;
            }
            if (this.submitted)
            {
                this.submitted = false;
                return;
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                this.TrySubmit(value);
            }
        }

        private void OnConfirmClicked()
        {
            if (this.waitingConfirm)
            {
                this.CloseAfterWait();
                return;
            }
            if (this.previewHits.Count > 0 && this.dropdownIndex >= 0 && this.dropdownIndex < this.previewHits.Count)
            {
                this.AcceptGuess(this.previewHits[this.dropdownIndex]);
                return;
            }
            this.TrySubmit(this.input != null ? this.input.text : "");
        }

        private void OnGiveUpClicked()
        {
            if (this.finished)
            {
                return;
            }
            this.RevealAnswer();
        }

        private void OnInputChanged(string value)
        {
            this.RefreshPreview(value);
        }

        private void KeepCaret()
        {
            if (this.input == null)
            {
                return;
            }
            this.input.caretPosition = this.input.text.Length;
            this.input.selectionAnchorPosition = this.input.caretPosition;
            this.input.selectionFocusPosition = this.input.caretPosition;
        }

        private void BuildDropdown()
        {
            GameObject go = new GameObject("Dropdown", typeof(RectTransform));
            go.transform.SetParent(this.transform, false);
            this.dropdownRoot = go.GetComponent<RectTransform>();
            this.dropdownRoot.anchorMin = new Vector2(0.5f, 0f);
            this.dropdownRoot.anchorMax = new Vector2(0.5f, 0f);
            this.dropdownRoot.pivot = new Vector2(0.5f, 0f);
            this.dropdownRoot.anchoredPosition = new Vector2(-60f, DropdownBottom);
            this.dropdownRoot.sizeDelta = new Vector2(720f, DropdownHeight(PreviewLimit));

            Image bg = go.AddComponent<Image>();
            bg.sprite = WhiteSprite();
            bg.color = new Color(0.08f, 0.10f, 0.14f, 0.96f);
            bg.raycastTarget = true;

            for (int i = 0; i < PreviewLimit; i++)
            {
                int captured = i;
                Image row = CreateImage(go.transform, "Opt_" + i, new Color(0.16f, 0.18f, 0.22f, 1f));
                RectTransform rowRt = row.rectTransform;
                rowRt.anchorMin = new Vector2(0.5f, 1f);
                rowRt.anchorMax = new Vector2(0.5f, 1f);
                rowRt.pivot = new Vector2(0.5f, 1f);
                rowRt.sizeDelta = new Vector2(720f - DropdownPad * 2f, DropdownRowHeight);
                Button btn = row.gameObject.AddComponent<Button>();
                btn.onClick.AddListener(delegate
                {
                    if (captured < this.previewHits.Count)
                    {
                        this.AcceptGuess(this.previewHits[captured]);
                    }
                });
                Text label = CreateText(row.transform, "Label", "", 18, TextAnchor.MiddleLeft);
                label.raycastTarget = false;
                label.color = Color.white;
                StretchFull(label.rectTransform);
                label.rectTransform.offsetMin = new Vector2(12f, 2f);
                label.rectTransform.offsetMax = new Vector2(-8f, -2f);
                this.dropdownRows.Add(row);
                this.dropdownLabels.Add(label);
                row.gameObject.SetActive(false);
            }
            go.SetActive(false);
        }

        private void RefreshPreview(string value)
        {
            this.previewHits.Clear();
            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
            {
                this.dropdownRoot.gameObject.SetActive(false);
                this.PlaceStatus(false, 0);
                return;
            }

            List<GDESkillData> hits = PhoenixSkillUtil.SearchSkills(value);
            int shown = Mathf.Min(PreviewLimit, hits.Count);
            for (int i = 0; i < shown; i++)
            {
                this.previewHits.Add(hits[i]);
            }

            if (this.previewHits.Count == 0)
            {
                this.dropdownRoot.gameObject.SetActive(false);
                this.PlaceStatus(false, 0);
                this.statusText.color = new Color(1f, 0.55f, 0.45f, 1f);
                this.statusText.text = PhoenixLoc.Loc("Riddle/NoMatch");
                return;
            }

            this.statusText.color = new Color(0.85f, 0.85f, 0.85f, 1f);
            this.statusText.text = hits.Count > shown
                ? string.Format(PhoenixLoc.Loc("Riddle/MoreMatches"), hits.Count)
                : PhoenixLoc.Loc("Riddle/InputHint");

            this.dropdownIndex = 0;
            this.dropdownRoot.sizeDelta = new Vector2(720f, DropdownHeight(this.previewHits.Count));
            this.PlaceStatus(true, this.previewHits.Count);
            this.dropdownRoot.gameObject.SetActive(true);
            for (int i = 0; i < PreviewLimit; i++)
            {
                bool on = i < this.previewHits.Count;
                this.dropdownRows[i].gameObject.SetActive(on);
                if (on)
                {
                    RectTransform rowRt = this.dropdownRows[i].rectTransform;
                    rowRt.anchoredPosition = new Vector2(0f, -DropdownPad - i * (DropdownRowHeight + DropdownRowGap));
                    rowRt.sizeDelta = new Vector2(720f - DropdownPad * 2f, DropdownRowHeight);
                    this.dropdownLabels[i].text = PhoenixSkillUtil.FormatSkillOption(this.previewHits[i]);
                    this.dropdownLabels[i].color = Color.white;
                }
            }
            this.RefreshDropdownHighlight();
        }

        private static float DropdownHeight(int count)
        {
            if (count <= 0)
            {
                return DropdownPad * 2f;
            }
            return DropdownPad * 2f + count * DropdownRowHeight + (count - 1) * DropdownRowGap;
        }

        private void PlaceStatus(bool dropdownOpen, int count)
        {
            if (this.statusText == null)
            {
                return;
            }
            float y = DropdownBottom;
            if (dropdownOpen)
            {
                y = DropdownBottom + DropdownHeight(count) + 8f;
            }
            this.statusText.rectTransform.anchoredPosition = new Vector2(0f, y);
        }

        private void RefreshDropdownHighlight()
        {
            for (int i = 0; i < this.dropdownRows.Count; i++)
            {
                if (!this.dropdownRows[i].gameObject.activeSelf)
                {
                    continue;
                }
                bool selected = i == this.dropdownIndex;
                this.dropdownRows[i].color = selected
                    ? new Color(0.22f, 0.46f, 0.78f, 1f)
                    : new Color(0.16f, 0.18f, 0.22f, 1f);
                this.dropdownLabels[i].color = Color.white;
            }
        }

        private int MaxGuessNow
        {
            get { return PhoenixSkillUtil.MaxGuess; }
        }

        private void EnsureImaginedNow()
        {
            if (this.casual)
            {
                if (string.IsNullOrEmpty(this.casualImaginedKey))
                {
                    this.casualImaginedKey = PhoenixSkillUtil.PickRandomImaginedKey();
                }
                return;
            }
            if (this.state != null)
            {
                this.state.EnsureImagined();
            }
        }

        private string CurrentImaginedKey
        {
            get
            {
                if (this.casual)
                {
                    return this.casualImaginedKey;
                }
                return this.state != null ? this.state.ImaginedKey : "";
            }
            set
            {
                if (this.casual)
                {
                    this.casualImaginedKey = value;
                    return;
                }
                if (this.state != null)
                {
                    this.state.ImaginedKey = value;
                }
            }
        }

        private int CurrentWrong
        {
            get
            {
                if (this.casual)
                {
                    return this.casualWrong;
                }
                return this.state != null ? this.state.WrongGuesses : 0;
            }
            set
            {
                if (this.casual)
                {
                    this.casualWrong = value;
                    return;
                }
                if (this.state != null)
                {
                    this.state.WrongGuesses = value;
                }
            }
        }

        private void TrySubmit(string raw)
        {
            if (this.finished || (!this.casual && this.state == null))
            {
                return;
            }

            List<GDESkillData> hits = PhoenixSkillUtil.SearchSkills(raw);
            if (hits.Count != 1)
            {
                this.statusText.color = new Color(1f, 0.55f, 0.45f, 1f);
                this.statusText.text = hits.Count == 0
                    ? PhoenixLoc.Loc("Riddle/NotExist")
                    : string.Format(PhoenixLoc.Loc("Riddle/NotUnique"), hits.Count);
                if (this.input != null)
                {
                    this.input.ActivateInputField();
                    this.input.Select();
                }
                return;
            }

            this.AcceptGuess(hits[0]);
        }

        private void AcceptGuess(GDESkillData guess)
        {
            this.EnsureImaginedNow();
            bool firstTry = this.CurrentWrong == 0 && this.tableRoot.childCount <= 1;
            if (firstTry && !this.casual && guess.KeyID == this.CurrentImaginedKey && !B_BossPhoenix_P.IsStubborn(this.phoenix))
            {
                this.CurrentImaginedKey = PhoenixSkillUtil.PickRandomImaginedKeyExcept(guess.KeyID);
            }

            GDESkillData target = PhoenixSkillUtil.FindSkill(this.CurrentImaginedKey);
            if (target == null)
            {
                this.statusText.text = PhoenixLoc.Loc("Riddle/NotExist");
                return;
            }

            if (guess.KeyID == this.CurrentImaginedKey)
            {
                this.AddRow(this.tableRoot, false, guess, target);
                this.WaitForConfirm();
                return;
            }

            this.CurrentWrong = this.CurrentWrong + 1;
            if (!this.casual)
            {
                this.DealWrongPain(this.CurrentWrong);
            }
            this.AddRow(this.tableRoot, false, guess, target);
            this.statusText.color = new Color(0.85f, 0.85f, 0.85f, 1f);
            this.statusText.text = string.Format(PhoenixLoc.Loc("Riddle/WrongCount"), this.CurrentWrong, this.MaxGuessNow);

            if (this.input != null)
            {
                this.input.text = "";
                this.input.ActivateInputField();
                this.input.Select();
            }
            this.dropdownRoot.gameObject.SetActive(false);
            this.previewHits.Clear();

            if (this.CurrentWrong >= this.MaxGuessNow)
            {
                if (this.casual)
                {
                    this.RevealAnswer();
                    return;
                }
                this.Finish(Result.Lost);
            }
        }

        private void DealWrongPain(int amount)
        {
            if (this.casual || BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return;
            }
            List<BattleChar> alives = new List<BattleChar>(BattleSystem.instance.AllyTeam.AliveChars);
            for (int i = 0; i < alives.Count; i++)
            {
                alives[i].Damage(this.phoenix, amount, false, true, false, 0, false, false, false);
            }
        }

        private void RevealAnswer()
        {
            this.EnsureImaginedNow();
            GDESkillData target = PhoenixSkillUtil.FindSkill(this.CurrentImaginedKey);
            if (target != null)
            {
                this.AddRow(this.tableRoot, false, target, target);
                this.statusText.color = new Color(1f, 0.78f, 0.35f, 1f);
                this.statusText.text = string.Format(PhoenixLoc.Loc("Riddle/GiveUpReveal"), PhoenixSkillUtil.FormatSkillOption(target));
            }
            else
            {
                this.statusText.color = new Color(1f, 0.78f, 0.35f, 1f);
                this.statusText.text = PhoenixLoc.Loc("Riddle/GiveUpRevealEmpty");
            }
            this.finished = true;
            this.waitingConfirm = true;
            this.ignoreConfirmKey = true;
            LastResult = Result.Lost;
            if (this.input != null)
            {
                this.input.interactable = false;
            }
            if (this.giveUpButton != null)
            {
                this.giveUpButton.gameObject.SetActive(false);
            }
            if (this.dropdownRoot != null)
            {
                this.dropdownRoot.gameObject.SetActive(false);
            }
            this.previewHits.Clear();
        }

        private void CloseAfterWait()
        {
            if (!this.waitingConfirm)
            {
                return;
            }
            this.waitingConfirm = false;
            if (!this.casual && LastResult == Result.Lost && this.state != null && this.state.RegisterRiddleLoss())
            {
                this.EndBattleNow();
            }
            this.CloseSelf();
        }

        private void WaitForConfirm()
        {
            this.finished = true;
            this.waitingConfirm = true;
            this.ignoreConfirmKey = true;
            LastResult = Result.Won;
            if (this.input != null)
            {
                this.input.interactable = false;
            }
            if (this.giveUpButton != null)
            {
                this.giveUpButton.gameObject.SetActive(false);
            }
            if (this.dropdownRoot != null)
            {
                this.dropdownRoot.gameObject.SetActive(false);
            }
            this.previewHits.Clear();
            if (this.statusText != null)
            {
                this.statusText.color = new Color(0.55f, 0.92f, 0.58f, 1f);
                this.statusText.text = PhoenixLoc.Loc("Riddle/WonHint");
            }
        }

        private void Finish(Result result)
        {
            this.finished = true;
            LastResult = result;
            if (this.input != null)
            {
                this.input.interactable = false;
            }
            if (result == Result.Lost && !this.casual && this.state != null && this.state.RegisterRiddleLoss())
            {
                this.EndBattleNow();
            }
            this.Invoke("CloseSelf", 0.45f);
        }

        private void EndBattleNow()
        {
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return;
            }
            List<BattleChar> alives = new List<BattleChar>(BattleSystem.instance.AllyTeam.AliveChars);
            for (int i = 0; i < alives.Count; i++)
            {
                alives[i].HP = 0;
                alives[i].Dead();
            }
        }

        private void CloseSelf()
        {
            if (instance == this)
            {
                instance = null;
            }
            Object.Destroy(this.gameObject);
        }

        private void AddRow(RectTransform parent, bool header, GDESkillData guess, GDESkillData target)
        {
            GameObject row = new GameObject(header ? "Header" : "Row", typeof(RectTransform));
            row.transform.SetParent(parent, false);
            RectTransform rowRt = row.GetComponent<RectTransform>();
            rowRt.sizeDelta = new Vector2(CellWidth * ColCount, CellHeight);
            HorizontalLayoutGroup hlg = row.AddComponent<HorizontalLayoutGroup>();
            hlg.spacing = 4f;
            hlg.childAlignment = TextAnchor.MiddleCenter;
            hlg.childControlHeight = true;
            hlg.childControlWidth = false;
            hlg.childForceExpandHeight = true;
            hlg.childForceExpandWidth = false;

            if (header)
            {
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColName"), "Riddle/Tip/Name");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColOwner"), "Riddle/Tip/Owner");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColRole"), "Riddle/Tip/Role");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColCost"), "Riddle/Tip/Cost");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColTarget"), "Riddle/Tip/Target");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColMult"), "Riddle/Tip/Mult");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColType"), "Riddle/Tip/Type");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColTiming"), "Riddle/Tip/Timing");
                this.AddHeaderCell(row.transform, PhoenixLoc.Loc("Riddle/ColBuff"), "Riddle/Tip/Buff");
                return;
            }

            int guessCost = PhoenixSkillUtil.GetCost(guess);
            int targetCost = PhoenixSkillUtil.GetCost(target);
            int guessMult = PhoenixSkillUtil.GetMultiplier(guess);
            int targetMult = PhoenixSkillUtil.GetMultiplier(target);
            int guessBuff = PhoenixSkillUtil.GetBuffCount(guess);
            int targetBuff = PhoenixSkillUtil.GetBuffCount(target);

            this.AddCell(row.transform, PhoenixSkillUtil.GetSkillName(guess), ColorOf(PhoenixSkillUtil.CompareName(guess, target)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.GetOwnerName(guess), ColorOf(PhoenixSkillUtil.CompareOwner(guess, target)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.GetOwnerRoleName(guess), ColorOf(PhoenixSkillUtil.CompareRole(guess, target)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.FormatCost(guessCost) + PhoenixSkillUtil.Arrow(guessCost, targetCost), ColorOf(PhoenixSkillUtil.CompareCost(guessCost, targetCost)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.GetTargetName(guess), ColorOf(PhoenixSkillUtil.CompareTarget(guess, target)), ColorTextDark);
            this.AddCell(row.transform, guessMult.ToString() + "%" + PhoenixSkillUtil.Arrow(guessMult, targetMult), ColorOf(PhoenixSkillUtil.CompareMultiplier(guessMult, targetMult)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.GetSkillTypeName(guess), ColorOf(PhoenixSkillUtil.CompareType(guess, target)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.GetTimingName(guess), ColorOf(PhoenixSkillUtil.CompareTiming(guess, target)), ColorTextDark);
            this.AddCell(row.transform, PhoenixSkillUtil.FormatBuff(guessBuff) + PhoenixSkillUtil.Arrow(guessBuff, targetBuff), ColorOf(PhoenixSkillUtil.CompareBuff(guessBuff, targetBuff)), ColorTextDark);
        }

        private void AddHeaderCell(Transform parent, string content, string tipKey)
        {
            Image img = this.AddCell(parent, content, ColorHeader, Color.white);
            img.raycastTarget = true;
            HeaderTip tip = img.gameObject.AddComponent<HeaderTip>();
            tip.ui = this;
            tip.tipKey = tipKey;
        }

        private Image AddCell(Transform parent, string content, Color bg, Color fg)
        {
            Image img = CreateImage(parent, "Cell", bg);
            img.raycastTarget = false;
            LayoutElement le = img.gameObject.AddComponent<LayoutElement>();
            le.preferredWidth = CellWidth;
            le.minWidth = CellWidth;
            le.preferredHeight = CellHeight;
            Text text = CreateText(img.transform, "Label", content, 16, TextAnchor.MiddleCenter);
            text.color = fg;
            text.raycastTarget = false;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            StretchFull(text.rectTransform);
            return img;
        }

        private void BuildTip()
        {
            Image bg = CreateImage(this.transform, "Tip", new Color(0.08f, 0.10f, 0.14f, 0.96f));
            bg.raycastTarget = false;
            this.tipPanel = bg.rectTransform;
            this.tipPanel.anchorMin = new Vector2(0.5f, 0.5f);
            this.tipPanel.anchorMax = new Vector2(0.5f, 0.5f);
            this.tipPanel.pivot = new Vector2(0f, 1f);
            this.tipPanel.sizeDelta = new Vector2(420f, 160f);
            this.tipText = CreateText(bg.transform, "Text", "", 16, TextAnchor.UpperLeft);
            this.tipText.color = Color.white;
            this.tipText.raycastTarget = false;
            this.tipText.horizontalOverflow = HorizontalWrapMode.Wrap;
            this.tipText.verticalOverflow = VerticalWrapMode.Overflow;
            StretchFull(this.tipText.rectTransform);
            this.tipText.rectTransform.offsetMin = new Vector2(12f, 10f);
            this.tipText.rectTransform.offsetMax = new Vector2(-12f, -10f);
            bg.gameObject.SetActive(false);
        }

        public void ShowTip(string tipKey)
        {
            if (this.tipPanel == null || this.tipText == null)
            {
                return;
            }
            this.tipText.text = PhoenixLoc.Loc(tipKey);
            int lines = 1;
            if (!string.IsNullOrEmpty(this.tipText.text))
            {
                lines = this.tipText.text.Split('\n').Length;
            }
            this.tipPanel.sizeDelta = new Vector2(420f, 20f + lines * 22f);
            this.tipPanel.gameObject.SetActive(true);
            this.tipPanel.SetAsLastSibling();
            this.MoveTipToMouse();
        }

        public void HideTip()
        {
            if (this.tipPanel != null)
            {
                this.tipPanel.gameObject.SetActive(false);
            }
        }

        private void MoveTipToMouse()
        {
            if (this.tipPanel == null || !this.tipPanel.gameObject.activeSelf)
            {
                return;
            }
            RectTransform canvasRt = this.transform as RectTransform;
            Vector2 local;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRt, Input.mousePosition, null, out local))
            {
                this.tipPanel.anchoredPosition = local + new Vector2(16f, -12f);
            }
        }

        private class HeaderTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
        {
            public RiddleUI ui;
            public string tipKey;

            public void OnPointerEnter(PointerEventData eventData)
            {
                if (this.ui != null)
                {
                    this.ui.ShowTip(this.tipKey);
                }
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                if (this.ui != null)
                {
                    this.ui.HideTip();
                }
            }
        }

        private static Color ColorOf(RiddleMatch match)
        {
            if (match == RiddleMatch.Exact)
            {
                return ColorExact;
            }
            if (match == RiddleMatch.Close)
            {
                return ColorClose;
            }
            return ColorNone;
        }

        private static InputField CreateInput(Transform parent, string name, Vector2 pos, Vector2 size)
        {
            Image bg = CreateImage(parent, name, new Color(0.95f, 0.95f, 0.96f, 1f));
            RectTransform rt = bg.rectTransform;
            rt.anchorMin = new Vector2(0.5f, 0f);
            rt.anchorMax = new Vector2(0.5f, 0f);
            rt.pivot = new Vector2(0.5f, 0f);
            rt.anchoredPosition = pos;
            rt.sizeDelta = size;

            Text text = CreateText(bg.transform, "Text", "", 22, TextAnchor.MiddleLeft);
            text.color = ColorTextDark;
            text.supportRichText = false;
            RectTransform textRt = text.rectTransform;
            textRt.anchorMin = Vector2.zero;
            textRt.anchorMax = Vector2.one;
            textRt.offsetMin = new Vector2(12f, 4f);
            textRt.offsetMax = new Vector2(-12f, -4f);

            Text placeholder = CreateText(bg.transform, "Placeholder", PhoenixLoc.Loc("Riddle/Placeholder"), 20, TextAnchor.MiddleLeft);
            placeholder.color = new Color(0.5f, 0.5f, 0.52f, 0.85f);
            placeholder.fontStyle = FontStyle.Italic;
            RectTransform phRt = placeholder.rectTransform;
            phRt.anchorMin = Vector2.zero;
            phRt.anchorMax = Vector2.one;
            phRt.offsetMin = new Vector2(12f, 4f);
            phRt.offsetMax = new Vector2(-12f, -4f);

            InputField field = bg.gameObject.AddComponent<InputField>();
            field.textComponent = text;
            field.placeholder = placeholder;
            field.lineType = InputField.LineType.SingleLine;
            field.characterLimit = 80;
            return field;
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
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.font = ResolveFont(fontSize);
            return text;
        }

        private static Button CreateButton(Transform parent, string name, string label, UnityEngine.Events.UnityAction onClick)
        {
            Image bg = CreateImage(parent, name, new Color(0.25f, 0.52f, 0.78f, 1f));
            Button btn = bg.gameObject.AddComponent<Button>();
            ColorBlock colors = btn.colors;
            colors.highlightedColor = new Color(0.35f, 0.62f, 0.88f, 1f);
            colors.pressedColor = new Color(0.18f, 0.40f, 0.62f, 1f);
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

        private static Sprite WhiteSprite()
        {
            if (whiteSprite != null)
            {
                return whiteSprite;
            }
            Texture2D tex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            tex.SetPixel(0, 0, Color.white);
            tex.Apply();
            whiteSprite = Sprite.Create(tex, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f), 1f);
            return whiteSprite;
        }

        private static Font ResolveFont(int fontSize)
        {
            if (cachedFont != null)
            {
                return cachedFont;
            }
            Text existing = Object.FindObjectOfType<Text>();
            if (existing != null && existing.font != null)
            {
                cachedFont = existing.font;
                return cachedFont;
            }
            cachedFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
            if (cachedFont == null)
            {
                cachedFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            }
            if (cachedFont == null)
            {
                cachedFont = Font.CreateDynamicFontFromOSFont(new[] { "Microsoft YaHei", "SimHei", "Arial" }, fontSize);
            }
            return cachedFont;
        }
    }
}
