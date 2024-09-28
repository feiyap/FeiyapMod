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
namespace Reisen
{
	/// <summary>
	/// 「幻胧月睨(Lunatic Red Eyes)」
	/// 必定命中。获得6颗[子弹]。使用这个技能击杀敌人时，从牌库和弃牌堆挑选1张自己的技能加入手中。
	/// </summary>
    public class S_Reisen_10Rare:Skill_Extended
    {
        public override bool TargetHit(BattleChar Target)
        {
            return true;
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);

            List<Skill> list = new List<Skill>();
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill.Master == this.BChar)
                {
                    list.Add(skill);
                }
            }
            foreach (Skill skill2 in BattleSystem.instance.AllyTeam.Skills_UsedDeck)
            {
                if (skill2.Master == this.BChar && skill2.MySkill.KeyID != this.MySkill.MySkill.KeyID)
                {
                    list.Add(skill2);
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