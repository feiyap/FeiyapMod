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
namespace HinanawiTenshi
{
	/// <summary>
	/// 「全人类的绯想天」
	/// 丢弃所有技能。抽取等量的技能。
	/// </summary>
    public class Boss_S_Tenshi_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = BattleSystem.instance.AllyTeam.Skills.Count;
            List<Skill> list = new List<Skill>();
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill != this.MySkill)
                {
                    list.Add(skill);
                }
            }
            foreach (Skill skill2 in list)
            {
                skill2.Delete(false);
            }
            BattleSystem.instance.AllyTeam.Draw(count);
        }
    }
}