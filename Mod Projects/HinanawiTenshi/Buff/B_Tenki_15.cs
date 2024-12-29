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
	/// 天气 - 极光
	/// 从其他所有天气中随机生效一种。每次使用技能后改变。
	/// 当前生效的天气为：&a
	/// </summary>
    public class B_Tenki_15:Buff, IP_SkillUseHand_Team
    {
        public int count = 0;

        public override string DescExtended()
        {
            GDEBuffData gdebuffData = new GDEBuffData(tenkiList[count]);
            return base.DescExtended().Replace("&a", gdebuffData.Name);
        }

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            count = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 21);

            switch (count)
            {
                case 1:
                    this.PlusPerStat.Damage += 10;
                    break;
                case 2:
                    this.PlusStat.cri += 20;
                    break;
                case 5:
                    this.PlusStat.HEALTaken += 33;
                    break;
                case 6:
                    this.PlusStat.dod += 15;
                    break;
                case 8:
                    this.PlusStat.maxhp += 5;
                    break;
                case 11:
                    this.PlusStat.PlusCriDmg += 50;
                    break;
                case 13:
                    this.PlusStat.IgnoreTaunt = true;
                    break;
                case 14:
                    this.PlusPerStat.Damage += 30;
                    this.PlusStat.DMGTaken += 50;
                    break;
                case 17:
                    this.PlusStat.def += 15;
                    break;
                case 18:
                    this.PlusStat.dod += 10;
                    this.PlusStat.cri += 10;
                    break;
                case 19:
                    this.PlusStat.HIT_CC += 50;
                    this.PlusStat.HIT_DEBUFF += 50;
                    this.PlusStat.HIT_DOT += 50;
                    break;
                case 20:
                    this.PlusStat.Strength = true;
                    break;
                default:
                    break;
            }
        }

        public List<String> tenkiList = new List<string>
        {
            "B_Tenki_1",
            "B_Tenki_2",
            "B_Tenki_3",
            "B_Tenki_4",
            "B_Tenki_5",
            "B_Tenki_6",
            "B_Tenki_7",
            "B_Tenki_8",
            "B_Tenki_9",
            "B_Tenki_10",
            "B_Tenki_11",
            "B_Tenki_12",
            "B_Tenki_13",
            "B_Tenki_14",
            "B_Tenki_15",
            "B_Tenki_16",
            "B_Tenki_17",
            "B_Tenki_18",
            "B_Tenki_19",
            "B_Tenki_20"
        };
    }
}