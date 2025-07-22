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
	/// 群体回血
	/// </summary>
    public class B_FLancelot_0_2:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                bc.Heal(this.BChar, 8, false, false, null);
            }
            this.SelfDestroy();
        }
    }
}