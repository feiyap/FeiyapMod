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
namespace MinamiRio
{
	/// <summary>
	/// 箭越（向后）
	/// 使所有敌人行动倒计时+1
	/// </summary>
    public class S_MinamiRio_5_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            using (List<BattleEnemy>.Enumerator enumerator = BattleSystem.instance.EnemyList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    BattleEnemy battleEnemy = enumerator.Current;
                    foreach (CastingSkill castingSkill in battleEnemy.SkillQueue)
                    {
                        castingSkill._CastSpeed += 1;
                    }
                }
            }

            IEnumerable<BattleEnemy> enumerable = BattleSystem.instance.EnemyTeam.AliveChars.OfType<BattleEnemy>();
            BattleEnemy battleEnemy2;
            if (enumerable == null)
            {
                battleEnemy2 = null;
            }
            else
            {
                IOrderedEnumerable<BattleEnemy> orderedEnumerable = enumerable.OrderBy(delegate (BattleEnemy x)
                {
                    List<CastingSkill> skillQueue = x.SkillQueue;
                    int? num;
                    if (skillQueue == null)
                    {
                        num = null;
                    }
                    else
                    {
                        CastingSkill castingSkill = skillQueue.FirstOrDefault<CastingSkill>();
                        num = ((castingSkill != null) ? new int?(castingSkill.CastSpeed) : null);
                    }
                    int? num2 = num;
                    return num2.GetValueOrDefault();
                });
                battleEnemy2 = ((orderedEnumerable != null) ? orderedEnumerable.FirstOrDefault<BattleEnemy>() : null);
            }

            Skill skill = Skill.TempSkill("S_MinamiRio_5_2", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.FreeUse = true;
            this.BChar.ParticleOut(skill, battleEnemy2);

            BattleSystem.instance.AllyTeam.Draw();

            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                this.BChar.BuffReturn("B_MinamiRio_P1").SelfDestroy();
                this.BChar.BuffAdd("B_MinamiRio_P2", this.BChar);
            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                this.BChar.BuffReturn("B_MinamiRio_P2").SelfDestroy();
                this.BChar.BuffAdd("B_MinamiRio_P1", this.BChar);
            }
        }
    }
}