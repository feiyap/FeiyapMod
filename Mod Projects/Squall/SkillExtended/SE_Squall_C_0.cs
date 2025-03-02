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
namespace Squall
{
	/// <summary>
	/// 斯考尔拥有[刃甲]时，造成的伤害提升30%。
	/// 攻击技能
	/// </summary>
    public class SE_Squall_C_0:Skill_Extended
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
            BattleChar battleChar2 = null;
            foreach (BattleChar battleChar3 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar3.Info.KeyData == "Squall")
                {
                    battleChar2 = battleChar3;
                    break;
                }
            }
            if (battleChar2.IsDead)
            {
                return;
            }

            if (battleChar2.BuffFind("B_Squall_P"))
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 30, 0);
            }
        }
    }
}