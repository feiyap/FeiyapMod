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
namespace HouraisanKaguya
{
	/// <summary>
	/// 「蓬莱人形」
	/// </summary>
    public class B_FMokou_Stage_1:Buff, IP_Hit
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            bool flag = Dmg > 0;
            if (flag)
            {
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}