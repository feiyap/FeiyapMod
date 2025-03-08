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
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace HiHouClab
{
    public static class Planck
    {
        public static int PlanckAP
        {
            get
            {
                return _PlanckAP;
            }
            set
            {
                SetPlanckAP(value, false);
            }
        }

        private static int _PlanckAP;

        public static void SetPlanckAP(int value, bool NewTurnRecover = false)
        {
            foreach (IP_APChanged ip_APChanged in BattleSystem.instance.IReturn<IP_APChanged>())
            {
                if (ip_APChanged != null)
                {
                    ip_APChanged.APChanged(_PlanckAP, value, NewTurnRecover);
                }
            }
            _PlanckAP = value;
            if (BattleSystem.instance.AllyTeam.AP >= 10)
            {
                _PlanckAP = 10 - (BattleSystem.instance.AllyTeam.AP - _PlanckAP);
            }
            if (BattleSystem.instance.AllyTeam.AP - _PlanckAP >= 10)
            {
                _PlanckAP = 0;
            }

            BattleSystem.instance.ActWindow.Init(BattleSystem.instance.AllyTeam);
        }
    }

    [HarmonyPatch(typeof(BattleAlly))]
    public static class BattleAllyPatch
    {
        //释放迅速技能时优先消耗普朗克法力值
        [HarmonyPrefix]
        [HarmonyPatch("UseSkillAfter")]
        public static bool UseSkillAfter_Prefix(BattleAlly __instance, Skill skill)
        {
            bool isTri = false;
            int ap = skill.AP;
            if (skill.UsedApNum < 0)
            {
                skill.UsedApNum = 0;
            }
            if (!skill.FreeUse && skill.NotCount)
            {
                if (Planck.PlanckAP >= ap)
                {
                    Planck.PlanckAP -= ap;
                    isTri = true;
                }
                else
                {
                    ap -= Planck.PlanckAP;
                    Planck.PlanckAP = 0;
                    __instance.MyTeam.AP -= ap;
                    isTri = true;
                }
            }

            if (isTri)
            {
                if (skill.BasicSkill && !skill.IsNowCasting)
                {
                    __instance.MyBasicSkill.ThisSkillUse = true;
                    foreach (Skill_Extended skill_Extended in __instance.MyBasicSkill.buttonData.AllExtendeds)
                    {
                        if (skill_Extended.SkillParticleLive != null)
                        {
                            UnityEngine.Object.Destroy(skill_Extended.SkillParticleLive);
                        }
                    }
                    if (SaveManager.Difficalty == 2)
                    {
                        __instance.MyBasicSkill.CoolDownNum = 2;
                        if (__instance.MyBasicSkill.buttonData.BasicOption)
                        {
                            __instance.MyBasicSkill.CoolDownNum--;
                        }
                    }
                    if (__instance.MyBasicSkill.buttonData.BasicOption)
                    {
                        __instance.MyBasicSkill.InActive = true;
                    }
                    else
                    {
                        for (int i = 0; i < __instance.MyTeam.Chars.Count; i++)
                        {
                            BattleAlly battleAlly = __instance.MyTeam.Chars[i] as BattleAlly;
                            if (!battleAlly.IsDead && battleAlly.MyBasicSkill != null && !battleAlly.MyBasicSkill.buttonData.BasicOption)
                            {
                                battleAlly.MyBasicSkill.InActive = true;
                            }
                        }
                    }
                    foreach (IP_SkillUse_BasicSkill ip_SkillUse_BasicSkill in BattleSystem.instance.IReturn<IP_SkillUse_BasicSkill>())
                    {
                        if (ip_SkillUse_BasicSkill != null)
                        {
                            ip_SkillUse_BasicSkill.SkillUseBasicSkill(skill);
                        }
                    }
                }
                if (skill.IsNowCasting)
                {
                    if (!__instance.Dummy && !__instance.IsLucyNoC)
                    {
                        __instance.WindowAni.SetTrigger("Deselected");
                    }
                }
                using (List<IP_SkillUse_Team>.Enumerator enumerator3 = __instance.IReturn<IP_SkillUse_Team>(null).GetEnumerator())
                {
                    while (enumerator3.MoveNext())
                    {
                        IP_SkillUse_Team ip_SkillUse_Team = enumerator3.Current;
                        if (ip_SkillUse_Team != null)
                        {
                            ip_SkillUse_Team.SkillUseTeam(skill);
                        }
                    }
                    if (!__instance.Dummy && !__instance.IsLucyNoC)
                    {
                        __instance.WindowAni.SetTrigger("Deselected");
                    }
                }
                if (skill.OriginalSelectSkill != null)
                {
                    if (skill.BasicOption)
                    {
                        skill.OriginalSelectSkill.BasicOption = true;
                    }
                    __instance.UseSkillAfter(skill.OriginalSelectSkill);
                }
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(BattleActWindow))]
    public class BattleActWindowPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Init")]
        private static void Init_Postfix(BattleActWindow __instance, BattleTeam Team)
        {
            __instance.MP.text = Team.AP.ToString();
            for (int i = 0; i < __instance.Crystals.Length; i++)
            {
                if (Team.MAXAP <= i)
                {
                    __instance.Crystals[i].SetBool("Lock", true);
                }
                else
                {
                    __instance.Crystals[i].SetBool("Lock", false);
                }
                if (Team.AP <= i)
                {
                    __instance.Crystals[i].SetBool("On", false);
                }
                else
                {
                    __instance.Crystals[i].SetBool("On", true);
                }
            }
            if (Planck.PlanckAP > 0)
            {
                for (int i = Team.AP - Planck.PlanckAP; i < Team.AP; i++)
                {
                    __instance.Crystals[i].transform.Find("On").GetComponent<Image>().color = new UnityEngine.Color(0f, 1f, 1f);
                }
            }
        }
    }

    //回合开始时清空普朗克法力值
    [HarmonyPatch(typeof(BattleTeam))]
    public static class BattleTeamPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("MyTurn")]
        public static void MyTurn_Postfix()
        {
            Planck.PlanckAP = 0;
        }

        [HarmonyPostfix]
        [HarmonyPatch("get_AP")] // 针对 AP 属性的 get 方法
        static void AP_Postfix(BattleTeam __instance, ref int __result)
        {
            var _AP = Traverse.Create(__instance).Field("_AP").GetValue<int>();
            __result = _AP + Planck.PlanckAP;
        }
    }

    //[HarmonyPatch(typeof(SkillButton))]
    //[HarmonyPatch("Update")]
    //public static class SkillButton_Update_Patch
    //{
    //    // Transpiler Patch：使用 CodeMatcher 修改方法的 IL 代码
    //    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    //    {
    //        var matcher = new CodeMatcher(instructions)
    //            .MatchForward(false, // 向前查找
    //                new CodeMatch(OpCodes.Ldarg_0), // this
    //                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(SkillButton), "Myskill")), // Myskill
    //                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(Skill), "Master")), // Master
    //                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(Character), "MyTeam")), // MyTeam
    //                new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(BattleSystem), "instance")), // BattleSystem.instance (静态字段)
    //                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(BattleSystem), "AllyTeam")), // AllyTeam (实例字段)
    //                new CodeMatch(OpCodes.Bne_Un_S), // != (短格式)
    //                new CodeMatch(OpCodes.Ldarg_0) // this
    //            )
    //            .ThrowIfInvalid("Failed to find target code segment") // 如果未找到目标代码段，抛出异常
    //            .Advance(7) // 移动到目标代码段的末尾
    //            .InsertAndAdvance(
    //                new CodeInstruction(OpCodes.Ldarg_0), // this
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(SkillButton), "Myskill")), // Myskill
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Skill), "Master")), // Master
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Character), "MyTeam")), // MyTeam
    //                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(BattleSystem), "instance")), // BattleSystem.instance (静态字段)
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(BattleSystem), "AllyTeam")), // AllyTeam (实例字段)
    //                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Planck), "get_PlanckAP")), // Planck.PlanckAP
    //                new CodeInstruction(OpCodes.Add), // +
    //                new CodeInstruction(OpCodes.Ldarg_0), // this
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(SkillButton), "Myskill")), // Myskill
    //                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Skill), "AP_OverloadViewOnly")), // AP_OverloadViewOnly
    //                new CodeInstruction(OpCodes.Bge) // >=
    //            );

    //        return matcher.InstructionEnumeration();
    //    }
    //}
}