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
	/// 死符「醉人之生，死的梦幻」
	/// 仅能在华胥状态下使用。
	/// 华胥 - 减少20返魂值。
	/// 葬送 - 选择手中1个技能放逐，亡者召还1。
	/// 施加[醉梦蝶]：3回合；受到的伤害降低为0，但自身增加等量于伤害值的返魂值；自身陷入永眠时立即解除。
	/// </summary>
    public class S_YuyukoF_8:Skill_Extended
    {

    }
}