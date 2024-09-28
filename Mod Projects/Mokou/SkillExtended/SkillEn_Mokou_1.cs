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
namespace Mokou
{
	/// <summary>
	/// 妹红每拥有1层赤魂，造成的伤害增加20%。
	/// </summary>
    public class SkillEn_Mokou_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && MainSkill.AP >= 1;
        }
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            int num = 0;
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleAlly.Info.KeyData == "Mokou")
                {
                    if (battleAlly.BuffFind("B_Mokou_0", false) == false)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = battleAlly.BuffReturn("B_Mokou_0", false).StackNum ;
                    }
                }
            }
            num *= 20;
            return Damage += BattleChar.CalculationResult((float)this.MySkill.TargetDamageOriginal, num, 0);
        }
    }
}