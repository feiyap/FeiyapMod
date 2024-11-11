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
	/// 神秘的创造物
	/// 创造物。
	/// 打出后抽1张技能。
	/// </summary>
    public class S_Ralmia_2: SkillEn_Ralmia_0
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.AllyTeam.Draw();
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1f)).ToString());
        }
    }
}