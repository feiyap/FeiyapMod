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
namespace HouraisanKaguya
{
	/// <summary>
	/// 「永夜归返  -世间开明-」
	/// 这个伤害的25%超额治疗自己。
	/// 这个伤害的25%转化为自己的保护罩。
	/// 重复释放1次。
	/// <color=yellow><i>永夜归返光初露，
	/// 世间开明渐破晓。</i></color>
	/// </summary>
    public class S_FKaguya_10Rare_19: SkillExtended_10Rare
    {
        public override bool Terms()
        {
            return true;
        }

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            base.SkillParticleOn();
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 0.25f)), this.BChar.GetCri(), true, null);
            this.BChar.BuffAdd("B_FKaguya_10Rare_17", this.BChar, false, 0, false, -1, false).BarrierHP += (int)((float)DMG * 0.25f);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (!this.MySkill.FreeUse)
            {
                Skill skill = this.MySkill.CloneSkill(false, null, null, false);
                skill.NotCount = true;
                skill.AP = 0;
                skill.Counting = -99;
                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
            }
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.5f);
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
    }
}