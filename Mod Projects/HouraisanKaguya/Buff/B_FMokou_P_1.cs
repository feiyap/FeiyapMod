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
namespace HouraisanKaguya
{
	/// <summary>
	/// 「不朽的弹幕」
	/// 每次复活后，获得+20%最大体力，+20%攻击力，+10%命中率。
	/// </summary>
    public class B_FMokou_P_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.MaxHP = 20 * StackNum;
            this.PlusPerStat.Damage = 20 * StackNum;
            this.PlusStat.hit = 10 * StackNum;
        }
    }
}