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
namespace FFAce
{
	/// <summary>
	/// 计数器
	/// </summary>
    public class B_FFAce_4_Count:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            SelfDestroy();
        }
    }
}