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
namespace Lumiore
{
	/// <summary>
	/// 龙之启示
	/// </summary>
    public class B_Lumiore_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.MPR = base.StackNum;
        }
    }
}