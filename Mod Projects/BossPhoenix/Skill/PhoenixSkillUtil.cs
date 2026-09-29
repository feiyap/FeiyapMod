using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ChronoArkMod;
using ChronoArkMod.ModData;
using GameDataEditor;
using UnityEngine;

namespace BossPhoenix
{
    public enum RiddleMatch
    {
        None,
        Close,
        Exact
    }

    public static class PhoenixSkillUtil
    {
        public const int MaxGuess = 8;
        public const int MaxRiddleLoss = 3;
        /// <summary>原版找面包</summary>
        public const string VanillaFindBread = "S_Phoenix_10_0";
        /// <summary>原版扔面包</summary>
        public const string VanillaThrowBread = "S_Phoenix_10_1";

        private static List<GDESkillData> cachedCatalog;

        public static int GetCost(Skill skill)
        {
            if (skill == null)
            {
                return 0;
            }
            return skill.AP;
        }

        public static int GetCost(GDESkillData data)
        {
            if (data == null)
            {
                return 0;
            }
            return data.UseAp;
        }

        public static string GetTargetKey(Skill skill)
        {
            if (skill == null || skill.MySkill == null || skill.MySkill.Target == null)
            {
                return "";
            }
            return skill.MySkill.Target.Key;
        }

        public static string GetTargetKey(GDESkillData data)
        {
            if (data == null || data.Target == null)
            {
                return "";
            }
            return data.Target.Key;
        }

        public static string GetOwnerKey(Skill skill)
        {
            if (skill == null)
            {
                return "";
            }
            if (skill.Master != null && skill.Master.Info != null && !string.IsNullOrEmpty(skill.Master.Info.KeyData))
            {
                return skill.Master.Info.KeyData;
            }
            if (skill.MySkill != null && !string.IsNullOrEmpty(skill.MySkill.User))
            {
                return skill.MySkill.User;
            }
            return "";
        }

        public static string GetOwnerKey(GDESkillData data)
        {
            if (data == null || string.IsNullOrEmpty(data.User))
            {
                return "";
            }
            return data.User;
        }

        public static int GetMultiplier(Skill skill)
        {
            if (skill == null || skill.MySkill == null)
            {
                return 0;
            }
            return GetMultiplier(skill.MySkill);
        }

        public static int GetMultiplier(GDESkillData data)
        {
            if (data == null || data.Effect_Target == null)
            {
                return 0;
            }
            GDESkillEffectData effect = data.Effect_Target;
            if (effect.DMG_Per != 0)
            {
                return effect.DMG_Per;
            }
            return effect.HEAL_Per;
        }

        public static int GetBuffCount(GDESkillData data)
        {
            if (data == null)
            {
                return 0;
            }
            return CountEffectBuffs(data.Effect_Target) + CountEffectBuffs(data.Effect_Self);
        }

        private static int CountEffectBuffs(GDESkillEffectData effect)
        {
            if (effect == null || effect.Buffs == null)
            {
                return 0;
            }
            int n = 0;
            for (int i = 0; i < effect.Buffs.Count; i++)
            {
                if (effect.Buffs[i] != null)
                {
                    n++;
                }
            }
            return n;
        }

        public static string GetSkillTypeKey(GDESkillData data)
        {
            if (data == null)
            {
                return "Normal";
            }
            string key = data.KeyID ?? "";
            string category = "";
            if (data.Category != null)
            {
                category = data.Category.Key;
            }
            if (key.IndexOf("Curse", StringComparison.OrdinalIgnoreCase) >= 0
                || key.IndexOf("LucyCurse", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "Curse";
            }
            if (category == "PublicSkill" || category == GDEItemKeys.SkillCategory_PublicSkill
                || key.StartsWith("S_Public_"))
            {
                return "Public";
            }
            if (data.Rare)
            {
                return "Rare";
            }
            return "Normal";
        }

        /// <summary>
        /// NotCount 为迅速，其余一律视为过载。
        /// </summary>
        public static string GetTimingKey(GDESkillData data)
        {
            if (data != null && data.NotCount)
            {
                return "Swift";
            }
            return "Overload";
        }

        public static int CountMatches(Skill a, Skill b)
        {
            int n = 0;
            if (GetCost(a) == GetCost(b))
            {
                n++;
            }
            if (GetTargetKey(a) == GetTargetKey(b))
            {
                n++;
            }
            if (GetOwnerKey(a) == GetOwnerKey(b))
            {
                n++;
            }
            if (GetMultiplier(a) == GetMultiplier(b))
            {
                n++;
            }
            return n;
        }

        public static bool ExactlyOneMatch(Skill a, Skill b)
        {
            return CountMatches(a, b) == 1;
        }

        public static List<Skill> CollectFightSkills()
        {
            List<Skill> result = new List<Skill>();
            HashSet<string> seen = new HashSet<string>();
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return result;
            }

            BattleTeam team = BattleSystem.instance.AllyTeam;
            AddRangeUnique(result, seen, team.Skills);
            AddRangeUnique(result, seen, team.Skills_Deck);
            AddRangeUnique(result, seen, team.Skills_UsedDeck);

            if (PlayData.TSavedata != null && PlayData.TSavedata.LucySkills != null)
            {
                foreach (string key in PlayData.TSavedata.LucySkills)
                {
                    AddTempIfNew(result, seen, key, team);
                }
            }

            AddTempIfNew(result, seen, VanillaFindBread, team);
            AddTempIfNew(result, seen, VanillaThrowBread, team);
            return result;
        }

