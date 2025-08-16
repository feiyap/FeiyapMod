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
	/// 随机丢弃手中 2 个技能。
	/// </summary>
    public class S_FAlice_8_1 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = BattleSystem.instance.AllyTeam.Skills
                .FindAll(s => s != this.MySkill.OriginalSelectSkill)
                .Random(this.BChar.GetRandomClass().Main, 2);
            foreach (Skill skill in list)
            {
                skill.Delete();
            }
        }
    }
}