using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using ChronoArkMod;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;
using GameDataEditor;

namespace CirnoBlizzard
{
    [HarmonyPatch(typeof(BattleActWindow))]
    public class BattleActWindowPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Init")]
        private static void Init_Postfix(BattleActWindow __instance, BattleTeam Team)
        {
            if (BattleEvent_CirnoBlizzard.Boss != null)
            {
                foreach (Animator ani in __instance.Crystals)
                {
                    ani.transform.Find("On").GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f);
                }
                for (int i = 0; i < BattleEvent_CirnoBlizzard.FreezeAP; i++)
                {
                    __instance.Crystals[9 - i].SetBool("Lock", false);
                    __instance.Crystals[9 - i].SetBool("On", true);
                    __instance.Crystals[9 - i].transform.Find("On").GetComponent<Image>().color = new UnityEngine.Color(0f, 1f, 1f);
                }

                if (BattleSystem.instance.AllyTeam.LucyChar.BuffFind("B_Boss_Cirno_P_3_0"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        __instance.Crystals[9 - i].SetBool("Lock", false);
                        __instance.Crystals[9 - i].transform.Find("On").GetComponent<Image>().color = new UnityEngine.Color(0f, 1f, 1f);
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(BattleTeam), nameof(BattleTeam.MAXAP), MethodType.Getter)]
    public class BattleTeam_MAXAP_Patch
    {
        static void Postfix(ref int __result)
        {
            if (BattleEvent_CirnoBlizzard.Boss != null)
            {
                int modifiedValue = Math.Min(10 - BattleEvent_CirnoBlizzard.FreezeAP, __result);
                __result = Math.Max(0, modifiedValue);
            }
            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.AllyTeam.LucyChar.BuffFind("B_Boss_Cirno_P_3_0"))
                {
                    __result = 0;
                }
            }
        }
    }
}
