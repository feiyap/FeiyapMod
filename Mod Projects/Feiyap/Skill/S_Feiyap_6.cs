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
namespace Feiyap
{
	/// <summary>
	/// 化身为神
	/// 使所有手中的技能获得随机<color=yellow>强化</color>。
	/// 如果这个技能拥有任意<color=yellow>强化</color>，额外使所有牌库中的技能获得随机<color=yellow>强化</color>。
	/// </summary>
    public class S_Feiyap_6:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.MySkill.Enforce)
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
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInput(this.Effect());
            
            if (this.MySkill.Enforce)
            {
                BattleSystem.DelayInput(this.Effect2());
            }
        }
        
        public IEnumerator Effect()
        {
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (!skill.Master.IsLucyNoC && !skill.Enforce)
                {
                    Skill_Extended skill_Extended = PlayData.GetBattleEnforce(skill).Random(this.BChar.GetRandomClass().Main);
                    if (skill_Extended != null)
                    {
                        skill.ExtendedAdd_Battle(skill_Extended);
                        skill.MyButton.InputData(skill, null, false);
                    }
                }
            }
            yield return null;
            yield break;
        }

        public IEnumerator Effect2()
        {
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (!skill.Master.IsLucyNoC && !skill.Enforce)
                {
                    Skill_Extended skill_Extended = PlayData.GetBattleEnforce(skill).Random(this.BChar.GetRandomClass().Main);
                    if (skill_Extended != null)
                    {
                        skill.ExtendedAdd_Battle(skill_Extended);
                    }
                }
            }
            yield return null;
            yield break;
        }
    }
}