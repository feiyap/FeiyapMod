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
namespace KirisameMarisa
{
	/// <summary>
	/// 危险冲刺
	/// 每个回合开始时，获得2次等待次数。
	/// </summary>
    public class B_KirisameMarisa_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.HIT_CC = 25;
            this.PlusStat.HIT_DEBUFF = 25;
            this.PlusStat.HIT_DOT = 25;
        }
    }
}