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
namespace Yuyuko
{
	/// <summary>
	/// <color=#8B008B>亡乡「亡我乡 -无道之路-」</color>
	/// 放逐目标技能，并依据放逐技能的费用，每点费用减少50返魂值。
	/// </summary>
    public class S_YuyukoF_P_3:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].Except();
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-100);

            {
                List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill sk) => sk.MySkill.KeyID != "S_YuyukoF_P_3"));

                if (excDeck.Count > 0)
                {
                    BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(excDeck, delegate (SkillButton skillbutton)
                    {
                        BV_ExceptDeck.RemoveSkill(skillbutton.Myskill);
                        BattleSystem.instance.AllyTeam.Add(skillbutton.Myskill, true);
                    }, ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("exceptSkill"), true, true, true, false, true));
                }
            }
        }
    }
}