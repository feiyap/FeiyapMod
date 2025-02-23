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
	/// 攻击力降低
	/// </summary>
    public class B_Squall_LucyD:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = -2;
        }
    }
}