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
namespace Squall
{
	/// <summary>
	/// 挑衅
	/// </summary>
    public class B_Sqaull_WeakTaunt:B_Taunt
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Weak = true;
        }
    }
}