using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

namespace MinamiRio
{
    [HarmonyPatch(typeof(Character), "get_stat", MethodType.Getter)]
    public static class Characterget_statPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ref Stat __result)
        {
            __result = P_MinamiRio.StatChange(__result);
        }
    }
}
