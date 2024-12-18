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
namespace YasakaKanano
{
	/// <summary>
	/// 丰收之西风
	/// 御柱的效果提升1/2/3/4级。
	/// </summary>
    public class B_Kanano_4:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = (float)2.5 * this.StackNum;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (this.StackNum).ToString());
        }
    }
}