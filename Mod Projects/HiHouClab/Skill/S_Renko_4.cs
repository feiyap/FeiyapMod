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
namespace HiHouClab
{
	/// <summary>
	/// 卫星鸟船
	/// 命中时，使目标的行动向后推进 2 个倒计时。
	/// </summary>
    public class S_Renko_4:Skill_Extended, IP_ParticleOut_Before
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void ParticleOut_Before(Skill SkillD, List<BattleChar> Targets)
        {
            int num = 2;
            if (Targets[0].Info.KeyData == GDEItemKeys.Enemy_S2_MainBoss_1_0 || Targets[0].Info.KeyData == GDEItemKeys.Enemy_S2_MainBoss_1_1)
            {
                using (List<BattleEnemy>.Enumerator enumerator = BattleSystem.instance.EnemyList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BattleEnemy battleEnemy = enumerator.Current;
                        foreach (CastingSkill castingSkill in battleEnemy.SkillQueue)
                        {
                            castingSkill._CastSpeed += num;
                        }
                    }
                    return;
                }
            }
            if (Targets[0] is BattleEnemy)
            {
                foreach (CastingSkill castingSkill2 in (Targets[0] as BattleEnemy).SkillQueue)
                {
                    castingSkill2._CastSpeed += num;
                }
            }
        }
    }
}