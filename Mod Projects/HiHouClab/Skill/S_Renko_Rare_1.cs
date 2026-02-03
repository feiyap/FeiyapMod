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
namespace HiHouClab
{
    /// <summary>
    /// 最澄澈的空与海
    /// 这个技能暴击时，额外造成150%伤害。
    /// 这个技能处于倒计时期间，自身无法使用其他攻击技能。
    /// </summary>
    public class S_Renko_Rare_1 : Skill_Extended, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.PlusSkillStat.Penetration = 100f;

            if (Targets[0].HP / Targets[0].GetStat.maxhp >= 90)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 2.0);
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
            }
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Cri)
            {
                return (int)(Damage * 1.5f);
            }
            else
            {
                return Damage;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 2.0)).ToString());
        }
    }
}