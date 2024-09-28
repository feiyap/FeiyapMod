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
namespace Lumiore
{
	/// <summary>
	/// 翱翔的龙人
	/// 丢弃1个手中费用最低的技能，抽1个技能。
	/// </summary>
    public class S_Lumiore_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));
            List<Skill> list2 = list.Skip(Math.Max(0, list.Count - 1)).Take(1).ToList<Skill>();
            for (int l = 0; l < list2.Count; l++)
            {
                list2[l].Delete(false);
            }
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}