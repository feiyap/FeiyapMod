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
namespace SatsukiRin
{
	/// <summary>
	/// 幻想天生
	/// </summary>
    public class B_Satsuki_11Rare:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 20;
            this.PlusStat.def = 20;
            this.PlusStat.hit = 20;
            this.PlusStat.dod = 20;
            this.PlusStat.cri = 20;
        }
    }
}