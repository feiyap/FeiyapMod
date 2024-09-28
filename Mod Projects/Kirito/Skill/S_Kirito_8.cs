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
	/// 羁绊
	/// 每回合获得1层[心意]，最多5层。
	/// 当有人进入濒死状态时，消耗所有[心意]层数，每层消耗掉的[心意]使自己获得3%攻击力、4%暴击率、2%命中率，并解除所有友军的减益。
	/// </summary>
    public class S_Kirito_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<GDESkillData> list = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == Targets[0].Info.KeyData && !gdeskillData.NoDrop)
                {
                    list.Add(gdeskillData);
                }
            }
            List<GDESkillData> list2 = new List<GDESkillData>();
            list2.AddRange(list.Random(this.BChar.GetRandomClass().Main, 2));
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