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
namespace Letty
{
	/// <summary>
	/// 寒潮
	/// 受到的减益效果延长 1 回合。
	/// </summary>
    public class B_Letty_6:Buff, IP_BuffAddAfter
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.DMGTaken = 15;
        }

        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Debuff && stackBuff.RemainTime != 0)
            {
                stackBuff.RemainTime++;
            }
        }
    }
}