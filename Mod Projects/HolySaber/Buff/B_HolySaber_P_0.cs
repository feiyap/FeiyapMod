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
namespace HolySaber
{
	/// <summary>
	/// 圣女的号令
	/// 受到的痛苦伤害降低为0。
	/// </summary>
    public class B_HolySaber_P_0:Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (NODEF)
            {
                Dmg = 0;
            }
            return Dmg;
        }
    }
}