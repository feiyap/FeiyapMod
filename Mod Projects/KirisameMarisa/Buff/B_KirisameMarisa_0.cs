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
namespace KirisameMarisa
{
	/// <summary>
	/// 危险激荡
	/// </summary>
    public class B_KirisameMarisa_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.spd = 1 * StackNum;
            this.PlusStat.dod = 10 * StackNum;
            this.PlusStat.DMGTaken = 15 * StackNum;
        }
    }
}