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
	/// 双枪洗礼
	/// 重复释放&a(3 + &b)次。
	/// 以倒计时1重复释放&a(3 + &b)次。
	/// 以倒计时2重复释放&a(3 + &b)次。
	/// 自身每有20%暴击率，重复释放的次数增加1次。
	/// 倒计时期间，释放“冷酷追击”会使重复释放的次数增加1次。
	/// </summary>
    public class S_Rozzi_Rare_3:Skill_Extended
    {

    }
}