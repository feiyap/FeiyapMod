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
namespace Yuyuko
{
	/// <summary>
	/// 冥符「黄泉平坂行路」
	/// 增加20返魂值。
	/// 使所有敌人获得与目标相同的“已损失最大体力值”的值。
	/// 葬送 - 使所有敌人失去&a最大体力值(攻击力的90%)。
	/// 幽冥蝶 - 回引时，造成&a的伤害(&user攻击力的90%)。
	/// 人魂蝶 - 回引时，(100%干扰成功率)眩晕1回合。
	/// </summary>
    public class S_YuyukoF_4:Skill_Extended
    {

    }
}