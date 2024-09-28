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
	/// 幸福祈愿
	/// </summary>
    public class B_HakureiReimu_F_LucyD_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 10;
            this.PlusStat.cri = 10;
        }
    }
}