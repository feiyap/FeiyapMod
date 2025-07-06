using ChronoArkMod;
namespace YorigamiSister
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 豪掷千金
		/// 每消耗100金币，使自身永久提升1%暴击率和0.5%暴击伤害。
		/// </summary>
        public static string Buff_B_Joon_P = "B_Joon_P";
        public static string SkillEffect_SE_T_S_Joon_1 = "SE_T_S_Joon_1";
		/// <summary>
		/// 疫病神的凭依
		/// 这个技能握在手中时，每次使用其他技能获得 25 金币，此技能的 X 回合后弃牌的回合计数将减少 1 。
		/// 这个技能的效果只在黑雾回合到来前有效。
		/// </summary>
        public static string Skill_S_Joon_0 = "S_Joon_0";
		/// <summary>
		/// 散财上钩拳
		/// 这个技能暴击时，从牌库、弃牌库中将1个“疫病神的凭依”拿到手中（若不存在，则生成1个附带放逐的“疫病神的凭依”）。
		/// </summary>
        public static string Skill_S_Joon_1 = "S_Joon_1";
		/// <summary>
		/// 依神女苑
		/// Passive:
		/// 使人消耗财产程度的能力 - 每消耗100金币，使自身永久提升1%暴击率和0.5%暴击伤害。
		/// 在篝火处可以消耗1200金币为依神女苑购买额外的装备栏。
		/// 今宵是飘逸的利己主义者 - 使用点金卷轴时，额外获得50%金币。
		/// </summary>
        public static string Character_YorigamiJoon = "YorigamiJoon";
		/// <summary>
		/// 依神紫苑
		/// Passive:
		/// </summary>
        public static string Character_YorigamiShion = "YorigamiShion";
		/// <summary>
		/// 名流燃烧
		/// 如果自身装备栏已满，则额外获得 2 层“拜金主义”。
		/// 否则会根据自身装备的平均品质，展示 3 件随机装备。那之后，可以消耗 200 金币选择并装备其中 1 件装备，直到战斗结束。
		/// </summary>
        public static string Skill_S_Joon_4 = "S_Joon_4";
        public static string SkillEffect_SE_T_S_Joon_4 = "SE_T_S_Joon_4";
		/// <summary>
		/// 拜金主义
		/// 攻击力随着“自己身上所有装备品质之和”提升（每点品质提升10%）。
		/// 造成伤害后移除 1 层。
		/// </summary>
        public static string Buff_B_Joon_4 = "B_Joon_4";
		/// <summary>
		/// 朱莉安娜羽扇回旋镖
		/// 倒计时期间，自身对这个技能指向的目标始终暴击。
		/// 这个技能暴击时，以倒计时2重复释放 1 次，不会再次重复释放。
		/// </summary>
        public static string Skill_S_Joon_5 = "S_Joon_5";
        public static string SkillEffect_SE_T_S_Joon_5 = "SE_T_S_Joon_5";

    }

    public static class ModLocalization
    {

    }
}