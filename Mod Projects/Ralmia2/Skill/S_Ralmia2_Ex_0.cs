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
	/// 过往核心
	/// 【融合】创造物。
	/// 与本技能【融合】时，本技能变为“城堡的创造物”。
	/// ————————————
	/// 无法使用。
	/// </summary>
    public class S_Ralmia2_Ex_0: SkillEn_Ralmia_0, IP_Fusion
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override bool Terms()
        {
            return false;
        }

        public void FusionCall(Skill skill)
        {
            if (skill != this.MySkill)
            {
                return;
            }
            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll(t => t != this.MySkill));
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].ExtendedFind_DataName("SkillEn_Ralmia_2") == null && list[i].ExtendedFind_DataName("SE_Ralmia_C_0") == null))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            this.MySkill.Delete();
            Mybutton.Myskill.Delete();

            Skill skill = Skill.TempSkill("S_Ralmia2_Ex_2", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);

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