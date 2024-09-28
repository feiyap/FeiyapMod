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
namespace Inaba
{
	/// <summary>
	/// 兔符「因幡的白兔」
	/// 从<color=#FFD700>帝的豪华奖池</color>中随机触发1个效果。
	/// </summary>
    public class S_Inaba_2: SE_Inaba_Draw
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            InabaDraw();
        }
    }
}