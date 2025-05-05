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
namespace Parsee
{
	/// <summary>
	/// 超越时间
	/// 下一次出手的该角色的技能费用+2。
	/// </summary>
    public class B_Parsee_4:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusMPUse.PlusMP_Skills = 2;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                base.SelfDestroy(false);
            }
        }
    }
}