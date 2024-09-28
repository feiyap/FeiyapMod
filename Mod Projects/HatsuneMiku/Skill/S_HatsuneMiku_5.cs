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
	/// 恋は戦争
	/// 施加2层[未来之音]。施加1层[恋は戦争]。
	/// 音弦2：额外施加1层[恋は戦争]。
	/// </summary>
    public class S_HatsuneMiku_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.TargetBuff = null;

            Targets[0].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            Targets[0].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            Targets[0].BuffAdd("B_HatsuneMiku_5", this.BChar, false, 0, false, -1, false);

            if (Targets[0].BuffFind("B_HatsuneMiku_P", false) && Targets[0].BuffReturn("B_HatsuneMiku_P", false).StackNum >= 2)
            {
                Targets[0].BuffAdd("B_HatsuneMiku_5", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}