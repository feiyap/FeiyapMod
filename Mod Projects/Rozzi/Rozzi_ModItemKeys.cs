using ChronoArkMod;
namespace Rozzi
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 洛兹
		/// Passive:
		/// 洛兹使用自己的专属技能后，下1个使用的非专属技能会释放2次，但每次只造成50%伤害。
		/// </summary>
        public static string Character_Rozzi = "Rozzi";
		/// <summary>
		/// 随意射击
		/// 抽取1个技能。
		/// </summary>
        public static string Skill_S_Rozzi_0 = "S_Rozzi_0";
        public static string SkillEffect_SE_T_S_Rozzi_0 = "SE_T_S_Rozzi_0";
        public static string SkillEffect_SE_S_S_Rozzi_0 = "SE_S_S_Rozzi_0";
		/// <summary>
		/// 漫游步伐
		/// </summary>
        public static string Buff_B_Rozzi_0 = "B_Rozzi_0";
		/// <summary>
		/// 全视角狙击
		/// 生成1个随机的通用攻击技能。
		/// </summary>
        public static string Skill_S_Rozzi_1 = "S_Rozzi_1";
        public static string SkillEffect_SE_T_S_Rozzi_1 = "SE_T_S_Rozzi_1";
		/// <summary>
		/// 中空弹
		/// 抽取1个技能。
		/// </summary>
        public static string Skill_S_Rozzi_2 = "S_Rozzi_2";
        public static string SkillEffect_SE_T_S_Rozzi_2 = "SE_T_S_Rozzi_2";
		/// <summary>
		/// 震晕
		/// </summary>
        public static string Buff_B_Rozzi_2 = "B_Rozzi_2";
		/// <summary>
		/// 换弹
		/// 丢弃手中所有自己的技能。
		/// 生成相同数量的通用攻击技能。
		/// 抽取2个技能。
		/// </summary>
        public static string Skill_S_Rozzi_3 = "S_Rozzi_3";
        public static string SkillEffect_SE_S_S_Rozzi_3 = "SE_S_S_Rozzi_3";
		/// <summary>
		/// 崭新出厂
		/// </summary>
        public static string Buff_B_Rozzi_3 = "B_Rozzi_3";
		/// <summary>
		/// 热诚烈弹
		/// </summary>
        public static string Skill_S_Rozzi_4 = "S_Rozzi_4";
        public static string SkillEffect_SE_T_S_Rozzi_4 = "SE_T_S_Rozzi_4";
		/// <summary>
		/// 银色回忆
		/// 受到伤害时，使&user获得“+5%攻击力”，持续1回合。
		/// </summary>
        public static string Buff_B_Rozzi_4 = "B_Rozzi_4";
		/// <summary>
		/// 冷酷追击
		/// 优先抽取1个自己的通用攻击技能。
		/// 回合开始时，如果该技能在弃牌库中，且上个回合至少使用3次通用技能，将这个技能拿回手中。
		/// </summary>
        public static string Skill_S_Rozzi_5 = "S_Rozzi_5";
		/// <summary>
		/// 钟鸣厄至
		/// 这场战斗中，每使用过1个通用技能，造成&a点额外伤害<color=#FF7A33>(攻击力的50%)</color>。
		/// </summary>
        public static string Skill_S_Rozzi_6 = "S_Rozzi_6";
        public static string SkillEffect_SE_T_S_Rozzi_6 = "SE_T_S_Rozzi_6";
		/// <summary>
		/// 恶意失真
		/// </summary>
        public static string Skill_S_Rozzi_7 = "S_Rozzi_7";
        public static string SkillEffect_SE_T_S_Rozzi_7 = "SE_T_S_Rozzi_7";
        public static string SkillEffect_SE_S_S_Rozzi_7 = "SE_S_S_Rozzi_7";
		/// <summary>
		/// 失真
		/// 场上每有1个[失真]减益再减少6%攻击力。
		/// </summary>
        public static string Buff_B_Rozzi_7 = "B_Rozzi_7";
		/// <summary>
		/// 恶意
		/// 场上每有1个[失真]减益使自己受到攻击的概率降低12%。
		/// </summary>
        public static string Buff_B_Rozzi_7_1 = "B_Rozzi_7_1";
		/// <summary>
		/// 高级会员卡
		/// 抽取2个技能。
		/// 使露西减少2层过载。
		/// </summary>
        public static string Skill_S_Rozzi_LucyD = "S_Rozzi_LucyD";
		/// <summary>
		/// 塞姆汀高爆弹MK-II
		/// </summary>
        public static string Skill_S_Rozzi_Rare_1 = "S_Rozzi_Rare_1";
        public static string SkillEffect_SE_T_S_Rozzi_Rare_1 = "SE_T_S_Rozzi_Rare_1";
		/// <summary>
		/// 子弹附着
		/// 回合结束时爆炸，解除该减益并造成&a点伤害<color=#FF7A33>(攻击力的100%)</color>。
		/// 受到5次伤害后立刻爆炸，解除该减益并额外造成&b点伤害<color=#FF7A33>(最大体力值的20%)</color>。
		/// 当前受到伤害次数：&c
		/// </summary>
        public static string Buff_B_Rozzi_Rare_1 = "B_Rozzi_Rare_1";
		/// <summary>
		/// 随意开火
		/// 使用这个技能击杀敌人时，获得1层[武器熟练度]。
		/// 击杀诅咒或BOSS级敌人时，额外获得4层[武器熟练度]。
		/// </summary>
        public static string Skill_S_Rozzi_Rare_2 = "S_Rozzi_Rare_2";
        public static string SkillEffect_SE_T_S_Rozzi_Rare_2 = "SE_T_S_Rozzi_Rare_2";
		/// <summary>
		/// 双枪洗礼
		/// 重复释放&a(3 + &b)次。
		/// 以倒计时1重复释放&a(3 + &b)次。
		/// 以倒计时2重复释放&a(3 + &b)次。
		/// 自身每有20%暴击率，重复释放的次数增加1次。
		/// 倒计时期间，释放“冷酷追击”会使重复释放的次数增加1次。
		/// </summary>
        public static string Skill_S_Rozzi_Rare_3 = "S_Rozzi_Rare_3";
        public static string SkillEffect_SE_T_S_Rozzi_Rare_3 = "SE_T_S_Rozzi_Rare_3";
		/// <summary>
		/// 双持
		/// 下1个使用的通用技能会释放2次，但每次只造成50%伤害。
		/// </summary>
        public static string Buff_B_Rozzi_P = "B_Rozzi_P";
		/// <summary>
		/// 警惕
		/// 下2次造成伤害时会额外造成20%痛苦伤害。
		/// </summary>
        public static string Buff_B_Rozzi_P_1 = "B_Rozzi_P_1";
		/// <summary>
		/// 武器熟练度
		/// 叠加到5层时解除该增益并获得1点永久攻击力。
		/// </summary>
        public static string Buff_B_Rozzi_Rare_2 = "B_Rozzi_Rare_2";

    }

    public static class ModLocalization
    {

    }
}