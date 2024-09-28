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
	/// 灵力狂涌
	/// 下个回合开始时，优先抽取1张自己的技能；触发后移除。
	/// </summary>
    public class B_HakureiReimu_F_0_2:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            this.SelfDestroy();
        }
    }
}