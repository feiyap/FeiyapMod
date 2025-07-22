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
	/// 白符「白垩的俄罗斯人偶」
	/// 这个技能处于倒计时中时，为&user提供“+4%防御力”。
	/// 触发时，获得 &a 防护墙(60%防御力)。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“保护体力极限”，持续 2 回合。
	/// </summary>
    public class S_FAlice_3:Skill_Extended
    {

    }
}