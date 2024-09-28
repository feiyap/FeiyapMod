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
namespace Lumiore
{
	/// <summary>
	/// 甲槌岩龙
	/// 丢弃1个技能，抽1个技能。
	/// </summary>
    public class S_Lumiore_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));
            foreach (Skill skill in list)
            {
                skill.DelObj = Targets[0];
            }
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}