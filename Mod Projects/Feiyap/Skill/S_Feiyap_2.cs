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
namespace Feiyap
{
	/// <summary>
	/// 未完成的一文字
	/// 选择 - 自身获得 1 层“血似刃流”；
	/// 对目标施加 1 层“体内灼烧”。
	/// </summary>
    public class S_Feiyap_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public List<BattleChar> tar;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            tar = Targets;
            List<Skill> list = new List<Skill>();

            list.Add(Skill.TempSkill("S_Feiyap_2_1", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Feiyap_2_2", this.BChar, this.BChar.MyTeam));

            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Feiyap_2_1")
            {
                this.BChar.BuffAdd("B_Feiyap_0", this.BChar);
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Feiyap_2_2")
            {
                foreach (BattleChar bc in tar)
                {
                    bc.BuffAdd("B_Feiyap_1", this.BChar);
                }
            }
        }
    }
}