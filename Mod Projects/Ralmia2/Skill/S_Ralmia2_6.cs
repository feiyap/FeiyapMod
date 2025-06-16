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
	/// 生命的奔流
	/// 将 1 个“过往核心”加入手中。
	/// </summary>
    public class S_Ralmia2_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Skill skill = Skill.TempSkill("S_Ralmia2_Ex_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}