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
namespace szb_elena
{
	/// <summary>
	/// 七宝石公主
	/// 回合结束时，恢复&a(40%)体力。
	/// </summary>
    public class B_szb_elena_R3: Buff,IP_TurnEnd
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.Usestate_L.GetStat.maxhp * 0.25f)).ToString());
        }
        public void TurnEnd()
        {
           
               this.BChar.Heal(this.BChar, (float)(this.Usestate_L.GetStat.maxhp * 0.25f), false, false, null);

        }
    }
}