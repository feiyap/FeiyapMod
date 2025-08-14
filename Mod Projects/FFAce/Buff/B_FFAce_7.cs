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
	/// 每次受到伤害时将被施加1层[霜冻]（1个回合内最多触发2次）。
	/// </summary>
    public class B_FFAce_7:Buff, IP_DamageTake, IP_TurnEnd
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_CC = -35;
            this.PlusStat.RES_DEBUFF = -35;
            this.PlusStat.RES_DOT = -35;
            count = 0;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && count < 2)
            {
                this.BChar.BuffAdd("B_FFAce_5_1", this.Usestate_F);
                count++;
            }
        }

        public void TurnEnd()
        {
            count = 0;
        }
    }
}