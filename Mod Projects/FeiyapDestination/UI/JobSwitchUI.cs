using GameDataEditor;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FeiyapDestination
{
    /// <summary>
    /// 角色界面转职按钮：挂在「升级」左侧，圆形，中间显示「转职」。
    /// </summary>
    public static class JobSwitchUI
    {
        private const float ButtonSize = 64f;
        private const float GapFromLevelUp = 12f;

        private static GameObject _buttonObj;
        private static TextMeshProUGUI _tmpLabel;
        private static Text _legacyLabel;
        private static Sprite _circleSprite;
        private static CharStatV4 _boundUi;

        public static void EnsureButton(CharStatV4 ui)
        {
            if (ui == null || !ui.gameObject.activeInHierarchy)
            {
                return;
            }
            Character selected = GetSelectedCharacter(ui);
            if (selected == null || selected.KeyData != FeiyapKeys.Destination)
            {
                if (_buttonObj != null)
                {
                    _buttonObj.SetActive(false);
                }
                return;
            }

            _boundUi = ui;

            // 父节点必须是升级按钮所在层；否则重建
            if (_buttonObj != null)
            {
                bool orphan = _buttonObj.transform.parent == null;
                bool wrongParent = ui.LevelUpBtn != null
                    && _buttonObj.transform.parent != ui.LevelUpBtn.transform.parent;
                if (orphan || wrongParent || ui.LevelUpBtn == null)
                {
                    Object.Destroy(_buttonObj);
                    _buttonObj = null;
                    _tmpLabel = null;
                    _legacyLabel = null;
                }
            }
            if (ui.LevelUpBtn == null)
            {
                return;
            }
            if (_buttonObj == null)
            {
                _buttonObj = CreateButton(ui);
            }
            if (_buttonObj != null)
            {
                _buttonObj.SetActive(true);
                PlaceBesideLevelUp(ui);
                // 打开界面时同步 Role 显示与存档职业一致
                ApplyRoleToCharacter(selected, CV_FeiyapDestination.Instance != null
                    ? CV_FeiyapDestination.Instance.Job
                    : JobMode.Offense);
                SyncRoleVisual(ui, selected);
            }
        }

        public static Character GetSelectedCharacter(CharStatV4 ui)
        {
            try
            {
                if (PlayData.TSavedata != null && PlayData.TSavedata.Party != null
                    && ui.NowCharIndex >= 0 && ui.NowCharIndex < PlayData.TSavedata.Party.Count)
                {
                    return PlayData.TSavedata.Party[ui.NowCharIndex];
                }
            }
            catch
            {
            }
            try
            {
                CharFace face = ui.GetNowCharInfo();
                if (face != null && face.AllyCharacter != null && face.AllyCharacter.Info != null)
                {
                    return face.AllyCharacter.Info;
                }
            }
            catch
            {
            }
            return null;
        }

        private static GameObject CreateButton(CharStatV4 ui)
        {
            Transform parent = ui.LevelUpBtn.transform.parent;
            GameObject go = new GameObject("FeiyapDestination_JobSwitch", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
            go.transform.SetParent(parent, false);

            RectTransform rt = go.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(ButtonSize, ButtonSize);

            Image img = go.GetComponent<Image>();
            img.sprite = GetCircleSprite();
            img.type = Image.Type.Simple;
            img.preserveAspect = true;
            img.color = new Color(0.14f, 0.22f, 0.40f, 0.96f);
            img.raycastTarget = true;

            Button btn = go.GetComponent<Button>();
            btn.targetGraphic = img;
            btn.onClick.AddListener(OnClick);

            GameObject textGo = new GameObject("Label", typeof(RectTransform), typeof(CanvasRenderer));
            textGo.transform.SetParent(go.transform, false);
            RectTransform trt = textGo.GetComponent<RectTransform>();
            trt.anchorMin = Vector2.zero;
            trt.anchorMax = Vector2.one;
            trt.offsetMin = Vector2.zero;
            trt.offsetMax = Vector2.zero;

            TextMeshProUGUI fontSrc = ui.LevelUpBtnDesc != null
                ? ui.LevelUpBtnDesc
                : ui.PassiveNameText;
            if (fontSrc != null)
            {
                _tmpLabel = textGo.AddComponent<TextMeshProUGUI>();
                _tmpLabel.font = fontSrc.font;
                _tmpLabel.fontSharedMaterial = fontSrc.fontSharedMaterial;
                _tmpLabel.fontSize = 18f;
                _tmpLabel.alignment = TextAlignmentOptions.Center;
                _tmpLabel.color = Color.white;
                _tmpLabel.raycastTarget = false;
                _tmpLabel.text = "转职";
            }
            else
            {
                _legacyLabel = textGo.AddComponent<Text>();
                _legacyLabel.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                _legacyLabel.fontSize = 18;
                _legacyLabel.alignment = TextAnchor.MiddleCenter;
                _legacyLabel.color = Color.white;
                _legacyLabel.raycastTarget = false;
                _legacyLabel.text = "转职";
            }

            PlaceBesideLevelUp(ui);
            return go;
        }

        private static void PlaceBesideLevelUp(CharStatV4 ui)
        {
            if (_buttonObj == null || ui == null || ui.LevelUpBtn == null)
            {
                return;
            }
            RectTransform levelRt = ui.LevelUpBtn.GetComponent<RectTransform>();
            RectTransform rt = _buttonObj.GetComponent<RectTransform>();
            rt.anchorMin = levelRt.anchorMin;
            rt.anchorMax = levelRt.anchorMax;
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.sizeDelta = new Vector2(ButtonSize, ButtonSize);
            // 升级按钮左侧
            float levelHalf = Mathf.Max(levelRt.rect.width, levelRt.sizeDelta.x) * 0.5f;
            if (levelHalf < 1f)
            {
                levelHalf = 40f;
            }
            rt.anchoredPosition = levelRt.anchoredPosition
                + new Vector2(-(levelHalf + ButtonSize * 0.5f + GapFromLevelUp), 0f);
            // 保持与升级按钮同层级顺序，避免被遮挡
            rt.SetSiblingIndex(levelRt.GetSiblingIndex());
        }

        private static Sprite GetCircleSprite()
        {
            if (_circleSprite != null)
            {
                return _circleSprite;
            }
            const int size = 64;
            Texture2D tex = new Texture2D(size, size, TextureFormat.ARGB32, false);
            tex.wrapMode = TextureWrapMode.Clamp;
            tex.filterMode = FilterMode.Bilinear;
            float center = (size - 1) * 0.5f;
            float radius = center - 0.5f;
            float radiusSq = radius * radius;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    float dx = x - center;
                    float dy = y - center;
                    float d2 = dx * dx + dy * dy;
                    // 硬圆 + 1px 软边
                    float a = d2 <= radiusSq ? 1f : Mathf.Clamp01(1f - (Mathf.Sqrt(d2) - radius));
                    tex.SetPixel(x, y, new Color(1f, 1f, 1f, a));
                }
            }
            tex.Apply(false, false);
            _circleSprite = Sprite.Create(tex, new Rect(0f, 0f, size, size), new Vector2(0.5f, 0.5f), 100f);
            return _circleSprite;
        }

        private static void OnClick()
        {
            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            if (cv == null)
            {
                return;
            }
            cv.Job = cv.Job == JobMode.Offense ? JobMode.Defense : JobMode.Offense;

            CharStatV4 ui = _boundUi;
            Character selected = ui != null ? GetSelectedCharacter(ui) : null;
            if (selected != null && selected.KeyData == FeiyapKeys.Destination)
            {
                ApplyRoleToCharacter(selected, cv.Job);
            }

            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam != null)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (bc != null && bc.Info != null && bc.Info.KeyData == FeiyapKeys.Destination)
                    {
                        P_FeiyapDestination p = bc.Info.Passive as P_FeiyapDestination;
                        if (p != null)
                        {
                            p.CurrentJob = cv.Job;
                            p.RefreshJobBuffs();
                            EffectView.TextOutSimple(bc, cv.Job == JobMode.Offense
                                ? "免许皆传·终点·绯夜氏"
                                : "流风遗韵·终点·绯夜氏");
                        }
                        ApplyRoleToCharacter(bc.Info, cv.Job);
                    }
                }
            }

            RefreshCharStatPage(ui);
            // 若被动悬停描述仍开着，按新职业刷新置灰
            PassivePageUI.RefreshIfBound();
        }

        /// <summary>将角色 GDE Role 设为输出 Role_DPS / 防御 Role_Tank。</summary>
        public static void ApplyRoleToCharacter(Character ch, JobMode job)
        {
            if (ch == null || ch.GetData == null)
            {
                return;
            }
            string roleKey = job == JobMode.Offense
                ? GDEItemKeys.CharRole_Role_DPS
                : GDEItemKeys.CharRole_Role_Tank;
            try
            {
                // 已是目标 Role 则跳过，避免无谓重建
                if (ch.GetData.Role != null && ch.GetData.Role.Key == roleKey)
                {
                    return;
                }
            }
            catch
            {
            }
            ch.GetData.Role = new GDECharRoleData(roleKey);
        }

        private static void SyncRoleVisual(CharStatV4 ui, Character ch)
        {
            if (ui == null || ch == null || ch.GetData == null || ch.GetData.Role == null)
            {
                return;
            }
            string key = ch.GetData.Role.Key;
            if (ui.RoleImage != null)
            {
                if (key == GDEItemKeys.CharRole_Role_DPS && ui.Role_ATK != null)
                {
                    ui.RoleImage.sprite = ui.Role_ATK;
                }
                else if (key == GDEItemKeys.CharRole_Role_Tank && ui.Role_DEF != null)
                {
                    ui.RoleImage.sprite = ui.Role_DEF;
                }
                else if (key == GDEItemKeys.CharRole_Role_Support && ui.Role_SUP != null)
                {
                    ui.RoleImage.sprite = ui.Role_SUP;
                }
            }
        }

        /// <summary>
        /// 转职后刷新当前角色展示。
        /// 不可调用 SelectMouseClick：那是技能页切换，会导致立绘错切到露西。
        /// </summary>
        private static void RefreshCharStatPage(CharStatV4 ui)
        {
            if (ui == null)
            {
                return;
            }
            Character selected = GetSelectedCharacter(ui);
            try
            {
                // 对当前头像重新 Init，刷新 Role 图标/文案，不改选中索引
                CharFace face = ui.GetNowCharInfo();
                if (face != null)
                {
                    face.Init();
                }
            }
            catch
            {
            }
            if (selected != null)
            {
                SyncRoleVisual(ui, selected);
            }
            EnsureButton(ui);
        }
    }

    [HarmonyPatch(typeof(CharStatV4), "Update")]
    public static class JobSwitch_CharStat_Patch
    {
        [HarmonyPostfix]
        public static void Update_Postfix(CharStatV4 __instance)
        {
            try
            {
                PassivePageUI.CleanupCharStatLeftovers(__instance);
                JobSwitchUI.EnsureButton(__instance);
            }
            catch
            {
            }
        }
    }
}
