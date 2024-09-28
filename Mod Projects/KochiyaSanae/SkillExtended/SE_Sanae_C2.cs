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
	/// 依据消耗的费用，生成等量的[东风灵]。
	/// </summary>
    public class SE_Sanae_C2:Skill_Extended
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
            if (battleChar != null)
            {
                for (int i = 0; i < SkillD.UsedApNum; i++)
                {
                    Skill skill = Skill.TempSkill("S_Sanae_P", battleChar, battleChar.MyTeam);
                    skill.NotCount = true;
                    skill.isExcept = true;
                    skill.AutoDelete = 1;
                    battleChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);
                }
            }
        }
    }
}