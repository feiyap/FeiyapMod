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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时符「隧穿效应」
	/// 抽取1个技能。
	/// 将牌堆1个技能置于牌堆顶部。
	/// 将手牌1个技能置于手牌顶部。
	/// </summary>
    public class S_Sakuya_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
            BattleSystem.DelayInput(this.Effect());

            /*
            List<Skill> list = new List<Skill>();
            for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills_Deck.Count; i++)
            {
                list.Add(BattleSystem.instance.AllyTeam.Skills_Deck[i]);
            }
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.TW_Red_4, true, true, true, false, true));
            */

            Skill tmpSkill2 = Skill.TempSkill("S_Sakuya_0_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
        }

        public IEnumerator Effect()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            list = RandomManager.Shuffle<Skill>(RandomClass.CreateRandomClass(this.BChar.GetRandomClass().Main), list);
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.UI_Skill.Lucy_23, false, true, true, false, true));
            yield return null;
            yield break;
        }


        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Skills_Deck.Remove(Mybutton.Myskill);
            BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, Mybutton.Myskill);
        }
    }
}