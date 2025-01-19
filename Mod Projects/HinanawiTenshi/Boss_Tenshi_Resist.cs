using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;
using GameDataEditor;

namespace HinanawiTenshi
{
    [HarmonyPatch(typeof(BattleChar))]
    [HarmonyPatch("BuffAdd")]
    public static class BuffAdd_Plugin
    {
        public static List<string> BuffIDList = new List<string>
        {
            "Boss_B_Tenshi_Phase_2"
        };

        [HarmonyPrefix]
        public static bool BuffAdd_Prefix(ref Buff __result, BattleChar __instance, string key, BattleChar UseState, bool hide = false, int PlusTagPer = 0, bool debuffnonuser = false, int RemainTime = -1, bool StringHide = false)
        {
            GDEBuffData gdebuffData = new GDEBuffData(key);
            Buff buff = Buff.DataToBuff(gdebuffData, __instance, UseState, RemainTime, false, 0);

            if (gdebuffData.BuffTag != null && gdebuffData.BuffTag.Key != "" && gdebuffData.BuffTag.Key != "null" && gdebuffData.Debuff)
            {
                if (!(BattleSystem.instance == null) && __instance.BuffFind("Boss_B_Tenshi_Phase_2", false))
                {
                    __instance.SimpleTextOut(ScriptLocalization.UI_Battle.DebuffGuard);
                    __result = null;
                    return false;
                }
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(BattleChar))]
    [HarmonyPatch("HPToZero")]
    public static class HPToZero_Plugin
    {
        [HarmonyPrefix]
        public static bool HPToZero_Prefix(BattleChar __instance)
        {
            if (__instance.Info.KeyData == "Boss_Tenshih")
            {
                return false;
            }

            return true;
        }
    }
}
