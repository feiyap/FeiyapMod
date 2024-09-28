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
	/// 使目标受到的追加攻击伤害+100%，持续1回合。
	/// <sprite name="비용1"><sprite name="이하">
	/// </summary>
    public class SE_Inaba_C2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].BuffAdd("B_Inaba_SE_C2", this.BChar);
        }

        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP <= 1;
        }
    }
}