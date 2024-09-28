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
	/// <color=#A0AC8F>风蚀</color>
	/// 正在遭受风压的侵蚀！
	/// </summary>
    public class Saber_fengshi:Buff
    {
         public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = (int)(float)(4f * base.StackNum);
        }
    }
}