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
namespace PatchouliKnowledge
{
	/// <summary>
	/// <color=#FFD700>金</color><color=#228B22>木</color><color=#00BFFF>水</color><color=#FF4500>火</color><color=#8B7355>土</color>符「贤者之石」
	/// 战斗开始时，放在牌库最上方。
	/// 抽取 1 个技能。获得<color=#FFD700>金</color>、<color=#228B22>木</color>、<color=#00BFFF>水</color>、<color=#FF4500>火</color>、<color=#8B7355>土</color>每种元素各 1 级。
	/// </summary>
    public class S_Pachi_E_7:Skill_Extended
    {
        public override void BattleStartDeck(List<Skill> Skills_Deck)
        {
            Skills_Deck.Remove(this.MySkill);
            Skills_Deck.Insert(0, this.MySkill);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();

            for (int i = 0; i < 5; i++)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setElementLevel(i, 1);
            }
        }
    }
}