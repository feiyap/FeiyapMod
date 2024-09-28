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
namespace saber
{
	/// <summary>
	/// 星蚀
	/// <color=#808080>直视闪耀的星光，必会付出代价。</color>
	/// </summary>
    public class Saber_xingguang_B:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 5f * base.StackNum;
            this.PlusStat.HEALTaken = -5f * base.StackNum;
            this.PlusStat.HIT_CC = -5f * base.StackNum;
            this.PlusStat.HIT_DOT = -5f * base.StackNum;
            this.PlusStat.HIT_DEBUFF = -5f * base.StackNum;
        }
    }
}