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
	/// 烧伤
	/// </summary>
    public class B_Mokou_T_1:Buff, IP_BuffAdd
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyList)
            {
                bool flag = battleChar.BuffFind("B_Mokou_S_R_1", false);
                if (flag)
                {
                    bool flag2 = BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_Mokou_T_1" && base.StackNum == this.BuffData.MaxStack && BuffUser != this.BChar;
                    if (flag2)
                    {
                        int num = addedbuff.Tick();
                        int stackNum = addedbuff.StackNum;
                        int num2 = num / stackNum;
                        BuffTaker.Damage(BuffUser, 5 * num2, false, true, true, 0, false, false, false);
                        break;
                    }
                }
            }
        }
        
        public override void Init()
        {
            this.PlusPerStat.Damage = -2 * base.StackNum;
        }
        
        public override void BuffStat()
        {
            this.PlusPerStat.Damage = -2 * base.StackNum;
            base.BuffStat();
        }
    }
}