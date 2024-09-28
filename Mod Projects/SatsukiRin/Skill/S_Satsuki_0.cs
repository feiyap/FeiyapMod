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
namespace SatsukiRin
{
	/// <summary>
	/// 风符「新生之风」
	/// </summary>
    public class S_Satsuki_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.SelfBuff = null;
            //this.BChar.BuffAdd("B_Satsuki_0", this.BChar, false, 0, false, -1, false);
            //this.BChar.BuffAdd("B_Satsuki_0", BattleSystem.instance.DummyChar, false, 0, false, -1, false);
        }
    }
}