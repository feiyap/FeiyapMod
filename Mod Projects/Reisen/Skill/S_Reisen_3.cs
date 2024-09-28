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
	/// 惑视「离圆花冠(Corolla Vision)」
	/// 对目标以外的所有敌人造成&a(100%)伤害。
	/// 幻象/狂气 - 下个回合开始时，对所有敌人造成&b(50%)伤害。
	/// </summary>
    public class S_Reisen_3:Skill_Extended
    {
        //public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        //{
        //    for (int i = 0; i< BattleSystem.instance.EnemyTeam.AliveChars.Count;i++)
        //    {
        //        if (BattleSystem.instance.EnemyTeam.AliveChars[i] != Targets[0])
        //        {
        //            Skill skill = Skill.TempSkill("S_Reisen_3_0", this.BChar, this.BChar.MyTeam);
        //            skill.isExcept = true;
        //            skill.FreeUse = true;
        //            skill.PlusHit = true;
        //            skill.NoAttackTimeWait = true;
        //            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars[i]);
        //        }
        //    }

        //    if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
        //    {
        //        Targets[0].BuffAdd("B_Reisen_3", this.BChar, true, 0, false, -1, false);
        //    }
        //}

        //public override string DescExtended(string desc)
        //{
        //    return base.DescExtended(desc).Replace("&a", ((int)((float)(0 + this.BChar.GetStat.atk * 0.8f))).ToString()).Replace("&b", ((int)((float)(0 + this.BChar.GetStat.atk * 0.4f))).ToString());
        //}
    }
}