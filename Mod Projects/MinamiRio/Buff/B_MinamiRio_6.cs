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
namespace MinamiRio
{
	/// <summary>
	/// 追踪术
	/// </summary>
    public class B_MinamiRio_6:Buff, IP_Dead
    {
        public override void Init()
        {
            this.PlusStat.RES_CC = -50;
            this.PlusStat.RES_DEBUFF = -50;
            this.PlusStat.RES_DOT = -50;
            this.PlusStat.IgnoreTaunt_EnemySelf = true;
        }

        public void Dead()
        {
            InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 200));
        }
    }
}