using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using GameDataEditor;

namespace FeiyapDestination
{
    /// <summary>
    /// 从角色 JSON 的 PassiveDes 解析分页文案；标蓝由 JSON 内 UBB（&lt;color&gt;）自行书写。
    /// 本类仅处理分页解析与未生效职业段置灰。
    /// </summary>
    public static class PassivePages
    {
        private const string ColorGray = "#919191";
        private const string PagesMarker = "<<PAGES>>";

        private static readonly Regex SectionRx = new Regex(
            @"<<(Any|Offense|Defense|EighthLocked|EighthUnlocked|OffenseLabel|DefenseLabel)>>\s*(.*?)\s*<</\1>>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex ColorTagRx = new Regex(
            @"<color=[^>]*>|</color>",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static List<string> BuildPages()
        {
            string raw = ReadPassiveDes();
            List<string> pages = new List<string>();
            if (string.IsNullOrEmpty(raw))
            {
                pages.Add("（PassiveDes 为空）");
                return pages;
            }

            int marker = raw.IndexOf(PagesMarker, StringComparison.OrdinalIgnoreCase);
            string body = marker >= 0
                ? raw.Substring(marker + PagesMarker.Length).Trim()
                : raw.Trim();

            string offenseLabel = "【免许皆传·终点·绯夜氏】（输出）";
            string defenseLabel = "【流风遗韵·终点·绯夜氏】（防御）";
            MatchCollection labelMatches = SectionRx.Matches(body);
            for (int i = 0; i < labelMatches.Count; i++)
            {
                Match m = labelMatches[i];
                string tag = m.Groups[1].Value;
                string val = m.Groups[2].Value.Trim();
                if (tag.Equals("OffenseLabel", StringComparison.OrdinalIgnoreCase) && val.Length > 0)
                {
                    offenseLabel = val;
                }
                else if (tag.Equals("DefenseLabel", StringComparison.OrdinalIgnoreCase) && val.Length > 0)
                {
                    defenseLabel = val;
                }
            }

            JobMode job = CurrentJob();
            bool gold = FriendshipUtil.HasGoldToken();
            string[] pageChunks = Regex.Split(body, @"<<PAGE>>", RegexOptions.IgnoreCase);
            for (int p = 0; p < pageChunks.Length; p++)
            {
                string chunk = pageChunks[p];
                if (string.IsNullOrWhiteSpace(chunk))
                {
                    continue;
                }
                StringBuilder sb = new StringBuilder();
                MatchCollection sections = SectionRx.Matches(chunk);
                for (int i = 0; i < sections.Count; i++)
                {
                    Match m = sections[i];
                    string tag = m.Groups[1].Value;
                    string text = m.Groups[2].Value.Trim();
                    if (text.Length == 0)
                    {
                        continue;
                    }
                    if (tag.Equals("OffenseLabel", StringComparison.OrdinalIgnoreCase)
                        || tag.Equals("DefenseLabel", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    if (tag.Equals("EighthLocked", StringComparison.OrdinalIgnoreCase))
                    {
                        if (gold)
                        {
                            continue;
                        }
                    }
                    else if (tag.Equals("EighthUnlocked", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!gold)
                        {
                            continue;
                        }
                    }

                    text = text
                        .Replace("{OffenseJob}", JobLabel(offenseLabel, job == JobMode.Offense))
                        .Replace("{DefenseJob}", JobLabel(defenseLabel, job == JobMode.Defense));

                    bool active = true;
                    if (tag.Equals("Offense", StringComparison.OrdinalIgnoreCase))
                    {
                        active = job == JobMode.Offense;
                    }
                    else if (tag.Equals("Defense", StringComparison.OrdinalIgnoreCase))
                    {
                        active = job == JobMode.Defense;
                    }

                    // 生效段：JSON 原文（含 UBB 标蓝）；未生效段：剥色后整段置灰
                    string rendered = active ? text : GrayBlock(text);
                    if (sb.Length > 0)
                    {
                        sb.Append("\n\n");
                    }
                    sb.Append(rendered);
                }

                if (sb.Length == 0)
                {
                    string plain = SectionRx.Replace(chunk, string.Empty).Trim();
                    if (plain.Length > 0)
                    {
                        sb.Append(plain);
                    }
                }
                if (sb.Length > 0)
                {
                    pages.Add(sb.ToString());
                }
            }

            if (pages.Count == 0)
            {
                pages.Add(body);
            }
            return pages;
        }

        /// <summary><<PAGES>> 之前的短提示（若无标记则整段）。</summary>
        public static string GetTip()
        {
            string raw = ReadPassiveDes();
            if (string.IsNullOrEmpty(raw))
            {
                return string.Empty;
            }
            int marker = raw.IndexOf(PagesMarker, StringComparison.OrdinalIgnoreCase);
            if (marker < 0)
            {
                return raw.Trim();
            }
            return raw.Substring(0, marker).Trim();
        }

        private static string ReadPassiveDes()
        {
            try
            {
                GDECharacterData data = new GDECharacterData(FeiyapKeys.Destination);
                if (data != null && !string.IsNullOrEmpty(data.PassiveDes))
                {
                    return data.PassiveDes;
                }
            }
            catch
            {
            }
            return null;
        }

        private static JobMode CurrentJob()
        {
            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            return cv != null ? cv.Job : JobMode.Offense;
        }

        /// <summary>去掉已有 color 标签后整段置灰，避免未生效段里残留标蓝。</summary>
        private static string GrayBlock(string text)
        {
            string plain = ColorTagRx.Replace(text, string.Empty);
            return "<color=" + ColorGray + ">" + plain + "</color>";
        }

        private static string JobLabel(string label, bool active)
        {
            if (active)
            {
                return label;
            }
            return "<color=" + ColorGray + ">" + ColorTagRx.Replace(label, string.Empty) + "</color>";
        }
    }
}
