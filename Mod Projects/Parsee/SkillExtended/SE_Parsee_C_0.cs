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
namespace Parsee
{
	/// <summary>
	/// 费用减少1点。释放时自身受到相当于最大体力值100%的痛苦伤害，等额增加技能伤害量。
	/// 单体攻击技能
	/// </summary>
    public class SE_Parsee_C_0:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.APChange = -1;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.Damage(this.BChar, this.BChar.GetStat.maxhp, false, true);
            this.SkillBasePlus.Target_BaseDMG = this.BChar.GetStat.maxhp;
        }
    }
}