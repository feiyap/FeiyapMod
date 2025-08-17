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
	/// 使所有倒计时中的「人形」倍率提升&a (攻击力的20%)或&b(治疗力的20%)或&c(防御力的20%)，或使叠加的减益增加 1 层。
	/// 费用 >= 2
	/// </summary>
    public class SE_FAlice_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill._AP >= 2;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc)
                .Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString())
                .Replace("&b", ((int)(this.BChar.GetStat.reg * 0.2f)).ToString())
                .Replace("&c", ((int)(this.BChar.GetStat.def * 0.2f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            foreach (CastingSkill castingSkill in SkillExtended_FAlice.AllDollsInCounting)
            {
                castingSkill.skill.ExtendedFind<SkillExtended_FAlice>()?.PlusPerNum(20, 20, 20, 1);
            }
        }
    }
}