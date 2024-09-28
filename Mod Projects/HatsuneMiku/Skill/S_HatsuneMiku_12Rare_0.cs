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
namespace HatsuneMiku
{
	/// <summary>
	/// アンノウン・マザーグース
	/// 赋予[未来之音]，直到和场上拥有[未来之音]层数的角色层数相同为止。
	/// </summary>
    public class S_HatsuneMiku_12Rare_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int max = 0;
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                int stackNum = battleChar.BuffReturn("B_HatsuneMiku_P", false).StackNum;
                if (max < stackNum)
                {
                    max = stackNum;
                }
            }

            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                int now = battleChar.BuffReturn("B_HatsuneMiku_P", false).StackNum;
                for (; now < max; now++)
                {
                    battleChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                }
            }
        }
    }
}