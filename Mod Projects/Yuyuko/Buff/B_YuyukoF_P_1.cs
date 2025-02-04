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
	/// 通常
	/// 当前返魂值为：&a
	/// </summary>
    public class B_YuyukoF_P_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().fanhun).ToString());
        }
    }
}