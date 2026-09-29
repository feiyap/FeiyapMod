using System;
using System.Collections.Generic;
using HarmonyLib;

namespace FeiyapDestination
{
    /// <summary>
    /// 优势/劣势：双掷取优/劣；同时存在时互相抵消。
    /// </summary>
    public static class AdvantageSystem
    {
        private static readonly Dictionary<string, int> HitAdv = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> CriAdv = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> DodAdv = new Dictionary<string, int>();

        private static bool _skip;

        public static void ClearBattle()
        {
            HitAdv.Clear();
            CriAdv.Clear();
            DodAdv.Clear();
        }

        public static void SetBaseAdvantage(string charKey, int hit, int cri, int dod)
        {
            if (string.IsNullOrEmpty(charKey))
            {
                return;
            }
            HitAdv[charKey] = hit;
            CriAdv[charKey] = cri;
            DodAdv[charKey] = dod;
        }

        private static int Get(Dictionary<string, int> map, string key)
        {
            int v;
            return map.TryGetValue(key, out v) ? v : 0;
        }

        public static int NetHit(BattleChar bc)
        {
            return bc == null || bc.Info == null ? 0 : Get(HitAdv, bc.Info.KeyData);
        }

        public static int NetCri(BattleChar bc)
        {
            return bc == null || bc.Info == null ? 0 : Get(CriAdv, bc.Info.KeyData);
        }

        public static int NetDod(BattleChar bc)
        {
            return bc == null || bc.Info == null ? 0 : Get(DodAdv, bc.Info.KeyData);
        }

        public static bool Combine(bool first, bool second, int net)
        {
            if (net > 0)
            {
                return first || second;
            }
            if (net < 0)
            {
                return first && second;
            }
            return first;
        }

        public static bool Skip
        {
            get { return _skip; }
            set { _skip = value; }
        }
    }

    public static class Advantage_BattleChar_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(BattleChar), "GetCri", new Type[] { typeof(int) })]
        public static void GetCri_Postfix(BattleChar __instance, int Plus, ref bool __result)
        {
            if (AdvantageSystem.Skip)
            {
                return;
            }
            int net = AdvantageSystem.NetCri(__instance);
            if (net == 0)
            {
                return;
            }
            AdvantageSystem.Skip = true;
            bool second = __instance.GetCri(Plus);
            AdvantageSystem.Skip = false;
            __result = AdvantageSystem.Combine(__result, second, net);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(BattleChar), "DodgeCheck")]
        public static void DodgeCheck_Postfix(BattleChar __instance, SkillParticle SP, ref bool __result)
        {
            if (AdvantageSystem.Skip)
            {
                return;
            }
            int net = AdvantageSystem.NetDod(__instance);
            if (net == 0)
            {
                return;
            }
            AdvantageSystem.Skip = true;
            bool second = __instance.DodgeCheck(SP);
            AdvantageSystem.Skip = false;
            __result = AdvantageSystem.Combine(__result, second, net);
        }
    }

    public static class Advantage_HitRoll_Patch
    {
        public static BattleChar CurrentAttacker;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(RandomManager), "RandomPer", new Type[] { typeof(string), typeof(int), typeof(int) })]
        public static void RandomPerString_Postfix(string Key, int Per, int MaxPer, ref bool __result)
        {
            if (AdvantageSystem.Skip || CurrentAttacker == null)
            {
                return;
            }
            int net = AdvantageSystem.NetHit(CurrentAttacker);
            if (net == 0)
            {
                return;
            }
            AdvantageSystem.Skip = true;
            bool second = RandomManager.RandomPer(Key, Per, MaxPer);
            AdvantageSystem.Skip = false;
            __result = AdvantageSystem.Combine(__result, second, net);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(RandomManager), "RandomPer", new Type[] { typeof(RandomClass), typeof(int), typeof(int) })]
        public static void RandomPerClass_Postfix(RandomClass RC, int Per, int MaxPer, ref bool __result)
        {
            if (AdvantageSystem.Skip || CurrentAttacker == null)
            {
                return;
            }
            int net = AdvantageSystem.NetHit(CurrentAttacker);
            if (net == 0)
            {
                return;
            }
            AdvantageSystem.Skip = true;
            bool second = RandomManager.RandomPer(RC, Per, MaxPer);
            AdvantageSystem.Skip = false;
            __result = AdvantageSystem.Combine(__result, second, net);
        }
    }
}
