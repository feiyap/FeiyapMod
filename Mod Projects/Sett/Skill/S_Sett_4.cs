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
namespace Sett
{
	/// <summary>
	/// 强手裂颅
	/// 选取 1 个与目标相邻的敌人（优先寻找右边）：
	/// 若两者嘲讽状态不同，则同时施加(<sprite=2>120%)“眩晕”；
	/// 否则施加(<sprite=2>40%)“眩晕”。
	/// </summary>
    public class S_Sett_4:Skill_Extended
    {

    }
}