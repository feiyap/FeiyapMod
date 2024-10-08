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
	/// 开眼者
	/// 受到的伤害降低2点。
	/// </summary>
    public class B_HolySaber_9:Buff, IP_DamageTakeChange_sumoperation
    {
        public void DamageTakeChange_sumoperation(BattleChar Hit, BattleChar User, int Dmg, bool Cri, ref int PlusDmg, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar)
            {
                PlusDmg = -1 * StackNum;
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (StackNum).ToString());
        }
    }
}