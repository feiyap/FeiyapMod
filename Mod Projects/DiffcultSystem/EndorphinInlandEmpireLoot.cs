using System;
using System.Collections.Generic;
using HarmonyLib;

namespace DiffcultSystem
{
    /// <summary>
    /// 内陆帝国：战斗结束额外 4 个随机战利品（非 4 份 RewardKey 整包）。
    /// 仅调用一次当前战斗战利品表，再从中独立抽取 4 件物品。
    /// </summary>
    public static class EndorphinInlandEmpireLoot
    {
        internal static string SeedSuffix;

        public static void AddExtraBattleRewards(int itemCount = 4)
        {
            if (BattleSystem.instance == null || string.IsNullOrEmpty(PlayData.BattleReward) || itemCount <= 0)
            {
                return;
            }

            SeedSuffix = "_EndorphinInlandEmpire";
            try
            {
                List<ItemBase> rolled = InventoryManager.RewardKey(PlayData.BattleReward, false);
                if (rolled == null || rolled.Count == 0)
                {
                    return;
                }

                // 从一次战利品表抽样中重复抽取，保证总共只追加 itemCount 个物品
                for (int i = 0; i < itemCount; i++)
                {
                    ItemBase item = rolled.Random(BattleRandom.PassiveItem);
                    if (item != null)
                    {
                        BattleSystem.instance.Reward.Add(item);
                    }
                }
            }
            finally
            {
                SeedSuffix = null;
            }
        }
    }

    [HarmonyPatch(typeof(RandomManager))]
    public static class RandomManager_InlandEmpireSeed_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("RandomInt", new Type[] { typeof(string), typeof(int), typeof(int) })]
        static void RandomInt_SeedPrefix(ref string RandomKey)
        {
            if (EndorphinInlandEmpireLoot.SeedSuffix != null)
            {
                RandomKey += EndorphinInlandEmpireLoot.SeedSuffix;
            }
        }
    }
}
