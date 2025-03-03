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
namespace Squall
{
    public class Squall_Plugin : ChronoArkPlugin
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

        [Description("战斗播放语音，需要在LangSystem中写入和LangData一模一样的对话")]
        [HarmonyPatch(typeof(PrintText))]
        [HarmonyPatch("TextInput")]
        private class Squall_TextInput_Postfix
        {
            [HarmonyPostfix]
            public static void Postfix(PrintText __instance, string inText)
            {
                if (ModManager.getModInfo("Squall") != null)
                {
                    if (PlayData.TSavedata.Party.Find((Character a) => a.KeyData == "Squall") != null)
                    {
                        ModLocalizationInfo localizationInfo = ModManager.getModInfo("Squall").localizationInfo;
                        foreach (string text in Dict_Sound.Keys)
                        {
                            if (inText == localizationInfo.SystemLocalizationUpdate(text))
                            {
                                Squall_PlaySound(Dict_Sound[text]);
                            }
                        }
                    }
                }
            }
            
            private static void Squall_PlaySound(string text)
            {
                if (!Squall_SoundOn)
                {
                    PlaySoundResult playSoundResult = MasterAudio.PlaySound(text, 1f, null, 0f, null, null, false, false);
                    playSoundResult.ActingVariation.SoundFinished += new SoundGroupVariation.SoundFinishedEventHandler(BGMback);
                    Squall_SoundOn = true;
                }
            }
            
            private static void BGMback()
            {
                Squall_SoundOn = false;
            }
            
            private static bool Squall_SoundOn;
            
            private static readonly Dictionary<string, string> Dict_Sound = new Dictionary<string, string>
            {
                {
                    "Character/Squall_Text_Battle_AllyND_0",
                    "Squall_Text_Battle_AllyND_0"
                },
                {
                    "Character/Squall_Text_Battle_Cri_0",
                    "Squall_Text_Battle_Cri_0"
                },
                {
                    "Character/Squall_Text_Battle_Cri_1",
                    "Squall_Text_Battle_Cri_1"
                },
                {
                    "Character/Squall_Text_Battle_Healed_0",
                    "Squall_Text_Battle_Healed_0"
                },
                {
                    "Character/Squall_Text_Battle_Healed_1",
                    "Squall_Text_Battle_Healed_1"
                },
                {
                    "Character/Squall_Text_Battle_Idle_0",
                    "Squall_Text_Battle_Idle_0"
                },
                {
                    "Character/Squall_Text_Battle_Idle_1",
                    "Squall_Text_Battle_Idle_1"
                },
                {
                    "Character/Squall_Text_Battle_Kill_0",
                    "Squall_Text_Battle_Kill_0"
                },
                {
                    "Character/Squall_Text_Battle_Kill_1",
                    "Squall_Text_Battle_Kill_1"
                },
                {
                    "Character/Squall_Text_Battle_Kill_2",
                    "Squall_Text_Battle_Kill_2"
                },
                {
                    "Character/Squall_Text_Battle_ND_0",
                    "Squall_Text_Battle_ND_0"
                },
                {
                    "Character/Squall_Text_Battle_ND_1",
                    "Squall_Text_Battle_ND_1"
                },
                {
                    "Character/Squall_Text_Battle_ND_2",
                    "Squall_Text_Battle_ND_2"
                },
                {
                    "Character/Squall_Text_Battle_Start_0",
                    "Squall_Text_Battle_Start_0"
                },
                {
                    "Character/Squall_Text_Battle_Start_1",
                    "Squall_Text_Battle_Start_1"
                },
                {
                    "Character/Squall_Text_Battle_Start_2",
                    "Squall_Text_Battle_Start_2"
                }
            };
        }
    }

    [HarmonyPatch(typeof(Character))]
    class Character_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("get_get_stat")]
        public static void get_stat_Postfix(ref Stat __result, Character __instance)
        {
            Stat stat = default(Stat);
            PerStat perstat = default(PerStat);

            if (__instance.KeyData == "Squall")
            {
                for (int k = 0; k < __instance.Equip.Count; k++)
                {
                    if (__instance.Equip[k] != null && __instance.Equip[k] is Item_Equip)
                    {
                        Item_Equip item_Equip = __instance.Equip[k] as Item_Equip;

                        stat.def -= item_Equip.ItemScript.PlusStat.def;
                        stat.def -= item_Equip.Enchant.EnchantData.PlusStat.def;
                        stat.def -= item_Equip.Curse.PlusStat.def;

                        perstat.MaxHP += (int)item_Equip.ItemScript.PlusStat.def;
                        perstat.MaxHP += (int)item_Equip.Enchant.EnchantData.PlusStat.def;
                        perstat.MaxHP += (int)item_Equip.Curse.PlusStat.def;
                    }
                }
            }
            
            __result += stat;
        }
    }
}