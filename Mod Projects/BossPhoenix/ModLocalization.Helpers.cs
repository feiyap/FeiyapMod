using System.Collections.Generic;
using ChronoArkMod;

namespace BossPhoenix
{
    /// <summary>
    /// 编辑器会整份重写 ModLocalization，运行时文案走这里。
    /// 新 Key 若还没被编辑器收录，用内置回退，避免界面露出 Key。
    /// </summary>
    public static class PhoenixLoc
    {
        public static string Loc(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            if (Table.ContainsKey(key))
            {
                return Fallback(key);
            }
            try
            {
                string text = ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate(key);
                if (!string.IsNullOrEmpty(text) && text != key)
                {
                    return text;
                }
            }
            catch
            {
            }
            return Fallback(key);
        }

        public static string RiddleCorrect
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixCorrect; }
        }

        public static string RiddleFail
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixFail; }
        }

        public static string BattleStart1
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixText1; }
        }

        public static string BattleStart2
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixText2; }
        }

        public static string BattleStart3
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixText3; }
        }

        public static string Stubborn
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixStubborn; }
        }

        public static string Soothe
        {
            get { return ModLocalization.BattleDiaBoss_PhoenixSoothe; }
        }

        public static string SmallWorldExile
        {
            get { return ModLocalization.SmallWorldExileSelect; }
        }

        public static string SmallWorldDraw
        {
            get { return ModLocalization.SmallWorldDrawSelect; }
        }

        private static string Fallback(string key)
        {
            string[] row;
            if (!Table.TryGetValue(key, out row) || row == null || row.Length < 5)
            {
                int slash = key.LastIndexOf('/');
                return slash >= 0 && slash + 1 < key.Length ? key.Substring(slash + 1) : key;
            }
            int i = LangIndex();
            if (i < 0 || i >= row.Length || string.IsNullOrEmpty(row[i]))
            {
                return row[3];
            }
            return row[i];
        }

        private static int LangIndex()
        {
            string lang = "";
            try
            {
                lang = I2.Loc.LocalizationManager.CurrentLanguage ?? "";
            }
            catch
            {
            }
            lang = lang.ToLowerInvariant();
            if (lang.IndexOf("korea") >= 0 || lang == "ko")
            {
                return 0;
            }
            if (lang.IndexOf("japan") >= 0 || lang == "ja")
            {
                return 2;
            }
            if (lang.IndexOf("tw") >= 0 || lang.IndexOf("trad") >= 0 || lang.IndexOf("hk") >= 0)
            {
                return 4;
            }
            if (lang.IndexOf("chinese") >= 0 || lang.IndexOf("zh") >= 0 || lang.IndexOf("cn") >= 0)
            {
                return 3;
            }
            if (lang.IndexOf("english") >= 0 || lang == "en")
            {
                return 1;
            }
            return 3;
        }

        // 韩 / 英 / 日 / 简中 / 繁中
        private static readonly Dictionary<string, string[]> Table = new Dictionary<string, string[]>
        {
            { "Riddle/OwnerNone", new[] { "없음", "None", "なし", "无", "無" } },
            { "Riddle/WonHint", new[] { "정답! 확인을 누르세요.", "Correct! Press OK.", "正解！決定を押して。", "猜对了！点击确定继续。", "猜對了！點擊確定繼續。" } },
            { "Riddle/GiveUpReveal", new[] { "봉황이 생각한 스킬: {0}", "Phoenix imagined: {0}", "鳳凰が思い浮かべたスキル：{0}", "凤凰想的是：{0}", "鳳凰想的是：{0}" } },
            { "Riddle/GiveUpRevealEmpty", new[] { "봉황이 생각한 스킬을 표시할 수 없습니다.", "Could not show the imagined skill.", "思い浮かべたスキルを表示できません。", "无法展示凤凰想象的技能。", "無法展示鳳凰想像的技能。" } },
            { "Riddle/InputHint", new[] { "정규식으로 스킬을 검색한 뒤 확인을 누르세요.", "Search a skill with regex, then press OK.", "正規表現でスキルを検索して決定。", "用正则搜索技能，然后按回车或点确定。", "用正則搜尋技能，然後按 Enter 或點確定。" } },
            { "Riddle/Target/all", new[] { "모든 대상", "All Targets", "全対象", "所有目标", "所有目標" } },
            { "Riddle/Target/all_onetarget", new[] { "단일 대상", "Single Target", "単一対象", "单个目标", "單個目標" } },
            { "Riddle/Target/all_ally", new[] { "모든 아군", "All Allies", "味方全体", "所有队友", "所有隊友" } },
            { "Riddle/Target/all_enemy", new[] { "모든 적", "All Enemies", "敵全体", "所有敌人", "所有敵人" } },
            { "Riddle/Target/ally", new[] { "아군 하나", "Single Ally", "味方単体", "指向队友", "指向隊友" } },
            { "Riddle/Target/enemy", new[] { "적 하나", "Single Enemy", "敵単体", "指向敌人", "指向敵人" } },
            { "Riddle/Target/skill", new[] { "스킬", "Skill", "スキル", "指向技能", "指向技能" } },
            { "Riddle/Target/choiceskill", new[] { "선택", "Option", "選択", "选项", "選項" } },
            { "Riddle/Target/random_enemy", new[] { "무작위 적", "Random Enemy", "ランダムな敵", "随机敌人", "隨機敵人" } },
            { "Riddle/ColTiming", new[] { "신속/과부하", "Timing", "迅速/過負荷", "是否过载", "是否過載" } },
            { "Riddle/ColRole", new[] { "직업", "Role", "職業", "职业", "職業" } },
            { "Riddle/Role/DPS", new[] { "딜러", "DPS", "アタッカー", "输出", "輸出" } },
            { "Riddle/Role/Support", new[] { "힐러", "Healer", "ヒーラー", "治疗", "治療" } },
            { "Riddle/Role/Tank", new[] { "탱커", "Tank", "タンク", "坦克", "坦克" } },
            { "Riddle/Role/None", new[] { "없음", "None", "なし", "无", "無" } },
            { "Riddle/Tip/Role", new[] { "딜러/힐러/탱커/없음. 모드 직업은 해당 LangSystem. 같으면 초록. 노랑 없음.", "DPS / Healer / Tank / None. Mod roles use that mod's LangSystem. Green if same. No yellow.", "アタッカー／ヒーラー／タンク／なし。MOD職業はそのLangSystem。同じなら緑。黄なし。", "输出、治疗、坦克或无。模组职业读其 LangSystem。相同为绿。没有黄色。", "輸出、治療、坦克或無。模組職業讀其 LangSystem。相同為綠。沒有黃色。" } },
            { "Riddle/MoreMatches", new[] { "검색 결과 {0}개", "{0} matches", "{0}件ヒット", "还有更多匹配（共 {0} 个）", "還有更多匹配（共 {0} 個）" } },
            { "Riddle/Type/Curse", new[] { "저주", "Curse", "呪い", "诅咒", "詛咒" } },
            { "Riddle/Type/Normal", new[] { "일반", "Common", "通常", "普通", "普通" } },
            { "Riddle/Type/Public", new[] { "공용", "Public", "汎用", "通用", "通用" } },
            { "Riddle/Type/Rare", new[] { "레어", "Rare", "レア", "稀有", "稀有" } },
            { "Riddle/Type/Attack", new[] { "공격", "Attack", "攻撃", "攻击", "攻擊" } },
            { "Riddle/Type/Heal", new[] { "회복", "Heal", "回復", "治疗", "治療" } },
            { "Riddle/Type/Lucy", new[] { "루시", "Lucy", "ルーシー", "露西", "露西" } },
            { "Riddle/Type/Support", new[] { "지원", "Support", "支援", "辅助", "輔助" } },
            { "Riddle/Timing/Swift", new[] { "신속", "Swift", "迅速", "迅速技能", "迅速技能" } },
            { "Riddle/Timing/Overload", new[] { "과부하", "Overload", "過負荷", "过载技能", "過載技能" } },
            { "Riddle/Tip/Name", new[] { "같으면 초록. 이름이 일부 같으면 노랑. 아니면 회색.", "Green if same. Yellow if names partly match. Else gray.", "同じなら緑。名前の一部が同じなら黄。それ以外は灰。", "相同为绿。技能名有部分相同为黄。否则为灰。", "相同為綠。技能名有部分相同為黃。否則為灰。" } },
            { "Riddle/Tip/Owner", new[] { "같으면 초록. 성별이 같으면 노랑. 다르거나 없으면 회색. 소유자 없으면 「없음」.", "Green if same owner. Yellow if same gender. Gray if different/unknown. No owner shows None.", "同じなら緑。性別が同じなら黄。違う／不明は灰。所有者がいなければ「なし」。", "持有者相同为绿。性别相同为黄。性别不同或无法判断为灰。无持有者显示「无」。", "持有者相同為綠。性別相同為黃。性別不同或無法判斷為灰。無持有者顯示「無」。" } },
            { "Riddle/Tip/Cost", new[] { "같으면 초록. 1 차이면 노랑. 화살표는 목표보다 높거나 낮음.", "Green if same. Yellow if off by 1. Arrows show higher/lower than the target.", "同じなら緑。差が1なら黄。矢印は目標より高い／低い。", "费用相同为绿。相差 1 为黄。箭头表示比目标更高或更低。", "費用相同為綠。相差 1 為黃。箭頭表示比目標更高或更低。" } },
            { "Riddle/Tip/Target", new[] { "같으면 초록.\n적 하나↔모든 적↔무작위 적, 아군 하나↔모든 아군, 단일 대상↔모든 대상은 노랑.\n무대상·선택·스킬은 노랑 없음.", "Green if same.\nSingle enemy↔all enemies↔random enemy, single ally↔all allies, single target↔all targets are yellow.\nNo target, Option and Skill never yellow.", "同じなら緑。\n敵単体↔全敵↔ランダムな敵、味方単体↔全味方、単一対象↔全対象は黄。\n対象なし・選択・スキルは黄なし。", "目标相同为绿。\n「指向敌人」「所有敌人」「随机敌人」互为黄色；「指向队友」与「所有队友」、「单个目标」与「所有目标」互为黄色。\n「无指向」「选项」「指向技能」不与任何标签互为黄色。", "目標相同為綠。\n「指向敵人」「所有敵人」「隨機敵人」互為黃色；「指向隊友」與「所有隊友」、「單個目標」與「所有目標」互為黃色。\n「無指向」「選項」「指向技能」不與任何標籤互為黃色。" } },
            { "Riddle/Tip/Mult", new[] { "같으면 초록. 차이가 50 이하면 노랑.", "Green if same. Yellow if difference ≤ 50.", "同じなら緑。差が50以下なら黄。", "倍率相同为绿。相差不超过 50 为黄。箭头表示比目标更高或更低。", "倍率相同為綠。相差不超過 50 為黃。箭頭表示比目標更高或更低。" } },
            { "Riddle/Tip/Type", new[] { "같으면 초록. 아니면 회색. 노랑 없음.", "Green if same. Else gray. No yellow.", "同じなら緑。それ以外は灰。黄なし。", "技能类型相同为绿。否则为灰。没有黄色。", "技能類型相同為綠。否則為灰。沒有黃色。" } },
            { "Riddle/Tip/Timing", new[] { "신속/과부하. 같으면 초록. 아니면 회색.", "Swift or Overload. Green if same. Else gray.", "迅速／過負荷。同じなら緑。それ以外は灰。", "迅速技能或过载技能。相同为绿。否则为灰。", "迅速技能或過載技能。相同為綠。否則為灰。" } },
            { "Riddle/Tip/Buff", new[] { "유무와 수가 같으면 초록. 둘 다 있고 수만 다르면 노랑.", "Green if presence and count match. Yellow if both have buffs but counts differ.", "有無と数が同じなら緑。両方あり数だけ違うなら黄。", "有无与层数都相同为绿。都有附加但层数不同为黄。箭头表示比目标更高或更低。", "有無與層數都相同為綠。都有附加但層數不同為黃。箭頭表示比目標更高或更低。" } }
        };
    }
}
