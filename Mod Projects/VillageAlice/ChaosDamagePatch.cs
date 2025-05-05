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
namespace VillageAlice
{
    public static class BattleCharExtensions
    {
        public static int ChaosDamage(this BattleChar instance, BattleChar User, int Dmg, bool Cri, bool Pain = false, bool NOEFFECT = false, int PlusPenetration = 0, bool IgnoreHealingPro = false, bool HealingPro = false, bool OnlyUnscaleTime = false)
        {
            if (instance.Dummy || instance.IsDead || instance.IsLucyNoC)
            {
                return 0;
            }
            if (instance.GetStat.invincibility)
            {
                return 0;
            }
            if (instance.Dummy)
            {
                return 0;
            }

            GameObject gameObject = Misc.UIInst(instance.BattleInfo.EffectViewOb);
            Dmg += (int)Misc.PerToNum((float)Dmg, (float)((int)instance.GetStat.DMGTaken));

            if (instance.Info.Ally)
            {
                gameObject.transform.position = instance.GetPos();
            }
            else
            {
                gameObject.transform.position = instance.GetTopPos();
            }

            foreach (IP_DamageCriCheck ip_DamageCriCheck in BattleSystem.instance.IReturn<IP_DamageCriCheck>())
            {
                if (ip_DamageCriCheck != null)
                {
                    ip_DamageCriCheck.DamageCriCheck(instance, User, Dmg, ref Cri, Pain, NOEFFECT);
                }
            }
            if (Cri)
            {
                Dmg = (int)((float)Dmg * (1.5f + (User.GetStat.PlusCriDmg + (float)instance.GetStat.CRIGetDMG) * 0.01f));
            }
            bool flag = false;
            if (Dmg <= 0)
            {
                Dmg = 1;
            }

            if (instance.GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count != 0)
            {
                Dmg = (int)Misc.PerToNum((float)Dmg, 120f);
            }

            if (Dmg <= 0)
            {
                Dmg = 1;
            }
            if (flag || instance.GetStat.invincibility)
            {
                gameObject.GetComponent<EffectView>().InputDamage(0, Cri, instance.Info.Ally, Pain);
                return 0;
            }
            int num2 = 0;
            foreach (IP_DamageTakeChange_sumoperation ip_DamageTakeChange_sumoperation in instance.IReturn<IP_DamageTakeChange_sumoperation>(null))
            {
                if (ip_DamageTakeChange_sumoperation != null)
                {
                    int num3 = 0;
                    ip_DamageTakeChange_sumoperation.DamageTakeChange_sumoperation(instance, User, Dmg, Cri, ref num3, Pain, NOEFFECT, false);
                    num2 += num3;
                }
            }
            Dmg += num2;
            foreach (IP_DamageTakeChange ip_DamageTakeChange in instance.IReturn<IP_DamageTakeChange>(null))
            {
                if (ip_DamageTakeChange != null)
                {
                    Dmg = ip_DamageTakeChange.DamageTakeChange(instance, User, Dmg, Cri, Pain, NOEFFECT, false);
                }
            }
            foreach (IP_DealDamage ip_DealDamage in User.IReturn<IP_DealDamage>(null))
            {
                if (ip_DealDamage != null)
                {
                    ip_DealDamage.DealDamage(instance, Dmg, Cri, Pain);
                }
            }
            foreach (IP_DealChaosDamage ip_DealChaosDamage in User.IReturn<IP_DealChaosDamage>(null))
            {
                if (ip_DealChaosDamage != null)
                {
                    ip_DealChaosDamage.DealChaosDamage(instance, Dmg, Cri, Pain);
                }
            }
            foreach (IP_DamageTake ip_DamageTake in instance.IReturn<IP_DamageTake>(null))
            {
                if (ip_DamageTake != null)
                {
                    ip_DamageTake.DamageTake(User, Dmg, Cri, ref flag, false, false, instance);
                }
            }
            foreach (IP_ChaosDamageTake ip_ChaosDamageTake in instance.IReturn<IP_ChaosDamageTake>(null))
            {
                if (ip_ChaosDamageTake != null)
                {
                    ip_ChaosDamageTake.ChaosDamageTake(User, Dmg, Cri, ref flag, false, false, instance);
                }
            }
            if (flag || instance.GetStat.invincibility)
            {
                gameObject.GetComponent<EffectView>().InputDamage(0, Cri, instance.Info.Ally, Pain);
                return 0;
            }

            instance.HP -= Dmg;

            if (!instance.Info.Ally && instance.IsDead)
            {
                BattleSystem.instance.ScriptOut.Text_Kill(User);
            }
            gameObject.GetComponent<EffectView>().InputDamage(Dmg, Cri, instance.Info.Ally, true);

            return Dmg;
        }
    }

