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
	/// 自动化
	/// 选择-从[解析的创造物] [古老的创造物] [神秘的创造物] [绚烂的创造物] 选择二种，各增加二张附带放逐的技能到牌堆中。
	/// </summary>
    public class S_Ralmia_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Ralmia_0", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_1", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_2", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Ralmia_3", this.BChar, this.BChar.MyTeam));
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            this.tmpSkill = Mybutton.Myskill;
            this.tmpSkill.isExcept = true;
            this.tmpSkill2 = Mybutton.Myskill;
            this.tmpSkill2.isExcept = true;
            this.BChar.MyTeam.Skills_Deck.InsertRandom(this.tmpSkill);
            this.BChar.MyTeam.Skills_Deck.InsertRandom(this.tmpSkill2);
            list.Remove(Mybutton.Myskill);
        }
        
        private Skill tmpSkill;
        private Skill tmpSkill2;
        private List<Skill> list;
    }
}