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
namespace HakureiReimu
{
	/// <summary>
	/// 不可思议
	/// 受到的减益效果持续时间减少1回合。
	/// </summary>
    public class B_HakureiReimu_F_8:Buff, IP_BuffAddAfter
    {
        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Debuff && (addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_Debuff || addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT || addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_CrowdControl) && stackBuff.RemainTime != 0)
            {
                stackBuff.RemainTime--;
            }
        }
    }
}