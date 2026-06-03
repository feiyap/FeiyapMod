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
namespace FeiyapTank
{
    /// <summary>
    /// 处于濒死状态时，费用降低 2 点，伤害提升40%。
    /// 2费以上的攻击技能：
    /// </summary>
    public class SE_FeiyapTank_C_2 : Skill_Extended, IP_HPChange, IP_DamageChange_sumoperation
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && MainSkill._AP >= 2;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (this.BChar.HP < 1)
            {
                this.APChange = -2;
            }
            else
            {
                this.APChange = 0;
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            if (this.BChar.HP < 1)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 40, 0);
            }
            else
            {
                PlusDamage = 0;
            }
        }
    }
}