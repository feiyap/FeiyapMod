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
    //童话技能在[现实]中无法看见技能名和技能描述
    [HarmonyPatch(typeof(SkillToolTip))]
    class SkillToolTip_Patch
    {
        //[HarmonyPostfix]
        //[HarmonyPatch(nameof(SkillToolTip.Input))]
        //static void InputPostfix(SkillToolTip __instance, Skill Skill, Stat _stat, ToolTipWindow.SkillTooltipValues skillvalues, bool View = false, SkillPrefab sp = null)
        //{
        //    if (Skill.ExtendedFind_DataName("SkillExtended_Fairytale") != null && !Skill.Master.BuffFind("B_FVAlice_P_1"))
        //    {
        //        UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkilTooltip"), __instance.SkillImage.transform);
        //        UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkilTooltip"), __instance.Desc.transform);
        //        UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkilTooltip"), __instance..transform);
        //    }
        //}
        
        [HarmonyPrefix]
        [HarmonyPatch(nameof(SkillToolTip.Input))]
        static bool InputPrefix(SkillToolTip __instance, ref Skill Skill, Stat _stat, ToolTipWindow.SkillTooltipValues skillvalues, bool View = false, SkillPrefab sp = null)
        {
            if (Skill.ExtendedFind_DataName("SkillExtended_Fairytale") != null && !Skill.Master.BuffFind("B_FVAlice_P_1"))
            {
                Skill tmpSkill = Skill.TempSkill("S_FVAlice_Default", skillvalues.SkillData.Master, skillvalues.SkillData.Master.MyTeam);
                Skill = tmpSkill;
            }
            return true;
        }
    }

    //童话技能在[现实]中无法看见技能名和技能描述（右上角预览）
    [HarmonyPatch(typeof(SkillTargetTooltip))]
    class SkillTargetTooltip_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(SkillTargetTooltip.InputInfo))]
        static bool InputInfoPrefix(SkillTargetTooltip __instance, BattleChar bc, ref Skill useskill)
        {
            if (useskill.ExtendedFind_DataName("SkillExtended_Fairytale") != null && !useskill.Master.BuffFind("B_FVAlice_P_1"))
            {
                Skill tmpSkill = Skill.TempSkill("S_FVAlice_Default", bc, bc.MyTeam);
                useskill = tmpSkill;
            }
            return true;
        }
    }

    //美梦 攻击时有概率（60%-目标ccRES%）攻击自己。
    [HarmonyPatch(typeof(BattleEnemy))]
    class BattleEnemy_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(BattleEnemy.TargetSelect))]
        static void TargetSelectPostfix(BattleEnemy __instance)
        {
            if (__instance.BuffFind("B_FVAlice_1"))
            {
                if (RandomManager.RandomPer(__instance.GetRandomClass().Main, 100, (int)(60 - __instance.GetStat.RES_CC)))
                {
                    __instance.SaveTarget.Clear();
                    List<BattleChar> list = new List<BattleChar>();
                    list.Add(__instance);
                    __instance.SaveTarget = list;
                }
            }
        }
    }
}