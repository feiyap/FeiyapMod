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
namespace MinamiRio
{
	/// <summary>
	/// <color=#54FF9F>风伤</color>
	/// </summary>
    public class B_MinamiRio_4:Buff
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = -10;
            this.PlusStat.hit = -10;
            this.PlusStat.DMGTaken = 10;
        }
    }
}