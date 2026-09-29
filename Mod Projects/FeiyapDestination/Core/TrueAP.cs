using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace FeiyapDestination
{
    /// <summary>
    /// 真法力：回合末保留；消耗顺序为普通法力优先，其后真法力。
    /// 仅当队伍中存在终点·绯夜氏时介入。
    /// </summary>
    public static class TrueAp
    {
        private static int _TrueAP;

        public static int TrueAP
        {
            get { return _TrueAP; }
            set { SetTrueAP(value); }
        }

        public static bool PartyHasDestination()
        {
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return false;
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (bc != null && bc.Info != null && bc.Info.KeyData == FeiyapKeys.Destination)
                {
                    return true;
                }
            }
            return false;
        }

        public static BattleChar FindDestination()
        {
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return null;
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (bc != null && bc.Info != null && bc.Info.KeyData == FeiyapKeys.Destination)
                {
                    return bc;
                }
            }
            return null;
        }

        public static void SetTrueAP(int value)
        {
            if (BattleSystem.instance == null)
            {
                _TrueAP = Math.Max(0, value);
                return;
            }
            _TrueAP = Math.Max(0, value);
            if (_TrueAP > 10)
            {
                _TrueAP = 10;
            }
            if (BattleSystem.instance.AllyTeam.AP + _TrueAP > 10)
            {
                BattleSystem.instance.AllyTeam.AP = 10 - _TrueAP;
            }
            if (BattleSystem.instance.ActWindow != null)
            {
                BattleSystem.instance.ActWindow.Init(BattleSystem.instance.AllyTeam);
            }
        }

        /// <summary>将普通法力转为真法力。</summary>
        public static void ConvertNormalToTrue(int amount)
        {
            if (BattleSystem.instance == null)
            {
                return;
            }
            for (int i = 0; i < amount && BattleSystem.instance.AllyTeam.AP > 0; i++)
            {
                BattleSystem.instance.AllyTeam.AP--;
                _TrueAP++;
            }
            if (_TrueAP > 10)
            {
                _TrueAP = 10;
            }
            if (BattleSystem.instance.ActWindow != null)
            {
                BattleSystem.instance.ActWindow.Init(BattleSystem.instance.AllyTeam);
            }
        }

        /// <summary>
        /// 先扣普通，再扣真。返回实际消耗的真法力点数。
        /// </summary>
        public static int SpendApNormalThenTrue(BattleAlly ally, int cost)
        {
            if (cost <= 0 || ally == null)
            {
                return 0;
            }
            int remain = cost;
            int fromNormal = Math.Min(remain, ally.MyTeam.AP);
            ally.MyTeam.AP -= fromNormal;
            remain -= fromNormal;
            int fromTrue = Math.Min(remain, _TrueAP);
            _TrueAP -= fromTrue;
            if (BattleSystem.instance != null && BattleSystem.instance.ActWindow != null)
            {
                BattleSystem.instance.ActWindow.Init(BattleSystem.instance.AllyTeam);
            }
            return fromTrue;
        }

        public static void OnTrueApConsumed(int amount)
        {
            if (amount <= 0)
            {
                return;
            }
            BattleChar dest = FindDestination();
            if (dest == null || dest.IsDead)
            {
                return;
            }
            for (int i = 0; i < amount; i++)
            {
                dest.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Lianxin, dest, false, 0, false, -1, false);
            }
        }
    }

    [HarmonyPatch(typeof(BattleAlly))]
    public static class TrueAp_BattleAlly_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("UseSkillAfter")]
        public static bool UseSkillAfter_Prefix(BattleAlly __instance, Skill skill)
        {
            if (!TrueAp.PartyHasDestination() || skill == null || skill.FreeUse)
            {
                return true;
            }
            int ap = skill.AP;
            if (skill.UsedApNum < 0)
            {
                skill.UsedApNum = 0;
            }
            // 仅当普通法力不足、需要动用真法力时介入
            if (TrueAp.TrueAP <= 0 || __instance.MyTeam.AP >= ap)
            {
                return true;
            }
            if (ap <= 0)
            {
                return true;
            }

            int trueSpent = TrueAp.SpendApNormalThenTrue(__instance, ap);
            skill.UsedApNum = ap;
            TrueAp.OnTrueApConsumed(trueSpent);

            // 复刻基础技能冷却等副作用的最小集合
            if (skill.BasicSkill && !skill.IsNowCasting)
            {
                __instance.MyBasicSkill.ThisSkillUse = true;
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
            }
            if (!__instance.Dummy && !__instance.IsLucyNoC)
            {
                __instance.WindowAni.SetTrigger("Deselected");
            }
            foreach (IP_SkillUse_Team ip in __instance.IReturn<IP_SkillUse_Team>(null))
            {
                if (ip != null)
                {
                    ip.SkillUseTeam(skill);
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
    }

    [HarmonyPatch(typeof(BattleSystem))]
    public static class TrueAp_BattleSystem_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("BattleStart")]
        public static void BattleStart_Prefix()
        {
            TrueAp.TrueAP = 0;
        }

        [HarmonyPrefix]
        [HarmonyPatch("BattleEnd")]
        public static void BattleEnd_Prefix()
        {
            TrueAp.TrueAP = 0;
        }
    }

    [HarmonyPatch(typeof(BattleActWindow))]
    public static class TrueAp_ActWindow_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Init")]
        public static void Init_Postfix(BattleActWindow __instance, BattleTeam Team)
        {
            if (!TrueAp.PartyHasDestination() || TrueAp.TrueAP <= 0)
            {
                return;
            }
            __instance.MP.text = (Team.AP + TrueAp.TrueAP).ToString();
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
                __instance.Crystals[i].SetBool("On", Team.AP + TrueAp.TrueAP > i);
            }
            foreach (Animator ani in __instance.Crystals)
            {
                Transform on = ani.transform.Find("On");
                if (on != null)
                {
                    Image img = on.GetComponent<Image>();
                    if (img != null)
                    {
                        img.color = Color.white;
                    }
                }
            }
            // 真法力显示在末尾晶格（普通之后）
            int start = Team.AP;
            for (int i = 0; i < TrueAp.TrueAP; i++)
            {
                int idx = start + i;
                if (idx >= 0 && idx < __instance.Crystals.Length)
                {
                    Transform on = __instance.Crystals[idx].transform.Find("On");
                    if (on != null)
                    {
                        Image img = on.GetComponent<Image>();
                        if (img != null)
                        {
                            img.color = new Color(0.4f, 0.7f, 1f);
                        }
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(SkillButton))]
    public static class TrueAp_SkillButton_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Update_Postfix(SkillButton __instance)
        {
            if (!TrueAp.PartyHasDestination() || BattleSystem.instance == null || __instance.Myskill == null)
            {
                return;
            }
            if (__instance.Myskill.Master == null || __instance.Myskill.Master.MyTeam != BattleSystem.instance.AllyTeam)
            {
                return;
            }
            int need = __instance.Myskill.AP_OverloadViewOnly;
            if (__instance.Myskill.Master.MyTeam.AP + TrueAp.TrueAP >= need)
            {
                if (!__instance.Myskill.Master.GetStat.Stun || __instance.Myskill.CanUseStun)
                {
                    if (!__instance.Myskill.NotAvailable)
                    {
                        __instance.interactable = true;
                    }
                }
            }
        }
    }
}
