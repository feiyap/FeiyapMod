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
namespace ShameimaruAya
{
	/// <summary>
	/// 风靡的幻想
	/// </summary>
    public class B_Shameimaru_Rare10_0:Buff
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = 25;
            this.PlusPerStat.Heal = 25;
        }
    }
}