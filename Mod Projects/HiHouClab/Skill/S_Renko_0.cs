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
namespace HiHouClab
{
	/// <summary>
	/// 走在夜晚的莲台野
	/// 可以无视嘲讽指向持有“量子纠缠”的敌人。
    /// 目标的剩余体力值百分比越高，这个技能的伤害越高(最多提升100%)。
	/// </summary>
    public class S_Renko_0:Skill_Extended, IP_DamageChange_sumoperation
    {
        public override bool CanIgnoreTauntTarget(BattleChar IgnoreTauntTarget)
        {
            return IgnoreTauntTarget.BuffFind("B_Renko_5") || base.CanIgnoreTauntTarget(IgnoreTauntTarget);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = (int)(Target.HP * 100 / Target.GetStat.maxhp);

            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }
    }
}