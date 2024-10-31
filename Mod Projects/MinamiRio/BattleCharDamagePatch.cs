using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection.Emit;

namespace MinamiRio
{
    [HarmonyPatch(typeof(BattleChar), nameof(BattleChar.Damage))]
    public static class BattleCharDamagePatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var cm = new CodeMatcher(instructions)
                .MatchForward(false,
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Call, typeof(BattleChar).GetProperty(nameof(BattleChar.GetStat)).GetGetMethod()),
                new CodeMatch(OpCodes.Ldfld, typeof(Stat).GetField("def"))
                );
            var label = new List<Label>(cm.Labels);
            cm.Labels.Clear();
            cm.Insert(
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Call, typeof(P_MinamiRio).GetMethod(nameof(P_MinamiRio.SetNeedChange)))
                );
            cm.AddLabels(label);
            cm.MatchForward(true,
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Call, typeof(BattleChar).GetProperty(nameof(BattleChar.GetStat)).GetGetMethod()),
                new CodeMatch(OpCodes.Ldfld, typeof(Stat).GetField("def")),
                new CodeMatch(OpCodes.Neg),
                new CodeMatch(OpCodes.Ldc_R4, 100f),
                new CodeMatch(OpCodes.Add)
                )
                .Advance(4);
            var label2 = new List<Label>(cm.Labels);
            cm.Labels.Clear();
            cm.Insert(
                new CodeInstruction(OpCodes.Call, typeof(P_MinamiRio).GetMethod(nameof(P_MinamiRio.ResetNeedChange)))
                );
            cm.AddLabels(label2);
            return cm.InstructionEnumeration();
        }
    }
}
