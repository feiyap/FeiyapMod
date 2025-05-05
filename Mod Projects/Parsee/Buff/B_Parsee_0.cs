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
namespace Parsee
{
	/// <summary>
	/// 他人的不幸甜如蜜
	/// 将伤害的20%转化为体力值。
	/// </summary>
    public class B_Parsee_0:Buff, IP_DealDamage
    {
        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.2f)), false, false, null);
            }
        }
    }
}