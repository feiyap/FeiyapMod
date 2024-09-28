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
	/// 太陽系デスコ
	/// 赋予5层[未来之音]。
	/// 赋予1层[太陽系デスコ]。
	/// </summary>
    public class S_HatsuneMiku_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < Targets.Count; i++)
            {
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_7", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}