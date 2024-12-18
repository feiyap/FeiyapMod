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
namespace YasakaKanano
{
	/// <summary>
	/// 神符「如水眼之美丽源泉」
	/// 从放逐牌库中选择1个技能，将其抽到手中。
	/// </summary>
    public class S_Kanano_Rare_3_1:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum1 == 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill skill) => skill.MySkill.KeyID != "S_Kanano_Rare_3_1"));

            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(excDeck, delegate (SkillButton skillbutton)
            {
                BV_ExceptDeck.RemoveSkill(skillbutton.Myskill);
                BattleSystem.instance.AllyTeam.Add(skillbutton.Myskill, false);
            }, ModManager.getModInfo("YasakaKanano").localizationInfo.SystemLocalizationUpdate("exceptSkillSelect"), true, true, true, false, true));

            BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum1++;
        }
    }
}