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
namespace FAlice
{
	/// <summary>
	/// 选择 1 个「人形」技能，将其置入弃牌库。
	/// </summary>
    public class S_FAlice_8_0 : Skill_Extended
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
            }, ScriptLocalization.System_SkillSelect.WasteSkill);
        }
    }
}