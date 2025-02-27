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
	/// 绯想之剑
	/// 攻击时获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class E_Tenshi_0:EquipBase, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 20;
            this.PlusStat.hit = 5;
        }

        public void Turn()
        {
            AddTenki(this.BChar, 3);
        }

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