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
	/// 改境的重启
	/// 选择自己手中 2 个费用为 2 或以下的“创造物”技能，获得其复制，并附带“1回合后丢弃”。
	/// </summary>
    public class S_Ralmia2_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll(t => t.MySkill.KeyID != "S_Ralmia2_4"));
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].ExtendedFind_DataName("SkillEn_Ralmia_2") == null && list[i].ExtendedFind_DataName("SE_Ralmia_C_0") == null) || list[i]._AP > 2)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill = Skill.TempSkill(Mybutton.Myskill.MySkill.KeyID, this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}