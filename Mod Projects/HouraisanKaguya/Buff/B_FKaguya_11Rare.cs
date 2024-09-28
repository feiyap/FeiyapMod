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
	/// 辉夜/蓬莱
	/// 每回合结束时，对所有敌人施加3次[辉夜/永夜]，每次1层。
	/// 每次敌人被施加超过层数上限的[辉夜/永夜]时，对其进行1次&a(20%)伤害的追加攻击。
	/// </summary>
    public class B_FKaguya_11Rare:Buff, IP_TurnEndButtonEnemy
    {
        public void TurnEndButtonEnemy()
        {
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                battleChar.BuffAdd("B_FKaguya_P", this.BChar, false, 0, false, 3, false);
                battleChar.BuffAdd("B_FKaguya_P", this.BChar, false, 0, false, 3, false);
                battleChar.BuffAdd("B_FKaguya_P", this.BChar, false, 0, false, 3, false);
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.BChar.GetStat.atk * 0.2f)).ToString());
        }
    }
}