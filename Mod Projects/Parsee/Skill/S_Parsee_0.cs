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
	/// 他人的不幸甜如蜜
	/// 点燃2层妒火。
	/// </summary>
    public class S_Parsee_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.BuffAdd("B_Parsee_P", this.BChar);
            this.BChar.BuffAdd("B_Parsee_P", this.BChar);
        }
    }
}