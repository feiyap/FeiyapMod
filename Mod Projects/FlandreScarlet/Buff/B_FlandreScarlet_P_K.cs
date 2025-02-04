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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁忌狂乱
	/// 芙兰朵露受到来自自己或队友的伤害累计一定次数后，部分技能会获得额外效果。
	/// 当前触发次数为：&a
	/// </summary>
    public class B_FlandreScarlet_P_K:Buff
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_FlandreScarlet_K>().count).ToString());
        }
    }
}