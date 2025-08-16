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
namespace FAlice
{
	/// <summary>
	/// 在手中生成 1 个指定的「人形」技能。
	/// </summary>
    public class S_FAlice_7_1 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = P_FAlice.Dolls.Select(str => Skill.TempSkill(str, this.BChar, this.BChar.MyTeam)).ToList();
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list,
                button => { button.Myskill.isExcept = true; BattleSystem.instance.AllyTeam.Add(button.Myskill, false); },
                ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }
    }
}