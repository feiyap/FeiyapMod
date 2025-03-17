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
namespace FFAce
{
	/// <summary>
	/// 灼魂刻印
	/// 受到来自艾斯的物理伤害量+30%；
	/// 受到深度灼伤的伤害量+25%。
	/// </summary>
    public class B_FFAce_1:Buff, IP_DamageTakeChange
    {
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (User == this.Usestate_F)
            {
                Dmg = Dmg * 130 / 100;
            }

            return Dmg;
        }
    }
}