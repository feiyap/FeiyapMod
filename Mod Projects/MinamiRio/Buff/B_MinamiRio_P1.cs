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
	/// <color=#48D1CC>单弓</color>
	/// 莉央在<color=#48D1CC>单弓</color>形态下手中的攻击技能获得无视嘲讽。
	/// 当前<color=#FA8072>穿甲</color>为：&a
	/// </summary>
    public class B_MinamiRio_P1:Buff
    {
        public override void Init()
        {
            this.PlusStat.IgnoreTaunt = true;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(BattleSystem.instance.GetBattleValue<BV_MinamiRio_P>().ArmorPiercing)).ToString());
        }
    }
}