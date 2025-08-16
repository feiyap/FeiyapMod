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
using Spine;

namespace FAlice
{
	/// <summary>
	/// 选择 1 个倒计时中的「人形」，将其置入弃牌库，并抽取 1 个技能、恢复 2 点法力值。
	/// </summary>
    public class S_FAlice_0_2 : Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.CastSkills.Any(cs => cs.skill.ExtendedFind<SkillExtended_FAlice>() != null);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            SkillExtended_FAlice.ChooseDollAndEffect((doll) =>
            {
                doll.CastingWaste();
                BattleSystem.instance.AllyTeam.Draw(1);
                BattleSystem.instance.AllyTeam.AP += 2;
            }, ScriptLocalization.System_SkillSelect.WasteSkill);
        }
    }
}