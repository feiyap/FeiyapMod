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
namespace VillageAlice
{
	/// <summary>
	/// 失重
	/// </summary>
    public class B_FVAlice_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = -42;
            this.PlusStat.hit = -42;
        }
    }
}