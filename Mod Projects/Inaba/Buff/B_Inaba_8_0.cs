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
	/// 因幡/兔怒
	/// </summary>
    public class B_Inaba_8_0:Buff
    {
        public override void Init()
        {
            this.PlusStat.def = -4 * StackNum;
            this.PlusStat.dod = -4 * StackNum;
        }

        public override void BuffStat()
        {
            this.PlusStat.def = -4 * StackNum;
            this.PlusStat.dod = -4 * StackNum;
        }
    }
}