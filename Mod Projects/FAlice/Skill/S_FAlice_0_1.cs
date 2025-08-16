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
	/// 额外消耗 1 点费用，使所有倒计时中的「人形」倍率提升&a (攻击力的25%)或&b(治疗力的40%)或&c(防御力的20%)。
	/// </summary>
    public class S_FAlice_0_1 : Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc)
                .Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString())
                .Replace("&b", ((int)(this.BChar.GetStat.reg * 0.2f)).ToString())
                .Replace("&c", ((int)(this.BChar.GetStat.def * 0.2f)).ToString());
        }

        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.AllyTeam.AP > (BattleSystem.instance.SelectedSkill?.AP ?? 0);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.AllyTeam.AP--;
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                castingSkill.skill.ExtendedFind<SkillExtended_FAlice>()?.PlusPerNum(20, 20, 20);
            }
        }
    }
}