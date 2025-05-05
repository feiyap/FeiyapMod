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
namespace Parsee
{
	/// <summary>
	/// 桥姬的裙带菜
	/// 解除时优先抽取自身1个技能。
	/// </summary>
    public class B_Parsee_2_0:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            this.SelfDestroy();
        }
    }
}