using System;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;
using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using ChronoArkMod.ModData;

namespace MinamiRio
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(StageChest))]
    public static class StageChestEnemyPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Open")]
        public static void Open_Postfix(StageChest __instance)
        {
            int num = RandomManager.RandomInt(RandomClassKey.StageChest, 0, 100);
            if (PlayData.TSavedata.StageNum == 0)
            {
                if (num < 15)
                {
                    FieldSystem.instance.BattleStart(new GDEEnemyQueueData("EnemyQueue_BlackSurvivor_1_1"), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
                }
            }
            else if (PlayData.TSavedata.StageNum == 1)
            {
                if (num < 15)
                {
                    FieldSystem.instance.BattleStart(new GDEEnemyQueueData("EnemyQueue_BlackSurvivor_1_2"), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
                }
            }
            else
            {
                if (num < 5)
                {
                    FieldSystem.instance.BattleStart(new GDEEnemyQueueData("EnemyQueue_BlackSurvivorPlayer_1"), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
                }
                else if (num < 10)
                {
                    FieldSystem.instance.BattleStart(new GDEEnemyQueueData("EnemyQueue_BlackSurvivorPlayer_2"), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
                }
                else if (num < 15)
                {
                    FieldSystem.instance.BattleStart(new GDEEnemyQueueData("EnemyQueue_BlackSurvivorPlayer_3"), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
                }
            }
        }
    }
}
