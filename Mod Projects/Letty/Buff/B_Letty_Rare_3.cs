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
namespace Letty
{
    /// <summary>
    /// 冬至
    /// 回合开始时，获得 &a 保护罩(&user最大体力值的25%)。
    /// </summary>
    public class B_Letty_Rare_3 : Buff, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.BChar.BuffAdd("B_Letty_Barrier", this.Usestate_L).BarrierHP = (int)(this.Usestate_L.GetStat.maxhp * 0.25);
        }

        public override string DescExtended()
        {

            return base.DescExtended().Replace("&a", ((int)(this.Usestate_L.GetStat.maxhp * 0.25)).ToString())
                                      .Replace("&user", this.Usestate_L.Info.Name);
        }
    }
}