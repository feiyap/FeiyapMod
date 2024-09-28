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
namespace Inaba
{
	/// <summary>
	/// 幸符「四叶的守护」
	/// 抽取2个技能。
	/// 从<color=#FFD700>帝的豪华奖池</color>中随机触发1个效果。
	/// </summary>
    public class S_Inaba_LucyD: SE_Inaba_Draw
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.KeyData == "Inaba")
                    {
                        InabaDraw(1, true);
                        break;
                    }
                }
            }
        }
    }
}