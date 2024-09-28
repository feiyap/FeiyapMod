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
namespace HouraisanKaguya
{
	/// <summary>
	/// 蓬莱山辉夜
	/// Passive:
	/// 竹取物语 - 蓬莱山辉夜的[难题]技能在达成某些条件时，会为自身赋予[辉夜/神宝]。
	/// 蓬莱山辉夜的[神宝]技能通过消耗[辉夜/神宝]，能够追加额外效果。
	/// 永远与须臾 - 蓬莱山辉夜在自身行动前，防御力提升50%，提升被攻击的概率；
	/// 全队对未拥有行动倒计时的敌人额外造成10%伤害。
	/// </summary>
    public class P_HouraisanKaguya:Passive_Char, IP_Hit, IP_PlayerTurn, IP_DamageTake, IP_BattleStart_Ones
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            bool flag = Dmg > 0;
            if (flag)
            {
                SP.SkillData.Master.BuffAdd("B_FKaguya_P", this.BChar, false, 0, false, 3, false);
            }
        }
        
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.count = 0;
        }

        public void BattleStart(BattleSystem Ins)
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].BuffAdd("B_FKaguya_P_0", this.BChar, true, 0, false, -1, false);
            }

            int cnt = 0;
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                if (BattleSystem.instance.AllyList[i].Info.KeyData == "HouraisanKaguya" ||
                    BattleSystem.instance.AllyList[i].Info.KeyData == "Reisen" ||
                    BattleSystem.instance.AllyList[i].Info.KeyData == "Eirin" ||
                    BattleSystem.instance.AllyList[i].Info.KeyData == "Inaba")
                {
                    cnt++;
                    Debug.Log(cnt);
                }
            }
            if (cnt >= 3)
            {
                Skill skill = Skill.TempSkill("S_FKaguya_Co1", this.BChar, this.BChar.MyTeam);
                this.BChar.MyTeam.Add(skill, true);
            }
        }

        public void Turn()
        {
            count = 0;
            if (this.BChar.BuffFind("B_FKaguya_6_0"))
            {
                this.BChar.BuffReturn("B_FKaguya_6_0").SelfDestroy();
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && !resist)
            {
                count += Dmg;
            }
            if (count >= this.BChar.GetStat.maxhp * 0.2)
            {
                this.BChar.BuffAdd("B_FKaguya_6_0", this.BChar, true, 0, false, -1, false);
            }
        }

        public int count;
    }
}