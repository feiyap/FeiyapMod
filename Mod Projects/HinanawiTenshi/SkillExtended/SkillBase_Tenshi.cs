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
	/// 天子基类
	/// </summary>
    public class SkillBase_Tenshi:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public void AddTenki(BattleChar bc, int count = 0)
        {
            for (int i = 0; i < count; i++)
            {
                List<String> tempList = new List<string> { };
                foreach (String str in tenkiList)
                {
                    if (!bc.BuffFind(str))
                    {
                        tempList.Add(str);
                    }
                }

                if (tempList.Count <= 0)
                {
                    return;
                }

                System.Random rand = new System.Random();
                int randomIndex = rand.Next(tempList.Count);
                string randomObject = tempList[randomIndex];

                bc.BuffAdd(randomObject, this.BChar);
            }
        }

        public bool CheckTenki(bool isPreview)
        {
            foreach (String str in tenkiList)
            {
                if (this.BChar.BuffFind(str))
                {
                    if (!isPreview)
                    {
                        this.BChar.BuffReturn(str).SelfDestroy();
                    }
                    return true;
                }
            }

            if (this.BChar.BuffFind("B_Rainbow_P_47"))
            {
                if (!isPreview)
                {
                    this.BChar.BuffReturn("B_Rainbow_P_47").SelfDestroy();
                }
                return true;
            }

            if (this.BChar.BuffFind("B_Rainbow_2_0"))
            {
                if (!isPreview)
                {
                    this.BChar.BuffReturn("B_Rainbow_2_0").SelfDestroy();
                }
                return true;
            }

            return false;
        }

        public bool CheckKishi(int count, bool isPreview)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
            }
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi >= count)
            {
                if (!isPreview)
                {
                    BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi -= count;

                    if (!BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().list.Exists(num => num == count))
                    {
                        BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().list.Add(count);
                    }
                }
                return true;
            }
            return false;
        }

        public int CheckBuffNum()
        {
            int count = 0;

            count = this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;

            return count;
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

        public List<String> tenkiSkillList = new List<string>
        {
            "S_Tenki_1",
            "S_Tenki_2",
            "S_Tenki_3",
            "S_Tenki_4",
            "S_Tenki_5",
            "S_Tenki_6",
            "S_Tenki_7",
            "S_Tenki_8",
            "S_Tenki_9",
            "S_Tenki_10",
            "S_Tenki_11",
            "S_Tenki_12",
            "S_Tenki_13",
            "S_Tenki_14",
            "S_Tenki_15",
            "S_Tenki_16",
            "S_Tenki_17",
            "S_Tenki_18",
            "S_Tenki_19",
            "S_Tenki_20"
        };
    }
}