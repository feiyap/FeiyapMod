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
namespace HakureiReimu
{
	/// <summary>
	/// 灵符「无理由的无差别降伏」
	/// 如果自身身上的增益效果种类不小于5个，额外造成&a(120%)伤害。
	/// 如果自身身上的增益效果种类不小于10个，打出时生成这个技能的复制。
	/// </summary>
    public class S_HakureiReimu_F_4: SkillExtended_Reimu
    {
        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    buffCount_N = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    buffCount_N = 0;
                }

                if (buffCount_N != buffCount_L && BattleSystem.instance != null && !this.MySkill.IsNowCounting)
                {
                    this.SkillChange("S_HakureiReimu_F_4", buffCount_N);
                }

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    this.buffCount_L = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    this.buffCount_L = 0;
                }

                if (CheckBuffNum() >= 5)
                {
                    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 1.2f);
                }
                else
                {
                    this.SkillBasePlus.Target_BaseDMG = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (CheckBuffNum() >= 5)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 1.2f);
            }

            if (CheckBuffNum() >= 10)
            {
                Skill tmpSkill = Skill.TempSkill("S_HakureiReimu_F_4", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }

            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count >= 1 &&
                Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count >= 1 &&
                Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count >= 1)
            {
                this.PlusSkillStat.cri = 100f;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.2f)).ToString());
        }
    }
}