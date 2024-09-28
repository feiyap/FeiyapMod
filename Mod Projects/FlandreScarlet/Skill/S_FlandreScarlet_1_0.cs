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
	/// 禁忌「四重存在」
	/// 禁忌 - 命中时超额治疗自己2点体力。
	/// </summary>
    public class S_FlandreScarlet_1_0:Skill_Extended
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
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                this.BChar.Heal(this.BChar, 2, this.BChar.GetCri(), true, null);
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