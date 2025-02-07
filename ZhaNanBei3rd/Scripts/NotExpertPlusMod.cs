using System;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using ChronoArkMod.ModData;
using System.Collections;

namespace ZhaNanBei3rd
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(CampUI))]
    public static class CampUIPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Update_Postfix(CampUI __instance)
        {
            if (__instance.Button_BloodyMist != null)
            {
                __instance.Button_BloodyMist.gameObject.SetActive(false);
            }
            if (__instance.Button_FriendShip != null)
            {
                __instance.Button_FriendShip.gameObject.SetActive(false);
            }
            if (__instance.Button_LerynPassive != null)
            {
                __instance.Button_LerynPassive.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(FieldSystem))]
    class FieldSystem_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FieldSystem.StageStart))]
        static void StageStartPostfix()
        {
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage1_1)
            {
                ItemBase itemBase = ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Uncurse, 2);
                (itemBase as Item_Equip)._Isidentify = true;
                //PartyInventory.InvenM.AddNewItem(itemBase);
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread, 4));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Item_Key, 1));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 350));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));

                InventoryManager.Reward(itemBase);
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread, 4));
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Item_Key, 1));
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 350));
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage1_2)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 5));
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage2_2)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 5));
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage3)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
        }
    }
    
    [HarmonyPatch(typeof(BattleSystem))]
    class BattleSystem_Patch
    {
        public static int BattleWaveExtra;
        public static int BattleWaveExtraNow;
        public static List<GDEEnemyQueueData> BattleWaveExtraList = new List<GDEEnemyQueueData>();

        [HarmonyPostfix]
        [HarmonyPatch("BattleStart")]
        public static void BattleStart_Postfix(IEnumerator __result, BattleSystem __instance)
        {
            __instance.StartCoroutine(BattleInitExtra(__instance));
        }

        private static IEnumerator BattleInitExtra(BattleSystem __instance)
        {
            yield return new WaitForSeconds(0.05f);

            bool isBoss = false;

            using (List<BattleEnemy>.Enumerator enumerator3 = __instance.EnemyList.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    if (enumerator3.Current.Boss)
                    {
                        isBoss = true;
                    }
                }
            }

            foreach (GDEEnemyData gdeed in __instance.MainQueueData.Enemys)
            {
                if (gdeed.Boss == true || gdeed.Key == GDEItemKeys.Enemy_S1_Kitchenmaid)
                {
                    isBoss = true;
                }
            }

            if (!isBoss && PlayData.TSavedata.NowStageMapKey != GDEItemKeys.Stage_Stage_Crimson)
            {
                BattleWaveExtra = 3;
                if (PlayData.TSavedata.StageNum == 3)
                {
                    BattleWaveExtra = 4;
                }
                BattleWaveExtraNow = 0;

                BattleWaveExtraList.AddRange(StageSystem.instance.StageData.FieldEnemy);
            }
            else
            {
                BattleWaveExtra = 0;
                BattleWaveExtraNow = 0;
            }

            yield break;
        }

        [HarmonyPostfix]
        [HarmonyPatch("get_EnemyClear")]
        public static void EnemyClear_Postfix(ref bool __result, BattleSystem __instance)
        {
            using (List<SkillParticle>.Enumerator enumerator = __instance.Particles.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.NonEffect)
                    {
                        __result = false;
                    }
                }
            }
            bool isStarting = Traverse.Create(__instance).Field("isStarting").GetValue<bool>();
            __result = !__instance.ClearEnabled && isStarting && (__instance.EnemyTeam.AliveChars_Vanish.Count == 0 && __instance.EnemyWaveData.EnemyWaveObject.Count == 0 && __instance.EnemyWaveData.wave2out && __instance.EnemyWaveData.wave3out && BattleWaveExtraNow >= BattleWaveExtra);
        }

        [HarmonyPostfix]
        [HarmonyPatch("TurnEnd")]
        public static void TurnEnd_Postfix(BattleSystem __instance)
        {
            if (__instance.EnemyList.Count == 0 && __instance.EnemyWaveData.EnemyWaveObject.Count == 0 && __instance.EnemyWaveData.wave2out && __instance.EnemyWaveData.wave3out && BattleWaveExtraNow < BattleWaveExtra)
            {
                BattleWaveExtraNow++;

                GDEEnemyQueueData gdeeqd = BattleWaveExtraList.Random(RandomClassKey.Enemy);
                string Tempkey = gdeeqd.Key;

                __instance.CurseBattle = false;
                __instance.StartCoroutine(__instance.NewEnemy(Tempkey));

                __instance.EnemyWaveData.wave2turn = __instance.TurnNum + gdeeqd.Wave2Turn;
                if (gdeeqd.Wave2Turn >= 1 && gdeeqd.Wave2.Count != 0)
                {
                    __instance.EnemyWaveData.wave2out = false;
                }
                __instance.EnemyWaveData.wave3turn = __instance.TurnNum + gdeeqd.Wave3Turn;
                if (gdeeqd.Wave3Turn >= 1 && gdeeqd.Wave3.Count != 0)
                {
                    __instance.EnemyWaveData.wave3out = false;
                }

                BattleWaveExtraList.Remove(gdeeqd);
            }
        }
    }
}
