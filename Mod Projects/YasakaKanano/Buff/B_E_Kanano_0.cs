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
	/// 守矢之西风
	/// </summary>
    public class B_E_Kanano_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 5 * StackNum;
        }
    }
}