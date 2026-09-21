using ChronoArkMod;
namespace YakumoYukari
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 幻想的境界
		/// 迅捷动作：&a
		/// 移动动作：&b
		/// 标准动作：&c
		/// 境界力：&d/&e
		/// </summary>
        public static string Buff_B_YakumoYukari_P = "B_YakumoYukari_P";
        public static string SkillEffect_SE_T_S_YakumoYukari_1 = "SE_T_S_YakumoYukari_1";
        public static string SkillEffect_SE_T_S_YakumoYukari_2 = "SE_T_S_YakumoYukari_2";
		/// <summary>
		/// 执行动作
		/// 无指向。
		/// 消耗所选动作类型对应的槽：迅捷、移动或标准。
		/// </summary>
        public static string Skill_S_YakumoYukari_0 = "S_YakumoYukari_0";
		/// <summary>
		/// 后悔打开的玉匣
		/// 标准动作。指向敌人。
		/// 造成 &a 伤害<color=#FF7A33>(攻击力的100%)</color>。
		/// </summary>
        public static string Skill_S_YakumoYukari_1 = "S_YakumoYukari_1";
		/// <summary>
		/// 潜藏于禅寺的妖蝶
		/// 整轮动作。指向敌人。
		/// 消耗1个移动动作和1个标准动作。
		/// 造成 &a 伤害<color=#FF7A33>(攻击力的180%)</color>。
		/// </summary>
        public static string Skill_S_YakumoYukari_2 = "S_YakumoYukari_2";
		/// <summary>
		/// 静观其变之眼
		/// 迅捷动作。自身。
		/// 推进一次倒计时。获得1点【境界力】。
		/// </summary>
        public static string Skill_S_YakumoYukari_3 = "S_YakumoYukari_3";
		/// <summary>
		/// 执行动作
		/// 选择动作类型，再选择并执行一个具体动作。
		/// </summary>
        public static string Skill_S_YakumoYukari_Act = "S_YakumoYukari_Act";
		/// <summary>
		/// 移动动作
		/// 选择并执行一个移动动作。会推进一次倒计时。
		/// </summary>
        public static string Skill_S_YakumoYukari_Act_Move = "S_YakumoYukari_Act_Move";
		/// <summary>
		/// 标准动作
		/// 选择并执行一个标准动作。会推进一次倒计时。
		/// </summary>
        public static string Skill_S_YakumoYukari_Act_Standard = "S_YakumoYukari_Act_Standard";
		/// <summary>
		/// 迅捷动作
		/// 选择并执行一个迅捷动作。
		/// </summary>
        public static string Skill_S_YakumoYukari_Act_Swift = "S_YakumoYukari_Act_Swift";
		/// <summary>
		/// 八云紫
		/// Passive:
		/// <b>妖怪大贤者</b> - 身为贤者，八云紫能够超脱条理、制定框架。她不再遵循卡牌游戏方式。
		/// 战斗开始时，八云紫的牌组将不会加入到牌库中，而是全部转化为动作。重复的卡牌将会提升动作的等级。
		/// 回合开始时，八云紫会获得1个迅捷动作、1个移动动作、1个标准动作。此外，移动动作可以向下转化为迅捷动作、标准动作可以向下转化为移动动作。
		/// 此外，八云紫的固定技能为「执行动作」，可无限使用：点击后先选择迅捷、移动或标准，再选择具体动作并直接执行。整轮动作归入标准动作分类。执行移动动作和标准动作时，会推进一次倒计时。
		/// <b>操纵境界程度的能力</b> - 八云紫拥有特殊能量池【境界力】，并且八云紫每提升1级，【境界力】的上限便提升10点。部分动作需要消耗【境界力】才能执行。
		/// 每个回合开始时、或是成功对敌人造成伤害时，获得1点【境界力】。战斗结束时，清空所有【境界力】。
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// </summary>
        public static string Character_YakumoYukari = "YakumoYukari";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 행동을 선택
		/// English:
		/// Select an action
		/// Japanese:
		/// 行動を選択
		/// Chinese:
		/// 选择动作
		/// Chinese-TW:
		/// 選擇動作
		/// </summary>
        public static string selectAction => ModManager.getModInfo("YakumoYukari").localizationInfo.SystemLocalizationUpdate("selectAction");
		/// <summary>
		/// Korean:
		/// 행동 유형을 선택
		/// English:
		/// Select an action type
		/// Japanese:
		/// 行動タイプを選択
		/// Chinese:
		/// 选择动作类型
		/// Chinese-TW:
		/// 選擇動作類型
		/// </summary>
        public static string selectActionType => ModManager.getModInfo("YakumoYukari").localizationInfo.SystemLocalizationUpdate("selectActionType");

    }
}