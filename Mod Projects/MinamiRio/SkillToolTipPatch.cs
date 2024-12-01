using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection.Emit;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;

namespace MinamiRio
{
    [HarmonyPatch(typeof(SkillToolTip))]
    [HarmonyPatch("Input")]
    public static class SkillToolTip_Patch
    {
        [HarmonyPostfix]
        public static void SkillToolTip_Postfix(SkillToolTip __instance, Skill Skill)
        {
            //如果把无视隐匿做成属性，这里可以直接判断属性是否为true
            if (Skill.MySkill.PlusKeyWords.Find((GDESkillKeywordData a) => a.Key == "Keyword_VanishIgnore") != null)
            {
                string replacement = string.Empty;
                string text = string.Empty;
                GDESkillKeywordData gdeskillKeywordData = new GDESkillKeywordData("Keyword_VanishIgnore");
                text = SkillToolTip.ColorChange("FF7C34", ScriptLocalization.Battle_Keyword.IgnoreTaunt);
                replacement = text + ". " + SkillToolTip.ColorChange("FF7C34", gdeskillKeywordData.Name);
                Regex regex = new Regex(text);
                string text2 = regex.Replace(__instance.Desc.text, replacement, 1);
                bool flag2 = text2.Contains(text);
                if (flag2)
                {
                    __instance.Desc.text = text2;
                }
            }
        }

        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions)
                .MatchForward(false,
                new CodeMatch(OpCodes.Call, typeof(Character).GetMethod("Input"))
                    )
                .Insert(
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Call, typeof(SkillToolTip_Patch).GetMethod("StatChange"))
                )
                .InstructionEnumeration();
        }
    }
}
