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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时计「月时计」
	/// </summary>
    public class S_Sakuya_P:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            //伤害
            if (this.BChar.BuffFind("B_Sakuya_4_new"))
            {
                Skill skill2 = Skill.TempSkill("S_Sakuya_4_new", this.BChar, this.BChar.MyTeam);
                skill2.isExcept = true;
                skill2.FreeUse = true;
                skill2.PlusHit = true;
                BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
            }
        }
    }
}