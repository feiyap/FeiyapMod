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
	/// 惜命
	/// 对自身造成痛苦伤害（30%最大体力值），将一张「不死之身的舍身击」加入手牌。
	/// </summary>
    public class S_Mokou_8:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(2, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (EX_ability.CheckEXburn(2, this.BChar))
            {
                Skill skill1 = Skill.TempSkill("S_Mokou_8_0", this.BChar, null);
                skill1.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill1, true);
                EX_ability.UseEXburn(2, this.BChar);
            }
            Skill skill = Skill.TempSkill("S_Mokou_8_0", this.BChar, null);
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}