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
namespace HinanawiTenshi
{
	/// <summary>
	/// 地符「一击震乾坤」
	/// 依据自身持有的增益数量，每个提升10%暴击率。
	/// <color=#97FFFF>天启6</color> - 额外造成&a点伤害<color=#FF7A33>(攻击力的30%)</color>。
	/// </summary>
    public class S_Tenshi_6: SkillBase_Tenshi
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)(this.BChar.GetStat.atk * 0.1);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg * CheckTenkiBuffNum();

                if (CheckKishi(6, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg * CheckTenkiBuffNum();

            if (CheckKishi(6, false))
            {
                Targets[0].BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, false, 150, false, -1, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.1f)).ToString());
        }
    }
}