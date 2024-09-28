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
namespace HatsuneMiku
{
	/// <summary>
	/// ヴァンパイア
	/// 攻击时恢复造成伤害的50%
	/// </summary>
    public class B_HatsuneMiku_6:Buff, IP_DealDamage
    {
        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.5f)), false, false, null);
            }
        }
    }
}