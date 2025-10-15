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
namespace Letty
{
	/// <summary>
	/// 对无法行动的敌人造成的伤害提升40%。
	/// 攻击技能
	/// </summary>
    public class SE_Letty_C_0:Skill_Extended, IP_DamageChange_sumoperation
    {
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            this.OnePassive = true;

            if (Target.GetStat.Stun)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 40, 0);
            }
        }

        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && base.CanSkillEnforce(MainSkill);
        }
    }
}