        public static List<GDESkillData> GetSkillCatalog()
        {
            if (cachedCatalog != null)
            {
                return cachedCatalog;
            }

            List<GDESkillData> list = new List<GDESkillData>();
            HashSet<string> seen = new HashSet<string>();
            AppendCatalog(list, seen, PlayData.ALLSKILLLIST);
            AppendCatalog(list, seen, PlayData.ALLRARESKILLLIST);
            AppendSkillByKey(list, seen, VanillaFindBread);
            AppendSkillByKey(list, seen, VanillaThrowBread);
            cachedCatalog = list;
            return cachedCatalog;
        }

        public static bool HasSkillOwner(GDESkillData data)
        {
            return !string.IsNullOrEmpty(NormalizeOwnerKey(data));
        }

        public static bool CanImagine(GDESkillData data)
        {
            if (data == null || IsBannedTarget(data.KeyID) || IsLucyDrawSkill(data) || !HasSkillOwner(data))
            {
                return false;
            }
            // 不想象露西技能，除非职业为输出
            if (NormalizeOwnerKey(data) == "Lucy" && GetOwnerRoleKey(data) != "DPS")
            {
                return false;
            }
            return true;
        }

        public static string PickRandomImaginedKey()
        {
            List<GDESkillData> pool = new List<GDESkillData>();
            List<GDESkillData> catalog = GetSkillCatalog();
            for (int i = 0; i < catalog.Count; i++)
            {
                if (!CanImagine(catalog[i]))
                {
                    continue;
                }
                pool.Add(catalog[i]);
            }
            if (pool.Count == 0)
            {
                return VanillaFindBread;
            }
            return pool[UnityEngine.Random.Range(0, pool.Count)].KeyID;
        }

        public static string PickRandomImaginedKeyExcept(string exceptKey)
        {
            List<GDESkillData> pool = new List<GDESkillData>();
            List<GDESkillData> catalog = GetSkillCatalog();
            for (int i = 0; i < catalog.Count; i++)
            {
                if (!CanImagine(catalog[i]) || catalog[i].KeyID == exceptKey)
                {
                    continue;
                }
                pool.Add(catalog[i]);
            }
            if (pool.Count == 0)
            {
                return exceptKey;
            }
            return pool[UnityEngine.Random.Range(0, pool.Count)].KeyID;
        }

