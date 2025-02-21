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
                if (FieldSystem_Patch.count == 1)
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

    [HarmonyPatch(typeof(UI_RedHammer))]
    class UI_RedHammer_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("ItemUse")]
        public static bool ItemUse_Prefix(UI_RedHammer __instance, ItemObject select)
        {
            if (select.Item.itemkey == "E_YuyukoF_0")
            {
                List<ItemBase> list = new List<ItemBase>();
                list.Add(ItemBase.GetItem("E_YuyukoF_1", 1));
                InventoryManager.Reward(list);

                __instance.Inven.DelItem(select.Item);
                for (int i = 0; i < PlayData.TSavedata.Party.Count; i++)
                {
                    __instance.Equip[i].DelItem(select.Item);
                }
                __instance.UseItem.MyManager.DelItem(__instance.UseItem, 1);
                PartyInventory.InvenM.ItemUpdateFromInven();
                if (FieldSystem.instance != null)
                {
                    foreach (AllyWindow allyWindow in FieldSystem.instance.PartyWindow)
                    {
                        allyWindow.EquipUpdate();
                    }
                }
                __instance.SelfDestroy();
                return false;
            }
            return true;
        }
    }
}