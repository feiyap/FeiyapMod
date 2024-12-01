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
	/// 危险扳机
	/// <color=#00BFFF>危险等级</color>上限+1。
	/// </summary>
    public class B_KirisameMarisa_DangerTrigger:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 3;
            this.PlusStat.def = -15;
        }
    }
}