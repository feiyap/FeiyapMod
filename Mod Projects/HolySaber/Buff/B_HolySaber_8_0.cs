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
namespace HolySaber
{
	/// <summary>
	/// 守护神威
	/// </summary>
    public class B_HolySaber_8_0:Buff
    {
        public override void Init()
        {
            this.PlusStat.HIT_CC = 30;
            this.PlusStat.Strength = true;
        }
    }
}