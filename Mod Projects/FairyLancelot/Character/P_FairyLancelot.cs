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
namespace FairyLancelot
{
	/// <summary>
	/// 兰斯洛特
	/// Passive:
	/// 进入战斗回合开始时根据当前生命值变化状态。
	/// 每当体力值小于等于最大体力值50%时，获得“狂化”；
	/// 体力值大于最大体力值50%时，获得“理智”。
	/// 每回合开始时选择自己的形态。
	/// </summary>
    public class P_FairyLancelot:Passive_Char
    {

    }
}