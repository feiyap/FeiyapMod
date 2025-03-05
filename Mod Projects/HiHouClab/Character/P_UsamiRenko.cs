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
namespace HiHouClab
{
	/// <summary>
	/// 宇佐见莲子
	/// Passive:
	/// <b>莲台野夜行</b> - 宇佐见莲子尝试使用科学解析一切看到的事物。
	/// 每次造成伤害会对目标施加1层<b><color=#4169E1>科学解析</color></b>，降低目标的随机属性值。
	/// 场上的每层<b><color=#4169E1>科学解析</color></b>为宇佐见莲子提供5%暴击率。
	/// 当宇佐见莲子的暴击率超过100%时，获得<b><color=#4169E1>经典力学的尽头</color></b>：自身暴击伤害始终为100%，溢出的暴击伤害转化为等量的攻击力加成。
	/// </summary>
    public class P_UsamiRenko:Passive_Char
    {

    }
}