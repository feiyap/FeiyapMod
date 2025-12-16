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
namespace Jhin
{
	/// <summary>
	/// 最后的轻语
	/// 本回合内可重复释放。
	/// </summary>
    public class S_Jhin_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Jhin_0", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            tmpSkill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}