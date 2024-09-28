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
	/// 蓬莱/不朽
	/// 受到伤害时有33%几率抵消这次伤害，并双倍返还给来源。
	/// </summary>
    public class B_FMokou_Reward:Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            int prop = 33;
            int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 100);
            if (ran <= prop)
            {
                resist = true;
                User.Damage(this.BChar, Dmg * 2, false, true);
            }
        }
    }
}