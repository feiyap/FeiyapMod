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
namespace Parsee
{
	/// <summary>
	/// 舌切雀的尖鸣
	/// 受到攻击时反击(50%攻击力)。
	/// </summary>
    public class B_Parsee_5_0:Buff, IP_Hit, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                Skill skill = Skill.TempSkill("S_Parsee_5_3", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
        
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1 && !SP.UseStatus.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_Parsee_5_3", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
    }
}