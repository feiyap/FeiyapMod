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
namespace YasakaKanano
{
	/// <summary>
	/// 神符「神所踏足之御神渡」
	/// 无法指定露西技能和稀有技能。
	/// 生成目标技能的复制，直到手牌上限为止。使那些技能附带放逐。
	/// </summary>
    public class S_Kanano_Rare_3_3:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum3 == 0;
        }

        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill.Master.IsLucyNoC || ExceptSkill.MySkill.KeyID == "S_Kanano_Rare_3" || ExceptSkill.MySkill.Rare)
            {
                isLucyD = true;
            }
            return isLucyD;
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            for (int i = 0; i < 10 - BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                Skill skill = Targets[0].CloneSkill(true, null, null, false);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }

            BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum3++;
        }
    }
}