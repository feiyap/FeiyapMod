using System.Collections;
using HarmonyLib;

namespace IzayoiSakuya
{
    /// <summary>
    /// 额外回合：包装原版 MyTurn，并在设置期间跳过 EnemyTeam.NewTurn。
    /// </summary>
    [HarmonyPatch(typeof(BattleSystem))]
    public static class Sakuya_MyTurnPlugin
    {
        private static int ExtraTurnSetupDepth;

        public static bool IsExtraTurnSetup
        {
            get
            {
                return ExtraTurnSetupDepth > 0;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("MyTurn")]
        public static void Sakuya_MyTurnPostfix(ref IEnumerator __result, BattleSystem __instance)
        {
            foreach (BattleChar bc in __instance.AllyList)
            {
                if (bc.BuffFind("B_Sakuya_10Rare"))
                {
                    bc.BuffReturn("B_Sakuya_10Rare").SelfStackDestroy();
                    __result = Sakuya_ExtraTurn(__result);
                    break;
                }
            }
        }

        private static IEnumerator Sakuya_ExtraTurn(IEnumerator original)
        {
            ExtraTurnSetupDepth++;
            try
            {
                while (original.MoveNext())
                {
                    yield return original.Current;
                }
            }
            finally
            {
                ExtraTurnSetupDepth--;
            }
        }
    }

    [HarmonyPatch(typeof(EnemyTeam))]
    public static class Sakuya_EnemyTeamPlugin
    {
        [HarmonyPrefix]
        [HarmonyPatch("NewTurn")]
        public static bool Sakuya_EnemyTeamNewTurnPrefix()
        {
            return !Sakuya_MyTurnPlugin.IsExtraTurnSetup;
        }
    }
}
