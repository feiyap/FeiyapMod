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
namespace Suwako
{
	/// <summary>
	/// 蛙休
	/// </summary>
    public class B_Suwako_Rare2:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            BattleSystem.instance.AllyTeam.Draw(this.StackNum);
            this.SelfDestroy();
        }
    }
}