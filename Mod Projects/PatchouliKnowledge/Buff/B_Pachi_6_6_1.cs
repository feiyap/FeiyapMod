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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 月之暗面
	/// 按下回合结束按钮时，获得“月之面纱”。
	/// </summary>
    public class B_Pachi_6_6_1:Buff, IP_TurnEndButtonEnemy
    {
        public void TurnEndButtonEnemy()
        {
            this.BChar.BuffAdd("B_Pachi_6_6", this.Usestate_F);
        }
    }
}