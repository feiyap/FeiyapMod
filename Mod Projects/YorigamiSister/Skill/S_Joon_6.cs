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
namespace YorigamiSister
{
	/// <summary>
	/// 珠光指虎
	/// 这个技能暴击时，如果金币不低于 50，则消耗 50 金币，追加一次 &a 伤害的攻击(攻击力的100%)。
	/// </summary>
    public class S_Joon_6:Skill_Extended, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = P_YorigamiJoon.calculateTotalEquipQuality(this.BChar) * 10;

            Debug.Log(num);

            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }
    }
}