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
namespace ShameimaruAya
{
	/// <summary>
	/// 抓拍「Fast Shot」
	/// 使目标技能变为0费，且附带迅速。额外消耗那个技能原本费用的法力值。（无法指定露西技能）
	/// </summary>
    public class S_Shameimaru_8:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].ExtendedAdd("SE_Shameimaru_8");

            BattleSystem.instance.AllyTeam.AP -= Targets[0]._AP;
        }

        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill.Master.IsLucyNoC || ExceptSkill == this.MySkill)
            {
                isLucyD = true;
            }
            return isLucyD;
        }
    }
}