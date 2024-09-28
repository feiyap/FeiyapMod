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
	/// 悬滞的飞刃
	/// 每次自己触发「月魔术」的额外效果、或使用[时计「月时计」]时，对随机敌人造成%a(30%)伤害。
	/// </summary>
    public class B_Sakuya_4_new:Buff
    {
        public override string DescInit()
        {
            return base.DescInit().Replace("%a", ((int)(base.Usestate_F.GetStat.atk * 0.3f)).ToString());
        }
    }
}