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
using ChronoArkMod.ModData;
using HarmonyLib;
namespace Squall
{
    public class Squall_Plugin : ChronoArkPlugin
    {
        public override void Dispose()
        {
            Harmony harmony = this.harmony;
            if (harmony != null)
            {
                harmony.UnpatchSelf();
            }
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        private Harmony harmony;
    }

    [HarmonyPatch(typeof(Character))]
    class Character_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("get_get_stat")]
        public static void get_stat_Postfix(ref Stat __result, Character __instance)
        {
            Stat stat = default(Stat);

            if (__instance.KeyData == "Squall")
            {
                for (int k = 0; k < __instance.Equip.Count; k++)
                {
                    if (__instance.Equip[k] != null && __instance.Equip[k] is Item_Equip)
                    {
                        Item_Equip item_Equip = __instance.Equip[k] as Item_Equip;

                        stat.def -= item_Equip.ItemScript.PlusStat.def;
                        stat.def -= item_Equip.Enchant.EnchantData.PlusStat.def;
                        stat.def -= item_Equip.Curse.PlusStat.def;
                    }
                }
            }
            
            __result += stat;
        }
    }
}