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
namespace Inaba
{
	/// <summary>
	/// 因幡/遮眼
	/// </summary>
    public class B_Inaba_1:Buff
    {
        public override void Init()
        {
            this.PlusStat.HIT_DEBUFF = -30;
            this.PlusStat.HIT_DOT = -30;
        }
    }
}