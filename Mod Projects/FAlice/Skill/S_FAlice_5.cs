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
	/// 暗符「雾之伦敦人偶」
	/// 这个技能处于倒计时中时，为&user提供“+1速度”。
	/// 触发时，使所有友军获得“+25%闪避率、+25%减益抵抗率”，持续 1 回合。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“下 1 个固定能力费用降低 1 点”。
	/// </summary>
    public class S_FAlice_5:Skill_Extended
    {

    }
}