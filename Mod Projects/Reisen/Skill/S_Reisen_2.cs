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
namespace Reisen
{
	/// <summary>
	/// 狂符「幻视调律(Visionary Tuning)」
	/// 获得1次[等待]次数。
	/// </summary>
    public class S_Reisen_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            BattleSystem.instance.AllyTeam.WaitCount += 1;

            Targets[0].BuffAdd("B_Reisen_2", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_Reisen_Insane", this.BChar, false, 0, false, -1, false);

            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
            {
                Targets[0].BuffAdd("B_Reisen_2_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}