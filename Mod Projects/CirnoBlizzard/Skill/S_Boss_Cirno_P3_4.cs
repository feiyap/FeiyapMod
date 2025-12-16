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
namespace CirnoBlizzard
{
	/// <summary>
	/// 浅冬
	/// 攻击目标以及相邻的调查员。
	/// </summary>
    public class S_Boss_Cirno_P3_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

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

                    if (num != 0)
                    {
                        list.Add(allyList[num - 1]);
                    }
                    else
                    {
                        list.Add(allyList[BattleSystem.instance.AllyTeam.AliveChars.Count - 1]);
                    }

                    if (list.Count != 0)
                    {
                        Targets.AddRange(list);
                    }
                }
            }
        }
    }
}