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
namespace Mokou
{
	/// <summary>
	/// 「燃烧殆尽吧！」
	/// 每回合结束时，对所有敌人施加3次烧伤痛苦减益，每次1层。
	/// 每次敌人被施加超过层数上限的烧伤时，立刻造成1次相当于10层烧伤痛苦减益的痛苦伤害。
	/// </summary>
    public class B_Mokou_S_R_1:Buff, IP_TurnEndButtonEnemy
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(10 * (int)Misc.PerToNum((float)this.BChar.GetStat.atk, 15f))).ToString());
        }
        public void TurnEndButtonEnemy()
        {
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}