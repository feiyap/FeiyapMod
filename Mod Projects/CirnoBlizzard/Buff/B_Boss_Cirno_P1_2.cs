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
namespace CirnoBlizzard
{
	/// <summary>
	/// 冻疮
	/// </summary>
    public class B_Boss_Cirno_P1_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = -25;
            this.PlusStat.def = 25;
            this.PlusStat.HEALTaken = 25;
        }
    }
}