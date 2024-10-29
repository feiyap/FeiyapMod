using ChronoArkMod;
namespace Suwako
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 风雨御射
		/// 每个回合使用第4个技能时，将1个0费的[土著神「御射军神大人」]加入手中。
		/// </summary>
        public static string Buff_B_Suwako_3 = "B_Suwako_3";
		/// <summary>
		/// 风雨欲来
		/// 下次触发<color=#008B45>旋回</color>效果时，使被<color=#008B45>旋回</color>的技能在本场战斗中增加&a(40%)伤害或&b(65%)治疗量。
		/// </summary>
        public static string Buff_B_Suwako_8 = "B_Suwako_8";
		/// <summary>
		/// <color=green>连击</color></b>
		/// 每个回合中使用过的技能大于X个时，可以触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Combo = "Keyword_Combo";
		/// <summary>
		/// <color=#008B45>旋回</color>
		/// 从手牌或弃牌库加入牌库时，会触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Return = "Keyword_Return";
		/// <summary>
		/// 造成&a(40%)额外伤害或&b(65%)额外治疗。
		/// </summary>
        public static string SkillExtended_SE_Suwako_Rare2 = "SE_Suwako_Rare2";
        public static string SkillEffect_SE_S_S_Suwako_3 = "SE_S_S_Suwako_3";
        public static string SkillEffect_SE_S_S_Suwako_8 = "SE_S_S_Suwako_8";
        public static string SkillEffect_SE_Tick_B_Suwako_0 = "SE_Tick_B_Suwako_0";
        public static string SkillEffect_SE_T_S_FSL_Common = "SE_T_S_FSL_Common";
        public static string SkillEffect_SE_T_S_Suwako_0 = "SE_T_S_Suwako_0";
        public static string SkillEffect_SE_T_S_Suwako_1 = "SE_T_S_Suwako_1";
        public static string SkillEffect_SE_T_S_Suwako_2 = "SE_T_S_Suwako_2";
        public static string SkillEffect_SE_T_S_Suwako_3 = "SE_T_S_Suwako_3";
        public static string SkillEffect_SE_T_S_Suwako_4 = "SE_T_S_Suwako_4";
        public static string SkillEffect_SE_T_S_Suwako_5 = "SE_T_S_Suwako_5";
        public static string SkillEffect_SE_T_S_Suwako_P = "SE_T_S_Suwako_P";
        public static string SkillEffect_SE_T_S_Suwako_Rare_3_0 = "SE_T_S_Suwako_Rare_3_0";
		/// <summary>
		/// 诹访子基类
		/// </summary>
        public static string SkillExtended_SkillExtend_Suwako = "SkillExtend_Suwako";
		/// <summary>
		/// 洩矢诹访子
		/// Passive:
		/// <b>明日之盛，昨日之俗</b> - 战斗开始时，将技能组第1个技能放在牌堆顶。
		/// <b>创造坤程度的能力</b> - 回合结束时，将手中最上方的技能放回牌库最上方，那之后，抽取1个技能。
		/// <b><color=green>连击X</color></b> - 每个回合中使用过的技能大于X个时，可以触发额外效果。
		/// <b><color=#008B45>旋回</color></b> - 洩矢诹访子的部分技能从手牌或弃牌堆回到牌库时，会触发额外效果。
		/// </summary>
        public static string Character_Suwako = "Suwako";
        public static string Character_Skin_SuwakoEclips = "SuwakoEclips";
		/// <summary>
		/// 风灵
		/// 指向敌人时，造成&a(40%)伤害。指向友军时，恢复&b(65%)体力。
		/// <b><color=green>连击2</color></b> - 获得一次性。
		/// </summary>
        public static string Skill_S_FSL_Common = "S_FSL_Common";
		/// <summary>
		/// 神具「洩矢的铁轮」
		/// <color=green>连击2</color> - 释放后返回牌组。
		/// <color=#008B45>旋回</color> - 本次战斗期间的所有[神具「洩矢的铁轮」]的伤害增加&a(30%)点。
		/// </summary>
        public static string Skill_S_Suwako_0 = "S_Suwako_0";
		/// <summary>
		/// 源符「诹访清水」
		/// <color=#008B45>旋回</color> - 对随机敌人释放后抽取1个技能。
		/// </summary>
        public static string Skill_S_Suwako_1 = "S_Suwako_1";
		/// <summary>
		/// 源符「厌川的翡翠」
		/// 生成1个[南风灵]。
		/// <color=#008B45>旋回</color> - 生成2个[风灵]。
		/// </summary>
        public static string Skill_S_Suwako_2 = "S_Suwako_2";
		/// <summary>
		/// 土著神「御射军神大人」
		/// <color=#008B45>旋回</color> - 放逐这个技能，恢复2点法力值。
		/// </summary>
        public static string Skill_S_Suwako_3 = "S_Suwako_3";
		/// <summary>
		/// 土著神「宝永四年的赤蛙」
		/// 倒计时期间，每次触发<color=#008B45>旋回</color>，或是每使用4个技能，对所有敌人造成40%伤害。
		/// <color=#008B45>旋回</color> - 对所有敌人施加“防御力降低30%”，持续1回合。
		/// </summary>
        public static string Skill_S_Suwako_4 = "S_Suwako_4";
		/// <summary>
		/// 土著神「手长足长大人」
		/// 打出时，将手中最下方的1个技能放回牌库。那之后，抽取1个技能。
		/// <color=green>连击8</color> - 效果变为“打出时，将手中最下方的1个技能放回牌库。那之后，从牌库中选择1个技能抽取。”。
		/// <color=#008B45>旋回</color> - 展示牌堆最下方的3个技能，选择1个加入手中。使选择的技能获得迅速、致命。
		/// </summary>
        public static string Skill_S_Suwako_5 = "S_Suwako_5";
		/// <summary>
		/// 土著神「洩矢神」
		/// 将手中最上方的技能放回牌库，抽取1个技能。
		/// <color=green>连击4</color> - 生成1个1费的[土著神「洩矢神」]。
		/// </summary>
        public static string Skill_S_Suwako_6 = "S_Suwako_6";
		/// <summary>
		/// 土著神「七石七木」
		/// 生成1个[风灵]和1个[南风灵]。
		/// <color=#008B45>旋回</color> - 生成1个[南风灵]。
		/// </summary>
        public static string Skill_S_Suwako_7 = "S_Suwako_7";
		/// <summary>
		/// 土著神「小小青蛙不输风雨」
		/// </summary>
        public static string Skill_S_Suwako_8 = "S_Suwako_8";
		/// <summary>
		/// 神樱「湛樱花吹雪」
		/// 从手牌和弃牌库中各选择1个技能，将它们放回牌堆，再抽取到手中。
		/// <color=#008B45>旋回</color> - 将弃牌库中最上面的1个技能放回牌堆，再抽取到手中。
		/// </summary>
        public static string Skill_S_Suwako_9 = "S_Suwako_9";
		/// <summary>
		/// 开宴「二拜二拍一拜」
		/// 将手中最下面的技能放回牌库，抽取3个技能。
		/// </summary>
        public static string Skill_S_Suwako_LucyD = "S_Suwako_LucyD";
		/// <summary>
		/// 南风灵
		/// <color=#008B45>旋回</color> - 放逐这个技能。
		/// </summary>
        public static string Skill_S_Suwako_P = "S_Suwako_P";
		/// <summary>
		/// 蛙狩「蛙以口鸣，方致蛇祸」
		/// <color=green>连击4</color> - 随机从牌库中释放4个自己的技能。那之后，将他们放回牌库最上方（不会触发<color=#008B45>旋回</color>）。
		/// </summary>
        public static string Skill_S_Suwako_Rare_1 = "S_Suwako_Rare_1";
		/// <summary>
		/// 蛙休「总是能够冬眠」
		/// 将手牌中所有[风灵]系以外的技能返回牌库最上方，生成等量的、对应持有者的[风灵]。
		/// 那之后，使手中所有[风灵]系技能增加&a(40%)伤害或&b(65%)治疗量。
		/// 回合结束时，抽取与返回技能数等量的技能。
		/// </summary>
        public static string Skill_S_Suwako_Rare_2 = "S_Suwako_Rare_2";
		/// <summary>
		/// 蛙符「涂有鲜血的赤蛙塚」
		/// 这个技能释放后拿回手中。
		/// 将目标技能放回牌库最下方。那之后，选择 - 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]；或是什么都不做。
		/// 当这个技能获得5层[苏醒]时，放逐这个技能，将1个[祟神「赤口大人」]加入手中。
		/// 当前[苏醒]层数：&a
		/// &b
		/// </summary>
        public static string Skill_S_Suwako_Rare_3 = "S_Suwako_Rare_3";
		/// <summary>
		/// 祟神「赤口大人」
		/// 这个技能必定命中，无视防御。
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_0 = "S_Suwako_Rare_3_0";
		/// <summary>
		/// 重复释放
		/// 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]。
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_1 = "S_Suwako_Rare_3_1";
		/// <summary>
		/// 什么都不做
		/// 什么都不做。
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_2 = "S_Suwako_Rare_3_2";
		/// <summary>
		/// 蛙符「涂有鲜血的赤蛙塚」
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_3 = "S_Suwako_Rare_3_3";
		/// <summary>
		/// 蛙休
		/// </summary>
        public static string Buff_B_Suwako_Rare2 = "B_Suwako_Rare2";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>身上好像有什么东西进来了一样的恶寒……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text0 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text0");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>身体中好像有什么在蠕动着的不快感……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text1 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text1");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>感觉身体的毛孔里好像被针扎进去一样地发冷……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text2 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text2");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>……是虵。我看见虵了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text3 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text3");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <b><color=#FF0000>虵看见我了。</color></b>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text4 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text4");

    }
}