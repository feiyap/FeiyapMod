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
namespace Letty
{
	/// <summary>
	/// 冬符「北极的胜利者」
	/// 目标每有1%干扰抵抗率，这个技能增加1%伤害。
	/// </summary>
    public class S_Letty_7:Skill_Extended, IP_DamageChange_sumoperation
    {
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = (int)Target.GetStat.RES_CC;

            if (num < 0)
            {
                num = 0;
            }

            PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
        }
    }
}