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
using ChronoArkMod.ModData.Settings;
namespace saber
{
	/// <summary>
	/// 石中之剑
	/// 一把插在岩石中的剑
	/// 岩石上写着：拔出此剑者，即为英格兰之王！
	/// Button
	/// 尝试拔剑
	/// 离开
	/// ButtonToolTip
	/// </summary>
    public class Saber_bajian:RandomEventBaseScript
    {
        public override void EventOpen()
        {
            base.EventOpen();
            bool bossClear = PlayData.TSavedata.BossClear;
            if (bossClear)
            {
                this.MyInven.InventoryItems[0] = null;
                base.ChangeDesc(this.MainData.OrderStrings[1], true);
                base.EventDisable();
            }
            else
            {
                ItemBase item = ItemBase.GetItem("Saber_Calibur");
                this.MyInven.InventoryItems[0] = null;
                this.MyInven.AddNewItem(item);
            }
        }

        // Token: 0x060000DB RID: 219 RVA: 0x00005EAC File Offset: 0x000040AC
        public override void UseButton1()
        {
            base.UseButton1();
            InventoryManager.Reward(this.MyInven.InventoryItems[0]);
            this.MyInven.DelItem(0);
            base.ChangeDesc(this.MainData.OrderStrings[0], true);
            MasterAudio.PlaySound("PullingSwordout", 1f, null, 0f, null, null, false, false);
            base.EventDisable();
        }
    }
}