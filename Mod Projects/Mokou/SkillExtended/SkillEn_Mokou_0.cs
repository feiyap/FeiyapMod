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
namespace Mokou
{
	/// <summary>
	/// 过热：2——抽1回1
	/// </summary>
    public class SkillEn_Mokou_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "Mokou")
                {
                    if (EX_ability.CheckEXburn(2, battleAlly))
                    {
                        base.SkillParticleOn();
                    }
                    else
                    {
                        base.SkillParticleOff();
                    }
                }
            }
        }
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP <= 2;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "Mokou")
                {
                    if (EX_ability.CheckEXburn(2, battleAlly))
                    {
                        EX_ability.UseEXburn(2, battleAlly);
                        BattleSystem.instance.AllyTeam.Draw(1);
                        BattleSystem.instance.AllyTeam.AP += 1;
                    }
                }
            }
        }
    }
}