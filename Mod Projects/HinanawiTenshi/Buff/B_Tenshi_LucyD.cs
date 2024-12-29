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
	/// 勇气凛凛
	/// 获得增益时抽取1个技能（最多触发4次）。
	/// </summary>
    public class B_Tenshi_LucyD:Buff, IP_BuffAdd
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (!addedbuff.IsHide && BuffTaker == this.BChar)
            {
                BattleSystem.instance.AllyTeam.Draw(1);
            }
        }
    }
}