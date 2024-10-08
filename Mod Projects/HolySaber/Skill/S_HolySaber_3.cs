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
	/// 光灿圣骑士·维尔伯特
	/// <color=#4876FF>守护5</color> - 使手中这个技能<color=#FFA500>进化</color>。
	/// <color=#4876FF>守护10</color> - 额外获得[光灿圣骑]。
	/// <color=#FFA500>进化</color> - 额外造成&a(40%)伤害。
	/// </summary>
    public class S_HolySaber_3: SkillExtended_HolySaber
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
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
                    this.SkillChange(this.MySkill);
                }

                if (CheckUsedDefSkills(10))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            Skill tmpSkill = Skill.TempSkill("S_HolySaber_Token", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (CheckUsedDefSkills(10))
            {
                this.BChar.BuffAdd("B_HolySaber_3", this.BChar);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString());
        }
    }
}