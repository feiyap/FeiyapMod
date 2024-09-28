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
namespace ShameimaruAya
{
	/// <summary>
	/// 风神少女
	/// </summary>
    public class B_Shameimaru_P_0:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                foreach (Skill skill in this.BChar.MyTeam.Skills)
                {
                    if ((skill.Master == this.BChar || skill.MySkill.KeyID == "S_Shameimaru_LucyD") && skill.ExtendedFind_DataName("SE_Shameimaru_P_0") == null)
                    {
                        skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Shameimaru_P_0"));
                    }
                }
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            this.SelfDestroy();
        }
    }
}