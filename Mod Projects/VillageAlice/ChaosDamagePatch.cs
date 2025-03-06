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
    [HarmonyPatch(typeof(BattleChar))]
    [HarmonyPatch("ChaosDamage", MethodType.Normal)]
    public static class ChaosDamagePatch
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
            foreach (IP_DamageTake ip_DamageTake in instance.IReturn<IP_DamageTake>(null))
            {
                if (ip_DamageTake != null)
                {
                    ip_DamageTake.DamageTake(User, Dmg, Cri, ref flag, false, false, instance);
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
            gameObject.GetComponent<EffectView>().InputDamage(Dmg, Cri, instance.Info.Ally, Pain);

            return Dmg;
        }

        [HarmonyPostfix]
        public static void Postfix(BattleChar __instance)
        {
            // 使用反射将 ChaosDamage 方法添加到 BattleChar 类中
            var chaosDamageMethod = typeof(ChaosDamagePatch).GetMethod("ChaosDamage", BindingFlags.Static | BindingFlags.Public);
            var chaosDamageDelegate = Delegate.CreateDelegate(typeof(Func<BattleChar, int, int>), chaosDamageMethod);

            // 将方法添加到 BattleChar 实例中
            typeof(BattleChar).GetMethod("ChaosDamage", BindingFlags.Instance | BindingFlags.Public)
                ?.Invoke(__instance, new object[] { chaosDamageDelegate });
        }
    }
}