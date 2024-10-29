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
namespace MinamiRio
{
	/// <summary>
	/// <color=#FFD700>和弓</color>
	/// 当前<color=#FA8072>穿甲</color>：&a<color=#FFD700></color>
	/// </summary>
    public class B_MinamiRio_P2:Buff
    {
        public override void Init()
        {
            this.PlusStat.hit = 20;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(BattleSystem.instance.GetBattleValue<BV_MinamiRio_P>().ArmorPiercing)).ToString());
        }
    }
}