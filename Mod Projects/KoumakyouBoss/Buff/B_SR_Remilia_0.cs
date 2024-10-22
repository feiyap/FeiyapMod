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
namespace KoumakyouBoss
{
	/// <summary>
	/// 绯夜
	/// </summary>
    public class B_SR_Remilia_0:Buff, IP_DamageTakeChange, IP_PlayerTurn
    {
        int count;

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void Turn()
        {
            count = 0;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Dmg > 0 && NODEF)
            {
                if (count < 1)
                {
                    base.Usestate_L.Heal(base.Usestate_L, 5 * this.StackNum, false, false, null);
                    count++;
                }
            }
            return Dmg;
        }
    }
}