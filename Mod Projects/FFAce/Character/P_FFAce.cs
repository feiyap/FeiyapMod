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
	/// 艾斯
	/// Passive:
	/// <b>固定能力变更为‘翻牌’。</b>
	/// <color=#919191>- 此被动从1级开始生效。</color>
	/// </summary>
    public class P_FFAce:Passive_Char
    {
        public static List<Skill> DrawList = new List<Skill>();
    }
}