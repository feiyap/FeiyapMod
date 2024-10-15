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
namespace blackrabbitdoll
{
	/// <summary>
	/// 获得之前所有调查中未使用的金币的80%。
	/// （最多4000金币）
	/// 获得金币后减少等量的累计金币。
	/// 累积的金币：&a金币
	/// </summary>
    public class blackRabbit:PassiveItemBase, PassiveItem_EnableItem
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", SaveManager.NowData.SaveMoney.ToString());
        }
        
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.NoBattleRelic = true;
        }
        
        public void EnableItem()
        {
            int num = SaveManager.NowData.SaveMoney;
            if (num > 4000)
            {
                num = 4000;
            }
            SaveManager.NowData.SaveMoney -= num;
            InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, num));
        }
    }
}