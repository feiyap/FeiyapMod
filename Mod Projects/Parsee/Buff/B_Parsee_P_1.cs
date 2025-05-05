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
namespace Parsee
{
	/// <summary>
	/// 诅咒
	/// </summary>
    public class B_Parsee_P_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -10 * StackNum;
            this.PlusStat.RES_CC = -10 * StackNum;
            this.PlusStat.RES_DOT = -10 * StackNum;
            this.PlusStat.RES_DEBUFF = -10 * StackNum;
        }
    }
}