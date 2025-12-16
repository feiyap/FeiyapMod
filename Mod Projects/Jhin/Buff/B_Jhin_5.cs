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
	/// 盛装登场
	/// 这个减益解除时，(444%<sprite=2>)眩晕。
	/// </summary>
    public class B_Jhin_5:Buff
    {
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();

            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, false, 444, false, -1, false);
        }
    }
}