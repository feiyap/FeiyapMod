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
namespace HatsuneMiku
{
	/// <summary>
	/// メルト
	/// 赋予%a层[未来之音]。
	/// </summary>
    public class S_HatsuneMiku_11Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.TargetBuff = null;

            for (int i = 0; i < (int)(this.BChar.GetStat.reg * 1.0f); i++)
            {
                Targets[0].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 1.0f)).ToString());
        }
    }
}