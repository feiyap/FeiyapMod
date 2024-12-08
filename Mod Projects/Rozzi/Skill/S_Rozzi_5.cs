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
namespace Rozzi
{
	/// <summary>
	/// 冷酷追击
	/// 优先抽取1个自己的通用攻击技能。
	/// 回合开始时，如果该技能在弃牌库中，且上个回合至少使用3次通用技能，将这个技能拿回手中。
	/// </summary>
    public class S_Rozzi_5:Skill_Extended
    {

    }
}