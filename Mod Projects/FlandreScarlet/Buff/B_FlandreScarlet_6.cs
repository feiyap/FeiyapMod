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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁忌时刻
	/// 回合结束时，或者体力不高于0时，立即恢复&a(50%最大体力值)体力。那之后解除该增益。
	/// </summary>
    public class B_FlandreScarlet_6:Buff, IP_HPChange, IP_TurnEnd
    {
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char != this.BChar)
            {
                return;
            }
            if (Char.HP <= 0)
            {
                this.BChar.Heal(this.BChar, this.BChar.GetStat.maxhp * 0.5f, this.BChar.GetCri(), false, null);
                this.SelfDestroy();
            }
        }

        public void TurnEnd()
        {
            this.BChar.Heal(this.BChar, this.BChar.GetStat.maxhp * 0.5f, this.BChar.GetCri(), false, null);
            this.SelfDestroy();
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.5f)).ToString());
        }
    }
}