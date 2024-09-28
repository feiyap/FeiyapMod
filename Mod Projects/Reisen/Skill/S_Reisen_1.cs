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
	/// 懒符「生神停止(Idling Wave)」
	/// 获得2次[等待]次数。
	/// </summary>
    public class S_Reisen_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            BattleSystem.instance.AllyTeam.WaitCount += 1;

            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
            {
                BattleSystem.instance.AllyTeam.WaitCount += 1;
                Targets[0].BuffAdd("B_Reisen_1_0", this.BChar, false, 0, false, -1, false);
            }
            else
            {
                Targets[0].BuffAdd("B_Reisen_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}