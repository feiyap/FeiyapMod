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
	/// 宝符「阴阳宝玉」
	/// </summary>
    public class S_HakureiReimu_F_1: SkillExtended_Reimu
    {
        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    buffCount_N = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    buffCount_N = 0;
                }

                if (buffCount_N != buffCount_L && BattleSystem.instance != null && !this.MySkill.IsNowCounting)
                {
                    this.SkillChange("S_HakureiReimu_F_1", buffCount_N);
                }

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    this.buffCount_L = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    this.buffCount_L = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int count = CheckBuffNum();
            //if (!this.MySkill.FreeUse && count >= 1)
            //{
            //    if (count > 4)
            //    {
            //        count = 4;
            //    }

            //    Skill skill = this.MySkill.CloneSkill(false, null, null, false);
            //    skill.FreeUse = true;AutoDestroyPS
            //    skill.AP = 0;
            //    skill.Counting = -99;

            //    for (int i = 0; i < count; i++)
            //    {
            //        BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
            //    }
            //}

            BattleSystem.DelayInput(this.Effect(Targets[0], count));
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.1f);
            if (!Target.IsDead)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            }
            else if (Target.Info.Ally)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            yield break;
        }

        public IEnumerator Effect(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill("S_HakureiReimu_F_1_EX", this.BChar, this.BChar.MyTeam);
                    skill.MySkill.Effect_Target.DMG_Per = 25;
                    skill.PlusHit = true;
                    if (Target.IsDead && BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                    }
                    else
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, Target);
                    }
                }
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.25f)).ToString());
        }
    }
}