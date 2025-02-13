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
	/// 半分幻的庭师
	/// 受到伤害量-50%。
	/// 减少的伤害量会传递给“半灵”。
	/// 自身每行动2次，释放1次“半灵冲撞”。
	/// 剩余行动次数：&a
	/// 每行动3次，释放1次“拔刀术”。
	/// 剩余行动次数：&b
	/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
	/// “符卡层数”到达5层后释放“人鬼「未来永劫斩」”。
	/// </summary>
    public class B_YoumuF_P_0:Buff
    {

    }
}