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
namespace Sunmeitian
{
	/// <summary>
	/// 化缘求斋
	/// 每有一个体力值为满的单位，抽取1个技能（最大不超过4张）。
	/// 超过4张的部分转化为获得等量法力值。
	/// </summary>
    public class S_Sunmeitian_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = 0;

            for (int i = 0; i < Targets.Count(); i++)
            {
                if (Targets[i].HP == Targets[i].GetStat.maxhp)
                {
                    if (count < 4)
                    {
                        BattleSystem.instance.AllyTeam.Draw();
                        count++;
                    }
                    else
                    {
                        BattleSystem.instance.AllyTeam.AP++;
                    }
                }
            }
        }
    }
}