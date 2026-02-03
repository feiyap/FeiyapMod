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
namespace HiHouClab
{
	/// <summary>
	/// 未知之花、魅知之旅
	/// 展示倒计时栏中所有调查员的非稀有技能。
	/// 选择其中 1 个，使其从倒计时栏中移除，并生成 2 个完美复制，放回牌库随机位置。被放回牌库的技能的费用变为0。
	/// 那之后，抽取 2 个技能。
	/// </summary>
    public class S_Maribel_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();

            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (!cs.skill.MySkill.Rare)
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    list.Add(skill);
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (!cs.skill.MySkill.Rare)
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    list.Add(skill);
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill = Mybutton.Myskill.CloneSkill(true, null, null, false);
            Skill skill2 = Mybutton.Myskill.CloneSkill(true, null, null, false);
            skill.ExtendedAdd_Battle("SE_Maribel_8");
            skill2.ExtendedAdd_Battle("SE_Maribel_8");

            System.Random random = new System.Random();
            int randomIndex = random.Next(0, this.BChar.MyTeam.Skills_Deck.Count);
            BattleSystem.instance.AllyTeam.Skills_Deck.Insert(randomIndex, skill);
            int randomIndex2 = random.Next(0, this.BChar.MyTeam.Skills_Deck.Count);
            BattleSystem.instance.AllyTeam.Skills_Deck.Insert(randomIndex2, skill2);

            Debug.Log("A");
            BattleSystem.instance.AllyTeam.Draw(2);

            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    BattleSystem.instance.ActWindow.CastingWaste(cs);
                    BattleSystem.instance.CastSkills.Remove(cs);
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    BattleSystem.instance.ActWindow.CastingWaste(cs);
                    BattleSystem.instance.SaveSkill.Remove(cs);
                }
            }
        }
    }
}