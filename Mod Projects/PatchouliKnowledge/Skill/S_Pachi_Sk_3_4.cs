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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 火土符「环状熔岩带」
	/// 同时攻击与技能目标嘲讽状态相同的所有敌人。
	/// 造成伤害的30%转化为自身的保护罩。
	/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的10%)。
	/// 每个等级的“土”使保护罩转化倍率提升20%。
	/// </summary>
    public class S_Pachi_Sk_3_4:Skill_Extended, IP_SkillUse_Target
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0] is BattleEnemy)
            {
                if ((Targets[0] as BattleEnemy).istaunt)
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                    {
                        if (be != Targets[0] && be.istaunt)
                        {
                            Targets.Add(be);
                        }
                    }
                }
                else
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                    {
                        if (be != Targets[0] && !be.istaunt)
                        {
                            Targets.Add(be);
                        }
                    }
                }
            }

            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1)
            {
                this.BChar.BuffAdd("B_Pachi_Barrier", this.BChar).BarrierHP += (int)Misc.PerToNum((float)DMG, 30f + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 20);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.1f)).ToString());
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));
        }
    }
}