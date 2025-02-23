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
namespace Squall
{
	/// <summary>
	/// 狮子奋起
	/// 回合开始时，额外获得一层[刃甲]。
	/// </summary>
    public class B_Squall_1:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            this.BChar.BuffAdd("B_Squall_P", this.BChar);
        }
    }
}