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
using TileTypes;

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
                //PlayData.TSavedata.IdentifyItems.Add(GDEItemKeys.Item_Scroll_Scroll_Uncurse);
                //PartyInventory.InvenM.AddNewItem(itemBase);
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread, 4));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Item_Key, 1));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 350));
                //PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));

                List<ItemBase> list = new List<ItemBase>();
                //list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Uncurse, 2));
                list.Add(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread, 4));
                //list.Add(ItemBase.GetItem(GDEItemKeys.Item_Misc_Item_Key, 1));
                list.Add(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 350));
                list.Add(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));

                InventoryManager.Reward(list);
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage1_2)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 5));
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage2_2)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage3)
            {
                //InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
        }
    }

    [HarmonyPatch(typeof(FieldStore))]
    class FieldStore_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FieldStore.Init))]
        static void InitPostfix(FieldStore __instance)
        {
            ItemBase ib = __instance.StoreItems.Find(t => t.itemkey == GDEItemKeys.Item_Consume_DLC_Ticket_SwimDLC);
            if (ib != null)
            {
                    __instance.StoreItems.Remove(ib);
            }
            ItemBase ib2 = __instance.StoreItems.Find(t => t.itemkey == GDEItemKeys.Item_Consume_DLC_Ticket_CasinoDLC);
            if (ib2 != null)
            {
                __instance.StoreItems.Remove(ib2);
            }
        }
    }

    [HarmonyPatch(typeof(HexGenerator))]
    class HexGenerator_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(HexGenerator.CrimsonMap))]
        static bool CrimsonMapPrefix(ref HexMap __result, HexGenerator __instance)
        {
            new TileTypes.Event();
            Start start = new Start();
            new Boss();
            MiniBoss miniBoss = new MiniBoss();
            new Block();
            new BlockEvent();
            new Objective();
            Monster monster = new Monster();
            new ItemEvent();
            new TeleportTile();
            new LightTile();
            new Store();
            new HiddenWall();
            Redwilder_Camp redwilder_Camp = new Redwilder_Camp();
            HexMap hexMap = new HexMap();
            hexMap.StageData = new GDEStageData(GDEItemKeys.Stage_Stage_Crimson);
            int num = 16;
            int num2 = 10;
            hexMap.MapObject = new MapTile[num, num2];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    hexMap.MapObject[i, j] = new MapTile();
                }
            }
            for (int k = 0; k < num; k++)
            {
                for (int l = 0; l < num2; l++)
                {
                    hexMap.MapObject[k, l].Init(new Vector2((float)k, (float)l), hexMap);
                    if (k <= 1 || k >= num - 2 || l <= 1 || l >= num2 - 2)
                    {
                        hexMap.MapObject[k, l].Info.Type = new Border();
                    }
                    else
                    {
                        hexMap.MapObject[k, l].Info.Type = new Block();
                    }
                }
            }
            new List<Vector2Int>();
            start.Add(ref hexMap, new Vector2Int(3, 4));
            hexMap.MapObject[4, 4].Info.Type = new DebugRoad();
            redwilder_Camp.Add(ref hexMap, hexMap.MapObject[5, 4].Pos);
            monster.Add(ref hexMap, hexMap.MapObject[6, 4].Pos);
            hexMap.MapObject[7, 4].Info.Type = new DebugRoad();
            hexMap.MapObject[8, 4].Info.Type = new DebugRoad();
            hexMap.MapObject[9, 4].Info.Type = new DebugRoad();
            hexMap.MapObject[4, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[7, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[8, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[9, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[10, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[11, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[12, 4].Info.Type = new DebugRoad();
            hexMap.MapObject[12, 5].Info.Type = new DebugRoad();
            hexMap.MapObject[13, 4].Info.Type = new DebugRoad();
            hexMap.MapObject[13, 5].Info.Type = new DebugRoad();
            miniBoss.Add(ref hexMap, hexMap.MapObject[13, 5].Pos);

            __result = hexMap;
            return false;
        }
    }

    [HarmonyPatch(typeof(RandomManager))]
    class RandomManager_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(RandomManager.RandomPer), new Type[] { typeof(string), typeof(int), typeof(int) })]
        static void RandomPerPostfix(ref bool __result, string RandomKey, int MaxPer, int Per)
        {
            if (RandomKey == RandomClassKey.BattleClear)
            {
                __result = RandomManager.RandomInt(RandomKey, 0, 100) < 50;
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
                BattleWaveExtra = 2;
                if (PlayData.TSavedata.StageNum == 2 || PlayData.TSavedata.StageNum == 3 || PlayData.TSavedata.StageNum == 4)
                {
                    BattleWaveExtra = 3;
                }
                BattleWaveExtraNow = 0;

                BattleWaveExtraList.Clear();
                GDEStageData stageData = new GDEStageData(PlayData.TSavedata.NowStageMapKey);
                BattleWaveExtraList.AddRange(stageData.FieldEnemy);
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
            if (BattleWaveExtraNow == 2)
            {
                __instance.CurseBattle = true;
            }
            else
            {
                __instance.CurseBattle = false;
            }
            if (__instance.EnemyList.Count == 0 && __instance.EnemyWaveData.EnemyWaveObject.Count == 0 && __instance.EnemyWaveData.wave2out && __instance.EnemyWaveData.wave3out && BattleWaveExtraNow < BattleWaveExtra)
            {
                BattleWaveExtraNow++;

                GDEEnemyQueueData gdeeqd = BattleWaveExtraList.Random(RandomClassKey.Enemy);
                string Tempkey = gdeeqd.Key;

                if (PlayData.TSavedata.StageNum == 1)
                {
                    __instance.CurseBattle = false;
                }
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
