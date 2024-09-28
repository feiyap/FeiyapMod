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
namespace Sunmeitian
{
	/// <summary>
	/// 取经之路
	/// </summary>
    public class B_Sunmeitian_7:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 1 * StackNum;
            this.PlusStat.def = 2 * StackNum;
        }
    }
}