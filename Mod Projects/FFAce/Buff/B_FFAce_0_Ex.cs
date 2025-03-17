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
	/// 深度灼伤
	/// </summary>
    public class B_FFAce_0_Ex:Buff
    {
        public override void FixedUpdate()
        {
            this.PlusDamageTick = (this.BChar.BuffReturn("B_FFAce_1")?.StackNum ?? 0) * 25 / 100 * (int)((base.BuffData.Tick.DMG_Per * base.Usestate_L.GetStat.atk / 100) + base.BuffData.Tick.DMG_Base);
        }
    }
}