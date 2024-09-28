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
	/// 「机械降神」
	/// 根据这个回合中发动过的追加攻击/反击的次数，重复释放这个技能。
	/// 当前次数：&a
	/// </summary>
    public class S_Inaba_Rare12:Skill_Extended, IP_SkillUse_Target
    {
        public int count;
        public int ShotNum
        {
            get
            {
                if (BattleSystem.instance != null && BattleSystem.instance.BattleLogs != null && BattleSystem.instance.TurnNum >= 1)
                {
                    return count;
                }
                return 0;
            }
        }

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public override void HandInit()
        {
            base.HandInit();
            count = 0;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.PlusHit && SP.SkillKey != "S_Inaba_Rare12_0")
            {
                count++;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", this.ShotNum.ToString());
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            Skill skill = Skill.TempSkill("S_Inaba_Rare12_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;

            for (int i = 0; i < ShotNum; i++)
            {
                BattleSystem.DelayInput(this.InabaAttack(skill, Targets[0]));
            }
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
    }
}