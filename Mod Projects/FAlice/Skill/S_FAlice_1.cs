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
	/// 诅咒「魔彩光的上海人形」
	/// 这个技能处于倒计时中时，为&user提供“+1攻击力”。
	/// 触发时，对随机敌人造成一次伤害。
	/// 每触发 3 次后，下 1 次触发改为对所有敌人造成伤害。
	/// </summary>
    public class S_FAlice_1:Skill_Extended
    {

    }
}