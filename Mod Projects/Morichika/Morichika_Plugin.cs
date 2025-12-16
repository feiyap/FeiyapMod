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
using Scrolls;

namespace Morichika
{
    public class Morichika_Plugin: ChronoArkPlugin
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

    [HarmonyPatch(typeof(Scroll_UseDefult), "ScrollUseEffect")]
    class ScrollUseEffect_Patch
    {
        static void Postfix(Scroll_UseDefult __instance)
        {
            List<IP_ScrollUse> list = new List<IP_ScrollUse>();
            foreach (Character chara in PlayData.TSavedata.Party)
            {
                if (chara.Passive != null)
                {
                    list.Add(chara.Passive as IP_ScrollUse);
                }
            }
            foreach (IP_ScrollUse ip_ScrollUse in list)
            {
                if (ip_ScrollUse != null)
                {
                    ip_ScrollUse.ScrollUse();
                }
            }
        }
    }

    [HarmonyPatch(typeof(FieldSystem), "StageStart")]
    class StageStart_Patch
    {
        static void Postfix(Scroll_UseDefult __instance)
        {
            List<IP_StageStart> list = new List<IP_StageStart>();
            foreach (Character chara in PlayData.TSavedata.Party)
            {
                if (chara.Passive != null)
                {
                    list.Add(chara.Passive as IP_StageStart);
                }
            }
            foreach (IP_StageStart ip_StageStart in list)
            {
                if (ip_StageStart != null)
                {
                    ip_StageStart.StageStart();
                }
            }
        }
    }
}