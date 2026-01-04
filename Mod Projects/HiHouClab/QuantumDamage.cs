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
    public static class BattleCharExtensions
    {
        public static int QuantumDamage(this BattleChar instance, BattleChar User, int Dmg, bool Cri, bool Pain = false, bool NOEFFECT = false, int PlusPenetration = 0, bool IgnoreHealingPro = false, bool HealingPro = false, bool OnlyUnscaleTime = false)
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

            EffectView component = gameObject.GetComponent<EffectView>();
            component.init(instance.Info.Ally);

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
            if (flag || instance.GetStat.invincibility)
            {
                //gameObject.GetComponent<EffectView>().InputDamage(0, Cri, instance.Info.Ally, Pain);

                component.MyText.font = component.PainDamageFont;
                component.MyText.transform.localPosition = new Vector3(0f, 0f, 0f);
                component.MyText.color = new Color(147f, 112f, 219f, 1f); // 红色，完全不透明
                component.XRand = UnityEngine.Random.Range(-15f, 15f);
                component.MyText.text = "0";
                component.GetComponent<Animator>().Play("Effect_Damage");
                component.TagDelete();
                return 0;
            }
            int num2 = 0;
            foreach (IP_DamageTakeChange_sumoperation_Quantum ip_DamageTakeChange_sumoperation_Quantum in instance.IReturn<IP_DamageTakeChange_sumoperation_Quantum>(null))
            {
                if (ip_DamageTakeChange_sumoperation_Quantum != null)
                {
                    int num3 = 0;
                    ip_DamageTakeChange_sumoperation_Quantum.DamageTakeChange_sumoperation_Quantum(instance, User, Dmg, Cri, ref num3, Pain, NOEFFECT, false);
                    num2 += num3;
                }
            }
            Dmg += num2;
            foreach (IP_DamageTakeChange_Quantum ip_DamageTakeChange_Quantum in instance.IReturn<IP_DamageTakeChange_Quantum>(null))
            {
                if (ip_DamageTakeChange_Quantum != null)
                {
                    Dmg = ip_DamageTakeChange_Quantum.DamageTakeChange_Quantum(instance, User, Dmg, Cri, Pain, NOEFFECT, false);
                }
            }
            foreach (IP_DealDamage ip_DealDamage in User.IReturn<IP_DealDamage>(null))
            {
                if (ip_DealDamage != null)
                {
                    ip_DealDamage.DealDamage(instance, Dmg, Cri, Pain);
                }
            }
            foreach (IP_DealQuantumDamage ip_DealQuantumDamage in User.IReturn<IP_DealQuantumDamage>(null))
            {
                if (ip_DealQuantumDamage != null)
                {
                    ip_DealQuantumDamage.DealQuantumDamage(instance, Dmg, Cri, Pain);
                }
            }
            foreach (IP_QuantumDamageTake ip_QuantumDamageTake in instance.IReturn<IP_QuantumDamageTake>(null))
            {
                if (ip_QuantumDamageTake != null)
                {
                    ip_QuantumDamageTake.QuantumDamageTake(User, Dmg, Cri, ref flag, false, false, instance);
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
            //gameObject.GetComponent<EffectView>().InputDamage(Dmg, Cri, instance.Info.Ally, true);

            if (Cri)
            {
                component.CriImage.gameObject.SetActive(true);
                component.CriImage.sprite = component.CritPainDamageSprite;
            }
            component.MyText.font = component.PainDamageFont;
            component.MyText.transform.localPosition = new Vector3(0f, 0f, 0f);

            Material newMaterial = new Material(component.MyText.material);
            newMaterial.color = new Color(65f / 255f, 105f / 255f, 225f / 255f, 1f);
            component.MyText.material = newMaterial;

            component.XRand = UnityEngine.Random.Range(-15f, 15f);
            component.MyText.text = Dmg.ToString();
            component.GetComponent<Animator>().Play("Effect_Damage");
            component.TagDelete();

            return Dmg;
        }
    }

    public interface IP_DealQuantumDamage
    {
        void DealQuantumDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot);
    }

    public interface IP_QuantumDamageTake
    {
        void QuantumDamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null);
    }

    public interface IP_DamageTakeChange_Quantum
    {
        int DamageTakeChange_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false);
    }

    public interface IP_DamageTakeChange_sumoperation_Quantum
    {
        void DamageTakeChange_sumoperation_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, ref int PlusDmg, bool NODEF = false, bool NOEFFECT = false, bool Preview = false);
    }
}