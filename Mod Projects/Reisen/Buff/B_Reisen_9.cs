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
namespace Reisen
{
	/// <summary>
	/// 幻象/胧月
	/// </summary>
    public class B_Reisen_9:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 25;
        }
    }
}