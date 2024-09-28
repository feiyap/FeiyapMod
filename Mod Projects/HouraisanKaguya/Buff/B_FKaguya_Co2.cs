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
namespace HouraisanKaguya
{
	/// <summary>
	/// 向那宇宙尽头
	/// 每个回合开始时，获得等同于当前回合数的最大生命值提升。
	/// </summary>
    public class B_FKaguya_Co2:Buff, IP_PlayerTurn
    {
        public int count = 0;

        public override void Init()
        {
            count = 0;
        }

        public override void BuffStat()
        {
            this.PlusStat.maxhp = count / 2;
            base.BuffStat();
        }

        public void Turn()
        {
            count += BattleSystem.instance.TurnNum;
            this.PlusStat.maxhp = count / 2;
        }
    }
}