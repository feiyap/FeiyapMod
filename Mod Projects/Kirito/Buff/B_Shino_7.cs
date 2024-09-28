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
namespace Kirito
{
	/// <summary>
	/// 影光G4
	/// </summary>
    public class B_Shino_7:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Penetration = 50f;
        }
    }
}