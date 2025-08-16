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
using BasicMethods;

namespace FAlice
{
	/// <summary>
	/// 使所有倒计时中的「人形」触发一次效果。
	/// </summary>
    public class S_FAlice_0_0 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                castingSkill.skill.ExtendedFind<SkillExtended_FAlice>()?.TriggerEffect(false);
            }
        }
    }
}