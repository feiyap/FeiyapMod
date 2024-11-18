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
namespace RemiliaScarlet
{
	/// <summary>
	/// 血狱
	/// 每次行动时，对左边和右边的敌人施加1层<sprite name="RemiliaScarlet_blood"><color=#FF3030>绯夜</color>；如果只剩自己，则对自己施加<sprite name="RemiliaScarlet_blood"><color=#FF3030>绯夜</color>。
	/// </summary>
    public class B_RemiliaScarlet_7:Buff
    {

    }
}