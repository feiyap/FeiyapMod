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
using I2.Loc;
using HarmonyLib;

namespace HolySaber
{
    //管理皮肤界面上锁
    [HarmonyPatch(typeof(CharacterSkinUI))]
    [HarmonyPatch("LockUISet")]
    public static class LockSkin_Plugin
    {
        public static List<string> skinList = new List<string>
        {
            "Wilbert"
        };

        [HarmonyPostfix]
        public static void Skin_Lock_Patch(CharacterSkinUI __instance)
        {
            if (__instance._nowSelectSkin != null && __instance._nowSelectSkin._skinData != null)
            {
                if (__instance._nowSelectSkin._skinData.Key == "Wilbert")
                {
                    if (!SaveManager.IsUnlock("Wilbert"))
                    {
                        __instance._applyBtnDesc.text = "使用圣辉女剑士通关1次后解锁。";
                        __instance._applyBtn.interactable = false;
                    }
                }
            }
        }
    }
}
