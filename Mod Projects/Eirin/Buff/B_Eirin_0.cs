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
namespace Eirin
{
	/// <summary>
	/// 月人/梦蝶
	/// 解除弱化减益
	/// 无法行动，受到伤害后解除
	/// </summary>
    public class B_Eirin_0:Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
        }
        
        public override void BuffOneAwake()
        {
            base.BuffOneAwake();
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, true, false))
            {
                buff.SelfDestroy(false);
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            base.SelfDestroy(false);
        }
    }
}