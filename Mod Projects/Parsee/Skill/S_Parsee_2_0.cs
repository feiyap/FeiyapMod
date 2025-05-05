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
	/// 宇治桥姬入我心
	/// 帕露西熄灭2层妒火。
	/// </summary>
    public class S_Parsee_2_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffReturn("B_Parsee_P", this.BChar)?.SelfStackDestroy();
            this.BChar.BuffReturn("B_Parsee_P", this.BChar)?.SelfStackDestroy();
        }
    }
}