using ChronoArkMod;
namespace FAlice
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 爱丽丝
		/// Passive:
		/// 操控人偶程度的能力 - 爱丽丝的「人形」技能在使用后会以倒计时∞的形式加入倒计时栏中。这些技能不会因回合结束而释放。
		/// 场上最多只能存在“等同于爱丽丝等级”数量的「人形」技能。
		/// 布加勒斯特的人偶师 - 每个回合开始时，生成 1 个费用为 1 的“操符「操纵人形」”，附带放逐和 1 回合后弃牌。
		/// </summary>
        public static string Character_FAlice = "FAlice";
		/// <summary>
		/// 操符「操纵人形」
		/// 选择：
		/// - 使所有倒计时中的「人形」触发一次效果。
		/// - 额外消耗 1 点费用，使所有倒计时中的「人形」倍率提升&a (攻击力的25%)或&b(治疗力的40%)或&c(防御力的20%)。
		/// - 选择 1 个倒计时中的「人形」，将其置入弃牌库，并抽取 1 个技能、恢复 2 点法力值。
		/// - 在手中随机生成 1 个「人形」。
		/// </summary>
        public static string Skill_S_FAlice_0 = "S_FAlice_0";
		/// <summary>
		/// 诅咒「魔彩光的上海人形」
		/// 这个技能处于倒计时中时，为&user提供“+1攻击力”。
		/// 触发时，对随机敌人造成一次伤害。
		/// 每触发 3 次后，下 1 次触发改为对所有敌人造成伤害。
		/// </summary>
        public static string Skill_S_FAlice_1 = "S_FAlice_1";
        public static string SkillEffect_SE_T_S_FAlice_1 = "SE_T_S_FAlice_1";
		/// <summary>
		/// 苍符「博爱的奥尔良人形」
		/// 这个技能处于倒计时中时，为&user提供“+1治疗力”。
		/// 触发时，对体力值最低的、已受伤的友军治疗一次。
		/// 每触发 3 次后，下 1 次触发改为对所有友军造成治疗。
		/// </summary>
        public static string Skill_S_FAlice_2 = "S_FAlice_2";
        public static string SkillEffect_SE_T_S_FAlice_2 = "SE_T_S_FAlice_2";
		/// <summary>
		/// 白符「白垩的俄罗斯人偶」
		/// 这个技能处于倒计时中时，为&user提供“+4%防御力”。
		/// 触发时，获得 &a 防护墙(60%防御力)。
		/// 每触发 3 次后，下 1 次触发还会使所有友军获得“保护体力极限”，持续 2 回合。
		/// </summary>
        public static string Skill_S_FAlice_3 = "S_FAlice_3";
		/// <summary>
		/// 红符「红发的荷兰人形」
		/// 这个技能处于倒计时中时，为&user提供“-1速度”。
		/// 触发时，使所有友军获得“+25%暴击率、+25%暴击伤害”，持续 1 回合。
		/// 每触发 3 次后，下 1 次触发还会使所有友军获得“+1攻击力”。
		/// </summary>
        public static string Skill_S_FAlice_4 = "S_FAlice_4";
		/// <summary>
		/// 暗符「雾之伦敦人偶」
		/// 这个技能处于倒计时中时，为&user提供“+1速度”。
		/// 触发时，使所有友军获得“+25%闪避率、+25%减益抵抗率”，持续 1 回合。
		/// 每触发 3 次后，下 1 次触发还会使所有友军获得“下 1 个固定能力费用降低 1 点”。
		/// </summary>
        public static string Skill_S_FAlice_5 = "S_FAlice_5";
		/// <summary>
		/// 人偶「未来文乐」
		/// 选择：
		/// - 选择 1 个「人形」技能，立即触发 2 次。
		/// - 选择 1 个「人形」技能，立即强化触发 1 次。
		/// </summary>
        public static string Skill_S_FAlice_6 = "S_FAlice_6";
		/// <summary>
		/// 战符「小小军势」
		/// 选择：
		/// - 在手中随机生成 2 个不同的「人形」技能。
		/// - 在手中生成 1 个指定的「人形」技能。
		/// </summary>
        public static string Skill_S_FAlice_7 = "S_FAlice_7";
		/// <summary>
		/// 聚焦「绊线」
		/// 选择：
		/// - 选择 1 个「人形」技能，将其置入弃牌库。
		/// - 随机丢弃手中 2 个技能。
		/// </summary>
        public static string Skill_S_FAlice_8 = "S_FAlice_8";
		/// <summary>
		/// 战操「玩偶战争」
		/// </summary>
        public static string Skill_S_FAlice_Rare_1 = "S_FAlice_Rare_1";
		/// <summary>
		/// 虹彩的人形使
		/// 每个回合开始时，额外生成 1 个“操符「操纵人形」”。
		/// 移除「人形」技能数量上限。
		/// </summary>
        public static string Buff_B_FAlice_Rare_1 = "B_FAlice_Rare_1";
        public static string SkillEffect_SE_T_S_FAlice_Rare_1 = "SE_T_S_FAlice_Rare_1";
		/// <summary>
		/// 枪符「萌萌大千枪」
		/// 使所有「人形」技能立即触发 3 次、强化触发 1 次。
		/// 那之后，将所有倒计时中的「人形」技能置入弃牌库。
		/// </summary>
        public static string Skill_S_FAlice_Rare_2 = "S_FAlice_Rare_2";
		/// <summary>
		/// 终符「猎奇剧团座流星雨」
		/// 将所有倒计时中的「人形」技能置入弃牌库。
		/// 将 1 个“试验中「歌莉娅人形」”加入倒计时栏。
		/// </summary>
        public static string Skill_S_FAlice_Rare_3 = "S_FAlice_Rare_3";
		/// <summary>
		/// 试验中「歌莉娅人形」
		/// 这个技能处于倒计时中时，为&user提供“+5攻击力，+5治疗力，+10最大体力值，+25%暴击率，+25%闪避率，+40%无法战斗抵抗”。
		/// 这个技能处于倒计时中时，使其他「人形」技能的效果变为：恢复 1 点法力值并抽取 1 个技能。
		/// 触发时，对所有敌人造成一次伤害。
		/// 每触发 3 次后，下 1 次触发改为对所有敌人造成 &a 伤害(攻击力的450%)。然后将这个技能放逐。
		/// </summary>
        public static string Skill_S_FAlice_Rare_3_0 = "S_FAlice_Rare_3_0";
        public static string SkillEffect_SE_T_S_FAlice_Rare_3_0 = "SE_T_S_FAlice_Rare_3_0";

    }

    public static class ModLocalization
    {

    }
}