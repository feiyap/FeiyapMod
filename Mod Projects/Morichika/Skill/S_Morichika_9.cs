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
namespace Morichika
{
	/// <summary>
	/// 无中生有
	/// 在所选友军的所有技能中选择 1 个，在牌库中和手中各生成 1 个。
	/// </summary>
    public class S_Morichika_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();
            List<GDESkillData> list2 = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == Targets[0].Info.KeyData)
                {
                    list2.Add(gdeskillData);
                }
            }
            foreach (GDESkillData gdeskillData2 in list2)
            {
                if (gdeskillData2 != null && !gdeskillData2.KeyID.IsNullOrEmpty())
                {
                    Skill skill = Skill.TempSkill(gdeskillData2.KeyID, Targets[0], BattleSystem.instance.AllyTeam).CloneSkill(false, null, null, false);
                    skill.isExcept = true;
                    list.Add(skill);
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Add(Mybutton.Myskill, true);
            BattleSystem.instance.AllyTeam.Skills_Deck.Add(Mybutton.Myskill.CloneSkill());
            this.BChar.MyTeam.ShuffleDeck();
        }
    }
}