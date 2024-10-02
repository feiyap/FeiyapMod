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
	/// 造成的伤害提升50%。
	/// </summary>
    public class SE_Musoutensei_Satsuki_0:Skill_Extended, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            this.OnePassive = true;
            if (SkillD.IsDamage)
            {
                return Damage += BattleChar.CalculationResult((float)this.MySkill.TargetDamageOriginal, 50, 0);
            }
            return Damage;
        }
    }
}