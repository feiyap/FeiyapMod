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
namespace RemiliaScarlet
{
	/// <summary>
	/// 爪击准备
	/// </summary>
    public class B_RemiliaScarlet_5:Buff
    {
        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.DMGTaken = -50f;
            this.PlusStat.RES_DOT = 300f;
            this.PlusStat.RES_CC = 300f;
            this.PlusStat.RES_DEBUFF = 300f;
            this.PlusStat.DeadImmune = 50;
        }
    }
}