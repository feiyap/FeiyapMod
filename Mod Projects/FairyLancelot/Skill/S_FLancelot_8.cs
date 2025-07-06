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
	/// 苍穹的试炼
	/// </summary>
    public class S_FLancelot_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                Targets[0].BuffAdd("B_FLancelot_8", this.BChar);
            }
            if (this.BChar.BuffFind("B_FLancelot_C_1"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.4);
            }
            if (this.BChar.BuffFind("B_FLancelot_P_2"))
            {
                this.BChar.BuffAdd("B_FLancelot_8_0", this.BChar);
            }
            if (this.BChar.BuffFind("B_FLancelot_P_1"))
            {
                this.PlusSkillStat.cri = 999f;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString());
        }
    }
}