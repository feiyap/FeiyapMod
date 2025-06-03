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
	/// 日月符「皇家钻戒」
	/// 重置所有“高级元素”符卡的可组合次数。
	/// </summary>
    public class S_Pachi_Sk_5_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill skill) => skill.MySkill.KeyID != "S_Pachi_Sk_5_6"));

            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(excDeck, delegate (SkillButton skillbutton)
            {
                BV_ExceptDeck.RemoveSkill(skillbutton.Myskill);
                BattleSystem.instance.AllyTeam.Add(skillbutton.Myskill, false);
            }, ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("exceptSkillSelect"), true, true, true, false, true));

            for (int i = 0; i < 7; i++)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().sunUsed[i] = 0;
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().moonUsed[i] = 0;
            }

            BattleSystem.instance.GetBattleValue<BV_Pachi_P>().sunUsed[6] = 1;
            BattleSystem.instance.GetBattleValue<BV_Pachi_P>().moonUsed[5] = 1;
        }
    }
}