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
namespace HinanawiTenshi
{
	/// <summary>
	/// 非想「非想非非想之剑」
	/// 消耗自身所有气质。每点消耗的气质使这个技能造成的伤害提升1.1倍。
	/// 当前提升的倍数为：&a
	/// 当前造成的伤害为：&b
	/// </summary>
    public class S_Tenshi_2: SkillBase_Tenshi, IP_DamageChange_sumoperation
    {
        public override string DescExtended(string desc)
        {
            int kishi = 0;
            int dmg = 0;
            if (BattleSystem.instance != null && BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() != null)
            {
                kishi = BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi;
                dmg = (int)(this.BChar.GetStat.atk * 0.5 * Math.Pow(1.1, kishi));
            }

            return base.DescExtended(desc).Replace("&a", (Math.Pow(1.1, kishi)).ToString())
                                          .Replace("&b", (dmg).ToString());
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
            }

            int kishi = BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi;
            int num = (int)(Math.Pow(1.1, kishi) * 100) - 100;
            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }

            if (!View)
            {
                BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi = 0;
            }
        }
    }
}