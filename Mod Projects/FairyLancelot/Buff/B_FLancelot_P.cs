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
namespace FairyLancelot
{
	/// <summary>
	/// 好感度
	/// 每10点好感度提高0.5攻击力，每10点好感度提升2点最大体力。
	/// 部分技能根据好感度获得不同强化。
	/// </summary>
    public class B_FLancelot_P:Buff, IP_BattleEnd, IP_Kill, IP_SkillUseHand_Team, IP_Healed, IP_Dead
    {
        public int killnum = 0;
        public int skill3usenum = 0;
        public int skill2usenum = 0;
        public int healnum = 0;

        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = P_FairyLancelot.heartPoint / 20;
            this.PlusStat.maxhp = P_FairyLancelot.heartPoint / 5;

            killnum = 0;
            skill3usenum = 0;
            skill2usenum = 0;
            healnum = 0;

            this.OnePassive = true;
        }

        public void Dead()
        {
            if (P_FairyLancelot.heartList.Contains("S_FLancelot_H_1"))
            {
                P_FairyLancelot.heartPoint = 0;
            }
        }

        public void KillEffect(SkillParticle SP)
        {
            if (SP.SkillData.Master == this.BChar)
            {
                killnum++;
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                if (skill._AP == 3)
                {
                    skill3usenum++;
                }
                if (skill._AP == 2)
                {
                    skill2usenum++;
                }
            }
        }

        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (HealNum > 0)
            {
                healnum += HealNum;
            }
        }

        public void BattleEnd()
        {
            foreach (string str in P_FairyLancelot.heartList)
            {
                switch (str)
                {
                    case "S_FLancelot_H_1":
                        break;
                    case "S_FLancelot_H_2":
                        {
                            if (killnum >= 1)
                            {
                                P_FairyLancelot.heartPoint += 2;
                            }
                            else
                            {
                                P_FairyLancelot.heartPoint = 0;
                            }
                        }
                        break;
                    case "S_FLancelot_H_3":
                        {
                            if (skill3usenum < 1)
                            {
                                P_FairyLancelot.heartPoint += 4;
                            }
                            else
                            {
                                P_FairyLancelot.heartPoint = 0;
                            }
                        }
                        break;
                    case "S_FLancelot_H_4":
                        {
                            if (healnum < 40)
                            {
                                P_FairyLancelot.heartPoint += 3;
                            }
                            else
                            {
                                P_FairyLancelot.heartPoint = 0;
                            }
                        }
                        break;
                    case "S_FLancelot_H_5":
                        {
                            if (skill2usenum < 1)
                            {
                                P_FairyLancelot.heartPoint += 4;
                            }
                            else
                            {
                                P_FairyLancelot.heartPoint = 0;
                            }
                        }
                        break;
                }
            }

            if (this.BChar.Info.LV >= 3 && P_FairyLancelot.heartPoint >= 30 && !this.BChar.Info.SkillDatas.Exists(t => t.SkillInfo.KeyID == "S_FLancelot_2"))
            {
                Skill skill = Skill.TempSkill("S_FLancelot_2", this.BChar, BattleSystem.instance.AllyTeam);
                this.BChar.Info.UseSoulStone(skill);
            }

            if (this.BChar.Info.LV >= 4 && P_FairyLancelot.heartPoint >= 50 && !this.BChar.Info.SkillDatas.Exists(t => t.SkillInfo.KeyID == "S_FLancelot_3"))
            {
                Skill skill = Skill.TempSkill("S_FLancelot_3", this.BChar, BattleSystem.instance.AllyTeam);
                this.BChar.Info.UseSoulStone(skill);
            }

            if (this.BChar.Info.LV >= 5 && P_FairyLancelot.heartPoint >= 80 && !this.BChar.Info.SkillDatas.Exists(t => t.SkillInfo.KeyID == "S_FLancelot_4"))
            {
                Skill skill = Skill.TempSkill("S_FLancelot_4", this.BChar, BattleSystem.instance.AllyTeam);
                this.BChar.Info.UseSoulStone(skill);
            }
        }

        public override string DescExtended()
        {
            string text = "";
            string state = "";
            foreach (string str in P_FairyLancelot.heartList)
            {
                switch (str)
                {
                    case "S_FLancelot_H_1":
                        text += ModManager.getModInfo("FairyLancelot").localizationInfo.SystemLocalizationUpdate("S_FLancelot_H_1");
                        state += "0";
                        state += ";";
                        break;
                    case "S_FLancelot_H_2":
                        text += ModManager.getModInfo("FairyLancelot").localizationInfo.SystemLocalizationUpdate("S_FLancelot_H_2");
                        state += killnum;
                        state += ";";
                        break;
                    case "S_FLancelot_H_3":
                        text += ModManager.getModInfo("FairyLancelot").localizationInfo.SystemLocalizationUpdate("S_FLancelot_H_3");
                        state += skill3usenum;
                        state += ";";
                        break;
                    case "S_FLancelot_H_4":
                        text += ModManager.getModInfo("FairyLancelot").localizationInfo.SystemLocalizationUpdate("S_FLancelot_H_4");
                        state += healnum;
                        state += ";";
                        break;
                    case "S_FLancelot_H_5":
                        text += ModManager.getModInfo("FairyLancelot").localizationInfo.SystemLocalizationUpdate("S_FLancelot_H_5");
                        state += skill2usenum;
                        state += ";";
                        break;
                }
            }

            return this.BuffData.Description.Replace("&a", text)
                                            .Replace("&b", state);
        }
    }
}