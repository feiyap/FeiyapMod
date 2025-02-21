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
namespace Yuyuko
{
	/// <summary>
	/// 半分幻的庭师
	/// 受到伤害量-50%。
	/// 减少的伤害量会传递给“半灵”。
	/// 自身每行动2次，释放1次“半灵冲撞”。
	/// 剩余行动次数：&a
	/// 每行动3次，释放1次“拔刀术”。
	/// 剩余行动次数：&b
	/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
	/// “符卡层数”到达5层后释放“人鬼「未来永劫斩」”。
	/// </summary>
    public class B_YoumuF_P_0:Buff, IP_EnemyAttackScene, IP_Hit, IP_DamageTake, IP_SomeOneDead, IP_BattleStart_UIOnBefore
    {
        public int ghostnum = 0;
        public int slashnum = 0;
        public static int zhoujinum = 0;

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (2 - ghostnum).ToString())
                                      .Replace("&b", (3 - slashnum).ToString());
        }

        public override void Init()
        {
            base.Init();
            ghostnum = 0;
            slashnum = 0;
            this.PlusStat.DMGTaken = -50f;
            this.OnePassive = true;
        }

        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            MasterAudio.PlaySound("YoumuBoss", 1f, null, 0f, null, null, false, false);
            BattleSystem.instance.Reward.Add(ItemBase.GetItem("E_YuyukoF_0"));
        }

        public IEnumerator EnemyAttackScene(Skill UseSkill, List<BattleChar> Targets)
        {
            ghostnum++;
            if (ghostnum >= 2)
            {
                ghostnum = 0;
                BattleEnemy bee = new BattleEnemy();
                foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                {
                    if (be.Info.KeyData == "Boss_Ghost")
                    {
                        bee = be;
                    }
                }
                
                if (bee != null)
                {
                    int lastAct = 0;
                    foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                    {
                        if (cs.skill.Master == bee && cs.CastSpeed > lastAct)
                        {
                            lastAct = cs.CastSpeed;
                        }
                    }

                    List<BattleChar> list = new List<BattleChar>();
                    Skill skill = Skill.TempSkill("S_GhostF_0", bee, bee.MyTeam);
                    list.AddRange((bee as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(bee as BattleEnemy, skill, list, lastAct + 1, false);
                }
            }

            slashnum++;
            if (slashnum >= 3)
            {
                slashnum = 0;
                BattleEnemy bee = new BattleEnemy();
                foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                {
                    if (be.Info.KeyData == "Boss_Ghost_Youmu")
                    {
                        bee = be;
                    }
                }

                int lastAct = 0;
                foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                {
                    if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                    {
                        lastAct = cs.CastSpeed;
                    }
                }

                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_YoumuF_5", this.BChar, this.BChar.MyTeam);
                list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 1, false);

                if (bee != null)
                {
                    List<BattleChar> list2 = new List<BattleChar>();
                    Skill skill2 = Skill.TempSkill("S_YoumuF_5", bee, bee.MyTeam);
                    list2.AddRange((bee as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(bee as BattleEnemy, skill2, list2, lastAct + 2, false);
                }
            }

            this.BChar.BuffAdd("B_YoumuF_Spell", this.BChar);

            yield return null;
            yield break;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0)
            {
                this.BChar.BuffAdd("B_YoumuF_Spell", this.BChar);
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg > 0)
            {
                foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                {
                    if (be.Info.KeyData == "Boss_Ghost")
                    {
                        be.Damage(User, Dmg, Cri, true);
                    }
                }
            }
        }

        public void SomeOneDead(BattleChar DeadChar)
        {
            if (DeadChar.Info.KeyData == "Boss_Ghost")
            {
                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_GhostF_1", this.BChar, this.BChar.MyTeam);
                list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                this.BChar.BuffAdd(GDEItemKeys.Buff_B_RemoveStun, this.BChar, false, 0, false, -1, false);
                BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

                this.BChar.BuffReturn("B_YoumuF_Spell")?.SelfDestroy();
                this.BChar.BuffReturn("B_YoumuF_Spell2")?.SelfDestroy();
            }
        }
    }
}