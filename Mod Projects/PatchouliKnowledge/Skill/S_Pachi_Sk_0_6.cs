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
	/// 月金符「日光反射器」
	/// 将目标变为一只人畜无害的小动物。
	/// 若目标是友军，还会驱散所有减益效果，且恢复 2 点法力值。
	/// 若目标是Boss，则改为眩晕 1 回合。
	/// </summary>
    public class S_Pachi_Sk_0_6:Skill_Extended
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

                if (RandomManager.RandomPer(this.BChar.GetRandomClass().Main, 100, 50))
                {
                    BattleEnemy battleEnemy = Targets[0] as BattleEnemy;
                    GDEEnemyData gdeenemyData = new GDEEnemyData("E_Pachi_Zhu");
                    GameObject gameObject = battleEnemy.gameObject;
                    gameObject.SetActive(true);
                    BattleEnemy component = gameObject.GetComponent<BattleEnemy>();
                    component.init(gdeenemyData, BattleSystem.instance);
                }
                else
                {
                    BattleEnemy battleEnemy = Targets[0] as BattleEnemy;
                    GDEEnemyData gdeenemyData = new GDEEnemyData("S1_Dochi_L");
                    GameObject gameObject = battleEnemy.gameObject;
                    gameObject.SetActive(true);
                    BattleEnemy component = gameObject.GetComponent<BattleEnemy>();
                    component.init(gdeenemyData, BattleSystem.instance);
                }

                BattleSystem.instance.EnemyTeam.UpdateEnemyList();
            }

            if (Targets[0].Info.Ally)
            {
                for (int i = 0; i < Targets[0].Buffs.Count; i++)
                {
                    if (Targets[0].Buffs[i].BuffData.Debuff && !Targets[0].Buffs[i].CantDisable)
                    {
                        Targets[0].Buffs[i].SelfDestroy(false);
                    }
                }
            }

            if ((Targets[0] as BattleEnemy).Boss)
            {
                Targets[0].BuffAdd("B_Common_Rest", this.BChar, false, 999);
            }
        }
    }
}