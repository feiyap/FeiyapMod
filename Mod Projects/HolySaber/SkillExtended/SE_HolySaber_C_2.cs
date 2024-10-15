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
	/// 根据支付的费用，在手中生成相应数量的[圣骑士]。
	/// </summary>
    public class SE_HolySaber_C_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleChar battleChar = null;
            foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar2.Info.KeyData == "HolySaber")
                {
                    battleChar = battleChar2;
                }
            }
            if (battleChar != null)
            {
                for (int i = 0; i < SkillD.UsedApNum; i++)
                {
                    Skill skill = Skill.TempSkill("S_HolySaber_Token", battleChar, battleChar.MyTeam);
                    skill.NotCount = true;
                    skill.isExcept = true;
                    battleChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);
                }
            }
        }
    }
}