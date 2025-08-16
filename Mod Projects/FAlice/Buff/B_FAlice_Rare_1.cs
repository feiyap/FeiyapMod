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
namespace FAlice
{
    /// <summary>
    /// 虹彩的人形使
    /// 每个回合开始时，额外生成 1 个“操符「操纵人形」”。
    /// 移除「人形」技能数量上限。
    /// </summary>
    public class B_FAlice_Rare_1 : Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_FAlice_0, this.BChar, this.BChar.MyTeam);
            skill.AP = 1;
            skill.isExcept = true;
            skill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}