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
namespace Ralmia
{
	/// <summary>
	/// 宇宙之翼·洛菈米娅
	/// 若[本场战斗中，使用的创造物种类」为6种以上，额外对所有敌人造成2倍攻击力的伤害。
	/// </summary>
    public class S_Ralmia_10Rare:Skill_Extended
    {
        private bool isSpecies;
        private bool useflag;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            int count = this.BChar.BuffReturn("B_Ralmia_P", false).StackNum;
            if (count >= 6)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                if (!this.flag)
                {
                    this.flag = true;
                    this.NotCount = true;
                    return;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            useflag = true;
            if (!this.isSpecies)
            {
                return;
            }
            BattleSystem.DelayInput(this.Attack());
        }

        public IEnumerator Attack()
        {
            Skill skill = Skill.TempSkill("S_Ralmia_10Rare_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSeconds(0.3f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.5f)).ToString());
        }

        public bool flag;
    }
}