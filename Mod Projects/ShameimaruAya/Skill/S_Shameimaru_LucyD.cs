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
	/// 取材「射命丸文的暴力取材」
	/// 抽取2个技能。使目标技能费用降低1点。
	/// 这个技能也能因射命丸文的被动[风神少女]影响而获得迅速。
	/// </summary>
    public class S_Shameimaru_LucyD:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].APChange--;
        }

        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill == this.MySkill)
            {
                isLucyD = true;
            }
            return isLucyD;
        }
    }
}