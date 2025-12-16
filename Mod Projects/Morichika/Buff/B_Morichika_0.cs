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
namespace Morichika
{
	/// <summary>
	/// 发现弱点
	/// </summary>
    public class B_Morichika_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -10 * StackNum;
            this.PlusStat.crihit = 25 * StackNum;
            this.PlusStat.CRIGetDMG = 25 * StackNum;
        }
    }
}