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
	/// 「全人类的绯想天」
	/// 消耗所有气质，每点消耗的气质使这个技能向随机敌人重复释放 1 次。
	/// 每次释放，自身获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class S_Tenshi_Rare_1: SkillBase_Tenshi
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
            }

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi; i++)
            {
                BattleSystem.DelayInput(this.PlusAttack(Targets[0]));
            }

            BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi = 0;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            AddTenki(this.BChar, 1);
        }

        public IEnumerator PlusAttack(BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Skill skill = Skill.TempSkill("S_Tenshi_Rare_1", this.BChar, this.BChar.MyTeam);
            if (this.BChar != null && !this.BChar.Dummy && !this.BChar.IsDead)
            {
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield break;
        }
    }
}