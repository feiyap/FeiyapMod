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
	/// 狂灵「你知道今夜的月球为何是红色的吗？」
	/// <color=#FFD700>*「梦想天生」+「幻胧月睨」*</color>
	/// 造成&a（敌人的攻击力*300%）的伤害。
	/// 这个技能无视防御，必定命中。
	/// </summary>
    public class S_Musoutensei_Reisen: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.SkillBasePlus.Target_BaseDMG = (int)(Targets[0].GetStat.atk * 3f);
            this.PlusStat.Penetration = 100;
        }
    }
}