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
	/// 管家兔
	/// </summary>
    public class B_FVAlice_Rabbit_P:Buff, IP_Dead
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Dead()
        {
            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                bc.BuffAdd("B_ProgramMaster_1_Select_T", this.BChar, false, 0, false, 1);
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc != this.Usestate_F)
                {
                    bc.BuffAdd("B_ProgramMaster_1_Select_T", this.BChar, false, 0, false, 1);
                }
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}