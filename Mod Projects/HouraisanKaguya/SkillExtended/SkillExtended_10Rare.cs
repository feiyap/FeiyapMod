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
	/// 永夜归返 -强化-
	/// </summary>
    public class SkillExtended_10Rare:Skill_Extended
    {
        public override bool Terms()
        {
            return this.BChar.BuffFind("B_FKaguya_Sinnpou");
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            string nextSkillStr = "";
            int i = 0;
            for (; i < this.CardList.Count; i++)
            {
                if (CardList[i] == this.MySkill.MySkill.KeyID)
                {
                    if (i != CardList.Count - 1)
                    {
                        nextSkillStr = CardList[i + 1];
                        break;
                    }
                }
            }

            if (nextSkillStr != "" && this.MySkill.Master.Info.KeyData == "HouraisanKaguya" && !this.MySkill.FreeUse && !this.MySkill.isExcept)
            {
                CharInfoSkillData item = this.BChar.Info.SkillDatas.Find((CharInfoSkillData s) => s.SkillInfo.KeyID == this.MySkill.MySkill.KeyID);
                this.BChar.Info.SkillDatas.Remove(item);

                Skill skill = Skill.TempSkill(nextSkillStr, this.BChar, BattleSystem.instance.AllyTeam);
                this.BChar.Info.UseSoulStone(skill);

                if (i >= 9)
                {
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Insert(0, skill);
                }
            }
            
            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
            }
        }

        public List<string> CardList = new List<string>
        {
            "S_FKaguya_10Rare",
            "S_FKaguya_10Rare_0",
            "S_FKaguya_10Rare_1",
            "S_FKaguya_10Rare_2",
            "S_FKaguya_10Rare_3",
            "S_FKaguya_10Rare_4",
            "S_FKaguya_10Rare_5",
            "S_FKaguya_10Rare_6",
            "S_FKaguya_10Rare_7",
            "S_FKaguya_10Rare_8",
            "S_FKaguya_10Rare_9",
            "S_FKaguya_10Rare_10",
            "S_FKaguya_10Rare_11",
            "S_FKaguya_10Rare_12",
            "S_FKaguya_10Rare_13",
            "S_FKaguya_10Rare_14",
            "S_FKaguya_10Rare_15",
            "S_FKaguya_10Rare_16",
            "S_FKaguya_10Rare_17",
            "S_FKaguya_10Rare_18",
            "S_FKaguya_10Rare_19"
        };
    }
}