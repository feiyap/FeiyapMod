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
	/// 严寒
	/// 叠加至满层时，转变为“冻僵”。
	/// </summary>
    public class B_Letty_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = -6 * StackNum;

            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.AllyList.Any((BattleAlly i) => i.BuffFind("B_Letty_Rare_2", false)))
                {
                    this.BuffData.MaxStack = 4;
                    return;
                }
            }
            this.BuffData.MaxStack = 6;
        }

        public override void BuffStat()
        {
            base.BuffStat();

            if (this.StackNum >= this.BuffData.MaxStack)
            {
                this.SelfDestroy();
                this.BChar.BuffAdd("B_Letty_P_1", this.Usestate_L);
            }
        }
    }
}