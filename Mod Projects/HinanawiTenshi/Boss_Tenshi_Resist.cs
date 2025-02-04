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

namespace HinanawiTenshi
{
    [HarmonyPatch(typeof(FieldEventSelect))]
    [HarmonyPatch("FieldEventSelectOpen")]
    public static class EventPlugin
    {
        // Token: 0x0600004E RID: 78 RVA: 0x000031EC File Offset: 0x000013EC
        [HarmonyPrefix]
        public static void FieldEventSelectOpen_patch(FieldEventSelect __instance, ref List<string> EventList)
        {
            bool flag = false;
            bool flag2 = false;
            for (int i = 0; i < PlayData.TSavedata.RandomEvent_ChooseEvents.Count; i++)
            {
                if (PlayData.TSavedata.RandomEvent_ChooseEvents[i] == "RE_Tenshi_Boss")
                {
                    flag = true;
                }
            }
            foreach (string str in EventList)
            {
                if (str == "RE_Tenshi_Boss")
                {
                    flag2 = true;
                }
            }
            if (PlayData.TSavedata.StageNum == 4 && ModManager.getModInfo("HinanawiTenshi").GetSetting<ToggleSetting>("HinanawiBoss_Event").Value && !flag && !flag2 && PlayData.SpalcialRule != GDEItemKeys.SpecialRule_SR_Solo)
            {
                EventList.Insert(0, "RE_Tenshi_Boss");
            }
        }
    }

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
                if (BattleSystem.instance != null && __instance.HP >= 0)
                {
                    foreach (IP_HPZero ip_HPZero in __instance.IReturn<IP_HPZero>(null))
                    {
                        if (ip_HPZero != null)
                        {
                            ip_HPZero.HPZero();
                        }
                    }
                }

                __instance.SimpleTextOut(ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text6"));

                return false;
            }

            return true;
        }
    }

    //[HarmonyPatch(typeof(ToolTipWindow))]
    //[HarmonyPatch("SkillToolTip")]
    //public static class SkillToolTip_Plugin
    //{
    //    [HarmonyPostfix]
    //    public static void SkillToolTip_Prefix(ref GameObject __result)
    //    {
    //        if (__result.GetComponent<SkillToolTip>().Values.SkillData.MySkill.KeyID == "Boss_S_Tenshi_1")
    //        {
    //            __result.GetComponent<RectTransform>().pivot = new Vector2((float)0.5, (float)0.5);
    //            __result.transform.Rotate(180, 180, 0, Space.Self);
    //            __result.GetComponent<RectTransform>().pivot = new Vector2((float)0, (float)0);
    //        }
    //    }
    //}
}
