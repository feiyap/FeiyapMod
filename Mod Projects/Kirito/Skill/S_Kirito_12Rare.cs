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
	/// 二刀流
	/// 自己获得1回合BUFF[金色威信]。
	/// 然后回复3点AP。若[本场战斗中，丢弃手牌的次数]大于4次，丢弃2个技能，抽取3个技能。
	/// </summary>
    public class S_Kirito_12Rare:Skill_Extended
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
                Skill skill = Skill.TempSkill(gdeskillData2.Key, Targets[0], Targets[0].MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }
    }
}