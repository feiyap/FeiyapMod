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
	/// 双炮神罚
	/// 每次使用带有<color=#4876FF>守护</color>减益的技能时，减少1回合持续时间。
	/// 效果解除时，对所有敌人造成&a(100%)伤害，并施加<color=#4876FF>守护</color>。
	/// </summary>
    public class B_HolySaber_8:Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.ExtendedFind_DataName("SE_HolySaber_Defend") != null)
            {
                for (int i = 0; i < this.StackInfo.Count; i++)
                {
                    this.StackInfo[i].RemainTime--;
                    if (this.StackInfo[i].RemainTime == 0)
                    {
                        this.DestroyByTurn();
                        this.StackInfo.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            Skill skill = Skill.TempSkill("S_HolySaber_8_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            BattleTeam.SkillRandomUse(this.BChar, skill, false, true, false);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString());
        }
    }
}