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
    public class B_Feiyap_6:Buff, IP_SkillUseHand_Team
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
                count++;
                if (count >= 3)
                {
                    base.SelfDestroy(false);
                }
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", (3 - count).ToString());
        }
    }
}