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
namespace Squall
{
	/// <summary>
	/// 刃甲
	/// </summary>
    public class B_Squall_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 3 * StackNum;

            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.AllyList.Any((BattleAlly i) => i.BuffFind("B_Squall_Rare_2", false)))
                {
                    this.BuffData.MaxStack = 15;
                    return;
                }
            }
            this.BuffData.MaxStack = 10;
        }
    }
}