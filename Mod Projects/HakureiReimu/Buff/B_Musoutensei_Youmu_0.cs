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
namespace HakureiReimu
{
    /// <summary>
    /// 天人合一
    /// 受到敌人的攻击时，博丽灵梦和魂魄妖梦轮流对目标造成&a点伤害(攻击力的200%)和&b伤害(攻击力的200%)，并解除目标所有增益。那之后，解除该增益。
    /// </summary>
    public class B_Musoutensei_Youmu_0:Buff, IP_DamageTake
    {
        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended().Replace("&a", (0).ToString())
                                          .Replace("&b", (0).ToString());
            }

            BattleChar youmu = new BattleChar();
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.Info.Name == "Youmu")
                {
                    youmu = bc;
                    break;
                }
            }

            if (youmu == null)
            {
                return base.DescExtended().Replace("&a", ((int)((float)this.BChar.GetStat.atk * 2.0f)).ToString())
                                          .Replace("&b", (0).ToString());
            }

            return base.DescExtended().Replace("&a", ((int)((float)this.BChar.GetStat.atk * 2.0f)).ToString())
                                      .Replace("&b", ((int)((float)youmu.GetStat.atk * 2.0f)).ToString());
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && !User.Info.Ally && !resist)
            {
                Skill skill = Skill.TempSkill("S_Musoutensei_Youmu_1", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, User, this.BChar));

                BattleChar youmu = new BattleChar();
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (bc.Info.Name == "Youmu")
                    {
                        youmu = bc;
                        break;
                    }
                }

                if (youmu == null)
                {
                    return;
                }
                
                Skill skill2 = Skill.TempSkill("S_Musoutensei_Youmu_2", youmu, this.BChar.MyTeam);
                skill2.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill2, User, youmu));

                base.SelfDestroy(false);
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit, BattleChar use)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (!hit.IsDead)
            {
                use.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                use.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                use.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}