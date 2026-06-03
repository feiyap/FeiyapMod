using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace DiffcultSystem
{
    public class DiffcultSystem_Plugin : ChronoArkPlugin
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

    //鬼祟玲珑：-法力值上限为3。
    [HarmonyPatch(typeof(BattleTeam))]
    [HarmonyPatch(nameof(BattleTeam.MAXAP), MethodType.Getter)]
    public static class BattleTeam_MAXAP_Patch
    {
        public static void Postfix(ref int __result)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Sly"))
            {
                __result = 3;
            }
        }
    }

    //天人感应：+可选事件数+1。+可选选项数+1。
    [HarmonyPatch(typeof(RandomEventObject))]
    [HarmonyPatch(nameof(RandomEventObject.Event))]
    public static class RandomEventObject_Event_Patch
    {
        public static bool Prefix(RandomEventObject __instance)
        {
            if (__instance.EventList == null)
            {
                __instance.EventList = new List<string>();
            }
            __instance.EventList.Clear();
            __instance.EventList = FieldEventSelect.GetEventList(false, null);

            int optionCount = 2;
            if (PlayData.TSavedata.Passive_Itembase.Find((ItemBase a) => a != null && a.itemkey == GDEItemKeys.Item_Passive_Sign) != null)
            {
                optionCount = 3;
            }

            // 如果激活了 Endorphin_Mystical，增加1个选项
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Mystical"))
            {
                optionCount++;
            }

            FieldEventSelect.FieldEventSelectOpen(
                __instance.EventList.Random(RandomClassKey.Event, optionCount),
                __instance.MyEventObj,
                __instance.gameObject,
                false
            );

            __instance.MyEventObj.Useless();
            __instance.MyEventObj.Tile.Info.Type.Eventend = false;

            return false;
        }
    }

    //标新立异：+队员升级时，额外选择一次技能。
    [HarmonyPatch(typeof(CharacterWindow))]
    [HarmonyPatch(nameof(CharacterWindow.Upgrade))]
    public static class CharacterWindow_Upgrade_Patch
    {
        public static void Postfix(CharacterWindow __instance)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Innovative"))
            {
                new List<Skill>();
                SkillButton.SkillClickDel @delegate = new SkillButton.SkillClickDel(__instance.SkillAdd);
                FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(__instance.GetRandomSkill(), @delegate, ScriptLocalization.System_Item.SkillAdd, false, true, true, true, false));
            }
        }
    }

    //平心定气：+过载值不会影响技能法力值变动。
    [HarmonyPatch(typeof(Skill))]
    public static class Skill_AP_Patch
    {
        [HarmonyPatch(nameof(Skill.AP), MethodType.Getter)]
        [HarmonyPostfix]
        public static void AP_Postfix(Skill __instance, ref int __result)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Composed"))
            {
                // 减去 Overload 的影响
                if (!__instance.NotCount && __instance.Master != null)
                {
                    int overload = __instance.Master.Overload;
                    if (overload > 0)
                    {
                        __result -= overload;
                        if (__result < 0) __result = 0;
                    }
                }
            }
        }

        [HarmonyPatch(nameof(Skill.AP_OverloadViewOnly), MethodType.Getter)]
        [HarmonyPostfix]
        public static void AP_OverloadViewOnly_Postfix(Skill __instance, ref int __result)
        {
            // 减去 Overload 的影响（注意这个属性在 BattleSystem 存在时也会加 Overload）
            if (BattleSystem.instance != null && !__instance.NotCount && __instance.Master != null)
            {
                int overload = __instance.Master.Overload;
                if (overload > 0)
                {
                    __result -= overload;
                    if (__result < 0) __result = 0;
                }
            }
        }
    }

    //平心定气：-迅速技能将同时影响倒计时。
    [HarmonyPatch(typeof(BattleAlly))]
    [HarmonyPatch(nameof(BattleAlly.UseSkillAfter))]
    public static class BattleAlly_UseSkillAfter_Patch
    {
        [HarmonyPostfix]
        public static void UseSkillAfter_Postfix(BattleAlly __instance, Skill skill)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Composed"))
            {
                if (skill.NotCount && !skill.IsNowCasting)
                {
                    __instance.ActionCount--;
                    __instance.MyTeam.TurnActionNum++;
                }
            }
        }
    }
}