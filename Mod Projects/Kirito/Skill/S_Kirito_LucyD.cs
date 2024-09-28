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
namespace Kirito
{
	/// <summary>
	/// 给我十秒钟时间
	/// 选择：抽取2个技能，附带迅速；
	/// 或者恢复3点法力值。
	/// </summary>
    public class S_Kirito_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Kirito_LucyD_0", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Kirito_LucyD_1", this.BChar, this.BChar.MyTeam));
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Kirito_LucyD_0")
            {
                Skill skill = Skill.TempSkill("S_Kirito_LucyD_0", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Kirito_LucyD_1")
            {
                Skill skill2 = Skill.TempSkill("S_Kirito_LucyD_1", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
            }
        }
    }
}