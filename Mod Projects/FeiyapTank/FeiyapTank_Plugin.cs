using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace FeiyapTank
{
    public class FeiyapTank_Plugin: ChronoArkPlugin
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
            for (int i = 0 ; i < PlayData.TSavedata.RandomEvent_ChooseEvents.Count ; i++)
            {
                if (PlayData.TSavedata.RandomEvent_ChooseEvents[i] == "RE_FeiyapMage_0")
                {
                    flag = true;
                }
            }
            foreach (string str in EventList)
            {
                if (str == "RE_FeiyapMage_0")
                {
                    flag2 = true;
                }
            }
            if (PlayData.TSavedata.StageNum == 1 && ModManager.getModInfo("FeiyapTank").GetSetting<ToggleSetting>("FeiyapMage_Event").Value && !flag && !flag2 && PlayData.SpalcialRule != GDEItemKeys.SpecialRule_SR_Solo)
            {
                EventList.Insert(0, "RE_FeiyapMage_0");
            }
        }
    }
}