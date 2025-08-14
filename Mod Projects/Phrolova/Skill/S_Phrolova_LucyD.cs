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
namespace Phrolova
{
	/// <summary>
	/// Wonderful U
	/// 造成<color=purple>12痛苦伤害</color>。
	/// 抽取 3 个技能。
	/// </summary>
    public class S_Phrolova_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].Damage(this.BChar, 12, false, true);
            BattleSystem.instance.AllyTeam.Draw(3);
        }
    }
}