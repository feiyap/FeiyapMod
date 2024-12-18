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
namespace YasakaKanano
{
	/// <summary>
	/// 筒粥「神之粥」
	/// 优先丢弃牌库中目标友军的2个技能。抽取2个技能。
	/// </summary>
    public class S_Kanano_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < 2; i++)
            {
                Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => skill.Master == Targets[0]);
                if (skill2 == null)
                {
                    Skill tempSkill = BattleSystem.instance.AllyTeam.Skills_Deck[0];
                    BattleSystem.instance.AllyTeam.Skills_Deck.Remove(tempSkill);
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Insert(0, tempSkill);
                }
                else
                {
                    BattleSystem.instance.AllyTeam.Skills_Deck.Remove(skill2);
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Insert(0, skill2);
                }
            }

            BattleSystem.instance.AllyTeam.Draw(2);
        }
    }
}