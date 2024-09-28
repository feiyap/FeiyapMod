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
namespace KochiyaSanae
{
	/// <summary>
	/// <color=green>连击2</color> - 生成1个[风灵]。
	/// </summary>
    public class SE_Sanae_C1: SE_Sanae_Combo
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleChar battleChar = null;
            foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar2.Info.KeyData == "KochiyaSanae")
                {
                    battleChar = battleChar2;
                }
            }
            if (CheckUsedSkills(2))
            {
                Skill tmpSkill = Skill.TempSkill("S_FSL_Common", battleChar, battleChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}