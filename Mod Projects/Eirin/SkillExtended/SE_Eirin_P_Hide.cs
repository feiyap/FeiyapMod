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
namespace Eirin
{
    public class SE_Eirin_P_Hide:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_onetarget);
            }
            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_other)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_onetarget);
            }
        }
        
        public override void HandInit()
        {
            base.HandInit();
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.IsDamage = true;
            this.SkillBasePlusPreview.Target_BaseDMG = (int)((float)this.MySkill.TargetHeal * 1.0f);
        }
        
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            if (!Targets[0].Info.Ally)
            {
                this.IsDamage = true;
                this.SkillBasePlus.Target_BaseDMG = (int)((float)SkillD.TargetHeal * 1.0f);
                this.PlusSkillPerStat.Heal = -99999;
            }

            Skill skill = Skill.TempSkill("S_Eirin_P", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            BattleSystem.DelayInput(this.EirinAttack(skill, Targets[0]));
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (!hit.IsDead)
            {
                this.BChar.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}