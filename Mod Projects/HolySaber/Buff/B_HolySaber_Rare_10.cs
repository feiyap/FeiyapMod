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
	/// 尊荣骑士
	/// 当自己受到伤害时，对来源造成&a(50%防御力)的伤害。
	/// </summary>
    public class B_HolySaber_Rare_10:Buff, IP_Hit, IP_Dodge
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.def * 0.5f)).ToString());
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                Skill skill = Skill.TempSkill("S_HolySaber_Rare_1_0", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill.MySkill.Effect_Target.DMG_Base = (int)(this.BChar.GetStat.def * 0.5) - 1;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
        
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1 && !SP.UseStatus.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_HolySaber_Rare_1_0", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill.MySkill.Effect_Target.DMG_Base = (int)(this.BChar.GetStat.def * 0.5) - 1;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
    }
}