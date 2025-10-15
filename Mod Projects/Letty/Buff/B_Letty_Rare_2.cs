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
	/// 凛冬
	/// “严寒”的层数上限降低为4。
	/// </summary>
    public class B_Letty_Rare_2:Buff, IP_Awake
    {
        public void Awake()
        {
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.AllyTeam.AliveChars_Vanish);
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars_Vanish);
            foreach (BattleChar battleChar in list.FindAll((BattleChar a) => a.BuffFind("B_Letty_P", false)))
            {
                battleChar.BuffReturn("B_Letty_P", false).BuffData.MaxStack = 4;
                if (battleChar.BuffReturn("B_Letty_P", false).StackNum >= 4)
                {
                    battleChar.BuffReturn("B_Letty_P", false).SelfDestroy();
                    battleChar.BuffAdd("B_Letty_P_1", this.BChar);
                }
            }
        }
    }
}