using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using NLog.Targets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace FeiyapTank
{
	/// <summary>
	/// 雨曾为紫
	/// 自身每失去 10 点体力值，攻击力+1%；受到痛苦伤害时，最大体力值增加那个伤害的值。
	/// 不会因为受到痛苦伤害导致无法战斗。
	/// </summary>
    public class B_FeiyapTank_Rare_1_1:Buff, IP_DamageTake, IP_HPChange, IP_PainDeathEscape
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

        public bool PainDeathEscape(BattleChar User, int Dmg, bool Cri, BattleChar Target)
        {
            if (Target == this.BChar)
            {
                foreach (IP_DeadResist ip_DeadResist in Target.IReturn<IP_DeadResist>(null))
                {
                    if (ip_DeadResist != null && ip_DeadResist.DeadResist())
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}