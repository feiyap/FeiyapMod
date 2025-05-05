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
namespace Parsee
{
	/// <summary>
	/// 开花爷爷「小白的灰烬」
	/// 每有 1 层妒火，额外恢复 &a 点体力值[10%治疗力]。
	/// </summary>
    public class S_Parsee_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.BuffReturn("B_Parsee_P")?.StackNum ?? 0 * 0.1 * this.BChar.GetStat.reg);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (0.1 * this.BChar.GetStat.reg).ToString());
        }
    }
}