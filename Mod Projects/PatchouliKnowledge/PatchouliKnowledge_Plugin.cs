using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using Dialogical;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace PatchouliKnowledge
{
    public class PatchouliKnowledge_Plugin: ChronoArkPlugin
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

    [HarmonyPatch(typeof(PlayData))]
    class PlayData_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(PlayData.RemoveOverlapSkill))]
        public static bool Prefix(Character MyChar, List<GDESkillData> SkillList, ref List<GDESkillData> __result)
        {
            if (MyChar.KeyData == "PatchouliKnowledge")
            {
                __result = SkillList;
                return false;
            }
            
            return true;
        }
    }

    [HarmonyPatch(typeof(BattleChar))]
    [HarmonyPatch("BuffAdd")]
    public static class BuffAdd_Plugin
    {
        [HarmonyPrefix]
        public static bool BuffAdd_Prefix(ref Buff __result, BattleChar __instance, string key, BattleChar UseState, bool hide = false, int PlusTagPer = 0, bool debuffnonuser = false, int RemainTime = -1, bool StringHide = false)
        {
            GDEBuffData gdebuffData = new GDEBuffData(key);
            if (gdebuffData.BuffTag != null && gdebuffData.BuffTag.Key != "" && gdebuffData.BuffTag.Key != "null" && gdebuffData.Debuff)
            {
                if (!(BattleSystem.instance == null) && __instance.BuffFind("B_Pachi_0_4", false) && (gdebuffData.BuffTag.Key == "DOT" || gdebuffData.BuffTag.Key == "Debuff"))
                {
                    __instance.SimpleTextOut(ScriptLocalization.UI_Battle.DebuffGuard);
                    __instance.BuffReturn("B_Pachi_0_4", false)?.SelfStackDestroy();
                    __result = null;
                    return false;
                }
            }

            return true;
        }
    }

    //切换区域后重新施加区域BUFF
    [HarmonyPatch(typeof(FieldSystem))]
    [HarmonyPatch("NextStage")]
    public static class NextStage_Plugin
    {
        public static List<string> BuffIDList = new List<string>
        {
            "B_Pachi_3_5",
            "B_Pachi_4_5"
        };

        public class BuffInfo
        {
            public string CharacterId { get; set; }
            public string BuffId { get; set; }
            public int StackCount { get; set; }
        }

        public static List<BuffInfo> buffList = new List<BuffInfo> { };

        [HarmonyPrefix]
        public static void NextStage_Prefix(FieldSystem __instance)
        {
            buffList.Clear();
            foreach (Character character in PlayData.TSavedata.Party)
            {
                foreach (Buff buff in character.Buffs_Field)
                {
                    if (BuffIDList.Exists(t => t == buff.BuffData.Key))
                    {
                        buffList.Add(new BuffInfo{ CharacterId = character.KeyData, BuffId = buff.BuffData.Key, StackCount = buff.StackNum });
                    }
                }
            }
        }

        [HarmonyPostfix]
        public static void NextStage_Postfix(FieldSystem __instance)
        {
            foreach (Character character in PlayData.TSavedata.Party)
            {
                foreach (BuffInfo kvp in buffList)
                {
                    if (character.KeyData == kvp.CharacterId)
                    {
                        string buff = kvp.BuffId;
                        int stack = kvp.StackCount;
                        for (int i = 0; i < stack; i++)
                        {
                            character.Buff_FieldAdd(buff);
                        }
                    }
                }
            }
        }
    }

    //城镇小人
    public static class Patchouli_FriendShipPlugin
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
                GameObject gameObject = Enumerable.FirstOrDefault<GameObject>(__instance.UnlockMainNPCList, (GameObject target) => target.name == "PatchouliKnowledge");
                if (gameObject == null)
                {
                    GameObject gameObject2 = __instance.UnlockMainNPCList[0];
                    gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject2, gameObject2.transform.parent);
                    gameObject.GetComponentInChildren<SkeletonAnimation>().skeletonDataAsset = AddressableLoadManager.LoadAsyncCompletion<SkeletonDataAsset>(ModManager.getModInfo("PatchouliKnowledge").assetInfo.ObjectFromAsset<SkeletonDataAsset>("patchoulispine", "Assets/Patchouli/Spine/skeleton_SkeletonData.asset"), 0);
                    gameObject.GetComponentInChildren<SkeletonAnimation>().Initialize(true);
                    gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "animation";
                    gameObject.GetComponent<Dialogue>().tree = AddressableLoadManager.LoadAsyncCompletion<DialogueTree>(Dia_City.DialogueTreePath_Patchouli_Ark, 0);
                    gameObject.transform.position = new Vector3(-5.50f, 8.21f, 0f);
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    gameObject.name = "PatchouliKnowledge";
                    __instance.UnlockMainNPCList.Add(gameObject);
                }
                gameObject.SetActive(true);
            }
        }
    }
}