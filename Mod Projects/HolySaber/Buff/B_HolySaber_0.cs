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
	/// 神威独角兽
	/// 回合结束时，若自己的体力值为3的倍数，对随机敌人造成&a(50%)伤害；
	/// 若自己体力值为4的倍数，抽取1个技能。
	/// </summary>
    public class B_HolySaber_0:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            if (this.BChar.HP % 3 == 0)
            {
                Skill skill = Skill.TempSkill("S_HolySaber_0_0", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                BattleTeam.SkillRandomUse(this.BChar, skill, false, true, false);
            }
            if (this.BChar.HP % 4 == 0)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
        }
    }
}