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
namespace FlandreScarlet
{
	/// <summary>
	/// 易损
	/// </summary>
    public class B_FlandreScarlet_0:Buff
    {
        public override void BuffStat()
        {
            this.PlusStat.crihit = 5 * base.StackNum;
            base.BuffStat();
        }
    }
}