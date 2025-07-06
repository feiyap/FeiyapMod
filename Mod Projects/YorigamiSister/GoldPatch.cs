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
using System.Reflection;
using BasicMethods;
using EOS;
using EOS.Attributes;
using EOS.Tools;
namespace YorigamiSister
{
    [HarmonyPatch(typeof(PlayData))]
    [HarmonyPatch("Gold", MethodType.Setter)]
    public static class GoldPatch
    {
        public static void Prefix(int value)
        {
            int gold = PlayData.TSavedata._Gold;
            EOSManager.BroadCast<Gold_Event>(value - gold);
        }
    }

    public class Gold_Event : IEventCode
    {
        [EventCodeMethod]
        public void GoldChangeEvent(int num)
        {

        }
    }
}