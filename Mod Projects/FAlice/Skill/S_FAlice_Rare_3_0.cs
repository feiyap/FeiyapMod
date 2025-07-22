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
	/// 试验中「歌莉娅人形」
	/// 这个技能处于倒计时中时，为&user提供“+5攻击力，+5治疗力，+10最大体力值，+25%暴击率，+25%闪避率，+40%无法战斗抵抗”。
	/// 这个技能处于倒计时中时，使其他「人形」技能的效果变为：恢复 1 点法力值并抽取 1 个技能。
	/// 触发时，对所有敌人造成一次伤害。
	/// 每触发 3 次后，下 1 次触发改为对所有敌人造成 &a 伤害(攻击力的450%)。然后将这个技能放逐。
	/// </summary>
    public class S_FAlice_Rare_3_0:Skill_Extended
    {

    }
}