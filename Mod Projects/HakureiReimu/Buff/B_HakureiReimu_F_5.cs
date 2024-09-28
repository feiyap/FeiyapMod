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
namespace HakureiReimu
{
	/// <summary>
	/// 封魔阵
	/// </summary>
    public class B_HakureiReimu_F_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = -5 * StackNum;
            this.PlusStat.def = -5 * StackNum;
            this.PlusStat.hit = -5 * StackNum;
        }
    }
}