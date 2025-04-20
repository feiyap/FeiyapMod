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
namespace Feiyap
{
	/// <summary>
	/// 施加持续2回合的保护体力极限。
	/// 指向队友的治疗技能
	/// </summary>
    public class SE_Feiyap_C_0:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsHeal && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_otherally);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            Targets[0].BuffAdd("B_Feiyap_0", this.BChar);
            Targets[0].BuffAdd("B_Feiyap_0", this.BChar);
        }
    }
}