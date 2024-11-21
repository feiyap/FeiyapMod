using System;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;

namespace MinamiRio
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(CampAnvilEvent))]
    public static class ForgeTreePlugin
    {
        [HarmonyPrefix]
        [HarmonyPatch("B1Fuc")]
        public static bool B1Fuc_Prefix(CampAnvilEvent __instance)
        {
            List<ItemBase> atkEquip = new List<ItemBase>();
            List<ItemBase> defEquip = new List<ItemBase>();
            List<ItemBase> regEquip = new List<ItemBase>();
            foreach (ItemBase ib in PlayData.ALLITEMLIST)
            {
                if (!(ib is Item_Equip))
                {
                    continue;
                }
                if ((ib as Item_Equip).ItemScript.PlusStat.atk > 0 || (ib as Item_Equip).ItemScript.PlusPerStat.Damage > 0 || (ib as Item_Equip).ItemScript.PlusStat.cri > 0)
                {
                    atkEquip.Add(ib);
                }
                if ((ib as Item_Equip).ItemScript.PlusStat.def > 0 || (ib as Item_Equip).ItemScript.PlusStat.maxhp > 0 || (ib as Item_Equip).ItemScript.PlusPerStat.MaxHP > 0)
                {
                    defEquip.Add(ib);
                }
                if ((ib as Item_Equip).ItemScript.PlusStat.reg > 0 || (ib as Item_Equip).ItemScript.PlusPerStat.Heal > 0 || (ib as Item_Equip).ItemScript.PlusStat.dod > 0)
                {
                    regEquip.Add(ib);
                }
            }
            
            if (!__instance.CombineBtn.interactable || __instance.InventoryItems[0] == null || __instance.InventoryItems[1] == null)
            {
                return true;
            }

            if (__instance.InventoryItems[0] is Item_Passive || __instance.InventoryItems[1] is Item_Passive)
            {
                return true;
            }
            
            Item_Equip item_Equip;
            if (__instance.InventoryItems.Find((ItemBase a) => a.itemkey == ModItemKeys.Item_Misc_ForgeTree_TreeOfLife) != null)
            {
                if (__instance.InventoryItems[0] is Item_Equip)
                {
                    item_Equip = (__instance.InventoryItems[0] as Item_Equip);
                }
                else
                {
                    if (!(__instance.InventoryItems[1] is Item_Equip))
                    {
                        return true;
                    }
                    item_Equip = (__instance.InventoryItems[1] as Item_Equip);
                }
                int num = item_Equip.ItemClassNum;
                num++;
                if (num >= 4)
                {
                    num = 4;
                }
                int num2 = 0;
                string equipRandom;
                for (; ; )
                {
                    equipRandom = PlayData.GetEquipRandom(num);
                    if (!(equipRandom == __instance.InventoryItems[0].itemkey) && !(equipRandom == __instance.InventoryItems[1].itemkey) 
                        && (atkEquip.Find((ItemBase a) => a.itemkey == equipRandom) != null))
                    {
                        break;
                    }
                    num2++;
                    if (num2 >= 100)
                    {
                        MasterAudio.PlaySound("Anvil", 1f, null, 0f, null, null, false, false);
                        InventoryManager.Reward(ItemBase.GetItem(equipRandom));
                        __instance.DelItem(0);
                        __instance.DelItem(1);
                        PlayData.TSavedata.AnvilCount--;
                        if (PlayData.TSavedata.AnvilCount <= 0)
                        {
                            for (int i = 0; i < __instance.Align.transform.childCount; i++)
                            {
                                GameObject.Destroy(__instance.Align.transform.GetChild(i).gameObject);
                            }
                        }
                        return false;
                    }
                }
                MasterAudio.PlaySound("Anvil", 1f, null, 0f, null, null, false, false);
                InventoryManager.Reward(ItemBase.GetItem(equipRandom));
                __instance.DelItem(0);
                __instance.DelItem(1);
                PlayData.TSavedata.AnvilCount--;
                if (PlayData.TSavedata.AnvilCount <= 0)
                {
                    for (int i = 0; i < __instance.Align.transform.childCount; i++)
                    {
                        GameObject.Destroy(__instance.Align.transform.GetChild(i).gameObject);
                    }
                }
                return false;
            }

            return true;
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("FixedUpdate")]
        public static void FixedUpdate_Postfix(CampAnvilEvent __instance)
        {
            if (__instance.InventoryItems[0] == null || __instance.InventoryItems[1] == null)
            {
                return;
            }

            if (__instance.InventoryItems[0].itemkey == ModItemKeys.Item_Misc_ForgeTree_TreeOfLife)
            {
                if (__instance.InventoryItems[1] is Item_Equip)
                {
                    __instance.CombineInfoText.gameObject.SetActive(true);
                    __instance.CombinePerText.gameObject.SetActive(true);
                    __instance.CombineBtn.interactable = true;
                }
            }
            else if (__instance.InventoryItems[1].itemkey == ModItemKeys.Item_Misc_ForgeTree_TreeOfLife)
            {
                if (__instance.InventoryItems[0] is Item_Equip)
                {
                    __instance.CombineInfoText.gameObject.SetActive(true);
                    __instance.CombinePerText.gameObject.SetActive(true);
                    __instance.CombineBtn.interactable = true;
                }
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("OnDropSlot")]
        public static bool OnDropSlot_Prefix(CampAnvilEvent __instance, ItemBase inputitem, ref bool __result)
        {
            if (inputitem.itemkey == ModItemKeys.Item_Misc_ForgeTree_TreeOfLife)
            {
                __result = false;
                return false;
            }
            __result = false;
            return true;
        }
    }
}
