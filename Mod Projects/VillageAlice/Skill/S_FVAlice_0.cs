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
	/// 梦境信件
	/// 处于[梦境]时，再次释放一次此技能。
	/// 【童话】：手牌中随机一个调查队员的技能被【童话】化。
	/// </summary>
    public class S_FVAlice_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FVAlice_P_1"))
            {
                BattleSystem.DelayInput(this.PlusAttack(Targets[0], SkillD));
            }

            if (SkillD.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
            {
                new List<Skill>();
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == this.MySkill || list[i].ExtendedFind_DataName("SkillExtended_Fairytale") != null)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }

                System.Random random = new System.Random();
                int index = random.Next(list.Count);

                list[index].ExtendedAdd(Skill_Extended.DataToExtended("SkillExtended_Fairytale"));
            }
        }
        
        public IEnumerator PlusAttack(BattleChar hit, Skill SkillD)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            Skill skill = SkillD.CloneSkill(true, this.BChar, null, false);
            if (this.BChar != null && !this.BChar.Dummy && !this.BChar.IsDead)
            {
                if (!hit.IsDead)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, hit);
                }
                else if (BattleSystem.instance.EnemyList.Count > 0)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
                }
            }
            yield break;
        }
    }
}