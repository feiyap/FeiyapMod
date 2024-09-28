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
namespace KochiyaSanae
{
	/// <summary>
	/// 奇迹于你
	/// </summary>
    public class B_Sanae_2:Buff
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = 12;
            this.PlusPerStat.Heal = 12;
        }
    }
}