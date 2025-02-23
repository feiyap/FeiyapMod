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
	/// 连续剑•狮子奋迅
	/// 若[刃甲]超过2层，则消耗2层[刃甲]，进行2次追加攻击。
	/// 若[刃甲]超过3层，则额外消耗1层[刃甲]，使追加攻击以暴击形式命中。
	/// </summary>
    public class S_Squall_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffReturn("B_Squall_P")?.StackNum >= 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    BattleSystem.DelayInputAfter(this.Attack(Targets[0], true));
                }
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
            }
            else if (this.BChar.BuffReturn("B_Squall_P")?.StackNum >= 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    BattleSystem.DelayInputAfter(this.Attack(Targets[0], false));
                }
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
            }
        }

        public IEnumerator Attack(BattleChar bc, bool cri)
        {
            yield return new WaitForSecondsRealtime(0.25f);

            Skill skill = Skill.TempSkill("S_Squall_2_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            Skill_Extended se = new Skill_Extended();
            se.PlusSkillStat.cri = 100f;
            if (cri)
            {
                skill.ExtendedAdd(se);
            }

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            yield break;
        }
    }
}