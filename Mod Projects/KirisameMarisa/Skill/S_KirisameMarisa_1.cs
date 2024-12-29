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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Escape Velocity」
	/// 当前额外伤害：&a
	/// 握在手中时，每次按下等待按钮，此技能的伤害增加&a点(攻击力的70%)。
	/// </summary>
    public class S_KirisameMarisa_1: SkillBase_KirisameMarisa
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_10_Ex).Particle_Path;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.Targets.Any((BattleChar t) => t == this.BChar), (Skill skill) => skill.IsDamage, BattleSystem.instance.TurnNum).Count == 0)
            {
                this.PlusSkillStat.cri = 100f;
                return;
            }
            this.PlusSkillStat.cri = 0f;
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.Targets.Any((BattleChar t) => t == this.BChar), (Skill skill) => skill.IsDamage, BattleSystem.instance.TurnNum).Count == 0)
            {
                this.PlusSkillStat.cri = 100f;
                base.SkillParticleOn();
                return;
            }
            this.PlusSkillStat.cri = 0f;
            base.SkillParticleOff();
        }
    }
}