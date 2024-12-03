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
namespace KirisameMarisa
{
	/// <summary>
	/// 魔炮「Final Spark」
	/// </summary>
    public class S_KirisameMarisa_5_4 : SkillBase_KirisameMarisa, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Buff> buffs = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false);
            int num = 0;
            foreach (Buff buff in buffs)
            {
                num += buff.StackNum * 20;
            }
            if (PlayData.PartySpeed < 0)
            {
                this.PlusSkillStat.cri = num;
            }
            else
            {
                this.PlusSkillStat.cri = 0f;
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            List<Buff> buffs = Target.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false);
            int num = 0;
            foreach (Buff buff in buffs)
            {
                num += buff.StackNum * 20;
            }
            this.PlusSkillStat.cri = num;
            int num2 = 0;
            if (num > 100f)
            {
                num2 = (int)(num - 100f);
            }
            if (num2 > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num2, 0);
            }
        }
    }
}