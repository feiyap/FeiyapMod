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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁弹「刻着过去的钟表」
	/// 造成&a(50%当前体力值)的痛苦伤害。
	/// </summary>
    public class S_FlandreScarlet_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.Damage(this.BChar, (int)Math.Ceiling(this.BChar.HP * 0.5f), false, true, false, 0, false, false, false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.HP * 0.5f)).ToString());
        }
    }
}