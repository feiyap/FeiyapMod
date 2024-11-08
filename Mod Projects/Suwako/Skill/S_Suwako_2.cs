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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 源符「厌川的翡翠」
	/// 生成1个[南风灵]。
	/// <color=#008B45>旋回</color> - 生成2个[风灵]。
	/// </summary>
    public class S_Suwako_2:Skill_Extended, IP_SkillSelfToDeck
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Suwako_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            Skill tmpSkill2 = Skill.TempSkill("S_Suwako_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            Skill tmpSkill = Skill.TempSkill("S_FSL_Common", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            Skill tmpSkill2 = Skill.TempSkill("S_FSL_Common", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
        }
    }
}