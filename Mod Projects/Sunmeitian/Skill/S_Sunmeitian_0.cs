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
namespace Sunmeitian
{
	/// <summary>
	/// 粉碎打击
	/// 如果自身拥有[真假猴王]，以50%效率重复释放。
	/// </summary>
    public class S_Sunmeitian_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (!this.MySkill.FreeUse && this.BChar.BuffFind("B_Sunmeitian_1"))
            {
                Skill skill = this.MySkill.CloneSkill(false, null, null, false);
                skill.MySkill.Effect_Target.DMG_Per /= 2;
                skill.NotCount = true;
                skill.AP = 0;
                skill.Counting = -99;
                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
            }
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.2f);
            if (!Target.IsDead)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            }
            else if (Target.Info.Ally)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            yield break;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Sunmeitian_1", false))
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