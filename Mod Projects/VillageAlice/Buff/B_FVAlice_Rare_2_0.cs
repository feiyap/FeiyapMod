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
namespace VillageAlice
{
	/// <summary>
	/// 梦境弄臣
	/// 梦境回合结束时，若该单位被击杀，则再额外进行一次梦境回合，随机选取一名目标成为「梦境弄臣」的目标。
	/// </summary>
    public class B_FVAlice_Rare_2_0:Buff, IP_Dead, IP_PlayerTurn
    {
        public void Dead()
        {
            this.Usestate_F.BuffAdd("B_FVAlice_Rare_2", this.Usestate_F);
            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                bc.BuffAdd("B_FVAlice_Rare_2_0", this.Usestate_F);
                break;
            }
        }

        public void Turn()
        {
            foreach (BattleChar ba in BattleSystem.instance.AllyList)
            {
                if (ba != this.Usestate_F)
                {
                    ba.BuffAdd("B_FVAlice_Rare_2_1", this.Usestate_F);
                }
            }
        }
    }
}