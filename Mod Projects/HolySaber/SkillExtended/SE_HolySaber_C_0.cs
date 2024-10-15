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
namespace HolySaber
{
	/// <summary>
	/// 对拥有<color=#4876FF>守护</color>减益的敌人造成的伤害+30%。
	/// 攻击技能
	/// </summary>
    public class SE_HolySaber_C_0:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && base.CanSkillEnforce(MainSkill);
        }
        
        public override void Init()
        {
            base.Init();
            this.IgnoreTaunt = true;
            this.OnePassive = true;
        }
        
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            this.OnePassive = true;
            if (Target.BuffFind("B_HolySaber_Def", false))
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 30, 0);
            }
        }
    }
}