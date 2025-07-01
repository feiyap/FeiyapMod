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
namespace FeiyapBoss
{
	/// <summary>
	/// 幽壑千灯
	/// 这个技能额外造成「上个回合中，自己受到过的最高的单次伤害值」点伤害。
	/// </summary>
    public class S_Feiyap_Boss_3:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + (B_Feiyap_Boss_P_1.hprecordlast) / 2));
            }
        }

        public override void Init()
        {
            base.Init();
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            List<Buff> buffs = Target.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false);
            int num = 0;
            foreach (Buff buff in buffs)
            {
                num += buff.StackNum * 10;
            }

            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}