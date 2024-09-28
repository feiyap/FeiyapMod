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
	/// 创造物的同步
	/// 选择-从[解析的创造物] [古老的创造物] [绚烂的创造物] [典范转移] 中选1张加入手牌。
	/// </summary>
    public class S_Ralmia_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Ralmia_0", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_1", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_3", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_9_0", this.BChar, this.BChar.MyTeam));
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            this.tmpSkill = Mybutton.Myskill;
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }

        private Skill tmpSkill;
    }
}