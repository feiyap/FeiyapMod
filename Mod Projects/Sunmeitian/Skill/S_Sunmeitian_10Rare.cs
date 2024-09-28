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
	/// 大闹天宫
	/// 本回合内可以0费再次释放。
	/// </summary>
    public class S_Sunmeitian_10Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.AutoDelete != 0)
            {
                return;
            }
            Skill skill = Skill.TempSkill("S_Sunmeitian_10Rare", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.AP = 0;
            skill.AutoDelete = 1;
            this.BChar.MyTeam.Add(skill, true);
        }
    }
}