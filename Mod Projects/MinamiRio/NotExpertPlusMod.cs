using System;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using ChronoArkMod.ModData;

namespace MinamiRio
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(CampUI))]
    public static class CampUIPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Update_Postfix(CampUI __instance)
        {
            if (__instance.Button_BloodyMist != null)
            {
                __instance.Button_BloodyMist.gameObject.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(FieldSystem))]
    class FieldSystem_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FieldSystem.StageStart))]
        static void StageStartPostfix()
        {
            if (PlayData.TSavedata.StageNum == 0)
            {
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Uncurse, 2));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread, 4));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Item_Key, 1));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, 350));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
            if (PlayData.TSavedata.StageNum == 1)
            {
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 5));
            }
            if (PlayData.TSavedata.StageNum == 3)
            {
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 5));
            }
            if (PlayData.TSavedata.StageNum == 4)
            {
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 4));
            }
        }
    }


}
