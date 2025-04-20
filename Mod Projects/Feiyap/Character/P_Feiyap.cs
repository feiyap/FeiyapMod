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
namespace Feiyap
{
	/// <summary>
	/// 绯夜氏
	/// Passive:
	/// 自身拥有保护体力极限时，攻击造成伤害的25%转化为对自身的治疗。
	/// </summary>
    public class P_Feiyap:Passive_Char, IP_DealDamage
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1 && this.BChar.GetStat.Strength && !IsDot)
            {
                if (this.BChar.BuffFind("B_Feiyap_Rare_1"))
                {
                    Take.BuffAdd("B_RemiliaScarlet_0", this.BChar);
                }
                else
                {
                    this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.25f)), false, false, null);
                }
            }
        }
    }
}