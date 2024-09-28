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
	/// 蛙符「操纵蛤蟆」
	/// 使目标技能回到牌堆顶。那之后，根据目标技能的费用，生成相应数量的[风灵]（最少1个）。
	/// </summary>
    public class S_Sanae_8:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            int count = Targets[0].AP;

            BattleSystem.instance.AllyTeam.Skills.Remove(Targets[0]);
            BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, Targets[0]);
            
            if (count < 1)
            {
                count = 1;
            }
            for (int i = 0; i < count; i++)
            {
                Skill tmpSkill = Skill.TempSkill("S_FSL_Common", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}