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
namespace HolySaber
{
	/// <summary>
	/// 施加<color=#4876FF>守护</color>减益。<i>这个技能被视作带有<color=#4876FF>守护</color>减益的技能。</i>
	/// 攻击技能
	/// </summary>
    public class SE_HolySaber_C_1: SE_HolySaber_Defend
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && base.CanSkillEnforce(MainSkill);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleChar bc in Targets)
            {
                bc.BuffAdd("B_HolySaber_Def", this.BChar);
            }
        }
    }
}