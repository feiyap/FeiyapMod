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

namespace HakureiReimu
{
    [HarmonyPatch(typeof(ArkCode))]
    [HarmonyPatch("MoveTutorial")]
    public static class Unlock_Plugin
    {
        public static List<string> TouhouChara = new List<string>
        {
            "HakureiReimu",
            "RemiliaScarlet",
            "IzayoiSakuya",
            "SatsukiRin",
            "FlandreScarlet",
            "Reisen",
            "Eirin",
            "HouraisanKaguya",
            "Inaba",
            "KochiyaSanae",
            "ShameimaruAya",
            "YasakaKanano",
            "MoriyaSuwako",
            "Sunmeitian",
            "Mokou",
            "Youmu",
            "Cirno",
            "Daiyousei",
            "HoanMeirin",
            "TouhouAlice",
            "Kogasa",
            "Patchouli",
            "Marisa",
            "Koishi",
            "Kasen",
            "Kurumi"
        };

        [HarmonyPostfix]
        public static void Reimu_Unlock_Patch(ArkCode __instance)
        {
            foreach (string charaName in TouhouChara)
            {
                Statistics_Character charData = SaveManager.NowData.statistics.GetCharData(charaName);
                if (SaveManager.NowData.GameOptions.CasualMode)
                {
                    if (charData.HopeExpertClear >= 1)
                    {
                        UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                        return;
                    }
                    if (charData.HopeNomalClear >= 1)
                    {
                        UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                        return;
                    }
                    return;
                }
                else
                {
                    if (charData.ExpertClear >= 1)
                    {
                        UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                        return;
                    }
                    if (charData.NomalClear >= 1)
                    {
                        UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                        return;
                    }
                    if (charData.CasualClear >= 1)
                    {
                        UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                        return;
                    }
                    return;
                }
            }
        }
    }
}
