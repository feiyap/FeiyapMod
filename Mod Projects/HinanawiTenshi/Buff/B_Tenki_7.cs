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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 浓雾
	/// 造成伤害的10%治疗自己。
	/// </summary>
    public class B_Tenki_7:Buff, IP_DealDamage
    {
        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.1f)), false, false, null);
            }
        }
    }
}