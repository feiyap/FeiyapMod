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
namespace HakureiReimu
{
	/// <summary>
	/// 繁盛祈愿
	/// 下个回合开始时，优先抽取1个自己的技能。
	/// </summary>
    public class B_HakureiReimu_F_LucyD_0:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            this.SelfDestroy();
        }
    }
}