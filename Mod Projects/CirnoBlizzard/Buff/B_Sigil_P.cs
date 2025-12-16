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
namespace CirnoBlizzard
{
	/// <summary>
	/// 冰封魔印
	/// 琪露诺=暴风雪释放技能后，“冰封魔印”会依次以倒计时1、2、3重复释放，然后消失。
	/// 被调查员击破时，在手中生成 1 个“雪符「完美的冰晶片」” （一次性的完美防御）。
	/// “冰封魔印”会优先攻击治疗力最高的单位。受到攻击后，会改为以最后一次的攻击者为优先攻击的目标。
	/// 当前锁定的攻击目标：&target
	/// </summary>
    public class B_Sigil_P:Buff
    {

    }
}