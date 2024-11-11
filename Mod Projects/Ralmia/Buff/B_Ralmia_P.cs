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
namespace Ralmia
{
	/// <summary>
	/// 创造物种类
	/// </summary>
    public class B_Ralmia_P: Buff
    {
        public override string DescExtended()
        {
            int num = 0;
            if (BattleSystem.instance != null && BattleSystem.instance.GetBattleValue<BV_Artifact>() != null)
            {
                num = BattleSystem.instance.GetBattleValue<BV_Artifact>().UseNum;
            }

            return base.DescExtended().Replace("&a", num.ToString());
        }
    }
}