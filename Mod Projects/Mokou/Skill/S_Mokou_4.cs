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
namespace Mokou
{
	/// <summary>
	/// 不灭「不死鸟之尾」
	/// 根据自身的赤魂层数重复释放此技能。
	/// 重复释放的不灭「不死鸟之尾」造成一半伤害且只会施加一半烧伤。
	/// </summary>
	public class S_Mokou_4 : Skill_Extended
	{
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(4, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            num_S = 0;
            if (EX_ability.CheckEXburn(4, this.BChar))
            {
                num_S = 1;
            }
            base.SkillUseSingle(SkillD, Targets);
            if (!this.MySkill.PlusHit)
            {
                base.SkillUseSingleAfter(SkillD, Targets);
                this.SaveTarget = Targets[0];
                this.flag = true;
                BattleSystem.DelayInput(this.Delay());
            }
            if (EX_ability.CheckEXburn(4, this.BChar))
            {
                EX_ability.UseEXburn(4, this.BChar);
            }
        }
        public IEnumerator Delay()
        {
            yield return new WaitForFixedUpdate();
            BattleSystem.DelayInputAfter(this.Del());
            yield break;
        }
        public IEnumerator Del()
        {
            yield return new WaitUntil(() => this.flag);
            yield return new WaitForFixedUpdate();
            int num = 0;
            if (this.BChar.BuffFind("B_Mokou_0", false))
            {
                num += this.BChar.BuffReturn("B_Mokou_0", false).StackNum;
            }
            for (int i = 0; i < num; i++)
            {
                BattleSystem.DelayInputAfter(this.Ienum(num));
            }
            yield return new WaitForFixedUpdate();
            yield break;
        }
        public IEnumerator Ienum(int Num)
        {
            Skill skill = Skill.TempSkill("S_Mokou_4", this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusSkillPerStat.Damage = -(int)Misc.PerToNum((float)skill.MySkill.Effect_Target.DMG_Per, 50f);
            skill.ExtendedAdd(skill_Extended);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            if (num_S == 1)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
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
        private bool flag;
        private int num_S;
    }
}