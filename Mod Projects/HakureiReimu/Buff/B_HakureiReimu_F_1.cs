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
namespace HakureiReimu
{
	/// <summary>
	/// 灵力迸放
	/// 自身使用费用不低于2点的技能时，额外造成25%伤害。
	/// </summary>
    public class B_HakureiReimu_F_1:Buff, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.AP >= 2)
            {
                return (int)(Damage * 1.15);
            }
            return Damage;
        }
    }
}