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
namespace Inaba
{
	/// <summary>
	/// 幻象/因幡
	/// 触发追加攻击/反击时，&target会同时对目标进行一次&a(30%)伤害的追加攻击（不会触发[辉夜/梦乡]）。
	/// </summary>
    public class B_Inaba_9:Buff, IP_DamageChange, IP_SomeOneDead
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.PlusHit && SkillD.Master == this.BChar && SkillD.MySkill.KeyID != "S_Inaba_9_0")
            {
                Skill skill = Skill.TempSkill("S_Inaba_9_0", base.Usestate_L, base.Usestate_L.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.InabaAttack(skill, Target));
            }
            return Damage;
        }

        public IEnumerator InabaAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.1f);
            if (!Target.IsDead)
            {
                base.Usestate_L.ParticleOut(AttackSkill, Target);
            }
            else if (Target.Info.Ally)
            {
                base.Usestate_L.ParticleOut(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                base.Usestate_L.ParticleOut(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&target", base.Usestate_L.Info.Name).Replace("&a", ((int)(base.Usestate_L.GetStat.atk * 0.3f)).ToString());
        }

        public void SomeOneDead(BattleChar DeadChar)
        {
            if (DeadChar == base.Usestate_L)
            {
                this.SelfDestroy();
            }
        }
    }
}