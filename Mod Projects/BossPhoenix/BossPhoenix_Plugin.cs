using System;
using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using Dialogical;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;

namespace BossPhoenix
{
    [PluginConfig("BossPhoenix", "BossPhoenix", "1.0.0")]
    public class BossPhoenix_Plugin : ChronoArkPlugin
    {
        private Harmony harmony;

        public override void Dispose()
        {
            if (this.harmony != null)
            {
                this.harmony.UnpatchSelf();
            }
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        public override void OnModLoaded()
        {
            base.OnModLoaded();
            this.OnModSettingUpdate();
        }
    }

    [HarmonyPatch(typeof(FieldEventSelect))]
    [HarmonyPatch("FieldEventSelectOpen")]
    public static class EventPlugin
    {
        [HarmonyPrefix]
        public static void FieldEventSelectOpen_patch(FieldEventSelect __instance, ref List<string> EventList)
        {
            bool alreadyChosen = false;
            bool alreadyListed = false;
            for (int i = 0; i < PlayData.TSavedata.RandomEvent_ChooseEvents.Count; i++)
            {
                if (PlayData.TSavedata.RandomEvent_ChooseEvents[i] == ModItemKeys.RandomEvent_RE_BossPhoenix)
                {
                    alreadyChosen = true;
                }
            }
            foreach (string str in EventList)
            {
                if (str == ModItemKeys.RandomEvent_RE_BossPhoenix)
                {
                    alreadyListed = true;
                }
            }

            ChronoArkMod.ModData.ModInfo info = ModManager.getModInfo("BossPhoenix");
            if (info == null)
            {
                return;
            }

            bool forceEvent = info.GetSetting<ToggleSetting>("BossPhoenix_Event").Value;
            if (PlayData.TSavedata.StageNum == 2 && forceEvent && !alreadyChosen && !alreadyListed && PlayData.SpalcialRule != GDEItemKeys.SpecialRule_SR_Solo)
            {
                EventList.Insert(0, ModItemKeys.RandomEvent_RE_BossPhoenix);
            }
        }
    }

    [HarmonyPatch(typeof(BattleChar))]
    [HarmonyPatch("HPToZero")]
    public static class HPToZero_Plugin
    {
        [HarmonyPrefix]
        public static bool HPToZero_Prefix(BattleChar __instance)
        {
            if (__instance == null || __instance.Info == null || __instance.Info.KeyData != ModItemKeys.Enemy_Boss_Phoenix)
            {
                return true;
            }

            B_BossPhoenix_P passive = B_BossPhoenix_P.Get(__instance);
            if (passive == null || passive.Soothed)
            {
                return true;
            }

            __instance.IsDead = false;
            passive.SurviveAtOne();
            return false;
        }
    }

    /// <summary>
    /// 城镇凤凰：先邀请猜谜，选「是」开 8 次闲聊猜谜，选「否」走原版对话。
    /// </summary>
    [HarmonyPatch(typeof(ArkCode))]
    [HarmonyPatch("Start")]
    public static class PhoenixTownArk_Plugin
    {
        [HarmonyPostfix]
        public static void Start_Postfix(ArkCode __instance)
        {
            PhoenixTownRiddle.BindFromArk(__instance);
        }
    }

    [HarmonyPatch(typeof(Dialogue))]
    [HarmonyPatch("Activate")]
    public static class PhoenixTownDialogue_Plugin
    {
        [HarmonyPrefix]
        public static bool Activate_Prefix(Dialogue __instance)
        {
            return PhoenixTownRiddle.HandleActivate(__instance);
        }
    }

    [HarmonyPatch(typeof(Dialogue))]
    [HarmonyPatch("CallOption")]
    public static class PhoenixTownOption_Plugin
    {
        [HarmonyPrefix]
        public static bool CallOption_Prefix(Dialogue __instance, ConversationOption option)
        {
            return PhoenixTownRiddle.HandleOption(__instance, option);
        }
    }

    [HarmonyPatch(typeof(Dialogue))]
    [HarmonyPatch("set_conversationIsOver")]
    public static class PhoenixTownOver_Plugin
    {
        [HarmonyPostfix]
        public static void SetOver_Postfix(Dialogue __instance, bool value)
        {
            PhoenixTownRiddle.HandleConversationOver(__instance, value);
        }
    }

    public static class PhoenixTownRiddle
    {
        private static Dialogue bound;
        private static DialogueTree originalTree;
        private static DialogueTree inviteTree;
        private static bool playingInvite;
        private static bool passthroughOriginal;
        private static bool choseYes;
        private static bool handlingOver;

        public static void BindFromArk(ArkCode ark)
        {
            bound = null;
            originalTree = null;
            playingInvite = false;
            passthroughOriginal = false;
            if (ark == null || ark.UnlockMainNPCList == null)
            {
                return;
            }

            GameObject npc = null;
            for (int i = 0; i < ark.UnlockMainNPCList.Count; i++)
            {
                GameObject go = ark.UnlockMainNPCList[i];
                if (go != null && string.Equals(go.name, "Phoenix", StringComparison.OrdinalIgnoreCase))
                {
                    npc = go;
                    break;
                }
            }
            if (npc == null && ark.UnlockMainNPCList.Count > 0)
            {
                npc = ark.UnlockMainNPCList[0];
            }
            if (npc == null)
            {
                return;
            }

            bound = npc.GetComponent<Dialogue>();
            if (bound == null)
            {
                bound = npc.GetComponentInChildren<Dialogue>(true);
            }
            if (bound != null)
            {
                originalTree = bound.tree;
            }
        }

        public static bool HandleActivate(Dialogue dialogue)
        {
            if (dialogue == null || dialogue != bound)
            {
                return true;
            }
            if (passthroughOriginal)
            {
                return true;
            }
            if (playingInvite)
            {
                return true;
            }
            if (RiddleUI.IsOpen)
            {
                return false;
            }

            if (inviteTree == null)
            {
                inviteTree = AddressableLoadManager.LoadAsyncCompletion<DialogueTree>(Dia_City.DialogueTreePath_Phoenix_Ark, 0);
            }
            if (originalTree == null)
            {
                originalTree = dialogue.tree;
            }
            if (inviteTree == null)
            {
                return true;
            }

            dialogue.tree = inviteTree;
            playingInvite = true;
            choseYes = false;
            return true;
        }

        public static bool HandleOption(Dialogue dialogue, ConversationOption option)
        {
            if (!playingInvite || dialogue == null || dialogue != bound || option == null)
            {
                return true;
            }

            choseYes = option.id == 0;
            AccessTools.Property(typeof(Dialogue), "conversationIsOver").SetValue(dialogue, true, null);
            return false;
        }

        public static void HandleConversationOver(Dialogue dialogue, bool value)
        {
            if (!value || !playingInvite || handlingOver || dialogue == null || dialogue != bound)
            {
                return;
            }

            handlingOver = true;
            playingInvite = false;
            if (originalTree != null)
            {
                dialogue.tree = originalTree;
            }

            bool yes = choseYes;
            choseYes = false;
            handlingOver = false;

            if (yes)
            {
                RiddleUI.OpenCasual();
                return;
            }

            passthroughOriginal = true;
            try
            {
                dialogue.Activate();
            }
            finally
            {
                passthroughOriginal = false;
            }
        }
    }
}
