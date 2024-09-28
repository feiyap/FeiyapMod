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
	/// 血咒「无差别咒杀降伏」
	/// 如果自身身上的增益效果种类不小于5个，额外造成&a(120%)伤害。
	/// 如果自身身上的增益效果种类不小于10个，打出时生成这个技能的复制。
	/// 打出后，使自身过载层数减少2层。
	/// </summary>
    public class S_HakureiReimu_F_4_5: S_HakureiReimu_F_4
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.Overload -= 2;
        }
    }
}