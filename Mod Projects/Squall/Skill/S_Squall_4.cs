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
namespace Squall
{
	/// <summary>
	/// 残月轨迹
	/// 消耗最多6层[刃甲]。
	/// 每消耗1层[刃甲]使伤害增加4%，并重复释放1次。
	/// </summary>
    public class S_Squall_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = this.BChar.BuffReturn("B_Squall_P")?.StackNum ?? 0;

            if (count >= 6)
            {
                count = 6;
            }

            for (int i = 0; i < count; i++)
            {
                BattleSystem.DelayInputAfter(this.Attack(Targets[0], count));
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
            }
        }

        public IEnumerator Attack(BattleChar bc, int count)
        {
            Skill skill = Skill.TempSkill("S_Squall_4_0", this.BChar, this.BChar.MyTeam);
            skill.MySkill.Effect_Target.DMG_Per = 30 + 4 * count;
            skill.PlusHit = true;
            skill.FreeUse = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            yield return new WaitForSeconds(0.25f);
            yield break;
        }
    }
}