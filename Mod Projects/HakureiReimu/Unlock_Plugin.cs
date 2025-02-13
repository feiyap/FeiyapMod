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
    //露西睡醒、移动至卧室中央后，判断角色通关条件，解锁博丽灵梦或皮肤
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
            "Qinxin",
            "CuteDog",
            "Kasen",
            "Utuho",
            "Rin",
            "Touhou_LilyWhite",
            "Touhou_LilyBlack",
            "Kurumi",
            "Marisa",
            "Patchouli",
            "Koishi"
        };

        [HarmonyPostfix]
        public static void Reimu_Unlock_Patch(ArkCode __instance)
        {
            foreach (string charaName in TouhouChara)
            {
                Statistics_Character charData = SaveManager.NowData.statistics.GetCharData(charaName);

                if (charData.HopeExpertClear >= 1 || 
                    charData.HopeNomalClear >= 1 || 
                    charData.ExpertClear >= 1 ||
                    charData.NomalClear >= 1 ||
                    charData.CasualClear >= 1)
                {
                    UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                    if (charaName == "HakureiReimu" && !SaveManager.IsUnlock("HakureiReimuEclipse"))
                    {
                        SaveManager.NowData.unlockList.UnlockItems.Add("HakureiReimuEclipse");
                    }
                    return;
                }
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
            foreach (string charaName in Unlock_Plugin.TouhouChara)
            {
                Statistics_Character charData = SaveManager.NowData.statistics.GetCharData(charaName);

                if (charData.HopeExpertClear >= 1 ||
                    charData.HopeNomalClear >= 1 ||
                    charData.ExpertClear >= 1 ||
                    charData.NomalClear >= 1 ||
                    charData.CasualClear >= 1)
                {
                    UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                    if (charaName == "HakureiReimu" && !SaveManager.IsUnlock("HakureiReimuEclipse"))
                    {
                        SaveManager.NowData.unlockList.UnlockItems.Add("HakureiReimuEclipse");
                    }
                    return;
                }
            }
        }
    }
}
