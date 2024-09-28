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
	/// 神脑「思兼之脑」
	/// 消耗场上所有的[月人/新月]，对目标释放[消耗层数+2]次数的[月人/乱箭]。
	/// 依此法释放的[月人/乱箭]无视防御、必定命中。
	/// </summary>
    public class S_Eirin_4:Skill_Extended
    {
        public int num;

        public override void Init()
        {
            base.Init();
            num = 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            num = 0;
            
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                if (BattleSystem.instance.AllyList[i].BuffFind("B_Eirin_P", false) && BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).StackNum >= 1)
                {
                    num += BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).StackNum;
                    BattleSystem.instance.AllyList[i].BuffReturn("B_Eirin_P", false).SelfDestroy();
                }
            }
            
            for (int i = 0; i < num + 2;i++)
            {
                this.EirinAttack(Targets[0]);
            }
        }

        public virtual void EirinAttack(BattleChar hit)
        {
            Skill skill = Skill.TempSkill("S_Eirin_P", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.IsDamage = true;
            skill_Extended.PlusSkillStat.Penetration = 100f;
            skill.ExtendedAdd(skill_Extended);
            BattleSystem.DelayInput(this.EirinAttack(skill, hit));
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (!hit.IsDead)
            {
                this.BChar.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}