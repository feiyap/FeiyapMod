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
namespace HouraisanKaguya
{
	/// <summary>
	/// 新难题「Mysterium」
	/// 抽取2个技能。
	/// 使目标身上最大持续时间不低于2回合的增益延长1回合。
	/// 使目标身上最大持续时间不低于2回合的减益降低1回合。
	/// </summary>
    public class S_FKaguya_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            List<Buff> list = new List<Buff>();
            foreach (Buff buff in Targets[0].Buffs)
            {
                if (!buff.BuffData.Hide && buff.LifeTime >= 2)
                {
                    if (buff.BuffData.Debuff)
                    {
                        buff.TurnUpdate();
                    }
                    else if (buff.BuffData.LifeTime != 0f)
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