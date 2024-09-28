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
	/// 「这不知是第几次的生命，燃烧殆尽吧」
	/// </summary>
    public class B_FMokou_Stage_3:Buff, IP_TurnEndButtonEnemy
    {
        public void TurnEndButtonEnemy()
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}