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
	/// 爱丽丝漫游梦境
	/// 将目标变成“逆时行走的管家兔”
	/// 指向BOSS释放时无效。
	/// 【童话】：改为变成“半边假面的红王后”。
	/// </summary>
    public class S_FVAlice_Rare_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (!Targets[0].Info.Ally && !(Targets[0] as BattleEnemy).Boss)
            {
                foreach (Buff buff in Targets[0].Buffs)
                {
                    buff.SelfDestroy();
                }
                
                foreach (CastingSkill castingSkill in BattleSystem.instance.EnemyCastSkills)
                {
                    if (castingSkill.skill.Master == Targets[0])
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                    }
                }

                BattleSystem.instance.EnemyCastSkills.RemoveAll((CastingSkill a) => a.skill.Master == Targets[0]);

                if (this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") == null)
                {
                    BattleEnemy battleEnemy = Targets[0] as BattleEnemy;
                    GDEEnemyData gdeenemyData = new GDEEnemyData("Enemy_VillageAlice_Rabbit");
                    GameObject gameObject = battleEnemy.gameObject;
                    gameObject.SetActive(true);
                    BattleEnemy component = gameObject.GetComponent<BattleEnemy>();
                    component.init(gdeenemyData, BattleSystem.instance);

                    battleEnemy.BuffAdd("B_FVAlice_Rabbit_P", this.BChar);
                }
                else
                {
                    BattleEnemy battleEnemy = Targets[0] as BattleEnemy;
                    GDEEnemyData gdeenemyData = new GDEEnemyData("Enemy_VillageAlice_Queen");
                    GameObject gameObject = battleEnemy.gameObject;
                    gameObject.SetActive(true);
                    BattleEnemy component = gameObject.GetComponent<BattleEnemy>();
                    component.init(gdeenemyData, BattleSystem.instance);
                }
                
                BattleSystem.instance.EnemyTeam.UpdateEnemyList();
            }
        }
    }
}