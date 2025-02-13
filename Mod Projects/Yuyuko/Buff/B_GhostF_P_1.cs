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
namespace Yuyuko
{
	/// <summary>
	/// 生命二刀流·楼观剑
	/// 与“魂魄妖梦”共享体力值。
	/// 以倒计时+1复制所有“魂魄妖梦”的行动（除“人鬼「未来永劫斩」”外）。
	/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
	/// “符卡层数”到达5层后释放“空观剑「六根清净斩」”。
	/// </summary>
    public class B_GhostF_P_1:Buff
    {

    }
}