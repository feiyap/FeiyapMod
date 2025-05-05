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
	/// 大家的心理咨询师
	/// 每回合开始时生成一个“定期心理诊断”。
	/// </summary>
    public class B_Parsee_4_1:Buff, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Heal = 10;
        }

        public void Turn()
        {
            Skill tmpSkill = Skill.TempSkill("S_Parsee_4_2", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}