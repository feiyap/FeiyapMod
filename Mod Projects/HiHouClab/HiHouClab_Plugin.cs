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
namespace HiHouClab
{
    public class HiHouClab_Plugin: ChronoArkPlugin
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

    //莲子被动：暴击率转化为暴击伤害
    [HarmonyPatch(typeof(Character))]
    class Character_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("get_get_stat")]
        public static void get_stat_Postfix(ref Stat __result, Character __instance)
        {
            if (__instance.KeyData == "UsamiRenko")
            {
                if (__result.cri > 0)
                {
                    __result.PlusCriDmg += __result.cri; // 将 cri 值加到 PlusCriDmg
                }
                __result.cri = 0; // 将 cri 设为 0
            }
        }
    }
}