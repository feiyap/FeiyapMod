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
namespace IzayoiSakuya
{
	/// <summary>
	/// 奇术「误导」
	/// 将1个技能放回牌堆底，抽取1个技能。
	/// 月魔术 - 生成1张迅速、一次性、1回合后弃牌的[奇术「误导」]加入手中。这张[奇术「误导」]无法再触发月魔术。
	/// </summary>
    public class S_Sakuya_6_0:Skill_Extended
    {
    }
}