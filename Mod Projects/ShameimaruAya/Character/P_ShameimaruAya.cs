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
namespace ShameimaruAya
{
	/// <summary>
	/// 射命丸文
	/// Passive:
	/// </summary>
    public class P_ShameimaruAya:Passive_Char,IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.count = 0;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            this.BChar.BuffAdd("B_Shameimaru_P", this.BChar);

            if (skill.Master == this.BChar)
            {
                count++;
                if (count >= 3)
                {
                    this.BChar.BuffAdd("B_Shameimaru_P_0", this.BChar);
                    count = 0;
                }
            }
        }
    }
}