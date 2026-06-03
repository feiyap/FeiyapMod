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
namespace FeiyapTank
{
	/// <summary>
	/// 无归的旅途
	/// 抽取 3 个技能。
	/// 对目标友军造成<color=purple> 12 点痛苦伤害</color>。
	/// 若目标友军因此技能的伤害进入濒死状态，恢复 2 点法力值。
	/// </summary>
    public class S_FeiyapTank_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].Damage(this.BChar, 12, false, true, false, 0, false, false, false);
            BattleSystem.instance.AllyTeam.Draw(3);
            BattleSystem.DelayInputAfter(this.AttactAfter(Targets[0]));
        }

        public IEnumerator AttactAfter(BattleChar Target)
        {
            yield return new WaitForFixedUpdate();

            if (Target.BuffFind(GDEItemKeys.Buff_B_Neardeath, false))
            {
                BattleSystem.instance.AllyTeam.AP += 2;
            }
            
            yield break;
        }
    }
}