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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 潮汐引力
	/// 与距离最近的单位链接（优先向右寻找）；
	/// 受到单体技能时，会同时对链接目标重复释放 1 次。
	/// </summary>
    public class B_Pachi_2_6:Buff
    {

    }
}