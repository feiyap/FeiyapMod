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
	/// 禁忌「恋之迷宫」
	/// 技能出手时，受到&a(20%)痛苦伤害。
	/// 禁忌 - 不再受到痛苦伤害。造成&b(50%)点额外伤害。
	/// 狂乱4 - 场上每有1个敌人，造成&c(20%)点额外伤害。
	/// </summary>
    public class S_FlandreScarlet_4:Skill_Extended
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
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.2f));
            }
        }

        public int PlusDmg3
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

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString()).Replace("&b", (PlusDmg2).ToString()).Replace("&c", (PlusDmg3).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            useflag = true;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();

            if ((this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
                && ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 4)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false)))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg2 + PlusDmg3 * BattleSystem.instance.EnemyList.Count;
                return;
            }
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg2;
                return;
            }
            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 4)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg3 * BattleSystem.instance.EnemyList.Count;
                return;
            }
            base.SkillParticleOff();
        }

        private bool useflag;
    }
}