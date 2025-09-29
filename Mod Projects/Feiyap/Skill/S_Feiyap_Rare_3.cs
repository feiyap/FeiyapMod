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
namespace Feiyap
{
	/// <summary>
	/// 神之力量
	/// 抽取 1 个技能。
	/// </summary>
    public class S_Feiyap_Rare_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);

            MasterAudio.PlaySound("God_Strength", 1f, null, 0f, null, null, false, false);
        }
    }
}