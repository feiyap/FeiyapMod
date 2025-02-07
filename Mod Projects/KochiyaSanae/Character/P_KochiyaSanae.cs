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
    public class P_KochiyaSanae:Passive_Char, IP_PlayerTurn, IP_SkillUse_Team, IP_BattleStart_Ones
    {
        public static int UseNum;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            UseNum = 0;
        }

        public void Turn()
        {
            Skill tmpSkill = Skill.TempSkill("S_Sanae_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }

        public void SkillUseTeam(Skill skill)
        {
            Debug.Log(skill.MySkill.KeyID);
            if ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0)
            {
                UseNum++;
            }
            if (UseNum >= 4)
            {
                UseNum = 0;
                BattleSystem.instance.AllyTeam.AP += 1;
            }
        }

        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_Sanae_P", this.BChar);
        }
    }
}