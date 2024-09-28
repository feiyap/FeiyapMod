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
namespace Ralmia
{
	/// <summary>
	/// 发掘遗物
	/// 选择-从[迅袭的创造物] [守御的创造物] 中选1张打出。
	/// </summary>
    public class S_Ralmia_12:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Ralmia_9_1", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_9_3", this.BChar, this.BChar.MyTeam));
            foreach (Skill skill in list)
            {
                skill.DelObj = Targets[0];
            }
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Ralmia_9_1")
            {
                Skill skill = Skill.TempSkill("S_Ralmia_9_1", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Ralmia_9_3")
            {
                Skill skill3 = Skill.TempSkill("S_Ralmia_9_3", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill3, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
            }
        }
    }
}