using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

namespace MinamiRio
{
    [HarmonyPatch(typeof(Character), "get_stat", MethodType.Getter)]
    public static class Characterget_statPatch
    {
        //[HarmonyTranspiler]
        //public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        //{
        //    return new CodeMatcher(instructions)
        //        .MatchForward(false,
        //        new CodeMatch(OpCodes.Call, typeof(Character).GetMethod("StatC"))
        //            )
        //        .Insert(
        //        new CodeInstruction(OpCodes.Ldarg_0),
        //        new CodeInstruction(OpCodes.Call, typeof(P_MinamiRio).GetMethod("StatChange"))
        //        )
        //        .InstructionEnumeration();
        //}
        [HarmonyPostfix]
        public static void Postfix(ref Stat __result)
        {
            __result = P_MinamiRio.StatChange(__result);
        }
    }
}
