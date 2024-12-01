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
	/// 恋符「Master Spark」
	/// 自身的速度小于0时，每少1点使这个技能暴击率提升20%。
	/// 当此技能的暴击率超过100%时，技能伤害按照超出暴击率百分比增加。
	/// </summary>
    public class S_KirisameMarisa_5: SkillBase_KirisameMarisa, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (PlayData.PartySpeed < 0)
            {
                this.PlusSkillStat.cri = 30f * Math.Abs(PlayData.PartySpeed);
            }
            else
            {
                this.PlusSkillStat.cri = 0f;
            }
            this.useflag = true;
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar == null || this.BChar.MyTeam == null)
            {
                return;
            }
            if (!this.useflag)
            {
                if (PlayData.PartySpeed < 0)
                {
                    this.PlusSkillStat.cri = 30f * Math.Abs(PlayData.PartySpeed);
                    return;
                }
                this.PlusSkillStat.cri = 0f;
            }
        }
        
        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            float num = (float)this.MySkill.GetCriPer(Target, 0);
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
        
        private bool useflag;
    }
}