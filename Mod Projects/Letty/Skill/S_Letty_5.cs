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
namespace Letty
{
	/// <summary>
	/// 白符「波状光」
	/// 若只有 1 个目标，重复释放 1 次。
	/// </summary>
    public class S_Letty_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (this.BChar.BattleInfo.EnemyList.Count == 1)
            {
                base.SkillParticleOn();
                return;
            }
            base.SkillParticleOff();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets.Count == 1)
            {
                BattleSystem.DelayInput(this.PlusAttack(Targets[0]));
            }
        }
        
        public IEnumerator PlusAttack(BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            Skill skill = Skill.TempSkill("S_Letty_5", this.BChar, this.BChar.MyTeam);
            if (this.BChar != null && !this.BChar.Dummy && !this.BChar.IsDead)
            {
                if (!hit.IsDead)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, hit);
                }
                else if (BattleSystem.instance.EnemyList.Count > 0)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
                }
            }
            yield break;
        }
    }
}