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
	/// 夏季促销
	/// 在战斗中消耗金币时，每次消耗金币移除 1 层“夏季促销”，然后获得 50 金币，并获得 1 层“拜金主义”。
	/// 战斗结束时，剩余的“夏季促销”转化为金币（每层 25 金币）。
	/// </summary>
    public class B_Joon_7:Buff
    {

    }
}