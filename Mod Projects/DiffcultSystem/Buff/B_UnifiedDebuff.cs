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
namespace DiffcultSystem
{
	/// <summary>
	/// 同舟共济
	/// </summary>
    public class B_UnifiedDebuff:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.AggroPer = 77;
        }
    }
}