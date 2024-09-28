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
namespace Kirito
{
	/// <summary>
	/// 二刀流
	/// 攻击额外附带1次伤害。
	/// </summary>
    public class B_Kirito_12Rare:Buff, IP_DealDamage
    {
        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1 && !IsDot)
            {
                Take.Damage(base.Usestate_L, Damage, false, true, false, 0, false, false, false);
            }
        }
    }
}