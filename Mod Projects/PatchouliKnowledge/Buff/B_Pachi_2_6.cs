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
	/// 潮汐引力
	/// 与距离最近的单位链接（优先向右寻找）；
	/// 受到单体技能时，会同时对链接目标重复释放 1 次。
	/// </summary>
    public class B_Pachi_2_6:Buff, IP_Targeted
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            // 1. 首先检查是否有敌人已经拥有这个BUFF
            if (!this.BChar.Info.Ally)
            {
                bool anyHasBuff = BattleSystem.instance.EnemyList.Any(enemy => enemy.BuffFind("B_Pachi_2_6_1"));

                if (!anyHasBuff)
                {
                    // 2. 查找当前角色(this)在列表中的位置
                    int currentIndex = BattleSystem.instance.EnemyList.IndexOf((this.BChar) as BattleEnemy);

                    if (currentIndex >= 0) // 确保当前角色确实在列表中
                    {
                        // 3. 优先检查右边的角色
                        if (currentIndex - 1 >= 0)
                        {
                            // 对右边的角色施加BUFF
                            BattleSystem.instance.EnemyList[currentIndex - 1].BuffAdd("B_Pachi_2_6_1", this.Usestate_F);
                        }
                        // 4. 右边不存在则检查左边的角色
                        else if (currentIndex + 1 < BattleSystem.instance.EnemyList.Count)
                        {
                            // 对左边的角色施加BUFF
                            BattleSystem.instance.EnemyList[currentIndex + 1].BuffAdd("B_Pachi_2_6_1", this.Usestate_F);
                        }
                    }
                }
            }
            else
            {
                bool anyHasBuff = BattleSystem.instance.AllyList.Any(enemy => enemy.BuffFind("B_Pachi_2_6_1"));

                if (!anyHasBuff)
                {
                    // 2. 查找当前角色(this)在列表中的位置
                    int currentIndex = BattleSystem.instance.AllyList.IndexOf((this.BChar) as BattleAlly);

                    if (currentIndex >= 0) // 确保当前角色确实在列表中
                    {
                        // 3. 优先检查右边的角色
                        if (currentIndex - 1 >= 0)
                        {
                            // 对右边的角色施加BUFF
                            BattleSystem.instance.AllyList[currentIndex - 1].BuffAdd("B_Pachi_2_6_1", this.Usestate_F);
                        }
                        // 4. 右边不存在则检查左边的角色
                        else if (currentIndex + 1 < BattleSystem.instance.AllyList.Count)
                        {
                            // 对左边的角色施加BUFF
                            BattleSystem.instance.AllyList[currentIndex + 1].BuffAdd("B_Pachi_2_6_1", this.Usestate_F);
                        }
                    }
                }
            }
        }

        public void Targeted(Skill skill, List<BattleChar> Targets)
        {
            if (Targets != null && Targets.Count == 1 && Targets[0] == this.BChar && !skill.FreeUse && !skill.PlusHit)
            {
                if (Targets[0].Info.Ally)
                {
                    BattleChar firstWithBuff = BattleSystem.instance.AllyList
                                        .FirstOrDefault(enemy => enemy.BuffFind("B_Pachi_2_6_1"));
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
                else
                {
                    BattleChar firstWithBuff = BattleSystem.instance.EnemyList
                                        .FirstOrDefault(enemy => enemy.BuffFind("B_Pachi_2_6_1"));
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
}