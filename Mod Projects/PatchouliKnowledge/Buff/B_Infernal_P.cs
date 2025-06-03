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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 永久献祭
	/// 每个回合开始时，对所有队友造成 &a 伤害(攻击力的33%)。
	/// </summary>
    public class B_Infernal_P:Buff, IP_PlayerTurn, IP_TurnEnd
    {
        public void Turn()
        {
            foreach (BattleChar be in BattleSystem.instance.EnemyList)
            {
                be.Damage(this.BChar, ((int)(this.BChar.GetStat.atk * 0.33f)), false, true);
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", ((int)(this.BChar.GetStat.atk * 0.33f)).ToString());
        }

        public void TurnEnd()
        {
            if (!BattleSystem.instance.EnemyTeam.AliveChars.Find((BattleChar Char) => Char.Info.KeyData != "E_Pachi_Infernal" && !Char.BuffFind(GDEItemKeys.Buff_B_S4_King_P1_Half, false)))
            {
                this.BChar.Dead(false, false);
            }
        }
    }
}