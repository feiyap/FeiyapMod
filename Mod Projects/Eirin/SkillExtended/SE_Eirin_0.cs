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
	/// <summary>
	/// 若八意永琳在场，释放时根据该技能的费用，八意永琳对目标进行多次[幻象/乱箭]。
	/// </summary>
    public class SE_Eirin_0:Skill_Extended, IP_SkillUse_Target
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
                    if (battleChar3.Info.KeyData == "Eirin")
                    {
                        battleChar2 = battleChar3;
                        break;
                    }
                }
                if (battleChar2.IsDead)
                {
                    return;
                }

                for (int i = 0; i < SP.SkillData.AP; i++)
                {
                    BattleSystem.DelayInputAfter(this.Ienum(hit, battleChar2));
                }
            }
        }

        public IEnumerator Ienum(BattleChar hit, BattleChar battleChar2)
        {
            Skill skill;
            skill = Skill.TempSkill("S_Eirin_P", battleChar2, this.BChar.MyTeam);

            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;

            yield return new WaitForSecondsRealtime(0.2f);

            battleChar2.ParticleOut(skill, hit);

            yield break;
        }
    }
}