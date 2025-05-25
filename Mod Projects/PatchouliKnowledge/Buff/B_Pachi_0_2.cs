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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 百毒不侵
	/// </summary>
    public class B_Pachi_0_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.crihit = -10 * StackNum;
            this.PlusStat.RES_DOT = 10 * StackNum;
        }
    }
}