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
namespace KochiyaSanae
{
	/// <summary>
	/// 东风谷早苗
	/// Passive:
	/// </summary>
    public class P_KochiyaSanae:Passive_Char, IP_PlayerTurn, IP_SkillUse_Team
    {
        public int UseNum;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.UseNum = 0;
        }

        public void Turn()
        {
            Skill tmpSkill = Skill.TempSkill("S_Sanae_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }

        public void SkillUseTeam(Skill skill)
        {
            Debug.Log(UseNum);
            if ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0)
            {
                this.UseNum++;
            }
            if (this.UseNum >= 4)
            {
                this.UseNum = 0;
                BattleSystem.instance.AllyTeam.AP += 1;
            }
        }
    }
}