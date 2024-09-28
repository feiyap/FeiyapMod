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
namespace SatsukiRin
{
	/// <summary>
	/// 丰年瑞雪
	/// 持续时间内，受到的治疗效果增强25%。
	/// </summary>
    public class B_Satsuki_7:Buff
    {
        public override void Init()
        {
            base.Init();

            this.PlusStat.HEALTaken = 25;
        }
    }
}