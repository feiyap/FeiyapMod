using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace MinamiRio
{
    [HarmonyPatch(typeof(SkillTargetTooltip), nameof(SkillTargetTooltip.InputInfo))]
    public static class SkillTargetTooltipInputInfoPatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var cm = new CodeMatcher(instructions)
                .MatchForward(false,
                new CodeMatch(OpCodes.Ldarg_1),
                new CodeMatch(OpCodes.Callvirt, typeof(BattleChar).GetProperty(nameof(BattleChar.GetStat)).GetGetMethod()),
                new CodeMatch(OpCodes.Ldfld, typeof(Stat).GetField("def"))
                );
            List<Label> labels = new List<Label>(cm.Labels);
            cm.Labels.Clear();
            cm.Insert(
                new CodeInstruction(OpCodes.Ldarg_2),
                new CodeInstruction(OpCodes.Call, typeof(P_MinamiRio).GetMethod(nameof(P_MinamiRio.SetNeedChange_Skill)))
                );
            cm.AddLabels(labels);
            cm.MatchForward(true,
                new CodeMatch(OpCodes.Ldarg_1),
                new CodeMatch(OpCodes.Callvirt, typeof(BattleChar).GetProperty(nameof(BattleChar.GetStat)).GetGetMethod()),
                new CodeMatch(OpCodes.Ldfld, typeof(Stat).GetField("def")),
                new CodeMatch(OpCodes.Neg),
                new CodeMatch(OpCodes.Ldc_R4, 100f),
                new CodeMatch(OpCodes.Add)
                )
                .Advance(4);
            List<Label> labels2 = new List<Label>(cm.Labels);
            cm.Labels.Clear();
            cm.Insert(
                new CodeInstruction(OpCodes.Call, typeof(P_MinamiRio).GetMethod(nameof(P_MinamiRio.ResetNeedChange)))
                );
            cm.AddLabels(labels2);

            return cm.InstructionEnumeration();
        }
    }
}
