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
	/// 若目标持有痛苦减益，恢复 1 点法力值。
	/// 指向敌人的攻击技能
	/// </summary>
    public class SE_Feiyap_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count != 0)
            {
                this.BChar.MyTeam.AP += 1;
            }
        }
    }
}