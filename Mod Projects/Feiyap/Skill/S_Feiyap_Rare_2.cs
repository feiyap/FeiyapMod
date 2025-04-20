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
namespace Feiyap
{
	/// <summary>
	/// 无声星陨
	/// 若自身拥有保护体力极限，生成“星天陨辍”。
	/// </summary>
    public class S_Feiyap_Rare_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.GetStat.Strength)
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
            if (this.BChar.GetStat.Strength)
            {
                Skill skill = Skill.TempSkill("S_Feiyap_Rare_2_0", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }
    }
}