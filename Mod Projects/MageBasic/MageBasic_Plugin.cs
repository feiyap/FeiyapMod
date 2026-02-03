using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using EItem;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace MageBasic
{
    public class MageBasic_Plugin: ChronoArkPlugin
    {
        private Harmony harmony;
        public override void Dispose()
        {
            this.harmony.UnpatchSelf();
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        public override void OnModLoaded()
        {
            base.OnModLoaded();
            this.OnModSettingUpdate();
        }
    }

    //1-2商店出售魔女技能书
    [HarmonyPatch(typeof(FieldStore))]
    [HarmonyPatch("Init")]
    public static class FieldStorePlugin
    {
        // Token: 0x0600004E RID: 78 RVA: 0x000031EC File Offset: 0x000013EC
        [HarmonyPostfix]
        public static void Init_patch(FieldStore __instance)
        {
            if (PlayData.TSavedata.StageNum == 1)
            {
                __instance.StoreItems.Add(ItemBase.GetItem("SkillBookMage", 1));
            }
            if (PlayData.TSavedata.StageNum == 2)
            {
                __instance.StoreItems.Add(ItemBase.GetItem("SkillBookMage", 1));
            }
        }
    }

    //万花筒
    [HarmonyPatch(typeof(KaleidoScopeNecklace))]
    [HarmonyPatch("ItemEquip")]
    public static class KaleidoScopeNecklacePlugin
    {
        [HarmonyPostfix]
        public static IEnumerator Postfix(IEnumerator __result, KaleidoScopeNecklace __instance, Item_Equip equip)
        {
            while (__result.MoveNext())
            {
                yield return __result.Current;
            }

            if (__instance.MyChar != null && equip == __instance.MyItem)
            {
                if (__instance.MyChar.GetData.Role.Key.ToString() == "Role_Mage")
                {
                    __instance.PlusStat.cri += 11f;      // DPS cri
                    __instance.PlusStat.maxhp += 6;      // Tank maxhp
                    __instance.PlusStat.HEALTaken += 15f; // Tank HEALTaken
                    __instance.PlusStat.reg += 2;        // Support reg
                    __instance.PlusStat.HIT_DOT += 10f;   // Support HIT_DOT
                    __instance.PlusStat.HIT_CC += 10f;    // Support HIT_CC
                    __instance.PlusStat.HIT_DEBUFF += 10f; // Support HIT_DEBUFF
                }
            }
        }
    }

    //荒野的旋律
    [HarmonyPatch(typeof(CharEquipInven), "OnDropSlot")]
    public static class CharEquipInven_OnDropSlot_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(CharEquipInven __instance, ItemBase inputitem, ref bool __result)
        {
            if (!__result) return;
            if (inputitem.itemkey != GDEItemKeys.Item_Equip_Guitar) return;

            if (__instance.Info.GetData.Role.Key == "Role_Mage")
            {
                __result = false;
            }
        }
    }
}