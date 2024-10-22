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
	/// 奇迹「白昼的客星」
	/// 生成1个[风灵]。
	/// <b><color=green>连击2</color></b> - 额外恢复&a(20%)体力。
	/// <b><color=green>连击4</color></b> - 施加[奇迹于你]：3回合；攻击力+12%。
	/// </summary>
    public class S_Sanae_2: SE_Sanae_Combo
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(2))
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
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            Skill tmpSkill = Skill.TempSkill("S_FSL_Common", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (CheckUsedSkills(2))
            {
                this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * 0.20f);
            }

            if (CheckUsedSkills(4))
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Sanae_2", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.2f)).ToString());
        }
    }
}