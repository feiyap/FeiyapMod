using ChronoArkMod;
namespace SatsukiRin
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 薰风
		/// 下1次造成或受到的治疗效果+50%。触发后移除该增益。
		/// </summary>
        public static string Buff_B_Satsuki_0 = "B_Satsuki_0";
		/// <summary>
		/// 焚风
		/// 下1次造成的伤害效果+50%。触发后移除该增益。
		/// </summary>
        public static string Buff_B_Satsuki_1 = "B_Satsuki_1";
		/// <summary>
		/// 幻想天生
		/// </summary>
        public static string Buff_B_Satsuki_11Rare = "B_Satsuki_11Rare";
		/// <summary>
		/// 风花艳月
		/// 持续时间内受到的所有伤害和治疗效果将在效果结束后结算，其中治疗效果加倍结算。
		/// 当前伤害值：%a
		/// 当前治疗量：%b
		/// </summary>
        public static string Buff_B_Satsuki_12Rare = "B_Satsuki_12Rare";
		/// <summary>
		/// 季风
		/// 下个回合开始时，优先抽取1个自己的攻击技能。触发后移除该增益。
		/// </summary>
        public static string Buff_B_Satsuki_2 = "B_Satsuki_2";
		/// <summary>
		/// 朔风
		/// 下个回合开始时，优先抽取1个自己的治疗技能。触发后移除该增益。
		/// </summary>
        public static string Buff_B_Satsuki_3 = "B_Satsuki_3";
        public static string Buff_B_Satsuki_4 = "B_Satsuki_4";
		/// <summary>
		/// 似锦繁花
		/// 受到的痛苦伤害变为0。
		/// </summary>
        public static string Buff_B_Satsuki_5 = "B_Satsuki_5";
		/// <summary>
		/// 盛夏流颪
		/// 造成的伤害变为0。生效1次后移除。
		/// </summary>
        public static string Buff_B_Satsuki_5_0 = "B_Satsuki_5_0";
		/// <summary>
		/// 流金叠翠
		/// </summary>
        public static string Buff_B_Satsuki_6 = "B_Satsuki_6";
		/// <summary>
		/// 丰年瑞雪
		/// </summary>
        public static string Buff_B_Satsuki_7 = "B_Satsuki_7";
		/// <summary>
		/// 凶年残雪
		/// </summary>
        public static string Buff_B_Satsuki_7_0 = "B_Satsuki_7_0";
		/// <summary>
		/// 幻光
		/// </summary>
        public static string Buff_B_Satsuki_P = "B_Satsuki_P";
		/// <summary>
		/// 幻灭
		/// 当使用者身上的[幻光]层数不小于X层时，使用技能时会消耗对应层数的[幻光]，触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Disillusion = "Keyword_Disillusion";
		/// <summary>
		/// 冴月麟
		/// Passive:
		/// 战斗开始时，冴月麟获得20/23/26/29/32/35层[幻光]。每层[幻光]会增加1点最大体力值。
		/// 每当体力低于0时，触发幻灭10 - 将体力恢复至体力上限。
		/// 幻灭X：当冴月麟身上的[幻光]层数不小于X层时，使用技能时会消耗对应层数的[幻光]，触发额外效果。
		/// </summary>
        public static string Character_SatsukiRin = "SatsukiRin";
		/// <summary>
		/// 薰风
		/// 下1次造成的治疗效果+50%。
		/// </summary>
        public static string SkillExtended_SE_Satsuki_0 = "SE_Satsuki_0";
		/// <summary>
		/// 焚风
		/// 下一个技能造成的伤害增加50%。
		/// </summary>
        public static string SkillExtended_SE_Satsuki_1 = "SE_Satsuki_1";
		/// <summary>
		/// 打出时，血量最低的友军受到冴月麟50%治疗量的恢复。
		/// 费用 >=  1
		/// </summary>
        public static string SkillExtended_SE_Satsuki_2 = "SE_Satsuki_2";
        public static string SkillEffect_SE_S_S_Satsuki_0 = "SE_S_S_Satsuki_0";
        public static string SkillEffect_SE_S_S_Satsuki_1 = "SE_S_S_Satsuki_1";
        public static string SkillEffect_SE_S_S_Satsuki_10Rare = "SE_S_S_Satsuki_10Rare";
        public static string SkillEffect_SE_S_S_Satsuki_2 = "SE_S_S_Satsuki_2";
        public static string SkillEffect_SE_S_S_Satsuki_3 = "SE_S_S_Satsuki_3";
        public static string SkillEffect_SE_S_S_Satsuki_9 = "SE_S_S_Satsuki_9";
        public static string SkillEffect_SE_Tick_B_Satsuki_6 = "SE_Tick_B_Satsuki_6";
        public static string SkillEffect_SE_Tick_B_Satsuki_7 = "SE_Tick_B_Satsuki_7";
        public static string SkillEffect_SE_Tick_B_Satsuki_7_0 = "SE_Tick_B_Satsuki_7_0";
        public static string SkillEffect_SE_T_S_Satsuki_0 = "SE_T_S_Satsuki_0";
        public static string SkillEffect_SE_T_S_Satsuki_1 = "SE_T_S_Satsuki_1";
        public static string SkillEffect_SE_T_S_Satsuki_10Rare = "SE_T_S_Satsuki_10Rare";
        public static string SkillEffect_SE_T_S_Satsuki_11Rare = "SE_T_S_Satsuki_11Rare";
        public static string SkillEffect_SE_T_S_Satsuki_12Rare = "SE_T_S_Satsuki_12Rare";
        public static string SkillEffect_SE_T_S_Satsuki_2 = "SE_T_S_Satsuki_2";
        public static string SkillEffect_SE_T_S_Satsuki_4 = "SE_T_S_Satsuki_4";
        public static string SkillEffect_SE_T_S_Satsuki_4_0 = "SE_T_S_Satsuki_4_0";
        public static string SkillEffect_SE_T_S_Satsuki_5 = "SE_T_S_Satsuki_5";
        public static string SkillEffect_SE_T_S_Satsuki_6 = "SE_T_S_Satsuki_6";
        public static string SkillEffect_SE_T_S_Satsuki_7 = "SE_T_S_Satsuki_7";
        public static string SkillEffect_SE_T_S_Satsuki_9 = "SE_T_S_Satsuki_9";
        public static string SkillEffect_SE_T_S_Satsuki_LucyD = "SE_T_S_Satsuki_LucyD";
		/// <summary>
		/// 风符「新生之风」
		/// </summary>
        public static string Skill_S_Satsuki_0 = "S_Satsuki_0";
		/// <summary>
		/// 风符「流风若火」
		/// </summary>
        public static string Skill_S_Satsuki_1 = "S_Satsuki_1";
		/// <summary>
		/// 终焉「满溢着光的摇篮中」
		/// 幻灭X - 超额恢复X点体力值；解除所有友军的不可战斗状态。X等于自身所有的[幻光]层数（当前为%a）。
		/// </summary>
        public static string Skill_S_Satsuki_10Rare = "S_Satsuki_10Rare";
		/// <summary>
		/// 「那无法成为幻想的某物」
		/// 幻灭X - 获得X点防护墙。X为自身一半的[幻光]层数（向下取整）（当前为%a）。
		/// </summary>
        public static string Skill_S_Satsuki_11Rare = "S_Satsuki_11Rare";
		/// <summary>
		/// 「False Promise」
		/// 解除所有减益状态。
		/// </summary>
        public static string Skill_S_Satsuki_12Rare = "S_Satsuki_12Rare";
		/// <summary>
		/// 流风「风到达的地方」
		/// </summary>
        public static string Skill_S_Satsuki_2 = "S_Satsuki_2";
		/// <summary>
		/// 凪息「等待风的日子」
		/// 自己身上有下述至少1种增益时才能使用。
		/// 将自己身上的[薰风]、[焚风]、[季风]、[似锦繁花]和[流金叠翠]转让给目标调查员。
		/// 每转让1种增益，自身获得3层[幻光]。
		/// </summary>
        public static string Skill_S_Satsuki_3 = "S_Satsuki_3";
		/// <summary>
		/// 春之花「漫天流樱」
		/// 随机驱散1个减益效果。对随机敌人造成%a(60%)伤害。
		/// 可以对敌人释放。对敌人释放时，造成%a(60%)伤害，驱散目标身上的[流金叠翠]，恢复随机队友%b(130%)点体力。
		/// </summary>
        public static string Skill_S_Satsuki_4 = "S_Satsuki_4";
		/// <summary>
		/// 春之花「漫天流樱」
		/// </summary>
        public static string Skill_S_Satsuki_4_0 = "S_Satsuki_4_0";
		/// <summary>
		/// 夏之花「流风中的向日葵色」
		/// 对队友释放时，施加[似锦繁花]。
		/// 可以对敌人释放。对敌人释放时，没有治疗效果，施加[盛夏流颪]。
		/// </summary>
        public static string Skill_S_Satsuki_5 = "S_Satsuki_5";
		/// <summary>
		/// 秋之花「白诘草」
		/// 基于治疗力，造成%a(110%)痛苦伤害。
		/// 可以对敌人释放。
		/// </summary>
        public static string Skill_S_Satsuki_6 = "S_Satsuki_6";
		/// <summary>
		/// 冬之花「Windflower」
		/// 对所有队友施加[丰年瑞雪]；
		/// 对所有敌人施加[凶年残雪]。
		/// </summary>
        public static string Skill_S_Satsuki_7 = "S_Satsuki_7";
		/// <summary>
		/// 终符「花鸟风月为彷徨之行」
		/// 幻灭15 - 随机复活1个阵亡的调查员，使他的体力恢复至15点。
		/// 如果没有调查员阵亡、或是[幻光]层数不足以触发幻灭，改为自身获得5层[幻光]，抽取1个技能，恢复1点法力值。
		/// </summary>
        public static string Skill_S_Satsuki_8 = "S_Satsuki_8";
		/// <summary>
		/// 夜风「夜与雨的祷告」
		/// </summary>
        public static string Skill_S_Satsuki_9 = "S_Satsuki_9";
		/// <summary>
		/// 「花天月地、光风霄月」
		/// 抽取2个技能。
		/// </summary>
        public static string Skill_S_Satsuki_LucyD = "S_Satsuki_LucyD";

    }

    public static class ModLocalization
    {

    }
}