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
	/// Robinhood
	/// 攻击时会向目标施加[射手印记]：施加者可以无视嘲讽攻击[射手印记]的目标；
	/// 再次命中拥有[射手印记]的敌人时，消除场上所有[射手印记]，本次造成伤害翻倍，并且抽取1个功能。
	/// </summary>
    public class B_MinamiRio_Rare_1:Buff, IP_SkillUse_Target, IP_SpecialEnemyTargetSelect, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target.BuffFind("B_MinamiRio_Rare_1_0") && Damage > 1 && !View)
            {
                return (int)(Damage * 2);
            }
            return Damage;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage && SP.SkillData.Master == this.BChar)
            {
                if (hit.BuffFind("B_MinamiRio_Rare_1_0"))
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyTeam.AliveChars)
                    {
                        if (be.BuffFind("B_MinamiRio_Rare_1_0"))
                        {
                            be.BuffReturn("B_MinamiRio_Rare_1_0").SelfDestroy();
                        }
                    }
                    BattleSystem.instance.AllyTeam.Draw();
                }
                else
                {
                    hit.BuffAdd("B_MinamiRio_Rare_1_0", this.BChar);
                }
            }
        }

        public bool SpecialEnemyTargetSelect(Skill skill, BattleEnemy Target)
        {
            return Target.BuffFind("B_MinamiRio_Rare_1_0");
        }
    }
}