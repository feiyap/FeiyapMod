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
namespace ManyMapScroll
{
    public class ManyMapScroll_Plugin: ChronoArkPlugin
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

        [HarmonyPatch(typeof(FieldSystem))]
        class FieldSystem_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(FieldSystem.StageStart))]
            static void StageStartPostfix()
            {
                if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage1_1)
                {
                    List<ItemBase> list = new List<ItemBase>();
                    list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Mapping, 5));

                    InventoryManager.Reward(list);
                }
            }
        }
    }
}