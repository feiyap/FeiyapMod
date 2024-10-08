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
namespace HolySaber
{
	/// <summary>
	/// 背理盾·杰诺
	/// 抽取2个技能。
	/// 若圣辉女剑士存活，生成1个持有者为圣辉女剑士的[圣骑士]。
	/// </summary>
    public class S_HolySaber_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.KeyData == "HolySaber")
                    {
                        Skill tmpSkill = Skill.TempSkill("S_HolySaber_Token", enumerator.Current, enumerator.Current.MyTeam);
                        BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                        break;
                    }
                }
            }
        }
    }
}