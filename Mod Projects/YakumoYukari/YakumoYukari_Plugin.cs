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

namespace YakumoYukari
{
    [PluginConfig("YakumoYukari", "Feiyap", "1.0.0")]
    public class YakumoYukari_Plugin : ChronoArkPlugin
    {
        private Harmony harmony;

        public override void Dispose()
        {
            if (this.harmony != null)
            {
                this.harmony.UnpatchSelf();
            }
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

    /// <summary>
    /// 八云紫技能不显示法力费用。
    /// </summary>
    [HarmonyPatch(typeof(SkillButton), "InputData")]
    public static class YukariHideAPPatch
    {
        public static void Postfix(SkillButton __instance, Skill skill)
        {
            if (__instance == null || !IsYukariSkill(skill))
            {
                return;
            }
            __instance.ManaView = false;
        }

        public static bool IsYukariSkill(Skill skill)
        {
            if (skill == null || skill.MySkill == null)
            {
                return false;
            }
            if (skill.MySkill.User == "YakumoYukari")
            {
                return true;
            }
            if (skill.Master != null && skill.Master.Info != null && skill.Master.Info.KeyData == "YakumoYukari")
            {
                return true;
            }
            string id = skill.MySkill.KeyID;
            return !string.IsNullOrEmpty(id) && id.StartsWith("S_YakumoYukari");
        }
    }
}
