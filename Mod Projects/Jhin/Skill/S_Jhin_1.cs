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
	/// 曼舞手雷
	/// 击杀敌人时，生成 1 个该技能的非完美复制，并使其伤害提升44%，附带一次性、1回合后弃牌。
	/// </summary>
    public class S_Jhin_1:Skill_Extended
    {
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);

            Skill skill = this.MySkill.CloneSkill(true, null, null, true);
            skill.isExcept = true;
            skill.AutoDelete = 1;
            Skill_Extended skill_Extended = Skill_Extended.DataToExtended("SE_Jhin_1");
            skill.ExtendedAdd_Battle(skill_Extended);
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}