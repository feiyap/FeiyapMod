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
namespace HolySaber
{
	/// <summary>
	/// 虹蛇
	/// 打出带有<color=#4876FF>守护</color>减益的技能时，获得1点进化点。
	/// </summary>
    public class B_HolySaber_1:Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.ExtendedFind_DataName("SE_HolySaber_Defend") != null)
            {
                this.BChar.BuffAdd("B_HolySaber_P", this.BChar);
            }
        }
    }
}