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
	/// 禁弹「反折射」
	/// 命中时超额治疗自己5点体力。
	/// 禁忌 - 生成1张附带放逐、1回合后弃牌的禁弹「折反射」加入手中。
	/// </summary>
    public class S_FlandreScarlet_3_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            useflag = false;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            useflag = true;

            this.BChar.Heal(this.BChar, 5, this.BChar.GetCri(), true, null);

            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                Skill skill = Skill.TempSkill("S_FlandreScarlet_3", this.BChar, null);
                skill.isExcept = true;
                skill.AutoDelete = 2;
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
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