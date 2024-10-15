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
using System.IO;
using ChronoArkMod.ModEditor;
using Newtonsoft.Json;
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
            ModInfo modInfo = ModManager.getModInfo("HolySaber");
            modInfo.gdeinfo.gDEChangeDelBases.Clear();

            bool flag = false;

            if (SaveManager.NowData.EnableSkins.Any((SkinData v) => v.skinKey == "Wilbert"))
            {
                flag = true;
            }

            if (flag)
            {
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel.mykey = "HolySaber";
                //gdechangeDel.myfield = "PassiveName";
                //gdechangeDel.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveName"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel2 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel2.mykey = "HolySaber";
                //gdechangeDel2.myfield = "PassiveDes";
                //gdechangeDel2.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveDes"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel2);

                //ModGDEInfo.GDEChangeDel<string> gdechangeDel3 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel3.mykey = "HolySaber";
                //gdechangeDel3.myfield = "name";
                //gdechangeDel3.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_Name"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel3);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel4 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel4.mykey = "HolySaber";
                //gdechangeDel4.myfield = "SelectInfo";
                //gdechangeDel4.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_SelectInfo"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel4);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel5 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel5.mykey = "HolySaber";
                //gdechangeDel5.myfield = "CampSelectWord";
                //gdechangeDel5.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_CampSelectWord"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel5);
                //ModGDEInfo.GDEChangeDel<int> gdechangeDel6 = new ModGDEInfo.GDEChangeDel<int>();
                //gdechangeDel6.mykey = "HolySaber";
                //gdechangeDel6.myfield = "Gender";
                //gdechangeDel6.Del = (int original) => 0;
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel6);

                //ModGDEInfo.GDEChangeDel<string> gdechangeDel7 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel7.mykey = "HolySaber";
                //gdechangeDel7.myfield = "face";
                //gdechangeDel7.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertBattleFace"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel7);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel8 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel8.mykey = "HolySaber";
                //gdechangeDel8.myfield = "PassiveIcon";
                //gdechangeDel8.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertPassiveIcon"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel8);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel9 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel9.mykey = "HolySaber";
                //gdechangeDel9.myfield = "CollectionSprite_Cover";
                //gdechangeDel9.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertCollectionSprite_Cover"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel9);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel10 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel10.mykey = "HolySaber";
                //gdechangeDel10.myfield = "CollectionSprite_SkillFace";
                //gdechangeDel10.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertCollectionSprite_SkillFace"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel10);

                ModGDEInfo.GDEChangeDel<string> gdechangeDel11 = new ModGDEInfo.GDEChangeDel<string>();
                gdechangeDel11.mykey = "S_HolySaber_P_0";
                gdechangeDel11.myfield = "Name";
                gdechangeDel11.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Skill/Wilbert_P_0_Name"));
                modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel11);
                ModGDEInfo.GDEChangeDel<string> gdechangeDel12 = new ModGDEInfo.GDEChangeDel<string>();
                gdechangeDel12.mykey = "S_HolySaber_P_0";
                gdechangeDel12.myfield = "Description";
                gdechangeDel12.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Skill/Wilbert_P_0_Desc"));
                modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel12);

                ModGDEInfo.GDEChangeDel<string> gdechangeDel13 = new ModGDEInfo.GDEChangeDel<string>();
                gdechangeDel13.mykey = "B_HolySaber_P_0";
                gdechangeDel13.myfield = "Name";
                gdechangeDel13.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Buff/Wilbert_P_0_Name"));
                modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel13);

                Directory.CreateDirectory(Path.Combine(modInfo.DirectoryName, "gdata", "ModEditorJson"));
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(modInfo.DirectoryName, "gdata", "ModEditorJson"));
                new Dictionary<string, object>();
                FileInfo[] files = directoryInfo.GetFiles("*.json");
                for (int i = 0; i < files.Length; i++)
                {
                    ModEditorChangeDel modEditorChangeDel = JsonConvert.DeserializeObject<ModEditorChangeDel>(File.ReadAllText(files[i].FullName));
                    modEditorChangeDel.Init(modInfo);
                    if (modInfo.gdeinfo.gDEChangeDelBases == null)
                    {
                        modInfo.gdeinfo.gDEChangeDelBases = new List<ModGDEInfo.GDEChangeDelBase>();
                    }
                    modInfo.gdeinfo.gDEChangeDelBases.Add(modEditorChangeDel);
                }
            }
            else
            {
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel3 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel3.mykey = "HolySaber";
                //gdechangeDel3.myfield = "PassiveName";
                //gdechangeDel3.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveName"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel3);
                //ModGDEInfo.GDEChangeDel<string> gdechangeDel4 = new ModGDEInfo.GDEChangeDel<string>();
                //gdechangeDel4.mykey = "HolySaber";
                //gdechangeDel4.myfield = "PassiveDes";
                //gdechangeDel4.Del = ((string original) => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveDes"));
                //modInfo.gdeinfo.gDEChangeDelBases.Add(gdechangeDel4);
                Directory.CreateDirectory(Path.Combine(modInfo.DirectoryName, "gdata", "ModEditorJson"));
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(modInfo.DirectoryName, "gdata", "ModEditorJson"));
                new Dictionary<string, object>();
                FileInfo[] files = directoryInfo.GetFiles("*.json");
                for (int i = 0; i < files.Length; i++)
                {
                    ModEditorChangeDel modEditorChangeDel = JsonConvert.DeserializeObject<ModEditorChangeDel>(File.ReadAllText(files[i].FullName));
                    modEditorChangeDel.Init(modInfo);
                    if (modInfo.gdeinfo.gDEChangeDelBases == null)
                    {
                        modInfo.gdeinfo.gDEChangeDelBases = new List<ModGDEInfo.GDEChangeDelBase>();
                    }
                    modInfo.gdeinfo.gDEChangeDelBases.Add(modEditorChangeDel);
                }
            }
        }
    }

    //切换皮肤时，改动mod设置
    [HarmonyPatch(typeof(CharacterSkinUI))]
    [HarmonyPatch("ChangeToSkin")]
    public class ChangeToSkin_Plugin
    {
        [HarmonyPostfix]
        public static void ChangeToSkin_Patch(CharacterSkinUI __instance)
        {
            Debug.Log("A");
            HolySaber_Plugin a = new HolySaber_Plugin();
            a.OnModSettingUpdate();
            Debug.Log("A");
        }
    }
}