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
namespace FFAce
{
	/// <summary>
	/// 零式预判
	/// 抽到这张牌时，使用这张牌的[翻开]效果。
	/// 翻开：从弃牌库中选择1张调查员的普通技能置入手中并减少1费。1个回合中最多触发2次该效果。
	/// </summary>
    public class S_FFAce_3:Skill_Extended
    {

    }
}