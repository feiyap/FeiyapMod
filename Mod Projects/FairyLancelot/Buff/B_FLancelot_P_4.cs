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
namespace FairyLancelot
{
	/// <summary>
	/// 舞者
	/// 持有“龙之心”时无法获得。
	/// </summary>
    public class B_FLancelot_P_4:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = -1 * StackNum;
            this.PlusStat.cri = 5 * StackNum;

            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.AllyList.Any((BattleAlly i) => i.BuffFind("B_FLancelot_Rare_1", false)))
                {
                    this.BuffData.MaxStack = 5;
                    return;
                }
            }
            this.BuffData.MaxStack = 3;
        }
    }
}