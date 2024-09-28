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
namespace Lumiore
{
	/// <summary>
	/// 金刚钻厚头龙
	/// 若[本回合中，丢弃手牌的次数]大于等于1次，对随机敌人造成&a伤害。
	/// </summary>
    public class S_Lumiore_2:Skill_Extended, IP_Discard
    {
        private bool isSpecies;
        private bool useflag;

        public override void Init()
        {
            base.Init();
            this.UseNum = 0;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void HandInit()
        {
            base.HandInit();
            this.UseNum = 0;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            if (UseNum >= 1)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            this.UseNum = 0;
            if (!this.isSpecies)
            {
                return;
            }
            BattleSystem.DelayInput(this.Attack());
        }

        public IEnumerator Attack()
        {
            Skill skill = Skill.TempSkill("S_Lumiore_2_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSeconds(0.3f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }

        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            BattleSystem.DelayInput(this.Discard());
        }

        public IEnumerator Discard()
        {
            this.UseNum++;
            yield return null;
            yield break;
        }

        public int UseNum;
    }
}