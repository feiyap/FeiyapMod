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
namespace Eirin
{
	/// <summary>
	/// 月人/新月
	/// 使用指向单体的攻击技能时，消耗一层[月人/新月]，八意永琳会对目标进行一次[月人/乱箭]，视作追加攻击。
	/// 这个伤害的75%会转化为对自己的连锁治疗。
	/// </summary>
    public class B_Eirin_P:Buff, IP_SkillUse_Target, IP_SkillMiss_User
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            this.EirinAttack(hit, SP);
        }

        public void MissEffect(BattleChar hit, SkillParticle SP)
        {
            this.EirinAttack(hit, SP);
        }

        public virtual void EirinAttack(BattleChar hit, SkillParticle SP)
        {
            if (this.BChar.BuffFind("B_Eirin_12Rare"))
            {
                return;
            }
            if (SP.ALLTARGET.Count == 1 && SP.LastHit && !SP.SkillData.PlusHit && !hit.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_Eirin_P", base.Usestate_L, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, hit));
                this.SelfStackDestroy();
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (!hit.IsDead)
            {
                base.Usestate_L.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                base.Usestate_L.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                base.Usestate_L.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}