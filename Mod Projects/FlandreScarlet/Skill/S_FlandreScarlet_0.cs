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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁弹「星弧破碎」
	/// 技能出手时，受到&a(20%)痛苦伤害。
	/// 禁忌 - 额外造成&b(80%)伤害。这个技能暴击率+30%。
	/// </summary>
    public class S_FlandreScarlet_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            useflag = false;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.2f));
            }
        }

        public int PlusDmg2
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.8f));
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString()).Replace("&b", (PlusDmg2).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            useflag = true;

            if (this.BChar.HP > 0)
            {
                this.BChar.Damage(this.BChar, PlusDmg, false, true, false, 0, false, false, false);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false) 
                || this.BChar.BuffFind("B_FlandreScarlet_7", false) 
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg2;
                this.PlusSkillStat.cri = 30f;
                this.PlusSkillStat.hit = 30f;
            }
            else
            {
                base.SkillParticleOff();
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillStat.cri = 0f;
                this.PlusSkillStat.hit = 0f;
            }
        }

        private bool useflag;
    }
}