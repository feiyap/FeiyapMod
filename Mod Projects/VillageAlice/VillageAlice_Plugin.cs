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
namespace VillageAlice
{
    public class VillageAlice_Plugin: ChronoArkPlugin
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

    [HarmonyPatch(typeof(SkillToolTip))]
    class SkillToolTip_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(SkillToolTip.Input))]
        static void InputPostfix(SkillToolTip __instance, Skill Skill, Stat _stat, ToolTipWindow.SkillTooltipValues skillvalues, bool View = false, SkillPrefab sp = null)
        {
            if (Skill.Master.Info.KeyData == "VillageAlice")
            {
                UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkilTooltip"), __instance.SkillImage.transform);
                UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkilTooltip"), __instance.Desc.transform);
            }
        }
    }
}