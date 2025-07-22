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
namespace FAlice
{
	/// <summary>
	/// 红符「红发的荷兰人形」
	/// 这个技能处于倒计时中时，为&user提供“-1速度”。
	/// 触发时，使所有友军获得“+25%暴击率、+25%暴击伤害”，持续 1 回合。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“+1攻击力”。
	/// </summary>
    public class S_FAlice_4:Skill_Extended
    {

    }
}