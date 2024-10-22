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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 洩矢诹访子
	/// Passive:
	/// </summary>
    public class P_Suwako:Passive_Char
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
    }
}