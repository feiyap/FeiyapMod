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
namespace Necromancer
{
	/// <summary>
	/// 苦痛潮汐
	/// 获得此身为祭时，扩散至所有敌人，
	/// 忘却之灵：额外扩散一层。
	/// </summary>
    public class B_Necromancer_r_0:Buff, IP_BuffAdd
    {
        private int buffLv = 0;
        private int num = 0;
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker != BChar)
            {
                return;
            }
            if (addedbuff.BuffData.Key == "B_Necromancer_4")
            {
                num++;
                bool flag = BChar.BuffFind("B_Necromancer_1");
                foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
                {
                    bool oneTarget = BattleSystem.instance.EnemyList.Count == 1;
                    battleEnemy.BuffAdd("B_Necromancer_4", BChar);
                    if (buffLv >= 2 && oneTarget)
                    {
                        battleEnemy.BuffAdd("B_Necromancer_4", BChar);
                    }
                    if (flag || buffLv >= 1)
                    {
                        battleEnemy.BuffAdd("B_Necromancer_4", BChar);
                        if (buffLv >= 2 && oneTarget)
                        {
                            battleEnemy.BuffAdd("B_Necromancer_4", BChar);
                        }
                    }
                    if (buffLv >= 3)
                    {
                        battleEnemy.BuffAdd("B_Necromancer_8", BChar);
                        if (oneTarget)
                        {
                            battleEnemy.BuffAdd("B_Necromancer_8", BChar);
                        }
                    }
                    if (buffLv >= 4)
                    {
                        battleEnemy.BuffAdd("B_Necromancer_3", BChar);
                        if (oneTarget)
                        {
                            battleEnemy.BuffAdd("B_Necromancer_3", BChar);
                        }
                    }
                }
            }
            if (addedbuff.BuffData.Key == "B_Necromancer_r_0")
            {
                buffLv++;
            }
            if (num >= 9)
            {
                buffLv++;
                num -= 9;
            }
        }
        public override string DescExtended()
        {
            string des = base.DescExtended();
            des = des.Replace("&a", buffLv.ToString()).Replace("&b", num.ToString());
            if (buffLv == 0)
            {
                //des = des.Replace("#", "忘却之灵：额外扩散一层。\n");
                des = des.Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_r_0_1"));
            }
            if(buffLv >= 1)
            {
                //des = des.Replace("#", "额外扩散一层。\n#");
                des = des.Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_r_0_2"));
            }
            if (buffLv >= 2)
            {
                //des = des.Replace("#", "若目标唯一，扩散翻倍。\n#");
                des = des.Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_r_0_3"));
            }
            if (buffLv >= 3)
            {
                //des = des.Replace("#", "扩散时施加生命崩解。\n#");
                des = des.Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_r_0_4"));
            }
            if (buffLv >= 4)
            {
                //des = des.Replace("#", "扩散时施加灵压内爆。\n#");
                des = des.Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_r_0_5"));
            }
            des = des.Replace("#", "");
            return des;
        }

    }
}