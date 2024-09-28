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
namespace Sunmeitian
{
	/// <summary>
	/// 乾坤之跃
	/// </summary>
    public class S_Sunmeitian_4_2_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_Sunmeitian_1"))
            {
                Skill tmpSkill = Skill.TempSkill("S_Sunmeitian_4", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}