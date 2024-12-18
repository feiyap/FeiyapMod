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
namespace YasakaKanano
{
	/// <summary>
	/// <color=#CD5555>饥馑10</color> - 伤害增加30%。
	/// 攻击技能
	/// </summary>
    public class SE_Kanano_C1: Skillbase_Kanano
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && base.CanSkillEnforce(MainSkill);
        }
        
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            this.OnePassive = true;
            if (CheckDeck2(10))
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 30, 0);
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckDeck2(10))
            {

            }
        }
    }
}