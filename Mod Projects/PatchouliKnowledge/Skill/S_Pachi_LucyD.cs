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
using BasicMethods;
namespace PatchouliKnowledge
{
	/// <summary>
	/// 元素萃取
	/// 抽取 2 个技能。
	/// 展示放逐牌库中所有“基本元素”技能，选择其中 1 个，在手中生成其复制。
	/// 展示放逐牌库中所有“魔法书”技能，选择其中 1 个，在手中生成其复制。
	/// </summary>
    public class S_Pachi_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill sk) => sk.MySkill.KeyID != "S_Pachi_LucyD"));

            List<Skill> CList = excDeck
                .Where(skill => P_PatchouliKnowledge.BaseElement.Contains(skill.MySkill.KeyID))
                .GroupBy(skill => skill.MySkill.KeyID)
                .Select(group => group.First()) // 每个KeyID只保留第一个Skill
                .ToList();

            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(CList, delegate (SkillButton skillbutton)
            {
                BattleSystem.instance.AllyTeam.Add(skillbutton.Myskill.CloneSkill(false, skillbutton.Myskill.Master), false);
            }, ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("exceptSkillSelect"), true, true, true, false, true));

            List<Skill> DList = excDeck
                .Where(skill => skill.MySkill.PlusCustomKeywords().Contains("Koakuma_MagicBook"))
                .GroupBy(skill => skill.MySkill.KeyID)
                .Select(group => group.First()) // 每个KeyID只保留第一个Skill
                .ToList();

            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(DList, delegate (SkillButton skillbutton)
            {
                BattleSystem.instance.AllyTeam.Add(skillbutton.Myskill.CloneSkill(false, skillbutton.Myskill.Master), false);
            }, ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("exceptSkillSelect"), true, true, true, false, true));
        }
    }
}