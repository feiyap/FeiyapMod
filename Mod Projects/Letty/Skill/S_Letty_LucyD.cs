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
namespace Letty
{
	/// <summary>
	/// 寒符「霜打蔬菜分外甜」
	/// 使目标技能在本回合无法使用。
	/// 抽取 2 个技能，恢复 1 点法力值。
	/// </summary>
    public class S_Letty_LucyD:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].NotAvailable = true;

            BattleSystem.instance.AllyTeam.Draw(2);
            BattleSystem.instance.AllyTeam.AP += 2;
        }
    }
}