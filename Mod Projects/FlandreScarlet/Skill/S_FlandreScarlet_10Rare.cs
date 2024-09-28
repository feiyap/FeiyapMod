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
namespace FlandreScarlet
{
	/// <summary>
	/// 秘弹「之后就一个人都没有了吗？」
	/// 对随机敌人或队友再次释放，重复6次。对队友的伤害减少75%，并转为痛苦伤害。
	/// 禁忌 - 额外重复4次。降低随机到队友的几率。
	/// 狂乱4 - 额外重复4次。降低随机到队友的几率。
	/// </summary>
    public class S_FlandreScarlet_10Rare:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            useflag = false;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;

            int num = 8;
            int probability = 50;

            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                num += 4;
                probability -= 20;
            }

            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 4)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                num += 4;
                probability -= 20;
            }

            for (int i = 0; i < num; i++)
            {
                if (RandomManager.RandomPer(this.BChar.GetRandomClass().Main, 100, probability))
                {
                    BattleSystem.DelayInput(this.EffectAlly());
                }
                else
                {
                    BattleSystem.DelayInput(this.EffectEnemy());
                }
            }
        }

        public IEnumerator EffectAlly()
        {
            Skill skill = Skill.TempSkill("S_FlandreScarlet_10Rare_1", this.BChar, this.BChar.MyTeam);
            //skill.PlusHit = true;
            this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.AllyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public IEnumerator EffectEnemy()
        {
            Skill skill = Skill.TempSkill("S_FlandreScarlet_10Rare_0", this.BChar, this.BChar.MyTeam);
            //skill.PlusHit = true;
            //this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyList[i]);
            this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                return;
            }
            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 4)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                return;
            }
            base.SkillParticleOff();
        }

        private bool useflag;
    }
}