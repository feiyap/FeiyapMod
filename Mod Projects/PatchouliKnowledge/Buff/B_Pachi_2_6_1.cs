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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 引力潮汐
	/// </summary>
    public class B_Pachi_2_6_1:Buff, IP_Targeted
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            // 1. 首先检查是否有敌人已经拥有这个BUFF
            if (!this.BChar.Info.Ally)
            {
                bool anyHasBuff = BattleSystem.instance.EnemyList.Any(enemy => enemy.BuffFind("B_Pachi_2_6"));

                if (!anyHasBuff)
                {
                    this.SelfDestroy();
                }
            }
            else
            {
                bool anyHasBuff = BattleSystem.instance.AllyList.Any(enemy => enemy.BuffFind("B_Pachi_2_6"));

                if (!anyHasBuff)
                {
                    this.SelfDestroy();
                }
            }
        }

        public void Targeted(Skill skill, List<BattleChar> Targets)
        {
            if (Targets != null && Targets.Count == 1 && Targets[0] == this.BChar && !skill.FreeUse && !skill.PlusHit)
            {
                BattleChar firstWithBuff = BattleSystem.instance.EnemyList
                    .FirstOrDefault(enemy => enemy.BuffFind("B_Pachi_2_6"));
                if (firstWithBuff != null)
                {
                    Skill skill2 = skill.CloneSkill(true, skill.Master);
                    skill.isExcept = true;
                    skill.FreeUse = true;
                    skill.PlusHit = true;

                    if (firstWithBuff != null || firstWithBuff.IsDead)
                    {
                        skill.Master.ParticleOut(skill, firstWithBuff);
                    }
                }
            }
        }
    }
}