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
namespace YorigamiSister
{
	/// <summary>
	/// 即将破裂的泡沫
	/// 至多消耗 &a 金币(攻击力的2000%)，获得 &b 保护罩(消耗金币的10%)，持续 2 回合。
	/// 保护罩解除时，对所有敌人造成 &c 伤害（消耗金币的5%）。依据命中敌人的个数，获得相同层数的“拜金主义”。
	/// </summary>
    public class S_Joon_8:Skill_Extended
    {

    }
}