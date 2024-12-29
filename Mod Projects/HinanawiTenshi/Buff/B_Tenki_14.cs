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
	/// 天气 - 台风
	/// </summary>
    public class B_Tenki_14:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 30;
            this.PlusStat.DMGTaken = 50;
        }
    }
}