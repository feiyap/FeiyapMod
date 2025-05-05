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
namespace Parsee
{
	/// <summary>
	/// 妒符「绿眼怪物」
	/// 释放时，如果妒火层数≥4，则所有敌人持有的痛苦减益、弱化减益持续时间增加1回合；
	/// 如果妒火层数≤2，则所有队员持有的减益持续时间减少1回合。
	/// </summary>
    public class S_Parsee_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Buff> list = new List<Buff>();
            if (this.BChar.BuffReturn("B_Parsee_P")?.StackNum >= 4)
            {
                foreach (BattleChar bc in BattleSystem.instance.EnemyList)
                {
                    foreach (Buff buff in bc.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, true, false))
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
                    foreach (Buff buff in bc.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false))
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

            if (this.BChar.BuffReturn("B_Parsee_P")?.StackNum <= 2)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    foreach (Buff buff in bc.Buffs)
                    {
                        if (!buff.BuffData.Hide)
                        {
                            if (buff.BuffData.Debuff)
                            {
                                buff.TurnUpdate();
                            }
                        }
                    }
                }
            }
        }
    }
}