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
namespace Sunmeitian
{
	/// <summary>
	/// 乾坤之跃
	/// 选择 - 立即释放；
	/// 倒计时1，额外造成&a(60%)伤害；
	/// 倒计时2，额外造成&b(100%)伤害；
	/// 倒计时3，额外造成&c(120%)伤害。
	/// 释放时，如果自身拥有[真假猴王]，将1张[丛林之舞]加入手中。
	/// </summary>
    public class S_Sunmeitian_4_2:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.8));
            }
        }

        public int PlusDmg2
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 1.1));
            }
        }

        public int PlusDmg3
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 1.4));
            }
        }

        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Sunmeitian_4_2_0");
            this.ChoiceSkillList.Add("S_Sunmeitian_4_2_1");
            this.ChoiceSkillList.Add("S_Sunmeitian_4_2_2");
            this.ChoiceSkillList.Add("S_Sunmeitian_4_2_3");
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Sunmeitian_1", false))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString()).
                Replace("&b", (PlusDmg2).ToString()).
                Replace("&c", (PlusDmg3).ToString());
        }
    }
}