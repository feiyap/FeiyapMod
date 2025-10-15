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
	/// 寒符「延长的冬日」
	/// 使所有目标的增益和减益的持续时间延长 1 回合。
	/// </summary>
    public class S_Letty_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleChar battleChar in Targets)
            {
                foreach (Buff buff in battleChar.Buffs)
                {
                    if (!buff.BuffData.Hide)
                    {
                        if (buff.BuffData.LifeTime != 0f)
                        {
                            foreach (StackBuff stackBuff in buff.StackInfo)
                            {
                                stackBuff.RemainTime++;
                            }
                        }
                    }
                }
            }
        }
    }
}