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
	/// 你已无法离开我
	/// <color=#FF69B4><i>*兰斯洛特等级大于等于4且好感度达到30时自动学会*</i></color>
	/// </summary>
    public class S_FLancelot_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].BuffFind("B_FLancelot_2"))
            {
                if (this.BChar.BuffFind("B_FLancelot_P_3"))
                {
                    this.BChar.BuffAdd("B_FLancelot_P_3", this.BChar);
                    this.BChar.BuffAdd("B_FLancelot_P_3", this.BChar);
                    this.BChar.BuffAdd("B_FLancelot_P_3", this.BChar);
                }
                if (this.BChar.BuffFind("B_FLancelot_P_4"))
                {
                    this.BChar.BuffAdd("B_FLancelot_P_4", this.BChar);
                    this.BChar.BuffAdd("B_FLancelot_P_4", this.BChar);
                    this.BChar.BuffAdd("B_FLancelot_P_4", this.BChar);
                }
            }
        }
    }
}