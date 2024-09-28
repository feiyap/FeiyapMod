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
namespace Mokou
{
	/// <summary>
	/// 不死「凯风快晴飞翔蹴」
	/// 命中时结算并移除目标身上的烧伤。
	/// </summary>
    public class S_Mokou_9:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(1, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (EX_ability.CheckEXburn(1, this.BChar))
            {
                Skill skill = Skill.TempSkill("S_Mokou_9", this.BChar, null);
                skill.AutoDelete = 1;
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
                EX_ability.UseEXburn(1, this.BChar);
            }
        }
    }
}