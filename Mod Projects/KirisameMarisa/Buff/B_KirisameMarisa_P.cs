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
namespace KirisameMarisa
{
	/// <summary>
	/// <color=#00BFFF>危险等级</color>
	/// </summary>
    public class B_KirisameMarisa_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 2 * StackNum;
            this.PlusStat.def = -2 * StackNum;

            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.AllyList.Any((BattleAlly i) => i.BuffFind("B_KirisameMarisa_DangerTrigger", false)))
                {
                    this.BuffData.MaxStack = 5;
                    return;
                }
            }
            this.BuffData.MaxStack = 4;
        }
    }
}