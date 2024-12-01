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
namespace KirisameMarisa
{
	/// <summary>
	/// 彗星「Blazing Star」
	/// 倒计时期间，自身处于无敌状态。
	/// 释放时，速度大于0时，每有1点速度，这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的50%)</color>。
	/// </summary>
    public class S_KirisameMarisa_Rare_11:Skill_Extended
    {

    }
}