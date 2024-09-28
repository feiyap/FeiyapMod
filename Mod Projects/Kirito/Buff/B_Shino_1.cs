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
namespace Kirito
{
	/// <summary>
	/// 锁定
	/// </summary>
    public class B_Shino_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.CRIGetDMG = 10;
            this.PlusStat.crihit = 10;
        }
    }
}