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
namespace Mokou
{
	/// <summary>
	/// 难题完成
	/// 成功完成了辉夜的难题，全体友方获得增益。
	/// </summary>
    public class B_Kaguya_S_Achieve:Buff
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = (10 * base.StackNum);
            this.PlusPerStat.Heal = (10 * base.StackNum);
        }
    }
}