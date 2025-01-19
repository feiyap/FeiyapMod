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
namespace Elana
{
	/// <summary>
	/// 耶拉
	/// Passive:
	/// 当自己回复生命值时，使所有调查员获得+1攻击力和+1最大生命值。
	/// </summary>
    public class P_Elana:Passive_Char, IP_Healed
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Elana_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Elana_P());
            }

            BattleSystem.instance.GetBattleValue<BV_Elana_P>().count++;

            if (HealedChar == this.BChar)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (!bc.BuffFind("B_Elana_P"))
                    {
                        bc.BuffAdd("B_Elana_P", this.BChar);
                    }
                }
            }
        }
    }
}