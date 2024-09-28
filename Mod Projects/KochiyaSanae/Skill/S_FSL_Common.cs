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
	/// 风灵
	/// 指向敌人时，造成&a(40%)伤害。指向友军时，恢复&b(65%)体力。
	/// <b><color=green>连击2</color></b> - 获得一次性。
	/// </summary>
    public class S_FSL_Common:Skill_Extended
    {
        public override void Init()
        {
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count >= 2)
            {
                base.SkillParticleOn();
                this.Disposable = true;
            }
            else
            {
                base.SkillParticleOff();
                this.Disposable = false;
            }
        }

        public override void HandInit()
        {
            base.HandInit();
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.SkillBasePlusPreview.Target_BaseDMG = (int)((float)this.BChar.GetStat.atk * 0.4f);
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.IsDamage = false;
            this.IsHeal = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            if (!Targets[0].Info.Ally)
            {
                this.IsDamage = true;
                this.SkillBasePlus.Target_BaseDMG = (int)((float)this.BChar.GetStat.atk * 0.4f);
                this.PlusSkillPerStat.Heal = -99999;
            }
            else
            {
                this.IsHeal = true;
            }

            if (BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count >= 2)
            {
                this.Disposable = true;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.reg * 0.65f)).ToString());
        }
    }
}