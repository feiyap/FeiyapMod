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
	/// 日火符「伽马流射线」
	/// 击杀敌人时，抽取 1 个技能，并使这个技能造成的伤害永久提升 1.1 倍。
	/// 当前触发次数：&a
	/// 当前提升倍数：&b
	/// </summary>
    public class S_Pachi_Sk_3_5:Skill_Extended, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            
            if (SP.SkillKey == "S_Pachi_Sk_3_5")
            {
                this.BChar.MyTeam.Draw();

                this.BChar.BuffAdd("B_Pachi_3_5", this.BChar);
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = (int)(Math.Pow(1.1, this.BChar.BuffReturn("B_Pachi_3_5")?.StackNum ?? 0) * 100) - 100;
            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.BChar.BuffReturn("B_Pachi_3_5")?.StackNum ?? 0).ToString())
                                          .Replace("&b", ((Math.Pow(1.1, this.BChar.BuffReturn("B_Pachi_3_5")?.StackNum ?? 0))).ToString())
                                          .Replace("&c", ((int)(this.BChar.GetStat.atk * 1.0 * Math.Pow(1.1, this.BChar.BuffReturn("B_Pachi_3_5")?.StackNum ?? 0))).ToString());
        }
    }
}