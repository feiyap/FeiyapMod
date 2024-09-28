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
	/// 永远与须臾
	/// 对没有行动倒计时的敌人造成的伤害+10%
	/// </summary>
    public class B_FKaguya_P_0:Buff, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            BattleEnemy battleEnemy = Target as BattleEnemy;
            if (battleEnemy.SkillQueue.Count == 0)
            {
                Damage = Damage * 110 / 100;
            }
            return Damage;
        }
    }
}