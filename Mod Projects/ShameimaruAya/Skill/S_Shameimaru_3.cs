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
namespace ShameimaruAya
{
	/// <summary>
	/// 风符「天狗道的开风」
	/// 使用这个技能击杀敌人后，将1张0费的[风符「天狗道的开风」]加入手中。
	/// <b><color=green>连击12</color></b> - 额外造成&a(125%)伤害。
	/// </summary>
    public class S_Shameimaru_3: SE_Shameimaru_Combo
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 1.0));
            }
        }

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
                if (CheckUsedSkills(12))
                {
                    base.SkillParticleOn();
                    this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
                }
                else
                {
                    base.SkillParticleOff();
                    this.SkillBasePlus.Target_BaseDMG = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG = 0;

            if (CheckUsedSkills(12))
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            Skill tmpSkill = Skill.TempSkill("S_Shameimaru_3", this.BChar, this.BChar.MyTeam);
            tmpSkill.APChange -= 3;
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}