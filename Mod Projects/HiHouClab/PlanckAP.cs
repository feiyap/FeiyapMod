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
using System.Diagnostics;

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
            if (BattleSystem.instance.AllyTeam.AP + Planck.PlanckAP >= 10)
            {
                _PlanckAP = 10 - BattleSystem.instance.AllyTeam.AP;
            }
            if (BattleSystem.instance.AllyTeam.AP >= 10)
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
            __instance.MP.text = (Team.AP + Planck.PlanckAP).ToString();
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
                if (Team.AP + Planck.PlanckAP <= i)
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
                foreach (Animator ani in __instance.Crystals)
                {
                    ani.transform.Find("On").GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f);
                }
                for (int i = Team.AP; i < Team.AP + Planck.PlanckAP; i++)
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
    }

    //修改技能释放条件和法力值显示
    [HarmonyPatch(typeof(SkillButton))]
    public static class SkillButtonPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Update_Postfix(SkillButton __instance)
        {
            __instance.interactable = true;

            int ap_OverloadViewOnly = __instance.Myskill.AP_OverloadViewOnly;
            
            if (BattleSystem.instance != null)
            {
                
                if (__instance.Myskill.Master.MyTeam == BattleSystem.instance.AllyTeam)
                {
                    if (__instance.Myskill.NotCount)
                    {
                        if ((__instance.Myskill.Master.MyTeam.AP + Planck.PlanckAP) < ap_OverloadViewOnly)
                        {
                            __instance.interactable = false;
                        }
                    }
                    else
                    {
                        if (__instance.Myskill.Master.MyTeam.AP < ap_OverloadViewOnly)
                        {
                            __instance.interactable = false;
                        }
                    }
                }
                if (__instance.Myskill.Master.GetStat.Stun && !__instance.Myskill.CanUseStun)
                {
                    __instance.interactable = false;
                }
                if (__instance.Myskill.NotAvailable)
                {
                    __instance.interactable = false;
                }
                for (int j = 0; j < __instance.Myskill.AllExtendeds.Count; j++)
                {
                    if (__instance.Myskill.AllExtendeds[j].SetAlwaysCanUse)
                    {
                        __instance.interactable = true;
                        break;
                    }
                }

                if (__instance.gameObject.activeSelf)
                {
                    if (__instance.IsNowCasting)
                    {
                        __instance.Ani.SetBool("On", true);
                    }
                    else if (BattleSystem.instance.SelectedSkill == __instance.Myskill)
                    {
                        if (__instance.Myskill.BasicSkillButton == null && !__instance.IsUseBig)
                        {
                            __instance.MainAni.SetBool("Selected", true);
                        }
                    }
                    else if (BattleSystem.instance.SelectedSkill == null)
                    {
                        if (__instance.Myskill.BasicSkillButton == null && !__instance.IsUseBig)
                        {
                            __instance.MainAni.SetBool("Selected", false);
                        }
                        if (__instance.interactable)
                        {
                            __instance.Ani.SetBool("On", true);
                        }
                    }
                    else if (BattleSystem.instance.SelectedSkill != null && BattleSystem.instance.SelectedSkill != __instance.Myskill)
                    {
                        __instance.Ani.SetBool("On", false);
                    }
                }

                if (__instance.gameObject.activeSelf)
                {
                    if (!__instance.IsNowCasting && !__instance.interactable)
                    {
                        __instance.Ani.SetBool("On", false);
                    }
                    else
                    {
                        __instance.Ani.SetBool("On", true);
                    }
                }
            }

        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SkillButton.OnPointerEnter), new Type[] { })]
        public static bool OnPointerEnter_Prefix(SkillButton __instance)
        {
            if (__instance.IsUseBig)
            {
                __instance.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
            }
            if (BattleSystem.instance != null && __instance.Myskill.Master.BattleInfo == null)
            {
                ToolTipWindow.SkillToolTip(__instance.transform, __instance.Myskill, __instance.CharData, 0, 1, true, false, false);
                return false;
            }
            ToolTipWindow.SkillToolTip(__instance.TooltipTr, __instance.Myskill, __instance.CharData, 0, 1, true, false, false);
            if (__instance.Myskill.Master is BattleEnemy && __instance.IsNowCasting)
            {
                (__instance.Myskill.Master as BattleEnemy).CastingSkillMasterEffectOn();
            }
            if (BattleSystem.instance != null && __instance.CharData != null && __instance.Myskill.Master != BattleSystem.instance.DummyChar && __instance.Myskill.Master != BattleSystem.instance.AllyTeam.LucyAlly && __instance.CharData is BattleAlly)
            {
                (__instance.CharData as BattleAlly).WindowAni.SetTrigger("Selected");
            }
            if (BattleSystem.instance != null && !__instance.Myskill.BasicSkill && BattleSystem.instance.TargetSelecting && BattleSystem.instance.SelectedSkill.TargetTypeKey == GDEItemKeys.s_targettype_skill && TargetSelects.OneSelect != null)
            {
                using (List<Skill_Extended>.Enumerator enumerator = BattleSystem.instance.SelectedSkill.AllExtendeds.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.SkillTargetSelectExcept(__instance.Myskill))
                        {
                            return false;
                        }
                    }
                }
                TargetSelects.OneSelect.NewPos(__instance.TargetPos.position, true, __instance);
            }
            if (__instance.interactable && __instance.Myskill.AP >= 1 && BattleSystem.instance != null && !BattleSystem.instance.TargetSelecting && !UIManager.inst.CharstatUI.activeInHierarchy)
            {
                for (int i = (__instance.Myskill.MyTeam.AP + Planck.PlanckAP); i > (__instance.Myskill.MyTeam.AP + Planck.PlanckAP) - __instance.Myskill.AP; i--)
                {
                    BattleSystem.instance.ActWindow.APGroup.transform.GetChild(i - 1).GetComponent<Animator>().SetBool("Using", true);
                }
            }
            if (BattleSystem.instance != null && __instance.castskill != null)
            {
                if (BattleSystem.instance.ActWindow.On)
                {
                    __instance.Myskill.Master.TargetLook();
                }
                BattleSystem.instance.CastTargetView(__instance.castskill, false);
                if (!__instance.castskill.Usestate.Info.Ally)
                {
                    foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
                    {
                        if (battleEnemy != __instance.castskill.Usestate)
                        {
                            battleEnemy.UI.CharImage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.33f);
                        }
                    }
                }
            }
            if (BattleSystem.instance != null && __instance.Myskill.Counting >= 1 && __instance.castskill == null && !BattleSystem.instance.TargetSelecting && BattleSystem.instance.ActWindow.On)
            {
                BattleSystem.instance.ActWindow.CountSkillPointEnter(__instance.Myskill);
            }
            if (BattleSystem.instance != null)
            {
                foreach (Skill_Extended skill_Extended in __instance.Myskill.AllExtendeds)
                {
                    skill_Extended.Special_SkillButtonPointerEnter();
                }
            }

            return false;
        }
    }
}