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
	/// 资产重组
	/// 展示所有弃牌库中持有者为目标的技能。
	/// 从牌库最上方将那个数量的技能送入弃牌库。
	/// 将展示的技能放回牌库随机位置。
	/// </summary>
    public class S_Morichika_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();
            foreach (Skill skill in this.BChar.MyTeam.Skills_UsedDeck)
            {
                if (skill.Master == Targets[0] && skill.CharinfoSkilldata != this.MySkill.CharinfoSkilldata)
                {
                    list.Add(skill);
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.ShowMySkill, true, true, true, false, true));

            for (int i = list.Count - 1; i >= 0; i--)
            {
                Skill tmpskill = BattleSystem.instance.AllyTeam.Skills_Deck[i];
                BattleSystem.instance.AllyTeam.Skills_Deck.Remove(tmpskill);
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Insert(0, tmpskill);
            }

            foreach (Skill skill in list)
            {
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(skill);
                BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, skill);
            }

            this.BChar.MyTeam.ShuffleDeck();
        }

        public void Del(SkillButton Mybutton)
        {
            
        }
    }
}