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
namespace FairyLancelot
{
	/// <summary>
	/// 每回合抽牌
	/// </summary>
    public class B_FLancelot_LucyD_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusDraw = 2;
        }
    }
}