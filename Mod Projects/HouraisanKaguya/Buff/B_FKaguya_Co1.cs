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
namespace HouraisanKaguya
{
	/// <summary>
	/// 永远/亭下
	/// </summary>
    public class B_FKaguya_Co1:Buff
    {
        public override void Init()
        {
            this.PlusStat.hit = -100;
        }

        public override void BuffStat()
        {
            this.PlusStat.hit = -100;
            base.BuffStat();
        }
    }
}