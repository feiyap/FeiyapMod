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
    /// 改境的天宫·阿洛艾特
    /// 将 1 个“过往核心”和“未来核心”加入手中。
    /// 那之后，选择自己手中 1 个费用为 2 或以下的“创造物”技能，获得其复制。
    /// </summary>
    public class S_Ralmia2_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Skill skill = Skill.TempSkill("S_Ralmia2_Ex_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);

            Skill skill2 = Skill.TempSkill("S_Ralmia2_Ex_1", this.BChar, this.BChar.MyTeam);
            skill2.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill2, true);

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

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill = Skill.TempSkill(Mybutton.Myskill.MySkill.KeyID, this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}