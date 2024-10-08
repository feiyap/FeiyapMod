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
	/// 防御降临
	/// </summary>
    public class B_HolySaber_Rare_10_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = -100;
        }
    }
}