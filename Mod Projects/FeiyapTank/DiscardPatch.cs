using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using HarmonyLib;
namespace FeiyapTank
{
    [HarmonyPatch(typeof(SkillButton))]
    [HarmonyPatch("_Waste")]
    public static class SkillButton__Waste_Plugin
    {
        [HarmonyPrefix]
        public static void SkillButton__Waste_Patch(SkillButton __instance, bool use, bool HandFullWaste)
        {
            if (!__instance.AlreadyWasted && !__instance.Myskill.Master.IsDead && !use)
            {
                foreach (IP_DiscardBefore ip_DiscardBefore in __instance.Myskill.IReturn<IP_DiscardBefore>())
                {
                    if (ip_DiscardBefore != null)
                    {
                        ip_DiscardBefore.DiscardBefore(__instance.BClickWaste, __instance.Myskill, HandFullWaste);
                    }
                }
            }
        }
    }

    public interface IP_DiscardBefore
    {
        void DiscardBefore(bool Click, Skill skill, bool HandFullWaste);
    }
}