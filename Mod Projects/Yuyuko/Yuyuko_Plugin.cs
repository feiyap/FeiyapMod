using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using ChronoArkMod.ModData;
using HarmonyLib;
namespace Yuyuko
{
    public class Yuyuko_Plugin: ChronoArkPlugin
    {
        public override void Dispose()
        {
            Harmony harmony = this.harmony;
            if (harmony != null)
            {
                harmony.UnpatchSelf();
            }
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        private Harmony harmony;
    }

    [HarmonyPatch(typeof(FieldSystem))]
    class FieldSystem_Patch
    {
        public static int count = 0;

        [HarmonyPostfix]
        [HarmonyPatch(nameof(FieldSystem.StageStart))]
        static void StageStartPostfix()
        {
            count = 0;
        }
    }


    [HarmonyPatch(typeof(BattleSystem))]
    class BattleSystem_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        public static void Start_Postfix(BattleSystem __instance)
        {
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

            if (!isBoss && PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage_Crimson)
            {
                if (FieldSystem_Patch.count == 2)
                {
                    __instance.MainQueueData = new GDEEnemyQueueData("SR_Boss_Youmu");
                }
                else
                {
                    FieldSystem_Patch.count++;
                }
            }
        }
    }
}