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
		/// 下次触发<color=#008B45>旋回</color>效果时，使被<color=#008B45>旋回</color>的技能在本场战斗中增加&a(80%)伤害或&b(130%)治疗量。触发后解除。
		/// </summary>
        public static string Buff_B_Suwako_8 = "B_Suwako_8";
		/// <summary>
		/// 风雨已至
		/// 每次触发<color=#008B45>旋回</color>或使用0费技能时，使该减益的伤害增加2点。
		/// </summary>
        public static string Buff_B_Suwako_Dot = "B_Suwako_Dot";
		/// <summary>
		/// 风雨皆息
		/// 触发<color=#008B45>旋回</color>或释放手中的0费技能时，立即触发1次自己施加的[风雨已至]的伤害，但只造成50%的伤害量。
		/// </summary>
        public static string Buff_B_Suwako_Rare2 = "B_Suwako_Rare2";
		/// <summary>
		/// <color=green>连击</color></b>
		/// 每个回合中使用过的技能大于X个时，可以触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Combo = "Keyword_Combo";
		/// <summary>
		/// <color=#008B45>旋回</color>
		/// 技能加入牌库时，会触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Return = "Keyword_Return";
		/// <summary>
		/// 造成&a(40%)额外伤害或&b(65%)额外治疗。
		/// </summary>
        public static string SkillExtended_SE_Suwako_Rare2 = "SE_Suwako_Rare2";
        public static string SkillEffect_SE_S_S_Suwako_3 = "SE_S_S_Suwako_3";
        public static string SkillEffect_SE_S_S_Suwako_8 = "SE_S_S_Suwako_8";
        public static string SkillEffect_SE_S_S_Suwako_Rare_2 = "SE_S_S_Suwako_Rare_2";
        public static string SkillEffect_SE_Tick_B_Suwako_0 = "SE_Tick_B_Suwako_0";
        public static string SkillEffect_SE_Tick_B_Suwako_Dot = "SE_Tick_B_Suwako_Dot";
        public static string SkillEffect_SE_T_S_FSL_Common = "SE_T_S_FSL_Common";
        public static string SkillEffect_SE_T_S_Suwako_0 = "SE_T_S_Suwako_0";
        public static string SkillEffect_SE_T_S_Suwako_1 = "SE_T_S_Suwako_1";
        public static string SkillEffect_SE_T_S_Suwako_2 = "SE_T_S_Suwako_2";
        public static string SkillEffect_SE_T_S_Suwako_3 = "SE_T_S_Suwako_3";
        public static string SkillEffect_SE_T_S_Suwako_4 = "SE_T_S_Suwako_4";
        public static string SkillEffect_SE_T_S_Suwako_5 = "SE_T_S_Suwako_5";
        public static string SkillEffect_SE_T_S_Suwako_9 = "SE_T_S_Suwako_9";
        public static string SkillEffect_SE_T_S_Suwako_P = "SE_T_S_Suwako_P";
        public static string SkillEffect_SE_T_S_Suwako_Rare_1 = "SE_T_S_Suwako_Rare_1";
        public static string SkillEffect_SE_T_S_Suwako_Rare_2 = "SE_T_S_Suwako_Rare_2";
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
        public static string SimpleCampDialogue_CampDial_Suwako_HakureiReimu = "CampDial_Suwako_HakureiReimu";
        public static string SimpleCampDialogue_CampDial_Suwako_RemiliaScarlet = "CampDial_Suwako_RemiliaScarlet";
        public static string SimpleCampDialogue_CampDial_Suwako_IzayoiSakuya = "CampDial_Suwako_IzayoiSakuya";
        public static string SimpleCampDialogue_CampDial_Suwako_FlandreScarlet = "CampDial_Suwako_FlandreScarlet";
        public static string SimpleCampDialogue_CampDial_Suwako_SatsukiRin = "CampDial_Suwako_SatsukiRin";
        public static string SimpleCampDialogue_CampDial_Suwako_Mokou = "CampDial_Suwako_Mokou";
        public static string SimpleCampDialogue_CampDial_Suwako_Youmu = "CampDial_Suwako_Youmu";
        public static string SimpleCampDialogue_CampDial_Suwako_TouhouAlice = "CampDial_Suwako_TouhouAlice";
        public static string SimpleCampDialogue_CampDial_Suwako_Reisen = "CampDial_Suwako_Reisen";
        public static string SimpleCampDialogue_CampDial_Suwako_Eirin = "CampDial_Suwako_Eirin";
        public static string SimpleCampDialogue_CampDial_Suwako_HouraisanKaguya = "CampDial_Suwako_HouraisanKaguya";
        public static string SimpleCampDialogue_CampDial_Suwako_Inaba = "CampDial_Suwako_Inaba";
        public static string SimpleCampDialogue_CampDial_Suwako_KochiyaSanae = "CampDial_Suwako_KochiyaSanae";
        public static string SimpleCampDialogue_CampDial_Suwako_Cirno = "CampDial_Suwako_Cirno";
        public static string SimpleCampDialogue_CampDial_Suwako_Daiyousei = "CampDial_Suwako_Daiyousei";
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
		/// <color=green>连击4</color> - 必定暴击。
		/// <color=#008B45>旋回</color> - 对随机敌人释放后抽取1个技能。
		/// </summary>
        public static string Skill_S_Suwako_1 = "S_Suwako_1";
		/// <summary>
		/// 源符「厌川的翡翠」
		/// 生成2个[南风灵]。
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
		/// <color=#008B45>旋回</color> - 对随机敌人施加2层[风雨已至]。
		/// </summary>
        public static string Skill_S_Suwako_4 = "S_Suwako_4";
		/// <summary>
		/// 土著神「手长足长大人」
		/// 打出时，将手中最下方的1个技能放回牌库。那之后，抽取1个技能。
		/// <color=green>连击4</color> - 效果变为“打出时，将手中最下方的1个技能放回牌库。那之后，从牌库中选择1个技能抽取。”。
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
		/// 土著神「洩矢神」
		/// 将手中最上方的技能放回牌库，抽取1个技能。
		/// </summary>
        public static string Skill_S_Suwako_6_0 = "S_Suwako_6_0";
		/// <summary>
		/// 土著神「七石七木」
		/// 生成1个[风灵]和1个[南风灵]。
		/// <color=#008B45>旋回</color> - 选择手中1个技能放回牌库，抽取1个技能。
		/// </summary>
        public static string Skill_S_Suwako_7 = "S_Suwako_7";
		/// <summary>
		/// 土著神「小小青蛙不输风雨」
		/// </summary>
        public static string Skill_S_Suwako_8 = "S_Suwako_8";
		/// <summary>
		/// 祟符「御社宫司大人」
		/// <color=green>连击4</color> - 必定暴击。
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
		/// 使所有其他技能返回牌库。那之后，每个返回牌库的技能使这个技能造成额外&a(100%)伤害。
		/// </summary>
        public static string Skill_S_Suwako_Rare_1 = "S_Suwako_Rare_1";
		/// <summary>
		/// 蛙休「总是能够冬眠」
		/// 释放时如果场上没有[风雨已至]，使随机敌人获得1层[风雨已至]。
		/// </summary>
        public static string Skill_S_Suwako_Rare_2 = "S_Suwako_Rare_2";
		/// <summary>
		/// 蛙符「涂有鲜血的赤蛙塚」
		/// 将目标技能放回牌库最下方。释放后，将这个技能拿回手中。
		/// 那之后，选择 - 重复释放1次，然后抽取1个技能，并使这个技能获得1层<color=#FF0000>苏醒</color>；或是丢弃这个技能。
		/// 当这个技能获得5层<color=#FF0000>苏醒</color>时，放逐这个技能，将1个[蛙符「涂有鲜血的赤蛙塚」]置入弃牌库，将1个[祟神「赤口大人」]加入手中。
		/// 当前<color=#FF0000>苏醒</color>层数：&a
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
		/// 重复释放1次，然后抽取1个技能，并使这个技能获得1层<color=#FF0000>苏醒</color>。
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_1 = "S_Suwako_Rare_3_1";
		/// <summary>
		/// 丢弃这个技能
		/// 丢弃这个技能。
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_2 = "S_Suwako_Rare_3_2";
		/// <summary>
		/// 蛙符「涂有鲜血的赤蛙塚」
		/// </summary>
        public static string Skill_S_Suwako_Rare_3_3 = "S_Suwako_Rare_3_3";
		/// <summary>
		/// Passive:
		/// </summary>
        public static string Character_SuwakoRedhotSkin = "SuwakoRedhotSkin";
        public static string Character_Skin_SuwakoRedhot = "SuwakoRedhot";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// <i><color=#696969>You feel a chill, as if something has just entered your body...</color></i>
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>身上好像有什么东西进来了一样的恶寒……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text0 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text0");
		/// <summary>
		/// Korean:
		/// English:
		/// <i><color=#696969>You feel an unpleasant sensation, writhing within your body...</color></i>
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>身体中好像有什么在蠕动着的不快感……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text1 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text1");
		/// <summary>
		/// Korean:
		/// English:
		/// <i><color=#696969>You feel a prickling sensation, as if you were being pierced by pins and needles...</color></i>
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>感觉身体的毛孔里好像被针扎进去一样地发冷……</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text2 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text2");
		/// <summary>
		/// Korean:
		/// English:
		/// <i><color=#696969>A Snake... Just now, I saw a Snake.</color></i>
		/// Japanese:
		/// Chinese:
		/// <i><color=#696969>……是虵。我看见虵了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text3 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text3");
		/// <summary>
		/// Korean:
		/// English:
		/// <b><color=#FF0000>The Snake has marked you.</color></b>
		/// Japanese:
		/// Chinese:
		/// <b><color=#FF0000>虵看见我了。</color></b>
		/// Chinese-TW:
		/// </summary>
        public static string S_Suwako_Rare_3Text4 => ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text4");

    }
}