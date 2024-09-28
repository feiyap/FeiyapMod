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
namespace Reisen
{
	/// <summary>
	/// 若铃仙在场，释放时根据该技能的费用，铃仙对目标进行多次[幻象/乱弹]。
	/// 指向敌人的攻击技能
	/// </summary>
    public class SE_Reisen_0:Skill_Extended, IP_SkillUse_Target
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.UseStatus == this.BChar && !SP.SkillData.PlusHit && !SP.SkillData.FreeUse && SP.ALLTARGET.Count == 1 && hit.Info.Ally != this.BChar.Info.Ally)
            {
                BattleChar battleChar2 = null;
                foreach (BattleChar battleChar3 in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar3.Info.KeyData == "Reisen")
                    {
                        battleChar2 = battleChar3;
                        break;
                    }
                }
                if (battleChar2.IsDead)
                {
                    return;
                }

                for (int i = 0; i<SP.SkillData.AP;i++)
                {
                    BattleSystem.DelayInputAfter(this.Ienum(hit, battleChar2));
                }
            }
        }

        public IEnumerator Ienum(BattleChar hit, BattleChar battleChar2)
        {
            Skill skill;
            if (battleChar2.BuffFind("B_Reisen_6"))
            {
                skill = Skill.TempSkill("S_Reisen_P_2", battleChar2, this.BChar.MyTeam);
            }
            else if (battleChar2.BuffFind("B_Reisen_P"))
            {
                skill = Skill.TempSkill("S_Reisen_P_1", battleChar2, this.BChar.MyTeam);
            }
            else
            {
                skill = Skill.TempSkill("S_Reisen_P_0", battleChar2, this.BChar.MyTeam);
            }

            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;

            if (hit.BuffFind("B_Reisen_2"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.hit += 100f;
                skill.ExtendedAdd(skill_Extended);
            }
            if (hit.BuffFind("B_Reisen_2_0"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.cri += 100f;
                skill.ExtendedAdd(skill_Extended);
            }
            
            yield return new WaitForSecondsRealtime(0.1f);

            battleChar2.ParticleOut(skill, hit);

            yield break;
        }
    }
}