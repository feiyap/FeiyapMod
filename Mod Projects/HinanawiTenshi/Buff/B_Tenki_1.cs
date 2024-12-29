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
	/// 天气 - 快晴
	/// </summary>
    public class B_Tenki_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 10;
        }
    }
}