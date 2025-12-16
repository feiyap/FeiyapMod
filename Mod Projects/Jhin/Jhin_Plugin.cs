using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using ChronoArkMod.ModData;
using HarmonyLib;
using System.ComponentModel;
namespace Jhin
{
    public class Jhin_Plugin: ChronoArkPlugin
    {
        private Harmony harmony;
        public override void Dispose()
        {
            this.harmony.UnpatchSelf();
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

        [Description("战斗播放语音，需要在LangSystem中写入和LangData一模一样的对话")]
        [HarmonyPatch(typeof(PrintText))]
        [HarmonyPatch("TextInput")]
        private class Jhin_TextInput_Postfix
        {
            [HarmonyPostfix]
            public static void Postfix(PrintText __instance, string inText)
            {
                if (ModManager.getModInfo("Jhin") != null)
                {
                    if (PlayData.TSavedata.Party.Find((Character a) => a.KeyData == "Jhin") != null)
                    {
                        ModLocalizationInfo localizationInfo = ModManager.getModInfo("Jhin").localizationInfo;
                        foreach (string text in Dict_Sound.Keys)
                        {
                            if (inText == localizationInfo.SystemLocalizationUpdate(text))
                            {
                                Jhin_PlaySound(Dict_Sound[text]);
                            }
                        }
                    }
                }
            }

            private static void Jhin_PlaySound(string text)
            {
                if (!Jhin_SoundOn)
                {
                    PlaySoundResult playSoundResult = MasterAudio.PlaySound(text, 1f, null, 0f, null, null, false, false);
                    playSoundResult.ActingVariation.SoundFinished += new SoundGroupVariation.SoundFinishedEventHandler(BGMback);
                    Jhin_SoundOn = true;
                }
            }

            private static void BGMback()
            {
                Jhin_SoundOn = false;
            }

            private static bool Jhin_SoundOn;

            private static readonly Dictionary<string, string> Dict_Sound = new Dictionary<string, string>
            {
                {
                    "Character/Jhin_Text_Battle_Cri_0",
                    "Jhin_Text_Battle_Cri_0"
                },
                {
                    "Character/Jhin_Text_Battle_Cri_1",
                    "Jhin_Text_Battle_Cri_1"
                },
                {
                    "Character/Jhin_Text_Battle_Idle_0",
                    "Jhin_Text_Battle_Idle_0"
                },
                {
                    "Character/Jhin_Text_Battle_Kill_0",
                    "Jhin_Text_Battle_Kill_0"
                },
                {
                    "Character/Jhin_Text_Battle_Kill_1",
                    "Jhin_Text_Battle_Kill_1"
                },
                {
                    "Character/Jhin_Text_Battle_Kill_2",
                    "Jhin_Text_Battle_Kill_2"
                },
                {
                    "Character/Jhin_Text_Battle_Start_0",
                    "Jhin_Text_Battle_Start_0"
                },
                {
                    "Character/Jhin_Text_Battle_Start_1",
                    "Jhin_Text_Battle_Start_1"
                },
                {
                    "Character/Jhin_Text_Field_Idle_0",
                    "Jhin_Text_Field_Idle_0"
                }
            };
        }
    }

    //烬的法力值修改
    [HarmonyPatch(typeof(Skill), "AP", MethodType.Getter)]
    class Skill_AP_Patch
    {
        static void Postfix(Skill __instance, ref int __result)
        {
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_1") != null)
            {
                __result = 1;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_2") != null)
            {
                __result = 2;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_3") != null)
            {
                __result = 3;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_4") != null)
            {
                __result = 4;
            }
        }
    }

    [HarmonyPatch(typeof(Skill), "AP_OverloadViewOnly", MethodType.Getter)]
    class Skill_AP_OverloadViewOnly_Patch
    {
        static void Postfix(Skill __instance, ref int __result)
        {
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_1") != null)
            {
                __result = 1;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_2") != null)
            {
                __result = 2;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_3") != null)
            {
                __result = 3;
            }
            if (__instance?.ExtendedFind_DataName("SE_Jhin_P_4") != null)
            {
                __result = 4;
            }
        }
    }

    //烬的子弹层数修改
    [HarmonyPatch(typeof(BuffObject))]
    public class BuffObjectPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void UpdatePatch(BuffObject __instance)
        {
            if (__instance.MyBuff != null && __instance.MyBuff.BuffData.Key == "B_Jhin_P")
            {
                __instance.StackText.text = (BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum - 1).ToString();
            }
        }
    }

    //致命华彩标记
    [HarmonyPatch(typeof(BattleEnemy))]
    public class BattleEnemyPatch
    {
        [HarmonyPatch("Damage")]
        [HarmonyPostfix]
        public static void DamagePatch(BattleEnemy __instance)
        {
            __instance.BuffAdd("B_Jhin_2", __instance, true);
        }
    }
}