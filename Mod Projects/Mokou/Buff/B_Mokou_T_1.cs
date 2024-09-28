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
	/// 烧伤
	/// </summary>
    public class B_Mokou_T_1:Buff, IP_BuffAdd
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_Mokou_T_1" && base.StackNum == this.BuffData.MaxStack && BuffUser.BuffFind
                ("B_Mokou_S_R_1", false))
            {
                BuffTaker.Damage(BuffUser, 10 * (int)Misc.PerToNum((float)BuffUser.GetStat.atk, 15f), false, true, true, 0, false, false, false);
            }
        }
        public override void Init()
        {
            this.PlusPerStat.Damage = (-2 * base.StackNum);
        }
    }
}