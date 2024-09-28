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
namespace HakureiReimu
{
	/// <summary>
	/// 神技「八方龙杀阵」
	/// 目标身上每有2种减益效果，重复释放1次（最多3次）。
	/// </summary>
    public class S_HakureiReimu_F_5_5: S_HakureiReimu_F_5
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int count = CheckDebuffNum(Targets[0]);
            if (!this.MySkill.FreeUse && count >= 2)
            {
                Skill skill = this.MySkill.CloneSkill(false, null, null, false);
                skill.MySkill.Effect_Target.DMG_Per = skill.MySkill.Effect_Target.DMG_Per * 30 / 100;
                skill.FreeUse = true;
                skill.AP = 0;
                skill.Counting = -99;

                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
            }
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.1f);
            if (!Target.IsDead)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            }
            else if (Target.Info.Ally)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            yield break;
        }
    }
}