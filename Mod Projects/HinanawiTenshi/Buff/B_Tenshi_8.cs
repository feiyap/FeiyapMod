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
	/// 气焰万丈
	/// </summary>
    public class B_Tenshi_8:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 25;
            this.PlusStat.Penetration = 100;
            this.PlusStat.hit = 600;
        }
    }
}