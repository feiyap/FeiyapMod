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
	/// 锋锐的创造物
	/// 恢复自己等量于伤害值的血量。
	/// </summary>
    public class S_Ralmia_9_2: SkillEn_Ralmia_0
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.BChar.Heal(this.BChar, (float)((int)((double)this.BChar.GetStat.atk * 1.5)), false, true, null);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.5f)).ToString());
        }
    }
}