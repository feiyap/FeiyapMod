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
namespace Feiyap
{
	/// <summary>
	/// 幽壑千灯
	/// </summary>
    public class S_Feiyap_4:Skill_Extended, IP_DamageChange_sumoperation
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + (this.BChar.Recovery - this.BChar.HP) * 2));
            }
        }

        public override void Init()
        {
            base.Init();
            if (this.BChar.GetStat.Strength)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.GetStat.Strength)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.GetStat.Strength)
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