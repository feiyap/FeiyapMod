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
	/// 一伐枪
	/// </summary>
    public class B_HolySaber_9_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            this.PlusStat.def = 5;
        }
    }
}