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
namespace AlwaysInquisition
{
    public class AlwaysInquisition_Plugin: ChronoArkPlugin
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

    [HarmonyPatch(typeof(StageSystem))]
    public class StageSystemPatch
    {
        [HarmonyPatch("StageStart")]
        [HarmonyPrefix]
        private static bool StageStartPrefix(StageSystem __instance)
        {
            if (PlayData.TSavedata.StageNum == 4 && !PlayData.TSavedata.CantStoryAndAchievethisrun && !PlayData.SpRuleCheck(typeof(Story_AzarSolo)))
            {
                //PlayData.TSavedata.CasinoDLCTicketGet = false;
                SaveManager.NowData.storydata.JohanQuestClear = true;
            }
            return true;
        }
    }

    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(HexGenerator))]
    public class HexGenPrefix
    {
        [HarmonyPatch("GeneratorMap")]
        [HarmonyPrefix]
        private static bool HexPrefix(HexGenerator __instance, object[] __args)
        {
            GDEStageData gdestageData = (GDEStageData)__args[0];
            if (gdestageData.Key != "Stage_Camp" && PlayData.TSavedata.StageNum == 4 && !PlayData.TSavedata.CantStoryAndAchievethisrun && !PlayData.SpRuleCheck(typeof(Story_AzarSolo)))
            {
                //PlayData.TSavedata.CasinoDLCTicketGet = true;
                SaveManager.NowData.storydata.JohanQuestClear = false;
            }
            return true;
        }
    }
}