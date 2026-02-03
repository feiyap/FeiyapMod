using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using EItem;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace MageBasic
{
    public class MageBasic_Plugin : ChronoArkPlugin
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
    }

    [HarmonyPatch(typeof(TargetSelect), "Update")]
    public static class TargetSelect_Update_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(TargetSelect __instance)
        {
            // 只处理有MainScript的情况
            if (__instance.MainScript == null) return;

            // 检查按键并发送相应消息
            HandleKeyInputs(__instance);
        }

        private static void HandleKeyInputs(TargetSelect targetSelect)
        {
            // 处理S/DownArrow键
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (targetSelect.MainScript is SkillButton)
                {
                    targetSelect.MainScript.SendMessage("RightMove", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    targetSelect.MainScript.SendMessage("DownMove", SendMessageOptions.DontRequireReceiver);
                }
            }

            // 处理W/UpArrow键
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (targetSelect.MainScript is SkillButton)
                {
                    targetSelect.MainScript.SendMessage("LeftMove", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    targetSelect.MainScript.SendMessage("UpMove", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}