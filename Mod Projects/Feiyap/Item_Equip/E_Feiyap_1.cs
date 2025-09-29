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
namespace Feiyap
{
	/// <summary>
	/// 镇魂石
	/// 每个回合结束时，该装备提供的属性-5%/-5%/-5%。
	/// 黑雾回合到来时，装备属性重置。
	/// <color=#919191><i>再次鼓起失去的勇气。</i></color>
	/// </summary>
    public class E_Feiyap_1:EquipBase, IP_TurnEnd, IP_BattleEnd, IP_PlayerTurn
    {
        public void BattleEnd()
        {
            this.PlusPerStat.MaxHP = 25;
            this.PlusPerStat.Damage = 25;
            this.PlusStat.def = 25;
        }

        public override void Init()
        {
            base.Init();
            this.PlusPerStat.MaxHP = 25;
            this.PlusPerStat.Damage = 25;
            this.PlusStat.def = 25;
        }

        public void Turn()
        {
            if (BattleSystem.instance != null && BattleSystem.instance.FogTurn == BattleSystem.instance.TurnNum)
            {
                this.PlusPerStat.MaxHP = 25;
                this.PlusPerStat.Damage = 25;
                this.PlusStat.def = 25;
            }
        }

        public void TurnEnd()
        {
            this.PlusPerStat.MaxHP -= 5;
            this.PlusPerStat.Damage -= 5;
            this.PlusStat.def -= 5;
        }
    }
}