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
namespace Reisen
{
	/// <summary>
	/// 波符「赤眼催眠(Mind Shaker)」
	/// 幻象/狂气 - 必定暴击。
	/// </summary>
    public class S_Reisen_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
            {
                this.PlusSkillStat.cri = 999f;
            }
        }
    }
}