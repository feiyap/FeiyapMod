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
	/// 国士无双？
	/// </summary>
    public class B_Inaba_Rare11:Buff
    {
        public override void Init()
        {
            this.PlusStat.atk = 2;
            this.PlusStat.def = 5;
        }
    }
}