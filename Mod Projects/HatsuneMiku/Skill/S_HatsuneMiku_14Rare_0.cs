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
	/// *ワールドイズマイン
	/// </summary>
    public class S_HatsuneMiku_14Rare_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum * (int)(this.BChar.GetStat.reg * 0.1f);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum * (int)(this.BChar.GetStat.reg * 0.1f);
        }
    }
}