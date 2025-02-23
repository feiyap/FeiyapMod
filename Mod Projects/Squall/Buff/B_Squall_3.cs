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
namespace Squall
{
	/// <summary>
	/// 元素分割
	/// </summary>
    public class B_Squall_3:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = -this.Usestate_F.GetStat.def * 0.7f;
            this.PlusStat.def = -this.Usestate_F.GetStat.atk * 1.0f;
            this.PlusStat.dod = -20;
        }
    }
}