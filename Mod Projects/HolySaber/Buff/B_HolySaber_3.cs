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
	/// 光灿圣骑
	/// 回合结束时，对随机敌人造成&a(手牌中拥有[守护]减益的技能数 x 75%防御力)的伤害。
	/// </summary>
    public class B_HolySaber_3:Buff, IP_TurnEnd
    {
        public int PlusDmg()
        {
            if (BattleSystem.instance == null)
                return 0;

            int count = 0;
            foreach(Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.ExtendedFind_DataName("SE_HolySaber_Defend") != null)
                {
                    count++;
                }
            }
            return count;
        }

        public void TurnEnd()
        {
            Skill skill = Skill.TempSkill("S_HolySaber_5_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.MySkill.Effect_Target.DMG_Base = (int)(PlusDmg() * this.BChar.GetStat.def * 0.75) - 1;
            BattleTeam.SkillRandomUse(this.BChar, skill, false, true, false);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(PlusDmg() * this.BChar.GetStat.def * 0.75)).ToString());
        }
    }
}