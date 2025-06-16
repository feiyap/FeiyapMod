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
namespace Ralmia2
{
	/// <summary>
	/// 抗争领袖·露琪娜
	/// 打出时，将 1 个“过往核心”和“未来核心”加入手中。
	/// 命中时，将 1 个“攻击创造物”加入手中。
	/// </summary>
    public class S_Ralmia2_3:Skill_Extended, IP_SkillUse_Target
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Skill skill = Skill.TempSkill("S_Ralmia2_Ex_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);

            Skill skill2 = Skill.TempSkill("S_Ralmia2_Ex_1", this.BChar, this.BChar.MyTeam);
            skill2.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill2, true);
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1 && SP.SkillData == this.MySkill)
            {
                Skill skill = Skill.TempSkill("S_Ralmia2_Ex_3", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.APChange = -9;
                this.BChar.MyTeam.Add(skill, true);
            }
        }
    }
}