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
namespace HouraisanKaguya
{
	/// <summary>
	/// 神宝「佛体的金刚石」
	/// 如果暴击，以80%效率重复释放这个技能，视作追加攻击；最多重复释放5次。
	/// 神宝 - 额外造成&a(60%)伤害，暴击率提升25%。
	/// </summary>
    public class S_FKaguya_3:Skill_Extended, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg;
                this.PlusSkillStat.cri = 25f;
            }
            else
            {
                base.SkillParticleOff();
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillStat.cri = 0f;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.SkillBasePlus.Target_BaseDMG = PlusDmg;
                this.PlusSkillStat.cri = 25f;
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillStat.cri = 0f;
            }

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
            }
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillKey == "S_FKaguya_3" && Cri && DMG > 0)
            {
                Skill skill = this.MySkill.CloneSkill(false, null, null, false);
                skill.MySkill.Effect_Target.DMG_Per = skill.MySkill.Effect_Target.DMG_Per * 8 / 10;
                skill.NotCount = true;
                skill.PlusHit = true;
                skill.AP = 0;
                skill.Counting = -99;
                if (skill.MySkill.Effect_Target.DMG_Per >= 60)
                {
                    //BattleSystem.DelayInputAfter(this.PassiveAttack(skill, hit));
                    BattleSystem.DelayInputAfter(this.PlusAttack(skill, hit));
                }
            }
        }

        public IEnumerator PlusAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            yield break;
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(1.5f);
            if (!Target.IsDead)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            }
            else if (Target.Info.Ally)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.6));
            }
        }
    }
}