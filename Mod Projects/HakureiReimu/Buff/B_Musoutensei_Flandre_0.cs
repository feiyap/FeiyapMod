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
namespace HakureiReimu
{
	/// <summary>
	/// 绯生一文字
	/// 造成伤害时，额外造成50%的痛苦伤害。
	/// </summary>
    public class B_Musoutensei_Flandre_0:Buff, IP_DealDamage
    {
        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1 && !IsDot)
            {
                Take.Damage(base.Usestate_L, Damage / 2, false, true, false, 0, false, false, false);
            }
        }
    }
}