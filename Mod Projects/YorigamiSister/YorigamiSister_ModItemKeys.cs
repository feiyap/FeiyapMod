using ChronoArkMod;
namespace YorigamiSister
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 拜金主义
		/// 攻击力随着“自己身上所有装备品质之和”提升（每点品质提升10%）。
		/// 造成伤害后移除 1 层。
		/// </summary>
        public static string Buff_B_Joon_4 = "B_Joon_4";
		/// <summary>
		/// 豪掷千金
		/// 每消耗100金币，使自身永久提升1%暴击率和0.5%暴击伤害。
		/// </summary>
        public static string Buff_B_Joon_P = "B_Joon_P";
        public static string SkillEffect_SE_T_S_Joon_1 = "SE_T_S_Joon_1";
        public static string SkillEffect_SE_T_S_Joon_4 = "SE_T_S_Joon_4";
        public static string SkillEffect_SE_T_S_Joon_5 = "SE_T_S_Joon_5";
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
		/// 名流燃烧
		/// 如果自身装备栏已满，则额外获得 2 层“拜金主义”。
		/// 否则会根据自身装备的平均品质，展示 3 件随机装备。那之后，可以消耗 200 金币选择并装备其中 1 件装备，直到战斗结束。
		/// </summary>
        public static string Skill_S_Joon_4 = "S_Joon_4";
		/// <summary>
		/// 朱莉安娜羽扇回旋镖
		/// 倒计时期间，自身对这个技能指向的目标始终暴击。
		/// 这个技能暴击时，以倒计时2重复释放 1 次，不会再次重复释放。
		/// </summary>
        public static string Skill_S_Joon_5 = "S_Joon_5";
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
		/// 黄金龙卷风
		/// 若只有 1 个目标，以暴击形式命中。
		/// 这个技能暴击时，消耗 &a 金币(攻击力的135%)。
		/// </summary>
        public static string Skill_S_Joon_2 = "S_Joon_2";
        public static string SkillEffect_SE_T_S_Joon_2 = "SE_T_S_Joon_2";
		/// <summary>
		/// 香奈儿的手包
		/// 随机生成 3 个自己的专属技能，使它们附带放逐。
		/// 这个技能暴击时，还会额外使生成的技能费用降低为 0。
		/// </summary>
        public static string Skill_S_Joon_3 = "S_Joon_3";
        public static string SkillEffect_SE_T_S_Joon_3 = "SE_T_S_Joon_3";
		/// <summary>
		/// 珠光指虎
		/// 这个技能暴击时，如果金币不低于 50，则消耗 50 金币，追加一次 &a 伤害的攻击(攻击力的100%)。
		/// </summary>
        public static string Skill_S_Joon_6 = "S_Joon_6";
        public static string SkillEffect_SE_T_S_Joon_6 = "SE_T_S_Joon_6";
		/// <summary>
		/// 90%off！
		/// </summary>
        public static string Skill_S_Joon_7 = "S_Joon_7";
        public static string SkillEffect_SE_T_S_Joon_7 = "SE_T_S_Joon_7";
		/// <summary>
		/// 夏季促销
		/// 在战斗中消耗金币时，每次消耗金币移除 1 层“夏季促销”，然后获得 50 金币，并获得 1 层“拜金主义”。
		/// 战斗结束时，剩余的“夏季促销”转化为金币（每层 25 金币）。
		/// </summary>
        public static string Buff_B_Joon_7 = "B_Joon_7";
		/// <summary>
		/// 即将破裂的泡沫
		/// 至多消耗 &a 金币(攻击力的2000%)，获得 &b 保护罩(消耗金币的10%)，持续 2 回合。
		/// 保护罩解除时，对所有敌人造成 &c 伤害（消耗金币的5%）。依据命中敌人的个数，获得相同层数的“拜金主义”。
		/// </summary>
        public static string Skill_S_Joon_8 = "S_Joon_8";
        public static string SkillEffect_SE_T_S_Joon_8 = "SE_T_S_Joon_8";
		/// <summary>
		/// 即将破裂的泡沫
		/// 保护罩解除时，对所有敌人造成 &c 伤害（消耗金币的5%）。依据命中敌人的个数，使&user获得相同层数的“拜金主义”。
		/// </summary>
        public static string Buff_B_Joon_8 = "B_Joon_8";
		/// <summary>
		/// 「80年代的勒索者」
		/// 这个技能暴击时，造成伤害的100%转化为金币。
		/// 这个技能击杀敌人时，造成伤害的100%转化为金币。
		/// </summary>
        public static string Skill_S_Joon_Rare_1 = "S_Joon_Rare_1";
        public static string SkillEffect_SE_T_S_Joon_Rare_1 = "SE_T_S_Joon_Rare_1";
		/// <summary>
		/// 「Queen of Bubble」
		/// 本场战斗中，获得 1 个额外装备栏。
		/// 那之后，依据自身装备的平均品质，将随机装备填满自身装备栏，直到战斗结束。
		/// </summary>
        public static string Skill_S_Joon_Rare_2 = "S_Joon_Rare_2";
        public static string SkillEffect_SE_T_S_Joon_Rare_2 = "SE_T_S_Joon_Rare_2";
		/// <summary>
		/// 泡沫经济
		/// 每个回合开始时，消耗 100 金币，获得 2 层“拜金主义”。
		/// </summary>
        public static string Buff_B_Joon_Rare_2 = "B_Joon_Rare_2";
		/// <summary>
		/// 凭依剥夺「Slave Robber」
		/// </summary>
        public static string Skill_S_Joon_Rare_3 = "S_Joon_Rare_3";
        public static string SkillEffect_SE_T_S_Joon_Rare_3 = "SE_T_S_Joon_Rare_3";
        public static string SkillEffect_SE_S_S_Joon_Rare_3 = "SE_S_S_Joon_Rare_3";
		/// <summary>
		/// 凭依！疫病神
		/// 自身的属性提升&user对应的数值；
		/// 造成伤害时消耗等量的金币；
		/// 进入濒死状态时解除凭依。
		/// </summary>
        public static string Buff_B_Joon_Rare_3 = "B_Joon_Rare_3";
		/// <summary>
		/// 正在凭依
		/// <b>隐匿</b>
		/// 打出手中的技能时，或是金币低于100时解除凭依。
		/// </summary>
        public static string Buff_B_Joon_Rare_3_0 = "B_Joon_Rare_3_0";

    }

    public static class ModLocalization
    {

    }
}