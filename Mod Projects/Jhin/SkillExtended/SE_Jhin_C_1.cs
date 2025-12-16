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
namespace Jhin
{
	/// <summary>
	/// 无视嘲讽。施加(144%干扰)“穿帮”。
	/// 攻击技能
	/// </summary>
    public class SE_Jhin_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage;
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.IgnoreTaunt = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].BuffAdd("B_Jhin_4", this.BChar);
        }
    }
}