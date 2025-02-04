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
namespace szb_elena
{
	/// <summary>
	/// 独角兽战士
	/// 将1个“独角兽”加入手中。
	/// </summary>
    public class S_szb_elena_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {

            Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_szb_elena_3_0, this.BChar, this.BChar.MyTeam);
            skill.NotCount = true;
            skill.isExcept = true;
            this.BChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);

        }
    }
}