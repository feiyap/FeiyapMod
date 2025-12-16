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
namespace Jhin
{
	/// <summary>
	/// 施加“暴击率提升44%”，持续 1 回合。
	/// 指向单体的治疗技能
	/// </summary>
    public class SE_Jhin_C_2:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsHeal && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_self
                || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_otherally);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].BuffAdd("B_Jhin_C_2", this.BChar);
        }
    }
}