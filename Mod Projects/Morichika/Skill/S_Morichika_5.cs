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
namespace Morichika
{
    /// <summary>
    /// 售后服务
    /// 使所有友军的“保修服务”增益的持续时间延长 2 回合，并获得“保护体力极限”。
    /// 每有 1 个未持有“保修服务”增益的友军，恢复 1 点法力值。
    /// </summary>
    public class S_Morichika_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleChar battleChar in Targets)
            {
                if (battleChar.BuffFind("B_Morichika_P"))
                {
                    foreach (StackBuff stackBuff in battleChar.BuffReturn("B_Morichika_P")?.StackInfo)
                    {
                        stackBuff.RemainTime++;
                        stackBuff.RemainTime++;
                    }
                    battleChar.BuffReturn("B_Morichika_P")?.AddBuffEx(new B_Morichika_B_BuffEx());
                }
                else
                {
                    BattleSystem.instance.AllyTeam.AP++;
                }
            }
        }
    }
}