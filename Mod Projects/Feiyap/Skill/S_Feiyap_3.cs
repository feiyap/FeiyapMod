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
namespace Feiyap
{
	/// <summary>
	/// 天市右垣七
	/// 展示牌库和弃牌库中所有自己的技能。选择其中 1 个拿回手中。
	/// </summary>
    public class S_Feiyap_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck.FindAll(t => t.MySkill.KeyID != "S_Feiyap_3"));
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck.FindAll(t => t.MySkill.KeyID != "S_Feiyap_3"));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master.IsLucyNoC || list[i].Master != this.BChar)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);
        }
    }
}