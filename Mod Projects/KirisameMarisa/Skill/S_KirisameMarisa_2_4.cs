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
	/// 黑魔「Event Horizon」
	/// </summary>
    public class S_KirisameMarisa_2_4: SkillBase_KirisameMarisa, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString());
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int count = 0;
            if (Target.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count > 0)
            {
                count++;
            }
            if (Target.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count > 0)
            {
                count++;
            }
            if (Target.GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count > 0)
            {
                count++;
            }
            PlusDamage = (int)(this.BChar.GetStat.atk * 0.4f) * count;
        }

        

        //public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        //{
        //    base.SkillUseSingle(SkillD, Targets);

        //    int count = 0;
        //    if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count > 0)
        //    {
        //        count++;
        //    }
        //    if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count > 0)
        //    {
        //        count++;
        //    }
        //    if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count > 0)
        //    {
        //        count++;
        //    }
        //    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.4f) * count;

        //    this.BChar.Overload -= 2;
        //}
    }
}