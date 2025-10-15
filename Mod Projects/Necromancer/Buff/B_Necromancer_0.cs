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
	/// 恍惚
	/// </summary>
    public class B_Necromancer_0:Buff, IP_BuffAdd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override string DescExtended()
        {
            switch(StackNum)
            {
                case 1:
                    //return base.DescExtended().Replace("恍惚", "于死地的幻梦中沉溺。");
                    return base.DescExtended().Replace("&a", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_0_1"));
                case 2:
                    //return base.DescExtended().Replace("恍惚", "骨与血涌动着窃窃私语。");
                    return base.DescExtended().Replace("&a", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_0_2"));
                case 3:
                    //return base.DescExtended().Replace("恍惚", "某日记忆的残片掠过心头...");
                    return base.DescExtended().Replace("&a", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_0_3"));
                default:
                    return base.DescExtended().Replace("&a", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_0_0"));
            }
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (addedbuff.BuffData.Key == "B_Necromancer_1" && BuffTaker == BChar)
            {
                this.SelfDestroy();
            }
        }
    }
}