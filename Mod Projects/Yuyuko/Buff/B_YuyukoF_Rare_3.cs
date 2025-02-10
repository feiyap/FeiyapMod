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
	/// 明光蝶
	/// 每个回合第一次触发唤魂X时，获得X点亡魂，并回复X点法力值（无法超过法力值上限）。
	/// </summary>
    public class B_YuyukoF_Rare_3:Buff, IP_GhostChange, IP_PlayerTurn
    {
        public int num = 0;

        public void Turn()
        {
            num = 0;
        }

        public void GhostChange(int count)
        {
            if (num == 0)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost += count;
                BattleSystem.instance.AllyTeam.AP += count;
                if (this.BChar.MyTeam.AP >= this.BChar.MyTeam.MAXAP)
                {
                    this.BChar.MyTeam.AP = this.BChar.MyTeam.MAXAP;
                }
                num++;
            }
        }
    }
}