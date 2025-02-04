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
	/// 灵蝶「蝶之羽风暂留此世」
	/// 仅能在无法行动时、或处于永眠状态时使用。
	/// 解除所有干扰减益和永眠状态，抽取1个技能，恢复1点法力值。
	/// 将返魂值设置为50，并进入华胥状态。
	/// 立即获得30点亡魂。回合结束时，移除30点亡魂。
	/// 葬送 - 降低100返魂值。
	/// 幽冥蝶 - 施加时，抽取1个技能。
	/// 人魂蝶 - 施加时，恢复1点法力值。
	/// </summary>
    public class S_YuyukoF_7:Skill_Extended
    {

    }
}