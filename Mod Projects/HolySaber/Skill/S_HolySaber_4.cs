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
	/// 圣辉女剑士
	/// 无法使用进化点<color=#FFA500>进化</color>。
	/// <color=#FFC125>进化5</color> - 恢复2点法力值。
	/// <color=#FFA500>进化</color> - 额外造成&a(200%)伤害。
	/// </summary>
    public class S_HolySaber_4: SkillExtended_HolySaber
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckUsedExSkills(5))
                {
                    base.SkillParticleOn();
                    this.NotCount = true;
                }
                else
                {
                    base.SkillParticleOff();
                    this.NotCount = false;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (CheckUsedExSkills(5))
            {
                BattleSystem.instance.AllyTeam.AP += 2;
            }

            if (CheckUsedExSkills(10))
            {
                Skill tmpSkill = Skill.TempSkill("S_HolySaber_P_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 2.0f)).ToString());
        }
    }
}