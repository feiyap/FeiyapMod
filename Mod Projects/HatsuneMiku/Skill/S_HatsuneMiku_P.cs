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
namespace HatsuneMiku
{
	/// <summary>
	/// 大葱
	/// 抽取1个技能。
	/// 赋予1层[未来之音]。
	/// 音弦1：额外赋予1层[未来之音]。
	/// </summary>
    public class S_HatsuneMiku_P:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.AllyTeam.Draw();

            if (Targets[0].BuffFind("B_HatsuneMiku_P", false) && Targets[0].BuffReturn("B_HatsuneMiku_P", false).StackNum >= 1)
            {
                Targets[0].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}