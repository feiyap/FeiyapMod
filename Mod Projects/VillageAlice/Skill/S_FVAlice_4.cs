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
namespace VillageAlice
{
	/// <summary>
	/// 梦境速递
	/// 根据处于梦境的目标数量追加攻击。追加攻击造成混乱伤害。每次追加攻击造成&a点伤害(攻击力的50%)。
	/// 【童话】：消耗法力值并释放&user的固定能力。
	/// </summary>
    public class S_FVAlice_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = 0;
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.BuffFind("B_FVAlice_P_1"))
                {
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                BattleSystem.DelayInputAfter(this.Attack(Targets[0]));
            }

            if (this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
            {
                if (this.BChar.Info.BasicSkill != null)
                {
                    BattleSystem.DelayInput(this.Delay(this.BChar.Info.BasicSkill.SkillInfo.KeyID, Targets));
                }
            }
        }

        public IEnumerator Delay(string SkillD, List<BattleChar> Targets)
        {
            Skill skill = Skill.TempSkill(SkillD, this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.NotCount = true;

            yield return new WaitForSecondsRealtime(0.1f);
            
            if (Targets != null && Targets.Count != 0)
            {
                yield return BattleSystem.instance.ForceAction(skill.CloneSkill(true, skill.Master, null, false), Targets[0], false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill.CloneSkill(true, skill.Master, null, false), false, true, false);
            }

            yield break;
        }

        public IEnumerator Attack(BattleChar bc)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            Skill skill = Skill.TempSkill("S_FVAlice_4_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString())
                                          .Replace("&user", this.BChar.Info.Name);
        }
    }
}