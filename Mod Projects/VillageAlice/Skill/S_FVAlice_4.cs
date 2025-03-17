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
namespace VillageAlice
{
	/// <summary>
	/// 梦境速递
	/// 根据处于梦境的目标数量追加攻击。追加攻击造成混乱伤害。每次追加攻击造成&a点伤害(攻击力的50%)。
	/// 【童话】：消耗法力值并释放&user的固定能力。
	/// </summary>
    public class S_FVAlice_4:Skill_Extended
    {

    }
}