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
namespace FFAce
{
	/// <summary>
	/// 翻牌
	/// 从牌库和弃牌库中翻出随机1张自己的技能。
	/// 根据牌上的[翻开]效果获得相应的效果，然后将牌放回原位。
	/// 若翻出的技能没有[翻开]效果，则将此技能置入手中。
	/// </summary>
    public class S_FFAce_P:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master != this.BChar)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            var filteredList = list.Except(P_FFAce.DrawList).ToList();
            int drawNum = this.BChar.BuffReturn("B_FFAce_LucyD")?.StackNum ?? 0;
            drawNum += 1;

            System.Random random = new System.Random();
            var list2 = filteredList.OrderBy(x => random.Next()).Take(drawNum).ToList();

            P_FFAce.DrawList = list2;

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list2, new SkillButton.SkillClickDel(this.Del), ModManager.getModInfo("FFAce").localizationInfo.SystemLocalizationUpdate("drawInfo"), false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            foreach (Skill_Extended se in Mybutton.Myskill.AllExtendeds)
            {
                if (se.Name == Mybutton.Myskill.MySkill.KeyID)
                {
                    (se as SkillBase_Ace).AceDraw();
                }
            }
        }
    }
}