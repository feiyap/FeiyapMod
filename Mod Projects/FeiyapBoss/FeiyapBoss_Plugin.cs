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
using ChronoArkMod.ModData.Settings;
using HarmonyLib;
using PItem;

namespace FeiyapBoss
{
    public class FeiyapBoss_Plugin: ChronoArkPlugin
    {
        private Harmony harmony;
        public override void Dispose()
        {
            this.harmony.UnpatchSelf();
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        public override void OnModLoaded()
        {
            base.OnModLoaded();
            this.OnModSettingUpdate();
            PortableLunchBox.FoodList.Add("Item_BurnFullDuck");
        }
    }

    [HarmonyPatch(typeof(FieldEventSelect))]
    [HarmonyPatch("FieldEventSelectOpen")]
    public static class EventPlugin
    {
        [HarmonyPrefix]
        public static void FieldEventSelectOpen_patch(FieldEventSelect __instance, ref List<string> EventList)
        {
            bool flag = false;
            bool flag2 = false;
            for (int i = 0; i < PlayData.TSavedata.RandomEvent_ChooseEvents.Count; i++)
            {
                if (PlayData.TSavedata.RandomEvent_ChooseEvents[i] == "RE_Feiyap_Boss")
                {
                    flag = true;
                }
            }
            foreach (string str in EventList)
            {
                if (str == "RE_Feiyap_Boss")
                {
                    flag2 = true;
                }
            }
            if (PlayData.TSavedata.StageNum == 3 && ModManager.getModInfo("FeiyapBoss").GetSetting<ToggleSetting>("FeiyapBoss_Event").Value && !flag && !flag2 && PlayData.SpalcialRule != GDEItemKeys.SpecialRule_SR_Solo)
            {
                EventList.Insert(0, "RE_Feiyap_Boss");
            }
        }
    }
}