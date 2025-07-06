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
	/// 邪龙
	/// 特殊形态。
	/// 每次使用自身技能时，获得 1 层“龙之心”。
	/// </summary>
    public class B_FLancelot_C_1:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 1;
            this.PlusStat.Penetration = 10;
            this.OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.BChar.BuffAdd("B_FLancelot_P_3", this.BChar);
            }
        }
    }
}