    public interface IP_DealChaosDamage
    {
        void DealChaosDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot);
    }

    public interface IP_ChaosDamageTake
    {
        void ChaosDamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null);
    }

    public interface IP_ChangeDamageChaos
    {
        void ChangeDamageChaos(SkillParticle SP, BattleChar Target, int DMG, bool Cri, ref bool ToChaos);
    }

    [HarmonyPatch(typeof(BattleChar))]
    class Effect_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(BattleChar.Effect))]
        static bool EffectPrefix(BattleChar __instance, SkillParticle SP, bool Dodge)
        {
            bool flag = false;
            GDESkillEffectData effect_Target = SP.SkillData.MySkill.Effect_Target;
            if (Dodge)
            {
                if (SaveManager.Difficalty == 2 && SP.SkillData.Track)
                {
                    flag = true;
                    if (SP.LastHit)
                    {
                        EffectView.TextOutSimple(__instance, ScriptLocalization.Battle_Keyword.TrackEffect);
                    }
                    Dodge = false;
                }
                else if (SaveManager.Difficalty != 2 && SP.UseStatus.Info.Ally && !SP.UseStatus.Dummy)
                {
                    flag = true;
                    if (SP.LastHit)
                    {
                        EffectView.TextOutSimple(__instance, ScriptLocalization.Battle_Keyword.TrackEffect);
                    }
                    Dodge = false;
                }
            }
            if (Dodge && SP.LastHit)
            {
                foreach (IP_SkillMiss_User ip_SkillMiss_User in SP.UseStatus.IReturn<IP_SkillMiss_User>(null))
                {
                    if (ip_SkillMiss_User != null)
                    {
                        ip_SkillMiss_User.MissEffect(__instance, SP);
                    }
                }
                foreach (IP_Dodge ip_Dodge in BattleSystem.instance.IReturn<IP_Dodge>())
                {
                    if (ip_Dodge != null)
                    {
                        ip_Dodge.Dodge(__instance, SP);
                    }
                }
                GameObject gameObject = Misc.UIInst(__instance.BattleInfo.EffectViewOb);
                if (__instance.Info.Ally)
                {
                    gameObject.transform.position = __instance.GetPos();
                }
                else
                {
                    gameObject.transform.position = __instance.GetTopPos();
                }
                gameObject.GetComponent<EffectView>().Dodge(__instance.Info.Ally);
                if (!__instance.Info.Ally)
                {
                    List<BuffTag> list = new List<BuffTag>();
                    foreach (Skill_Extended skill_Extended in SP.SkillData.AllExtendeds)
                    {
                        list.AddRange(skill_Extended.TargetBuff);
                    }
                    __instance.SkillEffectBuffAdd(effect_Target, list, SP.UseStatus, SP.SkillData);
                }
                return false;
            }
            if (SP.UseStatus.Info.Ally != __instance.Info.Ally && !Dodge)
            {
                if (!SP.LastHit)
                {
                    MasterAudio.PlaySound("SE_Hit", 1f, null, 0f, null, null, false, false);
                }
                __instance.CharShake();
                if (SP.NoSlowTimeScale)
                {
                    SP.SkillData.NoAttackTimeWait = true;
                }
            }
            if (!SP.LastHit)
            {
                return false;
            }
            int num = SP.HitTime.Length;
            float num2 = (float)SP.SkillData.TargetDamage;
            if (flag)
            {
                num2 /= 2f;
            }
            if (__instance is BattleAlly)
            {
                __instance.MyTeam.AP += effect_Target.AP;
            }
            bool flag2 = RandomManager.RandomPer(__instance.GetRandomClass().DamageCri, 100, SP.SkillData.GetCriPer(__instance, 0));
            if (!SP.SkillData.IsDamage && !SP.SkillData.IsHeal)
            {
                flag2 = false;
            }
            if (flag)
            {
                flag2 = false;
            }
            int num3 = 0;
            foreach (IP_DamageChange_Hit_sumoperation ip_DamageChange_Hit_sumoperation in __instance.IReturn<IP_DamageChange_Hit_sumoperation>(SP.SkillData))
            {
                try
                {
                    int num4 = 0;
                    if (ip_DamageChange_Hit_sumoperation != null)
                    {
                        ip_DamageChange_Hit_sumoperation.DamageChange_Hit_sumoperation(SP.SkillData, (int)num2, ref flag2, false, ref num4);
                        num3 += num4;
                    }
                }
                catch
                {
                }
            }
            foreach (IP_DamageChange_sumoperation ip_DamageChange_sumoperation in SP.UseStatus.IReturn<IP_DamageChange_sumoperation>(SP.SkillData))
            {
                try
                {
                    int num5 = 0;
                    if (ip_DamageChange_sumoperation != null)
                    {
                        ip_DamageChange_sumoperation.DamageChange_sumoperation(SP.SkillData, __instance, (int)num2, ref flag2, false, ref num5);
                        num3 += num5;
                    }
                }
                catch
                {
                }
            }
            foreach (IP_DamageChange ip_DamageChange in SP.UseStatus.IReturn<IP_DamageChange>(SP.SkillData))
            {
                try
                {
                    if (ip_DamageChange != null)
                    {
                        num2 = (float)ip_DamageChange.DamageChange(SP.SkillData, __instance, (int)num2, ref flag2, false);
                    }
                }
                catch
                {
                }
            }
            num2 += (float)num3;
            if (SP.SkillData.ExtendedFind("Extended_Hein_P", true) != null)
            {
                for (int i = 0; i < (SP.SkillData.ExtendedFind("Extended_Hein_P", true) as Extended_Hein_P).PassiveUseNum; i++)
                {
                    num2 /= 2f;
                }
            }
            float num6 = (float)SP.SkillData.TargetHeal;
            if (SP.SkillData.NeverCri)
            {
                flag2 = false;
            }
            bool flag3 = false;
            bool pain = false;
            foreach (IP_ChangeDamageState ip_ChangeDamageState in SP.UseStatus.IReturn<IP_ChangeDamageState>(SP.SkillData))
            {
                if (ip_ChangeDamageState != null)
                {
                    ip_ChangeDamageState.ChangeDamageState(SP, __instance, (int)num2, flag2, ref flag3, ref pain);
                }
            }
            if (flag3)
            {
                num6 += num2;
                num2 = 0f;
            }
            foreach (IP_BeforeHit ip_BeforeHit in __instance.IReturn<IP_BeforeHit>(null))
            {
                try
                {
                    if (ip_BeforeHit != null)
                    {
                        ip_BeforeHit.BeforeHit(SP, (int)num2, flag2);
                    }
                }
                catch
                {

                }
            }

            bool flag4 = false;
            foreach (IP_ChangeDamageChaos ip_ChangeDamageChaos in SP.UseStatus.IReturn<IP_ChangeDamageChaos>(SP.SkillData))
            {
                if (ip_ChangeDamageChaos != null)
                {
                    ip_ChangeDamageChaos.ChangeDamageChaos(SP, __instance, (int)num2, flag2, ref flag4);
                }
            }
            if (flag4)
            {
                num2 = (float)__instance.ChaosDamage(SP.UseStatus, (int)num2, flag2, pain, false, (int)SP.SkillData.PlusSkillStat.Penetration, false, SP.SkillData.PlusSkillStat.Weak, SP.SkillData.NoAttackTimeWait);
                num2 = 0f;
                if (flag2)
                {
                    MasterAudio.PlaySound("SE_CriSound", 1f, null, 0f, null, null, false, false);
                    if (SP.UseStatus is BattleAlly && !__instance.Dummy)
                    {
                        __instance.BattleInfo.ScriptOut.Text_Cri(SP.UseStatus);
                    }
                }
                else
                {
                    MasterAudio.PlaySound("SE_Hit", 1f, null, 0f, null, null, false, false);
                }
            }
            if (num2 >= 1f)
            {
                num2 = (float)__instance.Damage(SP.UseStatus, (int)num2, flag2, pain, false, (int)SP.SkillData.PlusSkillStat.Penetration, false, SP.SkillData.PlusSkillStat.Weak, SP.SkillData.NoAttackTimeWait);
                if (flag2)
                {
                    MasterAudio.PlaySound("SE_CriSound", 1f, null, 0f, null, null, false, false);
                    if (SP.UseStatus is BattleAlly && !__instance.Dummy)
                    {
                        __instance.BattleInfo.ScriptOut.Text_Cri(SP.UseStatus);
                    }
                }
                else
                {
                    MasterAudio.PlaySound("SE_Hit", 1f, null, 0f, null, null, false, false);
                }
            }
            foreach (Skill_Extended skill_Extended2 in SP.SkillData.AllExtendeds)
            {
                try
                {
                    skill_Extended2.BeforeHeal(__instance, SP, num6, flag2);
                }
                catch
                {
                }
            }
            if (num6 >= 1f)
            {
                if (SP.SkillData.TargetChainHeal)
                {
                    num6 = (float)__instance.Heal(SP.UseStatus, (float)((int)num6), flag2, false, new BattleChar.ChineHeal());
                }
                else
                {
                    num6 = (float)__instance.Heal(SP.UseStatus, (float)((int)num6), flag2, SP.SkillData.TargetForceHeal, null);
                }
            }
            foreach (IP_SkillUse_Target ip_SkillUse_Target in SP.UseStatus.IReturn<IP_SkillUse_Target>(SP.SkillData))
            {
                try
                {
                    if (ip_SkillUse_Target != null)
                    {
                        ip_SkillUse_Target.AttackEffect(__instance, SP, (int)num2, flag2);
                    }
                }
                catch
                {
                }
            }
            foreach (Skill_Extended skill_Extended3 in SP.SkillData.AllExtendeds)
            {
                try
                {
                    skill_Extended3.AttackEffectSingle(__instance, SP, (int)num2, (int)num6);
                }
                catch
                {
                }
            }
            foreach (IP_Hit ip_Hit in __instance.IReturn<IP_Hit>(null))
            {
                try
                {
                    if (ip_Hit != null)
                    {
                        ip_Hit.Hit(SP, (int)num2, flag2);
                    }
                }
                catch
                {
                }
            }
            if (flag2)
            {
                foreach (IP_SomeDealCritical ip_SomeDealCritical in BattleSystem.instance.IReturn<IP_SomeDealCritical>())
                {
                    try
                    {
                        if (ip_SomeDealCritical != null)
                        {
                            ip_SomeDealCritical.SomeDealCritical(__instance, SP, (int)num2, (int)num6);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            List<BuffTag> list2 = new List<BuffTag>();
            foreach (Skill_Extended skill_Extended4 in SP.SkillData.AllExtendeds)
            {
                list2.AddRange(skill_Extended4.TargetBuff);
            }
            __instance.SkillEffectBuffAdd(effect_Target, list2, SP.UseStatus, SP.SkillData);

            return false;
        }
    }
}