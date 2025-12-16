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
namespace Jhin
{
	/// <summary>
	/// 终章
	/// 第 4 个技能总是会产生暴击，并造成相当于目标已损失生命值的44%的额外伤害。
	/// </summary>
    public class B_Jhin_P_0:Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.SelfDestroy();
            }
        }
    }
}