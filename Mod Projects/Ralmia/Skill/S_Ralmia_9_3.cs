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
namespace Ralmia
{
	/// <summary>
	/// 迅袭的创造物
	/// 重复触发1次。
	/// </summary>
    public class S_Ralmia_9_3: SkillEn_Ralmia_0
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(this.Damage(Targets[0]));
        }

        public IEnumerator Damage(BattleChar Target)
        {
            if (this.BChar.BattleInfo.EnemyList.Count != 0)
            {
                yield return new WaitForSecondsRealtime(0.3f);
                Skill skill = Skill.TempSkill("S_Ralmia_9_3", this.BChar, this.BChar.MyTeam);
                Skill_Extended skill_Extended = new Skill_Extended();
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill_Extended.PlusSkillStat.Penetration = 100f;
                skill.ExtendedAdd(skill_Extended);
                if (this.MySkill.AllExtendeds.Count > 0)
                {
                    foreach (Skill_Extended extended in this.MySkill.AllExtendeds)
                    {
                        skill.ExtendedAdd(extended);
                    }
                }
                if (Target.IsDead)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
                }
                else
                {
                    this.BChar.ParticleOut(this.MySkill, skill, Target);
                }
            }
            yield break;
        }
    }
}