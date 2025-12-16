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
namespace CirnoBlizzard
{
    /// <summary>
    /// 恸哭与冰之心
    /// 每个回合开始时，冻结最后 1 颗可用的法力水晶：这颗法力水晶不再可用。
    /// 每个回合中，最多能恢复 9 点法力值。超出时，清空所有法力值，并在本回合内暂时冻结所有法力水晶。
    /// 本回合还能恢复的法力值：&a
    /// </summary>
    public class B_Boss_Cirno_P_3_1 : Buff, IP_PlayerTurn, IP_APChanged
    {
        public int count = 0;

        public void Turn()
        {
            count = 0;
            BattleEvent_CirnoBlizzard.FreezeAP++;
            if (BattleSystem.instance.AllyTeam.AP > 10 - BattleEvent_CirnoBlizzard.FreezeAP)
            {
                BattleSystem.instance.AllyTeam.AP = 10 - BattleEvent_CirnoBlizzard.FreezeAP;
            }
        }

        public void APChanged(int OldValue, int NewValue, bool NewTurnRecover)
        {
            if (NewValue > OldValue && !NewTurnRecover)
            {
                count += NewValue - OldValue;
            }

            if (count > 9)
            {
                BattleSystem.instance.AllyTeam.AP = 0;
                BattleSystem.instance.AllyTeam.LucyChar.BuffAdd("B_Boss_Cirno_P_3_0", this.BChar);
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (9 - count).ToString());
        }
    }
}