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
namespace FairyLancelot
{
	/// <summary>
	/// 妖精剑舞
	/// </summary>
    public class S_FLancelot_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                this.BChar.BuffAdd("B_FLancelot_P_4", this.BChar);
            }
            if (this.BChar.BuffFind("B_FLancelot_C_1"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.7);
                this.BChar.BuffAdd("B_FLancelot_P_3", this.BChar);
            }
            if (P_FairyLancelot.heartPoint >= 30)
            {
                this.BChar.BuffAdd("B_FLancelot_1", this.BChar);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.7f)).ToString());
        }
    }
}