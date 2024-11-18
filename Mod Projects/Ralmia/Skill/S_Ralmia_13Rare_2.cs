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
namespace Ralmia
{
	/// <summary>
	/// 加农的创造物
	/// 这个回合每打出1张创造物技能，额外造成0.5倍攻击力伤害（最高增加2.5倍）。
	/// </summary>
    public class S_Ralmia_13Rare_2: SkillEn_Ralmia_0, IP_LogUpdate, IP_PlayerTurn
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.Turn >= BattleSystem.instance.TurnNum, (Skill skill) => (skill.ExtendedFind_DataName("SkillEn_Ralmia_2") != null || skill.ExtendedFind_DataName("SE_Ralmia_C_0") != null), -1).Count) * (this.BChar.GetStat.atk * 0.25f));
            }
        }
        
        public override string DescExtended(string desc)
        {
            string a = BattleSystem.instance.AllyTeam.Skills[0].MySkill.KeyID;

            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.25f)).ToString()).Replace("&b", this.SkillBasePlus.Target_BaseDMG.ToString());
        }
        
        public void LogUpdate(BattleLog log)
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
        
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
        
        public void Turn()
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
    }
}