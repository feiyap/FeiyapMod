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
namespace szb_elena
{
	/// <summary>
	/// 耶拉
	/// Passive:
	/// 当自己回复生命值时，使所有调查员在本场战斗中获得+1攻击力和+1最大生命值。
	/// </summary>
    public class P_szb_elena:Passive_Char, IP_BattleStart_Ones,IP_Healed,IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public void Turn()
        {
            TurnHealedNum = 0;
        }
        public void BattleStart(BattleSystem Ins)
		{
			HealedNum = 0;
            TurnHealedNum = 0;

            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
			{
				battleChar.BuffAdd(ModItemKeys.Buff_B_szb_elena_P, this.BChar, false, 0, false, -1, false);
			}
		}
       
        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal) 
		{
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (!battleChar.BuffFind(ModItemKeys.Buff_B_szb_elena_P))
                {
                    battleChar.BuffAdd(ModItemKeys.Buff_B_szb_elena_P, this.BChar, false, 0, false, -1, false);
                }
            }
            
            TurnHealedNum += 1;
            HealedNum += 1;

            if (this.BChar.BuffFind(ModItemKeys.Buff_B_szb_elena_3, true))
            {
                HealedNum += 1;
            }
            if (this.BChar.BuffFind(ModItemKeys.Buff_B_szb_elena_R1, true))
            {
                HealedNum += 1;
            }

            foreach (IP_ElenaHealed ip_ElenaHealed in BattleSystem.instance.IReturn<IP_ElenaHealed>())
            {
                if (ip_ElenaHealed != null)
                {
                    ip_ElenaHealed.ElenaHealed();
                }
            }
        }

        public static int HealedNum;
        public static int TurnHealedNum;
    }
}