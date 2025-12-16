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
namespace CirnoBlizzard
{
	/// <summary>
	/// 冰花恋曲
	/// 使手中第 9 个技能添加“九连环”。
	/// 每次推进倒计时，都会使“九连环”爆炸，对技能的持有者造成 12 痛苦伤害，并向上移动 1 个技能位置。
	/// 按下回合结束按钮时，立即结算剩余所有的“九连环”效果和伤害。
	/// </summary>
    public class S_Boss_Cirno_P3_S:Skill_Extended
    {

    }
}