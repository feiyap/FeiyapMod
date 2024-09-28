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
	/// 我还能更快
	/// </summary>
    public class B_Kirito_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusMPUse = -base.StackNum;
        }

        public override void BuffStat()
        {
            base.BuffStat();
        }
    }
}