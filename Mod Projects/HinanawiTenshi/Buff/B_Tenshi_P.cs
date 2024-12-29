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
	/// 天人之体
	/// 当前拥有的<color=#97FFFF>气质</color>：&a
	/// </summary>
    public class B_Tenshi_P:Buff
    {
        public override string DescExtended()
        {
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
            }
            return base.DescExtended().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi).ToString());
        }
    }
}