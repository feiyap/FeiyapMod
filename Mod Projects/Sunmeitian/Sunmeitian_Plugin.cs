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
namespace Sunmeitian
{
    [PluginConfig("Sunmeitian", "Feiyap", "1.0.0")]
    public class Sunmeitian_Plugin: ChronoArkPlugin
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

        [HarmonyPatch(typeof(FieldSystem))]
        private class FieldSystem_Patch
        {
            [HarmonyPatch("StageStart")]
            [HarmonyPostfix]
            public static void StageStartPostfix()
            {
                bool flag;
                if (ModManager.getModInfo("Sunmeitian") != null)
                {
                    flag = (PlayData.TSavedata.Party.Find((Character a) => a.KeyData == "Sunmeitian") != null);
                }
                else
                {
                    flag = false;
                }
                if (flag)
                {
                    if (StageSystem.instance.gameObject.activeInHierarchy && StageSystem.instance != null && StageSystem.instance.Map != null)
                    {
                        StageSystem.instance.Fogout(false);
                    }
                }
            }
        }
    }
}