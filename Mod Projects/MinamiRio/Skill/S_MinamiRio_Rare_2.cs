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
namespace MinamiRio
{
	/// <summary>
	/// 连矢
	/// <color=#48D1CC>单弓</color> - 重复释放2次。如果目标拥有嘲讽状态，使其失去嘲讽状态；否则使其(120%干扰)眩晕1回合。
	/// <color=#FFD700>和弓</color> - 额外造成&a(200%)伤害。本回合内，自身造成伤害提升35%。
	/// </summary>
    public class S_MinamiRio_Rare_2:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.HIT_CC + 120)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.atk * 2.5f)).ToString());
        }

        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_MinamiRio_P1"))
                {
                    this.SkillBasePlus.Target_BaseDMG = 0;
                    this.MySkill.MySkill.Name = ModManager.getModInfo("MinamiRio").localizationInfo.SystemLocalizationUpdate("S_MinamiRio_Rare_2_1");
                }
                else if (this.BChar.BuffFind("B_MinamiRio_P2"))
                {
                    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 2.5f);
                    this.MySkill.MySkill.Name = ModManager.getModInfo("MinamiRio").localizationInfo.SystemLocalizationUpdate("S_MinamiRio_Rare_2_2");
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                Skill skill = Skill.TempSkill("S_MinamiRio_Rare_2_0", this.BChar, this.BChar.MyTeam);
                skill.FreeUse = true;

                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));

                if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
                {
                    Targets[0].BuffScriptReturn("Common_Buff_EnemyTaunt").SelfDestroy(false);
                }
                else if (Targets[0] is BattleEnemy && !(Targets[0] as BattleEnemy).istaunt)
                {
                    Targets[0].BuffAdd("B_Common_Rest", this.BChar, false, 120);
                }
            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 2.5f);
                this.BChar.BuffAdd("B_MinamiRio_Rare_2", this.BChar);
            }
        }

        public IEnumerator PassiveAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.05f);
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
    }
}