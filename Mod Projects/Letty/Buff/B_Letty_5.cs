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
namespace Letty
{
	/// <summary>
	/// 雪灾
	/// </summary>
    public class B_Letty_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_CC = -40 * StackNum;
            this.PlusStat.RES_DEBUFF = -40 * StackNum;
        }
    }
}