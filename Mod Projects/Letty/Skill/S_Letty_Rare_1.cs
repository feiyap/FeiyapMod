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
namespace Letty
{
	/// <summary>
	/// 狂冬「暴风雪山庄」
	/// 将总计 4 个回合的“冻僵”效果平均分配给所有敌人。
	/// </summary>
    public class S_Letty_Rare_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets.Count > 0)
            {
                int totalTurns = 4;
                int baseTurns = totalTurns / Targets.Count;
                int remainder = totalTurns % Targets.Count;
                
                for (int i = 0; i < Targets.Count; i++)
                {
                    int turnsForThisEnemy = baseTurns;
                    if (i < remainder)
                    {
                        turnsForThisEnemy++;
                    }

                    if (turnsForThisEnemy > 0)
                    {
                        Targets[i].BuffAdd("B_Letty_P_1", this.BChar, false, 0, false, turnsForThisEnemy, false);
                    }
                }
            }
        }
    }
}