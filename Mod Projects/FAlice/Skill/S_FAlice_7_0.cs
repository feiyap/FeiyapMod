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
namespace FAlice
{
	/// <summary>
	/// 在手中随机生成 2 个不同的「人形」技能。
	/// </summary>
    public class S_FAlice_7_0 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<string> skillKeys = P_FAlice.Dolls.Random(this.BChar.GetRandomClass().Main, 2);
            foreach(string skillKey in skillKeys)
            {
                Skill skill = Skill.TempSkill(skillKey, this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }
    }
}