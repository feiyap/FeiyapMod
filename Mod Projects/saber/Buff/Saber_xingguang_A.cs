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
	/// 星光
	/// <color=#808080>她是星的宠儿
	/// </summary>
    public class Saber_xingguang_A:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = -5f * base.StackNum;
            this.PlusStat.HEALTaken = 5f * base.StackNum;
            this.PlusStat.RES_CC = 5f * base.StackNum;
            this.PlusStat.RES_DOT = 5f * base.StackNum;
            this.PlusStat.RES_DEBUFF = 5f * base.StackNum;
        }
    }
}