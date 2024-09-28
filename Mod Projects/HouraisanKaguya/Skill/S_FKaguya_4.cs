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
namespace HouraisanKaguya
{
	/// <summary>
	/// 难题「火鼠的皮衣　-不焦躁的内心-」
	/// </summary>
    public class S_FKaguya_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.MyTeam.Skills.Find((Skill a) => a != this.MySkill && a.Master == this.BChar) == null)
            {
                this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            }

            if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
            {
                Targets[0].BuffScriptReturn("Common_Buff_EnemyTaunt").SelfDestroy(false);
                return;
            }
            Targets[0].BuffAdd(GDEItemKeys.Buff_B_EnemyTaunt, Targets[0], false, 0, false, -1, false);
        }
    }
}