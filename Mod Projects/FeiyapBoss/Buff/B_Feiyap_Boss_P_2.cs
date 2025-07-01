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
namespace FeiyapBoss
{
	/// <summary>
	/// 雨曾为紫
	/// 受到痛苦伤害时，提升等量的最大体力值。
	/// 每失去30体力值，自身获得“+10%造成伤害量提升”。
	/// </summary>
    public class B_Feiyap_Boss_P_2:Buff, IP_DamageTake, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                if (NODEF)
                {
                    int now = this.BChar.HP;
                    this.PlusStat.maxhp += Dmg;
                    this.BChar.HP = now;
                }
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char == this.BChar)
            {
                this.PlusPerStat.Damage = (this.BChar.GetStat.maxhp - this.BChar.HP) / 10;
            }
        }
    }
}