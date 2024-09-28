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
namespace HakureiReimu
{
	/// <summary>
	/// 灵符「蹂躏阴阳玉」
	/// 根据命中敌人的数量，额外施加等量层数的[灵力激荡]。
	/// 如果仅有1个目标，那么额外造成&a(50%)伤害。
	/// </summary>
    public class S_HakureiReimu_F_3_2: S_HakureiReimu_F_3
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets.Count == 1)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.5f);
                this.BChar.BuffAdd("B_HakureiReimu_F_3", this.BChar);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}