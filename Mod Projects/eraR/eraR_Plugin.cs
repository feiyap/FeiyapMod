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
using System.Diagnostics;
namespace eraR
{
    public class eraR_Plugin: ChronoArkPlugin
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

    [HarmonyPatch(typeof(GDESkillData), "Rare", MethodType.Getter)]
    public static class GDESkillData_statPatch
    {
        [HarmonyPostfix]
        public static void Postfix(GDESkillData __instance, ref bool __result)
        {
            if (ShouldInvertRare(__instance))
            {
                __result = !__result;
            }
        }

        private static bool ShouldInvertRare(GDESkillData skillData)
        {
            return (skillData.User != "" && skillData.Category.Key != GDEItemKeys.SkillCategory_LucySkill &&
                skillData.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && skillData.User != GDEItemKeys.Character_LucyC);
        }
    }

    [HarmonyPatch(typeof(CharFace))]
    public static class CharFacePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("GetRandomSkill")]
        public static bool GetRandomSkill_Prefix(CharFace __instance, ref List<Skill> __result, int num = 3)
        {
            List<Skill> list = new List<Skill>();
            List<GDESkillData> characterSkillNoOverLap = PlayData.GetCharacterSkillNoOverLap(__instance.AllyCharacter.Info, false, null);
            int num2 = 0;
            while (num2 < num && characterSkillNoOverLap.Count != 0)
            {
                GDESkillData gdeskillData = characterSkillNoOverLap.RandomSkill(__instance.AllyCharacter.Info);
                characterSkillNoOverLap.Remove(gdeskillData);
                list.Add(Skill.TempSkill(gdeskillData.Key, __instance.AllyCharacter, PlayData.TempBattleTeam).CloneSkill(false, null, null, false));
                if (!SaveManager.IsUnlock(gdeskillData.Key, SaveManager.NowData.unlockList.SkillPreView))
                {
                    SaveManager.NowData.unlockList.SkillPreView.Add(gdeskillData.Key);
                }
                num2++;
            }
            if (PlayData.Passive.Find((Item_Passive a) => a.itemkey == GDEItemKeys.Item_Passive_505Error) != null)
            {
                List<GDESkillData> list2 = new List<GDESkillData>();
                foreach (GDESkillData gdeskillData2 in PlayData.ALLSKILLLIST)
                {
                    if (gdeskillData2.User != "" && gdeskillData2.Category.Key != GDEItemKeys.SkillCategory_LucySkill && gdeskillData2.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && gdeskillData2.User != GDEItemKeys.Character_LucyC && !gdeskillData2.NoDrop && !gdeskillData2.Lock && gdeskillData2.User != __instance.AllyCharacter.Info.KeyData)
                    {
                        GDECharacterData gdecharacterData = new GDECharacterData(gdeskillData2.User);
                        if (!(gdeskillData2.KeyID == GDEItemKeys.Skill_S_Phoenix_6) && !(gdeskillData2.Key == GDEItemKeys.Skill_S_Phoenix_6) && gdecharacterData != null && Misc.IsUseableCharacter(gdecharacterData.Key))
                        {
                            list2.Add(gdeskillData2);
                        }
                    }
                }
                List<GDESkillData> list3 = new List<GDESkillData>();
                List<Skill> list4 = new List<Skill>();
                list3.AddRange(list2.Random(RandomClassKey.AllSkill, 3));
                foreach (GDESkillData gdeskillData3 in list3)
                {
                    list4.Add(Skill.TempSkill(gdeskillData3.Key, __instance.AllyCharacter, __instance.AllyCharacter.MyTeam));
                }
                list.AddRange(list4);
            }
            __result = list;
            return false;
        }
    }
}