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
namespace Kirito
{
	/// <summary>
	/// 剑技连携
	/// 根据本回合释放的技能数量，重复释放本技能。
	/// </summary>
    public class S_Kirito_P:Skill_Extended
    {
        public int ShotNum
        {
            get
            {
                if (BattleSystem.instance != null && BattleSystem.instance.BattleLogs != null && BattleSystem.instance.TurnNum >= 1)
                {
                    if (BattleSystem.instance.BattleLogs.getSkills(null, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count >= 9)
                    {
                        return 9;
                    }
                    return BattleSystem.instance.BattleLogs.getSkills(null, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count;
                }
                return 0;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", this.ShotNum.ToString());
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            if (!this.MySkill.PlusHit)
            {
                base.SkillUseSingleAfter(SkillD, Targets);
                this.SaveTarget = Targets[0];
                BattleSystem.DelayInput(this.Delay());
            }
        }
        
        private void Del(SkillButton Myskill)
        {
        }
        
        public IEnumerator Delay()
        {
            yield return new WaitForFixedUpdate();
            for (int i = 0; i < ShotNum; i++)
            {
                BattleSystem.DelayInputAfter(this.Ienum(ShotNum));
            }
            yield break;
        }
        
        public IEnumerator Ienum(int Num)
        {
            Skill skill = Skill.TempSkill("S_Kirito_P", this.BChar, this.BChar.MyTeam);
            Skill_Extended extended = new Skill_Extended();
            skill.ExtendedAdd(extended);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            if (this.SaveTarget.IsDead)
            {
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(this.MySkill, skill, this.SaveTarget);
            }
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }

        private BattleChar SaveTarget;
    }
}