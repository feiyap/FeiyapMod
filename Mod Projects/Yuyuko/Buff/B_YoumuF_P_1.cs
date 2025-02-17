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
	/// 生命二刀流·白楼剑
	/// 与“魂魄妖梦·半灵”共享体力值。
	/// 每行动3次，释放1次“拔刀术”。
	/// 剩余行动次数：&b
	/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
	/// “符卡层数”到达5层后释放“人鬼「未来永劫斩」”。
	/// </summary>
    public class B_YoumuF_P_1:Buff, IP_HPChange, IP_DeadAfter, IP_EnemyAttackScene, IP_Hit
    {
        public int slashnum = 0;


        public override void Init()
        {
            base.Init();
            slashnum = 0;
            this.OnePassive = true;
        }
        
        public void HPChange(BattleChar Char, bool Healed)
        {
            foreach (BattleEnemy battleEnemy in this.BChar.BattleInfo.EnemyList)
            {
                if (battleEnemy != Char && (battleEnemy.BuffFind("B_GhostF_P_1", false)))
                {
                    battleEnemy.Info.Hp = Char.HP;
                    if (battleEnemy.Info.Hp == 0)
                    {
                        battleEnemy.Dead(false, false);
                    }
                }
            }
        }
        
        public void DeadAfter()
        {
            FieldSystem_Patch.count = 0;

            BattleChar battleChar = null;
            foreach (BattleEnemy battleEnemy in this.BChar.BattleInfo.EnemyList)
            {
                if (battleEnemy != this.BChar && (battleEnemy.BuffFind("B_GhostF_P_1", false)))
                {
                    battleChar = battleEnemy;
                    break;
                }
            }
            if (battleChar != null)
            {
                battleChar.Dead(false, false);
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&b", (3 - slashnum).ToString());
        }

        public IEnumerator EnemyAttackScene(Skill UseSkill, List<BattleChar> Targets)
        {
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
    }
}