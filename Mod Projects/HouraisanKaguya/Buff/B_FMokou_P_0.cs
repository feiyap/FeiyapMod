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
namespace HouraisanKaguya
{
	/// <summary>
	/// 「不死鸟重生」
	/// 妹红死亡时，有概率获得战斗胜利；
	/// 否则妹红复活并恢复所有体力值，那之后，概率翻倍。
	/// 当前概率为：&a
	/// </summary>
    public class B_FMokou_P_0:Buff
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)Math.Pow(2, this.StackNum - 1)).ToString());
        }
    }
}