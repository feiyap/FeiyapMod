using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using UnityEngine.Events;

namespace DiffcultSystem
{
    public class EndorphinSave : CustomValue
    {
        //实例化
        public static EndorphinSave Instance
        {
            get
            {
                EndorphinSave endorphinSave = PlayData.TSavedata.GetCustomValue<EndorphinSave>();
                if (endorphinSave == null)
                {
                    endorphinSave = new EndorphinSave();
                    PlayData.TSavedata.AddCustomValue(endorphinSave);
                }
                return endorphinSave;
            }
        }
        
        //获取内啡肽
        public static ItemBase GetEndorphinPassive()
        {
            ItemBase result;
            result = ItemBase.GetItem("Endorphin".ToString());
            return result;
        }

        //设置内啡肽
        public static void SetEndorphinPassive()
        {
            if (UIManager.NowActiveUI is ArkPartsUI)
            {
                UIManager.NowActiveUI.Delete();
            }
            Item_Passive item_Passive = EndorphinSave.GetEndorphinPassive() as Item_Passive;
                
            if (item_Passive != null)
            {
                int num = PlayData.TSavedata.Passive_Itembase.FindIndex(delegate (ItemBase i)
                {
                    Item_Passive item_Passive2 = i as Item_Passive;
                    return ((item_Passive2 != null) ? item_Passive2.ItemScript : null) is Endorphin;
                });
                    
                if (num < 0)
                {
                    PlayData.TSavedata.Passive_Itembase.Insert(0, item_Passive);
                    if (!EndorphinSave.Instance._PassiveSlotAdd)
                    {
                        PlayData.TSavedata.ArkPassivePlus++;
                        EndorphinSave.Instance._PassiveSlotAdd = true;
                    }
                    else
                    {
                        if (!PlayData.TSavedata.Passive_Itembase.Remove(null))
                        {
                            PlayData.TSavedata.ArkPassivePlus++;
                            EndorphinSave.Instance._PassiveSlotAdd = true;
                        }
                    }
                }
                else
                {
                    PlayData.TSavedata.Passive_Itembase[num] = item_Passive;
                }
            }
        }

        //处理部分启用时效果
        public void updateEndorphin(string keyid, bool isAdd)
        {
            switch (keyid)
            {
                //内陆帝国：-背包格子数-3。
                case "Endorphin_InlandEmpire":
                    ApplyInlandEmpireInventoryChange(isAdd);
                    break;
            }
        }

        // 内陆帝国：调整背包上限。原版 ChangeMaxInventoryNum 在增加格数时不会刷新 UI。
        static void ApplyInlandEmpireInventoryChange(bool isAdd)
        {
            int delta = isAdd ? -3 : 3;
            if (PartyInventory.InvenM != null)
            {
                PartyInventory.InvenM.ChangeMaxInventoryNum(delta);
            }
            else
            {
                PlayData.TSavedata.MaxinventoryNumPlus += delta;
            }

            if (!isAdd)
            {
                PartyInventory.Init();
                if (PartyInventory.Ins != null)
                {
                    PartyInventory.Ins.UpdateInvenUI();
                }
            }
        }

        public bool _PassiveSlotAdd = false;
        
        public List<string> endorphinActiveList = new List<string>();
    }
}