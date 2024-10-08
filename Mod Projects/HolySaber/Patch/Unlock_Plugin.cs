using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;

namespace HolySaber
{
    //露西睡醒、移动至卧室中央后，判断角色通关条件，解锁反甲哥皮肤
    [HarmonyPatch(typeof(ArkCode))]
    [HarmonyPatch("MoveTutorial")]
    public static class Unlock_Plugin
    {
        [HarmonyPostfix]
        public static void Reimu_Unlock_Patch(ArkCode __instance)
        {
            Statistics_Character charData = SaveManager.NowData.statistics.GetCharData("HolySaber");

            if (charData.HopeExpertClear >= 1 ||
                charData.HopeNomalClear >= 1 ||
                charData.ExpertClear >= 1 ||
                charData.NomalClear >= 1 ||
                charData.CasualClear >= 1)
            {
                if (!SaveManager.IsUnlock("Wilbert"))
                {
                    SaveManager.NowData.unlockList.UnlockItems.Add("Wilbert");
                }
                return;
            }
        }
    }
}
