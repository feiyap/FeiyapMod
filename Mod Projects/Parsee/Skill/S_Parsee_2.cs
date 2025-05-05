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
	/// 今宵依旧孤枕眠
	/// 生成1张“宇治桥姬入我心”。
	/// 点燃2层妒火。
	/// </summary>
    public class S_Parsee_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Parsee_2_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            this.BChar.BuffAdd("B_Parsee_P", this.BChar);
            this.BChar.BuffAdd("B_Parsee_P", this.BChar);
        }
    }
}