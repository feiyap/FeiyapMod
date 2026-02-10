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
	/// 离群别舞
	/// 释放时，若目标没有行动倒计时，恢复 2 点法力值。
	/// 居合 - 选择 1 个敌人，对其施加“交手”，然后以倒计时3释放。
	/// </summary>
    public class S_FeiyapTank_1:Skill_Extended, IP_DiscardBefore
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (hit is BattleEnemy)
            {
                BattleEnemy battleEnemy = hit as BattleEnemy;
                if (battleEnemy.SkillQueue.Count == 0)
                {
                    BattleSystem.instance.AllyTeam.AP += 2;
                }
            }
        }

        public void DiscardBefore(bool Click, Skill skill, bool HandFullWaste)
        {
            if (!HandFullWaste && skill == this.MySkill && !this.MySkill.isExcept)
            {
                Skill tempSkill = skill.CloneSkill(true, skill.Master, null, false);
                tempSkill.Counting = 2;
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(tempSkill.Master, tempSkill, false, false, false));
            }
        }
    }
}