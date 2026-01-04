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
    /// 量子隧穿
    /// 每层使受到倒计时技能的伤害提升6%，受到量子伤害提升6%。
    /// </summary>
    public class B_Renko_1:Buff, IP_DamageChange_Hit_sumoperation, IP_DamageTakeChange_sumoperation_Quantum
    {
        public void DamageChange_Hit_sumoperation(Skill SkillD, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int all_counting = SkillD._Counting;

            foreach (Skill_Extended skill_Extended in SkillD.AllExtendeds)//计算skillextended带来的额外倒计时
            {
                all_counting += skill_Extended.Counting;
            }
            if (all_counting > 0 && SkillD.IsDamage)
            {
                PlusDamage = (int)(Damage * this.StackNum * 0.06f);
            }
        }

        public void DamageTakeChange_sumoperation_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, ref int PlusDmg, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            PlusDmg = (int)(Dmg * this.StackNum * 0.06f);
        }
    }
}