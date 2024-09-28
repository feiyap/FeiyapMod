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
	/// 禁忌「禁果」
	/// 抽取1个技能，受到&a(50%当前体力值)的痛苦伤害。每失去4点体力，额外抽取1个技能（最多抽取4个技能）。
	/// </summary>
    public class S_FlandreScarlet_LucyD:Skill_Extended
    {

    }
}