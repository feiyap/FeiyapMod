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
    public class S_Ralmia_13Rare_2:Skill_Extended, IP_LogUpdate, IP_PlayerTurn
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.Turn >= BattleSystem.instance.TurnNum, (Skill skill) => (skill.MySkill.KeyID == "S_Ralmia_0" || skill.MySkill.KeyID == "S_Ralmia_1" || skill.MySkill.KeyID == "S_Ralmia_2"
            || skill.MySkill.KeyID == "S_Ralmia_3" || skill.MySkill.KeyID == "S_Ralmia_10Rare" || skill.MySkill.KeyID == "S_Ralmia_13Rare" || skill.MySkill.KeyID == "S_Ralmia_13Rare_0" || skill.MySkill.KeyID == "S_Ralmia_13Rare_1" || skill.MySkill.KeyID == "S_Ralmia_13Rare_2"), -1).Count) * (this.BChar.GetStat.atk * 0.25f));
            }
        }

        // Token: 0x06000E3B RID: 3643 RVA: 0x00084D64 File Offset: 0x00082F64
        public override string DescExtended(string desc)
        {
            string a = BattleSystem.instance.AllyTeam.Skills[0].MySkill.KeyID;

            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.25f)).ToString()).Replace("&b", this.SkillBasePlus.Target_BaseDMG.ToString());
        }

        // Token: 0x06000E3C RID: 3644 RVA: 0x00084DBB File Offset: 0x00082FBB
        public void LogUpdate(BattleLog log)
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        // Token: 0x06000E3D RID: 3645 RVA: 0x00084DCE File Offset: 0x00082FCE
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;

            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }
        }

        // Token: 0x06000E3E RID: 3646 RVA: 0x00084DE9 File Offset: 0x00082FE9
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        // Token: 0x06000E3F RID: 3647 RVA: 0x00084DBB File Offset: 0x00082FBB
        public void Turn()
        {
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
    }
}