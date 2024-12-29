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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 凪
	/// 回合结束时，治疗10点体力。
	/// </summary>
    public class B_Tenki_16:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            this.BChar.Heal(this.BChar, 10, false, false, null);
        }
    }
}