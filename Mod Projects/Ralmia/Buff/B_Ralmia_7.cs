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
namespace Ralmia
{
	/// <summary>
	/// 创造术
	/// 回合结束时抽取一张技能。
	/// </summary>
    public class B_Ralmia_7:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            BattleSystem.instance.AllyTeam.Draw();
            base.SelfDestroy(false);
        }
    }
}