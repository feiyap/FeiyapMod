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
namespace HiHouClab
{
    /// <summary>
    /// 重新装填
    /// </summary>
    public class B_Renko_P : Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.NotCount)
            {
                this.BChar.MyTeam.AP++;
                this.BChar.BuffAdd("B_Renko_P_1", this.BChar);
            }
            this.SelfDestroy();
        }
    }
}