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
	/// 城堡的创造物
	/// 【融合】创造物。
	/// 根据与本技能【融合】的技能的费用的合计而变身：
	/// 1⇒『毁灭创造物α』
	/// 2⇒『毁灭创造物β』
	/// 3或以上⇒『毁灭创造物γ』
	/// ————————————
	/// </summary>
    public class S_Ralmia2_Ex_2: SkillEn_Ralmia_0, IP_Fusion
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
            this.BChar.Heal(this.BChar, (float)((int)((double)this.BChar.GetStat.atk * 0.75)), false, false, null);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.75f)).ToString());
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
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
            string skid = "";
            switch (Mybutton.Myskill.AP)
            {
                case 0:
                    {
                        return;
                    }
                case 1:
                    {
                        skid = "S_Ralmia2_Ex_4";
                        break;
                    }
                case 2:
                    {
                        skid = "S_Ralmia2_Ex_5";
                        break;
                    }
                default:
                    {
                        skid = "S_Ralmia2_Ex_6";
                        break;
                    }
            }

            this.MySkill.Delete();
            Mybutton.Myskill.Delete();

            Skill skill = Skill.TempSkill(skid, this.BChar, this.BChar.MyTeam);
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