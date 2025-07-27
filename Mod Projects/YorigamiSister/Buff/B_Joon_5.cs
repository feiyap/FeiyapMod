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
namespace YorigamiSister
{
	/// <summary>
	/// 朱莉安娜羽扇回旋镖
	/// </summary>
    public class B_Joon_5:Buff, IP_DamageCriCheck, IP_TurnEnd
    {
        public void DamageCriCheck(BattleChar Hit, BattleChar User, int Dmg, ref bool Cri, bool Pain, bool NOEFFECT = false)
        {
            if (User == this.Usestate_F)
            {
                Cri = true;
            }
        }

        public void TurnEnd()
        {
            this.SelfDestroy();
        }
    }
}