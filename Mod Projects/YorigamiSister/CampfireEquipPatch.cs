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
    //修改篝火UI
    [HarmonyPatch(typeof(CampUI))]
    [HarmonyPatch("Update")]
    public static class CampUIPatch
    {
        public static void Postfix(int value)
        {

        }
    }
}