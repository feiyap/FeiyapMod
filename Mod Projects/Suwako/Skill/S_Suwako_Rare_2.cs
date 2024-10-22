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
namespace Suwako
{
	/// <summary>
	/// 蛙休「总是能够冬眠」
	/// 将手牌中所有[风灵]系以外的技能返回牌库最上方，生成等量的、对应持有者的[风灵]。
	/// 那之后，使手中所有[风灵]系技能增加&a(40%)伤害或&b(65%)治疗量。
	/// 回合结束时，抽取与返回技能数等量的技能。
	/// </summary>
    public class S_Suwako_Rare_2:Skill_Extended
    {

    }
}