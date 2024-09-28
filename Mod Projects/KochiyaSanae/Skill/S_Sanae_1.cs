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
namespace KochiyaSanae
{
	/// <summary>
	/// 秘术「一脉单传之弹幕」
	/// <b><color=green>连击4</color></b> - 将1张0费的[秘术「一脉单传之弹幕」]加入手中。
	/// </summary>
    public class S_Sanae_1: SE_Sanae_Combo
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (CheckUsedSkills(4))
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
            if (CheckUsedSkills(4))
            {
                Skill tmpSkill = Skill.TempSkill("S_Sanae_1_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}