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
	/// 秘法「九字切」
	/// </summary>
    public class S_Sanae_Rare11: SE_Sanae_Combo
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
            if (SkillUseCostZero() >= 10)
            {
                Skill tmpSkill = Skill.TempSkill("S_Sanae_Rare11_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }

            if (CheckUsedSkills(4))
            {
                this.SkillBasePlus.Target_BaseDMG = SkillUseCostZero();
            }
        }

        private int SkillUseCostZero()
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => skill.AP == 0, -1).Count;
        }

        public override string DescExtended(string desc)
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended(desc).Replace("&a", 0.ToString());
            }
            return base.DescExtended(desc).Replace("&a", (SkillUseCostZero()).ToString());
        }
    }
}