        public static List<GDESkillData> SearchSkills(string pattern)
        {
            List<GDESkillData> result = new List<GDESkillData>();
            if (string.IsNullOrEmpty(pattern))
            {
                return result;
            }

            string trimmed = pattern.Trim();
            List<GDESkillData> catalog = GetSkillCatalog();

            for (int i = 0; i < catalog.Count; i++)
            {
                GDESkillData data = catalog[i];
                if (IsHiddenFromSearch(data))
                {
                    continue;
                }
                if (string.Equals(GetSkillName(data), trimmed, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(data.KeyID, trimmed, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(data);
                }
            }
            if (result.Count == 1)
            {
                return result;
            }

            Regex regex;
            try
            {
                regex = new Regex(trimmed, RegexOptions.IgnoreCase);
            }
            catch
            {
                return new List<GDESkillData>();
            }

            List<GDESkillData> regexHits = new List<GDESkillData>();
            for (int i = 0; i < catalog.Count; i++)
            {
                GDESkillData data = catalog[i];
                if (IsHiddenFromSearch(data))
                {
                    continue;
                }
                string name = GetSkillName(data);
                if ((!string.IsNullOrEmpty(name) && regex.IsMatch(name))
                    || (!string.IsNullOrEmpty(data.KeyID) && regex.IsMatch(data.KeyID)))
                {
                    regexHits.Add(data);
                }
            }
            return regexHits;
        }

        public static GDESkillData FindSkill(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            List<GDESkillData> catalog = GetSkillCatalog();
            for (int i = 0; i < catalog.Count; i++)
            {
                if (catalog[i].KeyID == key)
                {
                    return catalog[i];
                }
            }
            try
            {
                return new GDESkillData(key);
            }
            catch
            {
                return null;
            }
        }

        public static string GetSkillName(GDESkillData data)
        {
            if (data == null)
            {
                return "";
            }
            if (!string.IsNullOrEmpty(data.Name))
            {
                return data.Name;
            }
            return data.KeyID;
        }

        public static string FormatSkillOption(GDESkillData data)
        {
            if (data == null)
            {
                return "";
            }
            string name = GetSkillName(data);
            if (string.IsNullOrEmpty(data.KeyID) || data.KeyID == name)
            {
                return name;
            }
            return name + "  [" + data.KeyID + "]";
        }

        public static string GetOwnerName(GDESkillData data)
        {
            string user = NormalizeOwnerKey(data);
            if (string.IsNullOrEmpty(user))
            {
                return PhoenixLoc.Loc("Riddle/OwnerNone");
            }
            if (user == "Lucy")
            {
                return PhoenixLoc.Loc("Riddle/OwnerLucy");
            }
            try
            {
                GDECharacterData ch = new GDECharacterData(user);
                if (ch != null && !string.IsNullOrEmpty(ch.name))
                {
                    return ch.name;
                }
            }
            catch
            {
            }
            return user;
        }

        public static string GetTargetName(GDESkillData data)
        {
            string key = NormalizeTargetKey(GetTargetKey(data));
            string locKey = "Riddle/Target/" + key;
            string loc = PhoenixLoc.Loc(locKey);
            if (!string.IsNullOrEmpty(loc) && loc != locKey)
            {
                return loc;
            }
            return PhoenixLoc.Loc("Riddle/Target/Misc");
        }

        public static string GetSkillTypeName(GDESkillData data)
        {
            return PhoenixLoc.Loc("Riddle/Type/" + GetSkillTypeKey(data));
        }

        public static string GetTimingName(GDESkillData data)
        {
            return PhoenixLoc.Loc("Riddle/Timing/" + GetTimingKey(data));
        }

        public static string FormatCost(int cost)
        {
            if (cost < 0)
            {
                return "X";
            }
            return cost.ToString();
        }

        public static string FormatBuff(int count)
        {
            if (count <= 0)
            {
                return PhoenixLoc.Loc("Riddle/BuffNone");
            }
            return string.Format(PhoenixLoc.Loc("Riddle/BuffYes"), count);
        }

        public static RiddleMatch CompareName(GDESkillData guess, GDESkillData target)
        {
            string a = GetSkillName(guess);
            string b = GetSkillName(target);
            if (a == b)
            {
                return RiddleMatch.Exact;
            }
            if (ShareNamePart(a, b))
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareOwner(GDESkillData guess, GDESkillData target)
        {
            if (NormalizeOwnerKey(guess) == NormalizeOwnerKey(target))
            {
                return RiddleMatch.Exact;
            }
            int ga = GetOwnerGender(guess);
            int gb = GetOwnerGender(target);
            if (ga >= 0 && ga == gb)
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        /// <summary>
        /// 0 男，1 女，-1 未知（无持有者等）。
        /// </summary>
        public static int GetOwnerGender(GDESkillData data)
        {
            string user = NormalizeOwnerKey(data);
            if (string.IsNullOrEmpty(user))
            {
                return -1;
            }
            if (user == "Lucy")
            {
                user = GDEItemKeys.Character_LucyC;
            }
            try
            {
                GDECharacterData ch = new GDECharacterData(user);
                if (ch != null && !string.IsNullOrEmpty(ch.name))
                {
                    return ch.Gender;
                }
            }
            catch
            {
            }
            return -1;
        }

        public static bool IsLucyCategorySkill(GDESkillData data)
        {
            if (data == null || data.Category == null)
            {
                return false;
            }
            string cat = data.Category.Key;
            return cat == "LucySkill" || cat == GDEItemKeys.SkillCategory_LucySkill;
        }

        public static string GetOwnerRoleKey(GDESkillData data)
        {
            string user = NormalizeOwnerKey(data);
            if (string.IsNullOrEmpty(user))
            {
                return "None";
            }
            if (user == "Lucy")
            {
                if (IsLucyCategorySkill(data))
                {
                    return "None";
                }
                user = GDEItemKeys.Character_LucyC;
            }
            try
            {
                GDECharacterData ch = new GDECharacterData(user);
                if (ch != null && ch.Role != null)
                {
                    string role = ch.Role.Key ?? "";
                    if (role.IndexOf("DPS", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return "DPS";
                    }
                    if (role.IndexOf("Support", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return "Support";
                    }
                    if (role.IndexOf("Tank", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return "Tank";
                    }
                    // 模组职业（Role_Mage 等）保留 GDE Key，对照时按 Key 相等判断
                    if (!string.IsNullOrEmpty(role))
                    {
                        return role;
                    }
                }
            }
            catch
            {
            }
            return "None";
        }

        public static string GetOwnerRoleName(GDESkillData data)
        {
            string key = GetOwnerRoleKey(data);
            if (key == "DPS" || key == "Support" || key == "Tank" || key == "None")
            {
                return PhoenixLoc.Loc("Riddle/Role/" + key);
            }
            return ResolveRoleNameFromLangSystem(key);
        }

        /// <summary>
        /// 用职业 GDE Key（如 Role_Mage）读各模组 LangSystem：System/Character/Role/{Key}。
        /// </summary>
        private static string ResolveRoleNameFromLangSystem(string roleKey)
        {
            if (string.IsNullOrEmpty(roleKey))
            {
                return PhoenixLoc.Loc("Riddle/Role/None");
            }
            string locKey = "System/Character/Role/" + roleKey;
            try
            {
                string i2 = I2.Loc.LocalizationManager.GetTranslation(locKey);
                if (IsResolvedLoc(i2, locKey))
                {
                    return i2;
                }
            }
            catch
            {
            }
            try
            {
                List<string> ids = ModManager.LoadedMods;
                if (ids == null || ids.Count == 0)
                {
                    ids = ModManager.AllModIDs;
                }
                if (ids != null)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        ModInfo mod = ModManager.getModInfo(ids[i]);
                        if (mod == null || mod.localizationInfo == null)
                        {
                            continue;
                        }
                        string text = mod.localizationInfo.SystemLocalizationUpdate(locKey);
                        if (IsResolvedLoc(text, locKey))
                        {
                            return text;
                        }
                    }
                }
            }
            catch
            {
            }
            return PhoenixLoc.Loc("Riddle/Role/None");
        }

        private static bool IsResolvedLoc(string text, string locKey)
        {
            return !string.IsNullOrEmpty(text) && text != locKey;
        }

        public static RiddleMatch CompareRole(GDESkillData guess, GDESkillData target)
        {
            if (GetOwnerRoleKey(guess) == GetOwnerRoleKey(target))
            {
                return RiddleMatch.Exact;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareCost(int guess, int target)
        {
            if (guess == target)
            {
                return RiddleMatch.Exact;
            }
            if (Math.Abs(guess - target) <= 1)
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareTarget(GDESkillData guess, GDESkillData target)
        {
            string a = NormalizeTargetKey(GetTargetKey(guess));
            string b = NormalizeTargetKey(GetTargetKey(target));
            if (a == b)
            {
                return RiddleMatch.Exact;
            }
            if (IsNoYellowTarget(a) || IsNoYellowTarget(b))
            {
                return RiddleMatch.None;
            }
            if (GetTargetFamily(a) == GetTargetFamily(b))
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareMultiplier(int guess, int target)
        {
            if (guess == target)
            {
                return RiddleMatch.Exact;
            }
            if (Math.Abs(guess - target) <= 50)
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareType(GDESkillData guess, GDESkillData target)
        {
            if (GetSkillTypeKey(guess) == GetSkillTypeKey(target))
            {
                return RiddleMatch.Exact;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareTiming(GDESkillData guess, GDESkillData target)
        {
            if (GetTimingKey(guess) == GetTimingKey(target))
            {
                return RiddleMatch.Exact;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareBuff(int guess, int target)
        {
            bool ga = guess > 0;
            bool ta = target > 0;
            if (ga == ta)
            {
                return guess == target ? RiddleMatch.Exact : RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static string Arrow(int guess, int target)
        {
            if (guess == target)
            {
                return "";
            }
            return guess > target ? " ↓" : " ↑";
        }

        public static Skill CreateTemp(string key)
        {
            BattleTeam team = BattleSystem.instance.AllyTeam;
            BattleChar lucy = team.LucyChar;
            return Skill.TempSkill(key, lucy, team);
        }

        public static Skill FindOrCreate(string key)
        {
            List<Skill> pool = CollectFightSkills();
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].MySkill.KeyID == key)
                {
                    return pool[i];
                }
            }
            return CreateTemp(key);
        }

        public static void GiveSkillToOwner(string key)
        {
            if (string.IsNullOrEmpty(key) || BattleSystem.instance == null)
            {
                return;
            }

            GDESkillData data = new GDESkillData(key);
            BattleChar owner = FindOwner(data.User);
            if (owner == null)
            {
                List<BattleChar> alives = BattleSystem.instance.AllyTeam.AliveChars;
                if (alives.Count > 0)
                {
                    owner = alives[UnityEngine.Random.Range(0, alives.Count)];
                }
                else
                {
                    owner = BattleSystem.instance.AllyTeam.LucyChar;
                }
            }

            Skill gift = Skill.TempSkill(key, owner, owner.MyTeam);
            gift.ExtendedAdd(new SE_PhoenixGift());
            gift.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(gift, true);
        }

        public static BattleChar FindOwner(string userKey)
        {
            if (string.IsNullOrEmpty(userKey) || BattleSystem.instance == null)
            {
                return null;
            }

            if (IsLucyUser(userKey) || IsLucyDrawUser(userKey))
            {
                return BattleSystem.instance.AllyTeam.LucyChar;
            }

            foreach (BattleChar c in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (c.Info.KeyData == userKey)
                {
                    return c;
                }
            }
            return null;
        }

        public static List<Skill> FilterExactlyOneMatch(IEnumerable<Skill> source, Skill reference)
        {
            List<Skill> list = new List<Skill>();
            if (source == null || reference == null)
            {
                return list;
            }
            foreach (Skill skill in source)
            {
                if (skill == null || skill == reference)
                {
                    continue;
                }
                if (ExactlyOneMatch(skill, reference))
                {
                    list.Add(skill);
                }
            }
            return list;
        }

        public static bool IsLucyUser(string user)
        {
            return user == "Lucy" || user == "LucyRare" || user == GDEItemKeys.Character_LucyC;
        }

        /// <summary>
        /// 露西抽牌技能：User 为 LucyDraw / LucyDraw3 等。
        /// </summary>
        public static bool IsLucyDrawUser(string user)
        {
            return !string.IsNullOrEmpty(user) && user.StartsWith("LucyDraw", StringComparison.Ordinal);
        }

        public static bool IsLucyDrawSkill(GDESkillData data)
        {
            if (data == null)
            {
                return false;
            }
            if (IsLucyDrawUser(GetOwnerKey(data)))
            {
                return true;
            }
            string key = data.KeyID ?? "";
            return key.IndexOf("_LucyDraw", StringComparison.OrdinalIgnoreCase) >= 0
                || key.IndexOf("LucyDraw", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static string NormalizeOwnerKey(GDESkillData data)
        {
            if (data == null || GetSkillTypeKey(data) == "Public")
            {
                return "";
            }
            string user = GetOwnerKey(data);
            if (string.IsNullOrEmpty(user) || user == "null" || IsLucyDrawUser(user))
            {
                return "";
            }
            if (IsLucyUser(user))
            {
                return "Lucy";
            }
            return user;
        }

        public static string NormalizeTargetKey(string key)
        {
            if (string.IsNullOrEmpty(key) || key == "null" || key == "Misc")
            {
                return "Misc";
            }
            if (key == "all_allyorenemy")
            {
                return "all";
            }
            return key;
        }

        public static bool IsNoYellowTarget(string key)
        {
            string n = NormalizeTargetKey(key);
            return n == "Misc" || n == "skill" || n == "choiceskill";
        }

        /// <summary>
        /// 很急版只作猜对奖励，不进搜索下拉。
        /// </summary>
        private static bool IsHiddenFromSearch(GDESkillData data)
        {
            if (data == null)
            {
                return true;
            }
            string key = data.KeyID ?? "";
            if (key == ModItemKeys.Skill_S_BossPhoenix_FindBread
                || key == ModItemKeys.Skill_S_BossPhoenix_ThrowBread)
            {
                return true;
            }
            string name = GetSkillName(data);
            return !string.IsNullOrEmpty(name)
                && (name.IndexOf("很急", StringComparison.Ordinal) >= 0
                    || name.IndexOf("Urgent", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static bool IsBannedTarget(string key)
        {
            return key == ModItemKeys.Skill_S_BossPhoenix_0
                || key == ModItemKeys.Skill_S_BossPhoenix_1
                || key == ModItemKeys.Skill_S_BossPhoenix_2
                || key == ModItemKeys.Skill_S_BossPhoenix_FindBread
                || key == ModItemKeys.Skill_S_BossPhoenix_ThrowBread
                || key == VanillaFindBread
                || key == VanillaThrowBread
                || key == "S_Phoenix_10"
                || key == GDEItemKeys.Skill_S_Phoenix_Draw
                || key == GDEItemKeys.Skill_S_Phoenix_Draw_0
                || key == GDEItemKeys.Skill_S_Phoenix_Draw_1;
        }

        private static void AppendSkillByKey(List<GDESkillData> list, HashSet<string> seen, string key)
        {
            if (string.IsNullOrEmpty(key) || !seen.Add(key))
            {
                return;
            }
            try
            {
                GDESkillData data = new GDESkillData(key);
                if (data != null)
                {
                    list.Add(data);
                }
            }
            catch
            {
            }
        }

        private static void AppendCatalog(List<GDESkillData> list, HashSet<string> seen, List<GDESkillData> source)
        {
            if (source == null)
            {
                return;
            }
            for (int i = 0; i < source.Count; i++)
            {
                GDESkillData data = source[i];
                if (data == null || string.IsNullOrEmpty(data.KeyID) || !seen.Add(data.KeyID) || IsHiddenFromSearch(data))
                {
                    continue;
                }
                if (string.IsNullOrEmpty(GetSkillName(data)))
                {
                    continue;
                }
                list.Add(data);
            }
        }

        private static bool ShareNamePart(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return false;
            }
            if (SharePunctuation(a, b))
            {
                return true;
            }
            if (a.Contains(b) || b.Contains(a))
            {
                return a.Length >= 2 && b.Length >= 2;
            }
            int len = Math.Min(a.Length, b.Length);
            for (int n = 2; n <= len; n++)
            {
                for (int i = 0; i <= a.Length - n; i++)
                {
                    if (b.Contains(a.Substring(i, n)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool SharePunctuation(string a, string b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (IsNamePunctuation(a[i]) && b.IndexOf(a[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsNamePunctuation(char c)
        {
            if (char.IsPunctuation(c))
            {
                return true;
            }
            return "·～~《》〈〉、".IndexOf(c) >= 0;
        }

        private static string GetTargetFamily(string key)
        {
            string n = NormalizeTargetKey(key);
            if (n == "enemy" || n == "all_enemy" || n == "random_enemy")
            {
                return "enemy";
            }
            if (n == "ally" || n == "all_ally")
            {
                return "ally";
            }
            if (n == "all_onetarget" || n == "all")
            {
                return "any";
            }
            return n;
        }

        private static void AddRangeUnique(List<Skill> result, HashSet<string> seen, List<Skill> source)
        {
            if (source == null)
            {
                return;
            }
            for (int i = 0; i < source.Count; i++)
            {
                Skill skill = source[i];
                if (skill == null || skill.MySkill == null)
                {
                    continue;
                }
                if (seen.Add(skill.MySkill.KeyID))
                {
                    result.Add(skill);
                }
            }
        }

        private static void AddTempIfNew(List<Skill> result, HashSet<string> seen, string key, BattleTeam team)
        {
            if (string.IsNullOrEmpty(key) || !seen.Add(key))
            {
                return;
            }
            result.Add(Skill.TempSkill(key, team.LucyChar, team));
        }
    }
}
