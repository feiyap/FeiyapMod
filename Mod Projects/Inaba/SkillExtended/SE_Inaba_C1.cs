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
	/// 从<color=#FFD700>帝的豪华奖池</color>中随机触发1个效果。
	/// <sprite name="비용2"><sprite name="이하">
	/// </summary>
    public class SE_Inaba_C1: SE_Inaba_Draw
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            InabaDraw();
        }

        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP >= 2;
        }
    }
}