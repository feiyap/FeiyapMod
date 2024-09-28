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
namespace FlandreScarlet
{
	/// <summary>
	/// 笼中鸟
	/// </summary>
    public class B_FlandreScarlet_8:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 20;
            this.PlusStat.PlusCriDmg = 40f;
            this.PlusStat.spd = -1;
        }
    }
}