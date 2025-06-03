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
	/// 熔损彗星
	/// 体力值低于13%时立即死亡。
	/// </summary>
    public class B_Pachi_3_6:Buff, IP_HPChange
    {
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char == this.BChar)
            {
                if (this.BChar.HP <= this.BChar.GetStat.maxhp * 0.13 && this.BChar.HP > 0)
                {
                    this.BChar.HPToZero();
                }
            }
        }
    }
}