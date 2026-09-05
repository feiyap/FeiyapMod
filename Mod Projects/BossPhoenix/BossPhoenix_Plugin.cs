using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using GameDataEditor;
using HarmonyLib;

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
            if (__instance.Info.KeyData != ModItemKeys.Enemy_Boss_Phoenix)
            {
                return true;
            }

            B_BossPhoenix_P passive = B_BossPhoenix_P.Get(__instance);
            if (passive == null || passive.Soothed)
            {
                return true;
            }

            if (__instance.HP < 1)
            {
                __instance.HP = 1;
            }
            __instance.IsDead = false;
            passive.TriggerStubborn();
            return false;
        }
    }
}
