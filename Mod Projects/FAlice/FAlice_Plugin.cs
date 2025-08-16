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
namespace FAlice
{
    public class FAlice_Plugin : ChronoArkPlugin
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

        [HarmonyPatch(typeof(SkillButton), "Update")]
        public static class FAlice_InfinityPatch
        {
            [HarmonyPostfix]
            public static void InfinityText(SkillButton __instance)
            {
                if (__instance.Myskill != null && __instance.IsNowCasting && __instance.castskill.CastSpeed > 1000)
                {
                    __instance.CountingText.text = "¡Þ";
                }
            }
        }

        /*[HarmonyPatch(typeof(SkillButton), "ChoiceSkill")]
        public static class FAlice_ChoiceSkillPatch
        {
            [HarmonyPrefix]
            public static void ChoiceSkillFix(SkillButton Mybutton)
            {
                Mybutton.Myskill.UsedApNum = BattleSystem.instance.SelectedSkill.AP;
            }
        }*/

        [HarmonyPatch(typeof(BattleSystem), "TargetSelect")]
        public static class FAlice_ChoiceSkillPatch
        {
            [HarmonyPostfix]
            public static void ChoiceSkillFix(Skill sdata, BattleChar Char)
            {
                if (sdata.OriginalSelectSkill != null)
                {
                    sdata.OriginalSelectSkill.UsedApNum = sdata.OriginalSelectSkill.AP;
                }
            }
        }
    }
}