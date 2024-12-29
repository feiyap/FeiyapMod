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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 烈日
	/// </summary>
    public class B_Tenki_19:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.HIT_CC = 50;
            this.PlusStat.HIT_DEBUFF = 50;
            this.PlusStat.HIT_DOT = 50;
        }
    }
}