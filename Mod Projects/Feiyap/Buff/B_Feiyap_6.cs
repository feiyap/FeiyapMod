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
	/// 化身为神
	/// </summary>
    public class B_Feiyap_6:Buff, IP_SkillUseHand_Team, IP_PainDeathEscape, IP_TurnEnd
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusMPUse.PlusMP_OnlyHand = -99;
            count = 0;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                if (count > 0)
                {
                    this.BChar.Damage(this.BChar, (int)(Math.Pow(2, count)), false, true);
                }
                count++;
            }
        }

        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return this.BuffData.Description.Replace("&a", (2).ToString());
            }
            return this.BuffData.Description.Replace("&a", ((int)(Math.Pow(2, count))).ToString());
        }

        public bool PainDeathEscape(BattleChar User, int Dmg, bool Cri, BattleChar Target)
        {
            if (Target != this.BChar)
            {
                return false;
            }
            foreach (IP_DeadResist ip_DeadResist in Target.IReturn<IP_DeadResist>(null))
            {
                if (ip_DeadResist != null && ip_DeadResist.DeadResist())
                {
                    return false;
                }
            }

            return true;
        }

        public void TurnEnd()
        {
            count = 0;
        }
    }
}