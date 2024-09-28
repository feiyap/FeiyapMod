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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻葬「夜雾幻影杀人鬼」
	/// 每有1层[时钟停摆]，额外造成%a伤害。
	/// </summary>
    public class S_Sakuya_11Rare:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                if (this.BChar.BuffFind("B_Sakuya_P_0", false))
                {
                    return (int)(this.BChar.BuffReturn("B_Sakuya_P_0", false).StackNum * this.BChar.GetStat.atk * 0.15f);
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 0.15f)).ToString());
        }

        public void LogUpdate(BattleLog log)
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public void Turn()
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
    }
}