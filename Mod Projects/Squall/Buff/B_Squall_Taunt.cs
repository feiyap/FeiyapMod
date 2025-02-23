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
namespace Squall
{
	/// <summary>
	/// 挑衅
	/// 无法攻击&target以外的目标。
	/// 攻击&target后，&target以4段&a伤害进行反击(攻击力的25%)。
	/// 攻击后解除。
	/// </summary>
    public class B_Squall_Taunt: B_Taunt, IP_SkillUse_User, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Weak = true;
        }
        
        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally != this.BChar.Info.Ally)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
            base.SkillUse(SkillD, Targets);
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.Info.KeyData == "Squall")
            {
                for (int i = 0; i < 4; i++)
                {
                    BattleSystem.DelayInputAfter(this.Attack(this.BChar));
                }
            }
        }

        public IEnumerator Attack(BattleChar bc)
        {
            for (int i = 0; i < BattleSystem.instance.EnemyList.Count; i++)
            {
                Skill skill = Skill.TempSkill("S_Squall_4_0", this.BChar, this.BChar.MyTeam);
                skill.MySkill.Effect_Target.DMG_Per = 25;
                skill.PlusHit = true;
                skill.FreeUse = true;

                if (bc != null || bc.IsDead)
                {
                    this.BChar.ParticleOut(skill, bc);
                }
                else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                {
                    this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                }
            }

            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", ((int)this.Usestate_F.GetStat.atk * 0.25f).ToString());
        }
    }
}