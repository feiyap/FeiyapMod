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
namespace Inaba
{
	/// <summary>
	/// 速符「高速的白影」
	/// 如果目标身上有3个以上弱化减益，额外追加攻击1次，造成&a(60%)伤害。
	/// </summary>
    public class S_Inaba_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int num = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count;
            if (num >= 2)
            {
                BattleSystem.DelayInputAfter(this.Ienum(Targets));
                BattleSystem.DelayInputAfter(this.Ienum(Targets));
            }
        }

        public IEnumerator Ienum(List<BattleChar> Targets)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Skill skill = Skill.TempSkill("S_Inaba_0_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.isExcept = true;
            skill.FreeUse = true;
            if (Targets[0].IsDead)
            {
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(this.MySkill, skill, Targets[0]);
            }
            yield break;
        }

        public IEnumerator InabaAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.05f);
            if (!Target.IsDead)
            {
                this.BChar.ParticleOut(AttackSkill, Target);
            }
            else if (Target.Info.Ally)
            {
                this.BChar.ParticleOut(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.plusHit).ToString());
        }

        public int plusHit
        {
            get
            {
                return (int)((float)(this.BChar.GetStat.atk * 0.3));
            }
        }
    }
}