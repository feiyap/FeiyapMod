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
namespace HiHouClab
{
	/// <summary>
	/// Bar·Old Adam
	/// 对持有“量子纠缠”的目标额外治疗 &a 体力(治疗力的65%)。
	/// </summary>
    public class S_Renko_7:Skill_Extended
    {
        public override void BattleStartDeck(List<Skill> Skills_Deck)
        {
            Skills_Deck.Remove(this.MySkill);
            Skills_Deck.Insert(0, this.MySkill);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                bc.BuffAdd("B_Renko_5", this.BChar, false, 0, false, 2);
            }
        }
    }
}