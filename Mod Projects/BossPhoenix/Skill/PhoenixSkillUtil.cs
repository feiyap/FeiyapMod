using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            if (data == null || data.Effect_Target == null || data.Effect_Target.Buffs == null)
            {
                return 0;
            }
            return data.Effect_Target.Buffs.Count;
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

            AddTempIfNew(result, seen, GDEItemKeys.Skill_S_Phoenix_Draw, team);
            AddTempIfNew(result, seen, GDEItemKeys.Skill_S_Phoenix_Draw_0, team);
            AddTempIfNew(result, seen, GDEItemKeys.Skill_S_Phoenix_Draw_1, team);
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
            cachedCatalog = list;
            return cachedCatalog;
        }

        public static string PickRandomImaginedKey()
        {
            List<GDESkillData> pool = new List<GDESkillData>();
            List<GDESkillData> catalog = GetSkillCatalog();
            for (int i = 0; i < catalog.Count; i++)
            {
                if (IsBannedTarget(catalog[i].KeyID))
                {
                    continue;
                }
                pool.Add(catalog[i]);
            }
            if (pool.Count == 0)
            {
                return GDEItemKeys.Skill_S_Phoenix_Draw_1;
            }
            return pool[UnityEngine.Random.Range(0, pool.Count)].KeyID;
        }

        public static string PickRandomImaginedKeyExcept(string exceptKey)
        {
            List<GDESkillData> pool = new List<GDESkillData>();
            List<GDESkillData> catalog = GetSkillCatalog();
            for (int i = 0; i < catalog.Count; i++)
            {
                if (IsBannedTarget(catalog[i].KeyID) || catalog[i].KeyID == exceptKey)
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

        public static string GetOwnerName(GDESkillData data)
        {
            string user = GetOwnerKey(data);
            if (string.IsNullOrEmpty(user) || user == "Lucy" || user == "LucyDraw" || user == "LucyRare" || user == GDEItemKeys.Character_LucyC)
            {
                return ModLocalization.Loc("Riddle/OwnerLucy");
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
            string key = GetTargetKey(data);
            string loc = ModLocalization.Loc("Riddle/Target/" + key);
            if (!string.IsNullOrEmpty(loc) && loc != "Riddle/Target/" + key)
            {
                return loc;
            }
            if (string.IsNullOrEmpty(key) || key == "null")
            {
                return ModLocalization.Loc("Riddle/Target/Misc");
            }
            return key;
        }

        public static string GetSkillTypeName(GDESkillData data)
        {
            return ModLocalization.Loc("Riddle/Type/" + GetSkillTypeKey(data));
        }

        public static string GetTimingName(GDESkillData data)
        {
            return ModLocalization.Loc("Riddle/Timing/" + GetTimingKey(data));
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
                return ModLocalization.Loc("Riddle/BuffNone");
            }
            return string.Format(ModLocalization.Loc("Riddle/BuffYes"), count);
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
            string a = GetOwnerKey(guess);
            string b = GetOwnerKey(target);
            if (a == b)
            {
                return RiddleMatch.Exact;
            }
            if (IsLucyUser(a) && IsLucyUser(b))
            {
                return RiddleMatch.Close;
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
            string a = GetTargetKey(guess);
            string b = GetTargetKey(target);
            if (a == b)
            {
                return RiddleMatch.Exact;
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
            int denom = Math.Max(Math.Abs(guess), Math.Abs(target));
            if (denom <= 0)
            {
                return RiddleMatch.None;
            }
            if ((float)Math.Abs(guess - target) / denom <= 0.5f)
            {
                return RiddleMatch.Close;
            }
            return RiddleMatch.None;
        }

        public static RiddleMatch CompareType(GDESkillData guess, GDESkillData target)
        {
            string a = GetSkillTypeKey(guess);
            string b = GetSkillTypeKey(target);
            if (a == b)
            {
                return RiddleMatch.Exact;
            }
            if ((a == "Normal" || a == "Rare") && (b == "Normal" || b == "Rare"))
            {
                return RiddleMatch.Close;
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
            BattleSystem.instance.AllyTeam.Add(gift, true);
        }

        public static BattleChar FindOwner(string userKey)
        {
            if (string.IsNullOrEmpty(userKey) || BattleSystem.instance == null)
            {
                return null;
            }

            if (IsLucyUser(userKey))
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
            return user == "Lucy" || user == "LucyDraw" || user == "LucyRare" || user == GDEItemKeys.Character_LucyC;
        }

        private static bool IsBannedTarget(string key)
        {
            return key == ModItemKeys.Skill_S_BossPhoenix_0
                || key == ModItemKeys.Skill_S_BossPhoenix_1
                || key == ModItemKeys.Skill_S_BossPhoenix_2
                || key == ModItemKeys.Skill_S_BossPhoenix_FindBread
                || key == ModItemKeys.Skill_S_BossPhoenix_ThrowBread;
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
                if (data == null || string.IsNullOrEmpty(data.KeyID) || !seen.Add(data.KeyID))
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

        private static string GetTargetFamily(string key)
        {
            if (key == "enemy" || key == "all_enemy" || key == "random_enemy" || key == "enemy_PlusRandom" || key == "all_onetarget")
            {
                return "enemy";
            }
            if (key == "ally" || key == "all_ally" || key == "otherally" || key == "self" || key == "deathally")
            {
                return "ally";
            }
            if (key == "skill" || key == "allskill" || key == "choiceskill")
            {
                return "skill";
            }
            return "misc";
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
