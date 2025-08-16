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
	/// 操符「操纵人形」
	/// 选择：
	/// - 使所有倒计时中的「人形」触发一次效果。
	/// - 额外消耗 1 点费用，使所有倒计时中的「人形」倍率提升&a (攻击力的25%)或&b(治疗力的40%)或&c(防御力的20%)。
	/// - 选择 1 个倒计时中的「人形」，将其置入弃牌库，并抽取 1 个技能、恢复 2 点法力值。
	/// - 在手中随机生成 1 个「人形」。
	/// </summary>
    public class S_FAlice_0 : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_0_0);
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_0_1);
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_0_2);
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_0_3);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc)
                .Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString())
                .Replace("&b", ((int)(this.BChar.GetStat.reg * 0.2f)).ToString())
                .Replace("&c", ((int)(this.BChar.GetStat.def * 0.2f)).ToString());
        }
    }
}