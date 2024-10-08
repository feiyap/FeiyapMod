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
	/// 光辉现世
	/// 回合结束时，对所有敌人造成&a(当前回合数 x 6)痛苦伤害。
	/// </summary>
    public class B_HolySaber_Rare_12:Buff, IP_TurnEnd
    {
        public int PlusDmg()
        {
            if (BattleSystem.instance == null)
                return 0;
            
            return BattleSystem.instance.TurnNum * 6;
        }

        public void TurnEnd()
        {
            Skill skill = Skill.TempSkill("S_HolySaber_Rare_3_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.MySkill.Effect_Target.DMG_Base = (int)(PlusDmg()) - 1;
            BattleTeam.SkillRandomUse(this.BChar, skill, false, true, false);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(PlusDmg())).ToString());
        }
    }
}