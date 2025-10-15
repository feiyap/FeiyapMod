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
using BasicMethods;
using System.Xml.Serialization;

namespace Letty
{
	/// <summary>
	/// 蕾蒂
	/// Passive:
	/// 操纵寒冷程度的能力 - 敌人行动时，对其施加 1 层“严寒”：叠加至满层时，转变为“冻僵”。
	/// 冻僵：无法行动，持续 1 回合。可被延长持续回合。
	/// Crystallize Silver - 蕾蒂可在持有“无法行动”减益时使用技能。
	/// </summary>
    public class P_Letty:Passive_Char, IP_EnemyActionBefore
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public IEnumerator EnemyActionBefore(BattleEnemy ActionEnemy, Skill EnemyUseSkill, bool IsDelayWait)
        {
            ActionEnemy.BuffAdd("B_Letty_P", this.BChar);
            yield break;
        }
    }
}