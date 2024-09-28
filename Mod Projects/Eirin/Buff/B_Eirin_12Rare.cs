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
	/// 月人/天网
	/// 即使身上没有[月人/新月]也可以触发[月人/乱箭]。
	/// </summary>
    public class B_Eirin_12Rare:Buff, IP_SkillUse_Target, IP_SkillMiss_User
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
            if (SP.ALLTARGET.Count == 1 && SP.LastHit && !SP.SkillData.PlusHit && SP.SkillData.TargetDamage >= 1)
            {
                Skill skill = Skill.TempSkill("S_Eirin_P", base.Usestate_L, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, hit));
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