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
    /// 水木符「水精灵」
    /// 释放时，同时对目标右边的角色释放。
    /// 每个等级的“水”使这个技能额外治疗&a点体力(治疗力的10%)。
    /// 每个等级的“木”额外施加1层“活水之精”。
    /// </summary>
    public class S_Pachi_Sk_1_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally)
            {
                if (BattleSystem.instance.AllyList.Count != 1)
                {
                    int num = 0;
                    for (int i = 0; i < BattleSystem.instance.AllyTeam.AliveChars.Count; i++)
                    {
                        if (BattleSystem.instance.AllyTeam.AliveChars[i] == Targets[0])
                        {
                            num = i;
                        }
                    }
                    List<BattleAlly> allyList = BattleSystem.instance.AllyList;
                    List<BattleChar> list = new List<BattleChar>();
                    if (allyList.Count > num + 1)
                    {
                        list.Add(allyList[num + 1]);
                    }
                    else
                    {
                        list.Add(allyList[0]);
                    }
                    if (list.Count != 0)
                    {
                        Targets.AddRange(list);
                    }
                }
            }

            this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]));

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1]; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Pachi_1_2", this.BChar);
                }
            }
        }
    }
}