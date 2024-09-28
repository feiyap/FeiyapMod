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
namespace Eirin
{
	/// <summary>
	/// 秘术「天文密葬法」
	/// 消耗场上所有[月人/新月]，每层消耗的[月人/新月]使这个技能额外造成&a(15%)伤害。
	/// 这个技能造成伤害的35%会转化为对自己的连锁治疗。
	/// </summary>
    public class S_Eirin_11Rare:Skill_Extended
    {
        public int num;

        public int PlusDmg
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 0.15f);
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                if (BattleSystem.instance.AllyList[i].BuffFind("B_Eirin_P", false) && BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).StackNum >= 1)
                {
                    num += BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).StackNum;
                    BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).SelfDestroy();
                }
            }

            this.SkillBasePlus.Target_BaseDMG = num * PlusDmg;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 35f / 100f)), this.BChar.GetCri(), false, new BattleChar.ChineHeal());
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString());
        }
    }
}