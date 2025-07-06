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
namespace FairyLancelot
{
	/// <summary>
	/// 龙之心
	/// 持有“舞者”时无法获得。
	/// </summary>
    public class B_FLancelot_P_3:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = StackNum;
        }
    }
}