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
namespace HatsuneMiku
{
	/// <summary>
	/// 恋は戦争
	/// 攻击力+25%。
	/// </summary>
    public class B_HatsuneMiku_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 15 * this.StackNum;
        }
    }
}