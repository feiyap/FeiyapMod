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
	/// <color=green>连击4</color> - 费用降低1点。
	/// 治疗技能
	/// </summary>
    public class SE_Shameimaru_C_1: SE_Shameimaru_Combo
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsHeal && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_self);
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
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(4))
                {
                    base.SkillParticleOn();
                    this.APChange = -1;
                }
                else
                {
                    base.SkillParticleOff();
                    this.APChange = 0;
                }
            }
        }
    }
}