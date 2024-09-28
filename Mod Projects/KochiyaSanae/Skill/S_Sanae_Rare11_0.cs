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
namespace KochiyaSanae
{
	/// <summary>
	/// 奇迹「奇迹五角星」
	/// 使目标技能获得迅速、无视嘲讽、致命。
	/// 如果目标技能的持有者为自己，使其额外造成&a(100%)伤害或&b(100%)治疗。
	/// </summary>
    public class S_Sanae_Rare11_0:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].ExtendedAdd("SE_Sanae_Rare11_0");
            if (Targets[0].Master == this.BChar)
            {
                Targets[0].ExtendedAdd("SE_Sanae_Rare11_0_0");
            }
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

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)this.BChar.GetStat.atk).ToString()).Replace("&b", ((int)this.BChar.GetStat.reg).ToString());
        }
    }
}