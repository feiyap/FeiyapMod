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
namespace HolySaber
{
    [PluginConfig("HolySaber", "Feiyap", "1.0.0")]
    public class HolySaber_Plugin : ChronoArkPlugin
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

        public override void OnModSettingUpdate()
        {
            base.OnModSettingUpdate();
            //ModInfo modInfo = ModManager.getModInfo("HolySaber");
            //modInfo.gdeinfo.gDEChangeDelBases.Clear();

            //bool flag = false;

            //if (SaveManager.NowData.EnableSkins.Any((SkinData v) => v.skinKey == "Wilbert"))
            //{
            //    flag = true;
            //}

            //if (flag)
            //{
            //    ModGDEInfo.GDEChangeDel<string> gdechangeDel = new ModGDEInfo.GDEChangeDel<string>();
            //    gdechangeDel.mykey = "HolySaber";
            //    gdechangeDel.myfield = "PassiveName";
            //    gdechangeDel.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveName"));
            //    Debug.Log(ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveName"));
            //    modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel);
            //    ModGDEInfo.GDEChangeDel<string> gdechangeDel2 = new ModGDEInfo.GDEChangeDel<string>();
            //    gdechangeDel2.mykey = "HolySaber";
            //    gdechangeDel2.myfield = "PassiveDes";
            //    gdechangeDel2.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveDes"));
            //    modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel2);
            //}
            //else
            //{
            //    ModGDEInfo.GDEChangeDel<string> gdechangeDel3 = new ModGDEInfo.GDEChangeDel<string>();
            //    gdechangeDel3.mykey = "HolySaber";
            //    gdechangeDel3.myfield = "PassiveName";
            //    gdechangeDel3.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveName"));
            //    Debug.Log(ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveName"));
            //    modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel3);
            //    ModGDEInfo.GDEChangeDel<string> gdechangeDel4 = new ModGDEInfo.GDEChangeDel<string>();
            //    gdechangeDel4.mykey = "HolySaber";
            //    gdechangeDel4.myfield = "PassiveDes";
            //    gdechangeDel4.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveDes"));
            //    modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel4);

            //}
        }
    }
}