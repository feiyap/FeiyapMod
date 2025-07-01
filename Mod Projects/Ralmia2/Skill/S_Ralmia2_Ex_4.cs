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
namespace Ralmia2
{
	/// <summary>
	/// 毁灭的创造物α
	/// 【融合】『毁灭创造物β』或『毁灭创造物γ』
	/// 与本技能【融合】时，若与本技能【融合】的种类为 2，则本技能变为『卓越创造物Ω』。
	/// ————————————
	/// 握在手中时，每当回合结束，恢复自身 &a 体力值(攻击力的150%)。
	/// </summary>
    public class S_Ralmia2_Ex_4: SkillEn_Ralmia_0, IP_TurnEnd, IP_Fusion
    {
        public List<string> fusionlist = new List<string>();

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;

            fusionlist.Clear();
        }

        public void TurnEnd()
        {
            this.BChar.Heal(this.BChar, (float)((int)((double)this.BChar.GetStat.atk * 0.75)), false, false, null);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.75f)).ToString());
        }

        public void FusionCall(Skill skill)
        {
            if (skill != this.MySkill)
            {
                return;
            }
            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll(t => t.MySkill.KeyID == "S_Ralmia2_Ex_5" || t.MySkill.KeyID == "S_Ralmia2_Ex_6"));

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete();

            fusionlist.Add(Mybutton.Myskill.MySkill.KeyID);

            bool containsFirst = fusionlist.Contains("S_Ralmia2_Ex_5");
            bool containsSecond = fusionlist.Contains("S_Ralmia2_Ex_6");

            if (containsFirst && containsSecond)
            {
                this.MySkill.Delete();

                Skill skill = Skill.TempSkill("S_Ralmia2_Ex_7", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }

            foreach (IP_FusionAfter ip_fusionAfter in BattleSystem.instance.IReturn<IP_FusionAfter>())
            {
                if (ip_fusionAfter != null)
                {
                    ip_fusionAfter.FusionAfterCall();
                }
            }
        }
    }
}