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
namespace HinanawiTenshi
{
	/// <summary>
	/// 地符「不让土壤之剑」
	/// 攻击后，若目标不是濒死状态，则再次攻击目标。
	/// 每次命中获得1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class Boss_S_Tenshi_1: SkillBase_Tenshi
    {
        public override void Init()
        {
            base.Init();
            this.EnemyPreviewNoArrow = true;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInput(this.AfterAttack(Targets[0]));
        }
        
        public IEnumerator AfterAttack(BattleChar Target)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (Target.HP >= 1)
            {
                Skill skill = Skill.TempSkill("Boss_S_Tenshi_1", this.BChar, this.BChar.MyTeam);
                this.BChar.ParticleOut(skill, Target);
            }
            yield break;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            AddTenki(this.BChar, 1);
        }
    }
}