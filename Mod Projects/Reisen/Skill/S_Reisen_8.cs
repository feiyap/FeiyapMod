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
	/// 幻爆「近眼花火(Mind Star Mine)」
	/// </summary>
    public class S_Reisen_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Reisen_P") || this.BChar.BuffFind("B_Reisen_6", false))
            {
                this.BChar.BuffReturn("B_Reisen_P").SelfDestroy();
            }
        }
    }
}