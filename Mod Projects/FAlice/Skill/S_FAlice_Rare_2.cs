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
	/// 枪符「萌萌大千枪」
	/// 使所有「人形」技能立即触发 3 次、强化触发 1 次。
	/// 那之后，将所有倒计时中的「人形」技能置入弃牌库。
	/// </summary>
    public class S_FAlice_Rare_2 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<SkillExtended_FAlice> dolls = new List<SkillExtended_FAlice>();
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                SkillExtended_FAlice se = castingSkill.skill.ExtendedFind<SkillExtended_FAlice>();
                if (se != null) dolls.Add(se);
            }
            foreach (SkillExtended_FAlice doll in dolls)
            {
                doll.TriggerEffect(false);
                doll.TriggerEffect(false);
                doll.TriggerEffect(false);
                doll.TriggerEffect(true);
                doll.CastingWaste();
            }
        }
    }
}