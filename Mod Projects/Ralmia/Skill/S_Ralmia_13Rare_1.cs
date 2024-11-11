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
namespace Ralmia
{
	/// <summary>
	/// 守卫的创造物
	/// 免疫受伤1次。恢复1倍攻击力血量。
	/// </summary>
    public class S_Ralmia_13Rare_1: SkillEn_Ralmia_0
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].BuffAdd("B_Ralmia_13Rare_1_0", this.BChar, false, 0, false, -1, false);
            Targets[0].Heal(this.BChar, (float)((int)((double)this.BChar.GetStat.atk * 1)), false, true, null);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1f)).ToString());
        }
    }
}