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
	/// 黑白乱舞·诺尔与卜朗
	/// 弃牌：将1张0费的、附带放逐的黑白乱舞·诺尔与卜朗加入手牌，改为造成0.5倍攻击力。
	/// 觉醒：改为造成3倍攻击力伤害。获得1回合BUFF：保护体力极限。全抗性增加。
	/// </summary>
    public class S_Lumiore_6: SkillExtedned_IlyaP
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

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.atk * 3.0f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            if (!isSpecies)
            {
                return;
            }
            this.IsDamage = true;
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 2.0f);
            base.SkillUseSingle(SkillD, Targets);
            this.BChar.BuffAdd("B_Lumiore_6", this.BChar, false, 0, false, 1, false);
        }

        public override void IlyaWaste()
        {
            base.IlyaWaste();
            Skill tmpSkill = Skill.TempSkill("S_Lumiore_6_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}