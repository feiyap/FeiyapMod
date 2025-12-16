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
namespace Jhin
{
	/// <summary>
	/// 完美
	/// 动静有时，大音希声。
	/// </summary>
    public class B_Jhin_P_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = (int)(14 + (this.BChar.GetStat.hit - 100) * 0.44);
        }
    }
}