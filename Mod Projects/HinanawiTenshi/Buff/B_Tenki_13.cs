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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 川雾
	/// 使手中的技能获得“无视嘲讽”。
	/// </summary>
    public class B_Tenki_13:Buff
    {
        public override void Init()
        {
            this.PlusStat.IgnoreTaunt = true;
            base.Init();
        }
    }
}