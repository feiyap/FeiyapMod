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
namespace Lumiore
{
	/// <summary>
	/// 龙之恩泽
	/// 使自己最大法力值+1。
	/// 觉醒：治疗&a。抽取2个技能。
	/// </summary>
    public class S_Lumiore_8:Skill_Extended
    {
        private bool useflag;
        private bool isSpecies;

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
            if (this.BChar.MyTeam.MAXAP >= 7)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            BattleSystem.instance.AllyTeam.LucyChar.BuffAdd("B_Lumiore_5", BattleSystem.instance.AllyTeam.LucyChar, true, 0, false, -1, false);

            if (!isSpecies)
            {
                return;
            }

            this.BChar.Heal(this.BChar, (int)(this.BChar.GetStat.atk * 0.5f), false, false, null);
            BattleSystem.instance.AllyTeam.Draw();
            BattleSystem.instance.AllyTeam.Draw();
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}