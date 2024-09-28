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
namespace Kirito
{
	/// <summary>
	/// 普通抽取
	/// </summary>
    public class S_Kirito_6_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<GDESkillData> list = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == this.BChar.Info.KeyData && !gdeskillData.NoDrop)
                {
                    list.Add(gdeskillData);
                }
            }
            List<GDESkillData> list2 = new List<GDESkillData>();
            list2.AddRange(list.Random(this.BChar.GetRandomClass().Main, 3));
            new List<Skill>();
            foreach (GDESkillData gdeskillData2 in list2)
            {
                Skill skill = Skill.TempSkill(gdeskillData2.Key, this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }
    }
}