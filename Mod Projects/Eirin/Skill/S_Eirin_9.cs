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
namespace Eirin
{
	/// <summary>
	/// 炼丹「水银之海」
	/// 生成1张随机的通用治疗技能，使其费用-1。
	/// </summary>
    public class S_Eirin_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            new List<Skill>();
            List<GDESkillData> list = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.Category.Key == GDEItemKeys.SkillCategory_PublicSkill && gdeskillData.KeyID != "S_Public_29" && !gdeskillData.Disposable && (gdeskillData.HealSkill || gdeskillData.Effect_Target.HEAL_Per >= 1))
                {
                    list.Add(gdeskillData);
                }
            }
            GDESkillData gdeskillData2 = list.Random(this.BChar.GetRandomClass().Main);
            list.Remove(gdeskillData2);
            Skill skill = Skill.TempSkill(gdeskillData2.Key, this.BChar, BattleSystem.instance.AllyTeam).CloneSkill(false, null, null, false);
            skill.APChange = -1;
            BattleSystem.instance.EffectDelaysAfter.Enqueue(this.AddSkill(skill));
        }
        
        public IEnumerator AddSkill(Skill skill)
        {
            BattleSystem.instance.AllyTeam.Add(skill, true);
            yield break;
        }
    }
}