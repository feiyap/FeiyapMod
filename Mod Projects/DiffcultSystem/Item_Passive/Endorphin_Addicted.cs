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
namespace DiffcultSystem
{
	/// <summary>
	/// 食髓知味
	/// <color=#98F5FF><b>+ 协调</b></color>
	/// + 速度+2。
	/// + 每回合抽取6个技能，回合结束时丢弃所有技能。
	/// <color=#FFDEAD><b>- 拮抗</b></color>
	/// - 速度小于3时，回合结束所有队员获得一层盐疫。
	/// </summary>
    public class Endorphin_Addicted:PassiveItemBase
    {

    }
}