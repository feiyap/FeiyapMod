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
	/// 月火符「燃烧的哈雷」
	/// 同时指向目标左边和右边的敌人。
	/// </summary>
    public class S_Pachi_Sk_3_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0] is BattleEnemy)
            {
                if ((Targets[0] as BattleEnemy).istaunt)
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                    {
                        if (be != Targets[0] && be.istaunt)
                        {
                            Targets.Add(be);
                        }
                    }
                }
                else
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                    {
                        if (be != Targets[0] && !be.istaunt)
                        {
                            Targets.Add(be);
                        }
                    }
                }
            }
        }
    }
}