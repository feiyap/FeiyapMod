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
namespace FAlice
{
	/// <summary>
	/// 白符「白垩的俄罗斯人形」
	/// </summary>
    public class B_FAlice_3_0 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 4 * StackNum;
            this.NoShowTimeNum_Tooltip = true;
        }
    }
}