using System.Text.RegularExpressions;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DiffcultSystem
{
    /// <summary>
    /// 疑神疑鬼：战斗部分数字信息不可视。
    /// </summary>
    public static class EndorphinParanoidView
    {
        public const string HiddenText = "?";

        private static readonly Regex TagContentRegex = new Regex(@">([^<]*)<", RegexOptions.Compiled);
        private static readonly Regex PlainNumberRegex = new Regex(@"(?<![=#\w])\d+(?![\w>])", RegexOptions.Compiled);

        public static bool IsActive =>
            BattleSystem.instance != null &&
            EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Paranoid");

        // 遮蔽 Tooltip 描述中的内嵌数字，保留富文本标签结构。
        public static string MaskTooltipNumbers(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            text = TagContentRegex.Replace(text, m =>
                ">" + Regex.Replace(m.Groups[1].Value, @"\d+", HiddenText) + "<");
            return PlainNumberRegex.Replace(text, HiddenText);
        }

        public static void MaskTmpText(TextMeshProUGUI tmp)
        {
            if (tmp != null)
            {
                tmp.text = MaskTooltipNumbers(tmp.text);
            }
        }

        public static void MaskTmpNumber(TextMeshProUGUI tmp)
        {
            if (tmp != null && !string.IsNullOrEmpty(tmp.text))
            {
                tmp.text = HiddenText;
            }
        }

        public static void MaskUnityText(Text text)
        {
            if (text != null && !string.IsNullOrEmpty(text.text))
            {
                text.text = HiddenText;
            }
        }

        public static void MaskSkillToolTip(SkillToolTip tooltip)
        {
            if (tooltip == null)
            {
                return;
            }

            MaskTmpNumber(tooltip.MP);
            MaskUnityText(tooltip.MP2);
            MaskTmpText(tooltip.Desc);
        }

        public static void MaskPlusSkillTooltips(SkillToolTip tooltip)
        {
            if (tooltip?.PlusTooltip == null)
            {
                return;
            }

            foreach (Transform child in tooltip.PlusTooltip)
            {
                ToolTipWindow window = child.GetComponent<ToolTipWindow>();
                if (window?.Description != null)
                {
                    window.Description.text = MaskTooltipNumbers(window.Description.text);
                }
            }
        }

        public static void MaskToolTipWindowDescription(ToolTipWindow window)
        {
            if (window?.Description != null)
            {
                window.Description.text = MaskTooltipNumbers(window.Description.text);
            }
        }

        public static void MaskCharUI(BattleChar chr)
        {
            if (!IsActive || chr?.UI == null)
            {
                return;
            }

            chr.UI.HPText.text = HiddenText;
            if (chr.UI.BarrierTextObj != null && chr.UI.BarrierTextObj.activeSelf && chr.UI.BarrierText != null)
            {
                chr.UI.BarrierText.text = HiddenText;
            }
        }

        public static void MaskSkillButton(SkillButton button)
        {
            if (!IsActive || button == null)
            {
                return;
            }

            if (button.MP != null)
            {
                button.MP.text = HiddenText;
            }

            if (button.CountingText != null && !string.IsNullOrEmpty(button.CountingText.text))
            {
                button.CountingText.text = HiddenText;
            }
        }

        public static void MaskBattleActWindow(BattleActWindow window)
        {
            if (!IsActive || window == null)
            {
                return;
            }

            if (window.MP != null)
            {
                window.MP.text = HiddenText;
            }

            if (window.DeckNum != null)
            {
                window.DeckNum.text = HiddenText;
            }

            if (window.TrashNum != null)
            {
                window.TrashNum.text = HiddenText;
            }

            if (BattleSystem.instance?.AllyTeam?.Skills == null)
            {
                return;
            }

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill?.MyButton?.MainButton?.SkillNum != null)
                {
                    skill.MyButton.MainButton.SkillNum.text = HiddenText;
                }
            }
        }

        public static void HideEffectNumber(EffectView effectView)
        {
            if (!IsActive || effectView == null)
            {
                return;
            }

            if (effectView.MyText != null)
            {
                effectView.MyText.text = string.Empty;
            }

            if (effectView.CriText != null)
            {
                effectView.CriText.text = string.Empty;
            }
        }
    }

    [HarmonyPatch(typeof(BattleAlly), nameof(BattleAlly.UIUpdate))]
    public static class BattleAlly_UIUpdate_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(BattleAlly __instance)
        {
            EndorphinParanoidView.MaskCharUI(__instance);
        }
    }

    [HarmonyPatch(typeof(BattleEnemy), nameof(BattleEnemy.UIUpdate))]
    public static class BattleEnemy_UIUpdate_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(BattleEnemy __instance)
        {
            EndorphinParanoidView.MaskCharUI(__instance);
        }
    }

    [HarmonyPatch(typeof(SkillButton), nameof(SkillButton.Update))]
    public static class SkillButton_Update_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(SkillButton __instance)
        {
            EndorphinParanoidView.MaskSkillButton(__instance);
        }
    }

    [HarmonyPatch(typeof(BattleActWindow), "Update")]
    public static class BattleActWindow_Update_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(BattleActWindow __instance)
        {
            EndorphinParanoidView.MaskBattleActWindow(__instance);
        }
    }

    [HarmonyPatch(typeof(EffectView), nameof(EffectView.InputDamage))]
    public static class EffectView_InputDamage_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(EffectView __instance)
        {
            EndorphinParanoidView.HideEffectNumber(__instance);
        }
    }

    [HarmonyPatch(typeof(EffectView), nameof(EffectView.Heal))]
    public static class EffectView_Heal_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(EffectView __instance)
        {
            EndorphinParanoidView.HideEffectNumber(__instance);
        }
    }

    [HarmonyPatch(typeof(BuffObject), "Update")]
    public static class BuffObject_Update_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(BuffObject __instance)
        {
            if (!EndorphinParanoidView.IsActive || __instance?.StackText == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(__instance.StackText.text))
            {
                __instance.StackText.text = string.Empty;
            }
        }
    }

    [HarmonyPatch(typeof(SkillToolTip), nameof(SkillToolTip.Input))]
    public static class SkillToolTip_Input_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(SkillToolTip __instance)
        {
            if (!EndorphinParanoidView.IsActive)
            {
                return;
            }

            EndorphinParanoidView.MaskSkillToolTip(__instance);
            EndorphinParanoidView.MaskPlusSkillTooltips(__instance);
        }
    }

    [HarmonyPatch(typeof(SkillToolTip), nameof(SkillToolTip.PlusTooltipsView), typeof(string), typeof(string))]
    public static class SkillToolTip_PlusTooltipsView_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(SkillToolTip __instance)
        {
            if (!EndorphinParanoidView.IsActive)
            {
                return;
            }

            EndorphinParanoidView.MaskPlusSkillTooltips(__instance);
        }
    }

    [HarmonyPatch(typeof(BuffTooltip), nameof(BuffTooltip.Input))]
    public static class BuffTooltip_Input_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(BuffTooltip __instance)
        {
            if (!EndorphinParanoidView.IsActive)
            {
                return;
            }

            EndorphinParanoidView.MaskTmpNumber(__instance.TimeNum);
            EndorphinParanoidView.MaskUnityText(__instance.TimeNum2);
            EndorphinParanoidView.MaskTmpText(__instance.Desc);
        }
    }

    [HarmonyPatch(typeof(SkillTargetTooltip), nameof(SkillTargetTooltip.InputInfo))]
    public static class SkillTargetTooltip_InputInfo_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(SkillTargetTooltip __instance)
        {
            if (!EndorphinParanoidView.IsActive)
            {
                return;
            }

            EndorphinParanoidView.MaskTmpText(__instance.InfoText);
        }
    }

    [HarmonyPatch(typeof(ToolTipWindow), nameof(ToolTipWindow.NewToolTip), typeof(Transform), typeof(string), typeof(int), typeof(Vector2), typeof(Vector2), typeof(Vector2))]
    public static class ToolTipWindow_NewToolTip_Paranoid_Patch
    {
        [HarmonyPostfix]
        static void Postfix(GameObject __result)
        {
            if (!EndorphinParanoidView.IsActive || __result == null)
            {
                return;
            }

            EndorphinParanoidView.MaskToolTipWindowDescription(__result.GetComponent<ToolTipWindow>());
        }
    }
}
