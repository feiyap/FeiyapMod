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
namespace Eirin
{
	/// <summary>
	/// 月人/操神
	/// </summary>
    public class B_Eirin_3:Buff
    {
        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.DMGTaken = -15f;
        }
    }
}