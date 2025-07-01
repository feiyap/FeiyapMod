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
namespace FairyLancelot
{
	/// <summary>
	/// 最后的妖精
	/// 骑士 - 抽取 1 个技能。依据“舞者”的层数：①恢复 5 点体力值；②使抽取到的技能费用降低 1 点；③选择并生成 1 个自己的专属技能。
	/// 邪龙 - 获得持续 1 回合的“攻击力+1”。依据“龙之心”的层数：①额外获得持续 1 回合的“攻击力+1”；②额外获得持续 1 回合的“防御穿透+10%”；③选择并生成 1 个自己的专属技能。
	/// 好感度大于 10 时，若自身为“理智”：本回合结束时恢复所有友方单位 5 点体力值；
	/// 若自身为“狂化”：本回合结束时生成 1 个“龙鳞”。
	/// </summary>
    public class S_FLancelot_0:Skill_Extended
    {

    }
}