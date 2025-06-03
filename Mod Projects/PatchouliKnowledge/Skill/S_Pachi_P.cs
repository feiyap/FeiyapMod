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
using System.Linq;
using BasicMethods;
namespace PatchouliKnowledge
{
    /// <summary>
    /// 元素祈唤
    /// 从放逐牌库中选择2种“元素”属性，将其组合后获得对应的符卡技能。
    /// </summary>
    public class S_Pachi_P:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            P_PatchouliKnowledge.firstskill = null;
            P_PatchouliKnowledge.secondskill = null;

            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill sk) => sk.Master == this.BChar));

            List<Skill> CList = excDeck
                .Where(skill => P_PatchouliKnowledge.BaseElement.Contains(skill.MySkill.KeyID) || P_PatchouliKnowledge.RareElement.Contains(skill.MySkill.KeyID))
                .GroupBy(skill => skill.MySkill.KeyID)
                .Select(group => group.First()) // 每个KeyID只保留第一个Skill
                .ToList();

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(CList, new SkillButton.SkillClickDel(this.Del), ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("selectElement"), false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            P_PatchouliKnowledge.firstskill = Mybutton.Myskill;

            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill sk) => sk.Master == this.BChar));

            List<Skill> CList = excDeck
                .Where(skill => P_PatchouliKnowledge.BaseElement.Contains(skill.MySkill.KeyID) || P_PatchouliKnowledge.RareElement.Contains(skill.MySkill.KeyID))
                .GroupBy(skill => skill.MySkill.KeyID)
                .Select(group => group.First()) // 每个KeyID只保留第一个Skill
                .ToList();

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(CList, new SkillButton.SkillClickDel(this.Del2), ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("selectElement"), false, true, true, false, true));
        }

        public void Del2(SkillButton Mybutton)
        {
            P_PatchouliKnowledge.secondskill = Mybutton.Myskill;

            string newskill = P_PatchouliKnowledge.GetSkill(P_PatchouliKnowledge.firstskill, P_PatchouliKnowledge.secondskill);
            
            Skill tmpSkill = Skill.TempSkill(newskill, this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            P_PatchouliKnowledge.firstskill = null;
            P_PatchouliKnowledge.secondskill = null;
        }
    }
}