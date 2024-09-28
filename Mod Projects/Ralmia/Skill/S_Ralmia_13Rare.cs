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
namespace Ralmia
{
	/// <summary>
	/// 创世的创造物
	/// 如果这张卡拥有迅速，将1张[守卫的创造物]和1张[防御的创造物]加入手卡。若[本场战斗中，使用的创造物种类」为6种以上，将2张[加农的创造物]加入手卡。
	/// </summary>
    public class S_Ralmia_13Rare:Skill_Extended
    {
        private bool isSpecies;
        private bool useflag;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            int count = 0;
            if (this.BChar.BuffFind("B_Ralmia_3", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_4", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_5", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_6", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_7", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_8", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_9", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_10Rare", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_0", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_1", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_2", false))
            {
                count++;
            }
            if (count >= 6)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                if (!this.flag)
                {
                    this.flag = true;
                    this.NotCount = true;
                    return;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            useflag = true;
            if (this.NotCount || this.MySkill.NotCount)
            {
                Skill tmpSkill = Skill.TempSkill("S_Ralmia_13Rare_0", this.BChar, this.BChar.MyTeam);
                Skill tmpSkill2 = Skill.TempSkill("S_Ralmia_13Rare_1", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }
            
            if (this.isSpecies)
            {
                Skill tmpSkill3 = Skill.TempSkill("S_Ralmia_13Rare_2", this.BChar, this.BChar.MyTeam);
                Skill tmpSkill4 = Skill.TempSkill("S_Ralmia_13Rare_2", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill3, true);
                BattleSystem.instance.AllyTeam.Add(tmpSkill4, true);
            }
        }

        public bool flag;
    }
}