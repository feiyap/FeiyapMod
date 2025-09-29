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
using UseItem;
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

    [HarmonyPatch(typeof(GDESkillData))]
    public static class GDESkillData_statPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Rare", MethodType.Getter)]
        public static void Rare_Postfix(GDESkillData __instance, ref bool __result)
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

    //[HarmonyPatch(typeof(Character))]
    //public static class Character_statPatch
    //{
    //    [HarmonyPostfix]
    //    [HarmonyPatch("SavePassing_Load")]
    //    public static void SavePassing_Load_Postfix(Character __instance, Character LoadChar)
    //    {
    //        foreach (CharInfoSkillData skill in __instance.SkillDatas)
    //        {
    //            if (ShouldInvertRare(skill.SkillInfo))
    //            {
    //                Debug.Log("A");
    //                Debug.Log(skill.SkillInfo.Name);
    //                Debug.Log(skill.SkillInfo.Rare);
    //                //skill.SkillInfo.Rare = skill.SkillInfo.Rare;
    //            }
    //        }
    //    }

    //    private static bool ShouldInvertRare(GDESkillData skillData)
    //    {
    //        return (skillData.User != "" && skillData.Category.Key != GDEItemKeys.SkillCategory_LucySkill &&
    //            skillData.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && skillData.User != GDEItemKeys.Character_LucyC);
    //    }
    //}

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
                list.Add(Skill.TempSkill(gdeskillData.Key, __instance.AllyCharacter, PlayData.TempBattleTeam));
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

    [HarmonyPatch(typeof(SkillBookCharacter_Rare))]
    public static class SkillBookCharacter_RarePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Use")]
        public static bool Use_Prefix(SkillBookCharacter_Rare __instance)
        {
            List<Skill> list = new List<Skill>();
            List<BattleAlly> battleallys = PlayData.Battleallys;
            BattleTeam tempBattleTeam = PlayData.TempBattleTeam;
            for (int i = 0; i < PlayData.TSavedata.Party.Count; i++)
            {
                bool flag = false;
                if (PlayData.TSavedata.SpRule == null || !PlayData.TSavedata.SpRule.RuleChange.CharacterRareSkillInfinityGet)
                {
                    using (List<CharInfoSkillData>.Enumerator enumerator = PlayData.TSavedata.Party[i].SkillDatas.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            Debug.Log("A");
                            Debug.Log(enumerator.Current.SkillInfo.Name);
                            Debug.Log(enumerator.Current.SkillInfo.Rare);
                            if (enumerator.Current.SkillInfo.Rare)
                            {
                                Debug.Log("A1");
                                flag = true;
                            }
                        }
                    }
                    if (PlayData.TSavedata.Party[i].BasicSkill.SkillInfo.Rare)
                    {
                        Debug.Log("A2");
                        flag = true;
                    }
                }
                Debug.Log("AA");
                Debug.Log(flag);
                if (!flag)
                {
                    Debug.Log("B");
                    GDESkillData gdeskillData = PlayData.GetMySkills(PlayData.TSavedata.Party[i].KeyData, true).Random(RandomClassKey.Skill(i));
                    if (gdeskillData != null)
                    {
                        Debug.Log("C");
                        list.Add(Skill.TempSkill(gdeskillData.KeyID, battleallys[i], tempBattleTeam));
                    }
                }
            }
            if (list.Count == 0)
            {
                EffectView.SimpleTextout(FieldSystem.instance.TopWindow.transform, ScriptLocalization.System.CantRareSkill, 1f, false, 1f);
                return false;
            }
            foreach (Skill skill in list)
            {
                if (!SaveManager.IsUnlock(skill.MySkill.KeyID, SaveManager.NowData.unlockList.SkillPreView))
                {
                    SaveManager.NowData.unlockList.SkillPreView.Add(skill.MySkill.KeyID);
                }
            }
            PlayData.TSavedata.UseItemKeys.Add(GDEItemKeys.Item_Consume_SkillBookCharacter_Rare);
            MasterAudio.PlaySound("BookFlip", 1f, null, 0f, null, null, false, false);
            FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(__instance.SkillAdd), ScriptLocalization.System_Item.SkillAdd, false, true, true, true, true));

            return false;
        }
    }
}