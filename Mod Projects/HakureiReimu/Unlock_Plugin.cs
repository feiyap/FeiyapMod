using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Dialogical;
using HarmonyLib;
using Spine.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

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
                    //UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
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
                    //UnlockWindow.Unlock("Unlock_HakureiReimu", SaveManager.NowData.unlockList.UnlockCharacter, "HakureiReimu", true, true);
                    if (charaName == "HakureiReimu" && !SaveManager.IsUnlock("HakureiReimuEclipse"))
                    {
                        SaveManager.NowData.unlockList.UnlockItems.Add("HakureiReimuEclipse");
                    }
                    return;
                }
            }
        }
    }

    public static class Reimu_FriendShipPlugin
    {
        // Token: 0x02000128 RID: 296
        [HarmonyPatch(typeof(ArkCode))]
        private class ArkCode_Plugin
        {
            // Token: 0x060004ED RID: 1261 RVA: 0x000159E0 File Offset: 0x00013BE0
            [HarmonyPatch("Start")]
            [HarmonyPostfix]
            public static void ArkCode_Start_Patch(ArkCode __instance)
            {
                try
                {
                    GameObject gameObject = Enumerable.FirstOrDefault<GameObject>(__instance.UnlockMainNPCList, (GameObject target) => target.name == "HakureiReimu");
                    if (gameObject == null)
                    {
                        GameObject gameObject2 = __instance.UnlockMainNPCList[0];
                        gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject2, gameObject2.transform.parent);
                        gameObject.GetComponentInChildren<SkeletonAnimation>().skeletonDataAsset = AddressableLoadManager.LoadAsyncCompletion<SkeletonDataAsset>(ModManager.getModInfo("HakureiReimu").assetInfo.ObjectFromAsset<SkeletonDataAsset>("reimu", "Assets/Reimu/Spine/skeleton_SkeletonData.asset"), 0);
                        gameObject.GetComponentInChildren<SkeletonAnimation>().Initialize(true);
                        gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "animation";
                        gameObject.GetComponent<Dialogue>().tree = AddressableLoadManager.LoadAsyncCompletion<DialogueTree>(Dia_City.DialogueTreePath_HakureiReimu_Ark, 0);
                        gameObject.transform.position = new Vector3(-2.55f, 6.85f, 0);
                        gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                        gameObject.name = "HakureiReimu";
                        __instance.UnlockMainNPCList.Add(gameObject);
                    }
                    gameObject.SetActive(true);
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("[HakureiReimu] 方舟 NPC 挂载失败: " + ex);
                }
            }
        }
    }
}
