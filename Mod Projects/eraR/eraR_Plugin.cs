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
using System.Diagnostics;
using UseItem;
namespace eraR
{
    public class eraR_Plugin: ChronoArkPlugin
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

    /// <summary>
    /// 角色技能稀有度倒转：普通技能视为稀有、稀有技能视为普通。
    /// 露西技能、默认技能等不参与倒转。
    /// </summary>
    public static class SkillRareInvert
    {
        public static bool ShouldInvert(GDESkillData skillData)
        {
            return skillData.User != "" && skillData.Category.Key != GDEItemKeys.SkillCategory_LucySkill &&
                skillData.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && skillData.User != GDEItemKeys.Character_LucyC;
        }

        public static bool ShouldInvertForCharacter(string charID)
        {
            if (charID == GDEItemKeys.Character_LucyC)
            {
                return false;
            }
            foreach (GDESkillData skill in PlayData.ALLSKILLLIST)
            {
                if (skill.User == charID)
                {
                    return ShouldInvert(skill);
                }
            }
            return false;
        }

        /// <summary>
        /// 倒转后视为「稀有」的技能池 = 原本不在 ALLRARESKILLLIST 中的角色技能。
        /// </summary>
        public static List<GDESkillData> GetInvertedRareSkills(string charID)
        {
            List<GDESkillData> result = new List<GDESkillData>();
            HashSet<string> originallyRareKeys = new HashSet<string>();
            foreach (GDESkillData skill in PlayData.ALLRARESKILLLIST)
            {
                originallyRareKeys.Add(skill.KeyID);
            }
            foreach (GDESkillData skill in PlayData.ALLSKILLLIST)
            {
                if (skill.User == charID && !originallyRareKeys.Contains(skill.KeyID))
                {
                    result.Add(skill);
                }
            }
            return result;
        }
    }

    [HarmonyPatch(typeof(GDESkillData))]
    public static class GDESkillData_statPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Rare", MethodType.Getter)]
        public static void Rare_Postfix(GDESkillData __instance, ref bool __result)
        {
            if (SkillRareInvert.ShouldInvert(__instance))
            {
                __result = !__result;
            }
        }
    }

    [HarmonyPatch(typeof(PlayData))]
    public static class PlayData_GetMySkillsPatch
    {
        /// <summary>
        /// 稀有技能书、黑市、特殊规则等通过 GetMySkills(true) 获取稀有技能池，倒转后改为返回原本的普通技能。
        /// GetMySkills(false) 仍走原逻辑（升级/普通技能书从全技能池抽取，重叠判定由 Rare getter 倒转处理）。
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch("GetMySkills")]
        public static bool GetMySkills_Prefix(string CharID, bool Rare, ref List<GDESkillData> __result)
        {
            if (Rare && SkillRareInvert.ShouldInvertForCharacter(CharID))
            {
                __result = SkillRareInvert.GetInvertedRareSkills(CharID);
                return false;
            }
            return true;
        }
    }
}
