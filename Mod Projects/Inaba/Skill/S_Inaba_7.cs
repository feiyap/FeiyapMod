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
namespace Inaba
{
	/// <summary>
	/// 影符「暗月下的逃逸」
	/// 生成1张仅能指向相同阵营单位的[影符「暗月下的误导」]。
	/// </summary>
    public class S_Inaba_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill skill = Skill.TempSkill("S_Inaba_7_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.AutoDelete = 1;
            this.BChar.MyTeam.Add(skill, true);
        }
    }
}