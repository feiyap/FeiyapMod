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
namespace FeiyapTank
{
	/// <summary>
	/// 朔风切
	/// 自身体力值低于 1 时才可使用。
	/// 释放时，所有调查员每失去 1 体力值，这个技能的伤害增加2%。
	/// </summary>
    public class S_FeiyapTank_2:Skill_Extended, IP_DamageChange_sumoperation
    {
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int count = 0;
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                count += bc.GetStat.maxhp - bc.HP;
            }
            PlusDamage = BattleChar.CalculationResult((float)Damage, count * 5, 0);
        }
    }
}