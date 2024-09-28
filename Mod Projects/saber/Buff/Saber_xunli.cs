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
namespace saber
{
	/// <summary>
	///  <color=#F0BCAF>孤独な巡礼</color>
	/// </summary>
    public class Saber_xunli:Buff,IP_PlayerTurn
    {
        public void Turn()
        {
            this.BChar.BuffAdd(ModItemKeys.Buff_Saber_moli, this.BChar, false, 0, false, -1, false);
        }
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = (int)(float)(-30 * base.StackNum);
            this.PlusPerStat.MaxHP  = (int)(float)(40 * base.StackNum);
            this.PlusStat.def = (int)(35);
            this.PlusStat.Strength = true;
        }
    }
}