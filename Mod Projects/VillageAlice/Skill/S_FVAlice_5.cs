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
namespace VillageAlice
{
	/// <summary>
	/// 梦境失重
	/// 命中时，额外造成100%攻击力的混乱伤害。
	/// 【童话】：附加一次性。必定命中。
	/// </summary>
    public class S_FVAlice_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
                {
                    base.SkillParticleOn();
                    this.Disposable = true;
                }
                else
                {
                    base.SkillParticleOff();
                    this.Disposable = false;
                }

                if (this.MySkill.ExtendedFind_DataName("SkillExtended_FishingVillage") != null)
                {
                    this.MySkill.Delete(false);
                    Skill tmpSkill = Skill.TempSkill("S_FVAlice_5_0", this.BChar, this.BChar.MyTeam);
                    tmpSkill.isExcept = true;
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                }
            }
        }

        public override bool TargetHit(BattleChar Target)
        {
            return this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") != null;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            hit.ChaosDamage(this.BChar, (int)(this.BChar.GetStat.atk), false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString());
        }
    }
}