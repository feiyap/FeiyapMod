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
	/// 狐耳圣骑士
	/// 生成2个[圣骑士]。
	/// <color=#4876FF>守护5</color> - 使生成的[圣骑士]<color=#FFA500>进化</color>。
	/// <color=#4876FF>守护10</color> - 使生成的[圣骑士]附带无视嘲讽和致命。
	/// <color=#FFA500>进化</color> - 额外造成&a(40%)伤害。
	/// </summary>
    public class S_HolySaber_5: SkillExtended_HolySaber
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

                if (CheckUsedDefSkills(5))
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

            if (CheckUsedDefSkills(5))
            {
                Skill tmpSkill = Skill.TempSkill("S_HolySaber_Token__Ex", this.BChar, this.BChar.MyTeam);
                Skill tmpSkill2 = Skill.TempSkill("S_HolySaber_Token__Ex", this.BChar, this.BChar.MyTeam);

                if (CheckUsedDefSkills(10))
                {
                    tmpSkill.IgnoreTaunt = true;
                    tmpSkill.Fatal = true;
                    tmpSkill2.IgnoreTaunt = true;
                    tmpSkill2.Fatal = true;
                }

                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }
            else
            {
                Skill tmpSkill = Skill.TempSkill("S_HolySaber_Token", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                Skill tmpSkill2 = Skill.TempSkill("S_HolySaber_Token", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString());
        }
    }
}