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
	/// 在手中随机生成 1 个「人形」技能，并使其费用转变为 0。
	/// </summary>
    public class SE_FAlice_C_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleChar FAlice = BattleSystem.instance.AllyTeam.AliveChars.Find(bc => bc.Info.KeyData == ModItemKeys.Character_FAlice);
            if (FAlice != null)
            {
                Skill skill = Skill.TempSkill(P_FAlice.Dolls.Random(FAlice.GetRandomClass().Main), FAlice, FAlice.MyTeam);
                skill.APChange = -99;
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }
    }
}