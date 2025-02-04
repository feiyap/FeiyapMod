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
	/// 禁弹「折反射」
	/// 技能出手时，受到&a(20%)痛苦伤害。
	/// 狂乱2 - 生成1张附带放逐、1回合后弃牌的禁弹「反折射」加入手中。
	/// </summary>
    public class S_FlandreScarlet_3:Skill_Extended
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

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            useflag = true;
            
            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && BattleSystem.instance.GetBattleValue<BV_FlandreScarlet_K>().count >= 2)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                Skill skill = Skill.TempSkill("S_FlandreScarlet_3_0", this.BChar, null);
                skill.isExcept = true;
                skill.AutoDelete = 2;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }

            if (this.BChar.HP > 0)
            {
                this.BChar.Damage(this.BChar, PlusDmg, false, true, false, 0, false, false, false);
            }
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();

            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && BattleSystem.instance.GetBattleValue<BV_FlandreScarlet_K>().count >= 2)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }

        private bool useflag;
    }
}