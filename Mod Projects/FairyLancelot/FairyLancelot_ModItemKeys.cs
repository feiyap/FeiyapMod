using ChronoArkMod;
namespace FairyLancelot
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 兰斯洛特
		/// Passive:
		/// 进入战斗回合开始时根据当前生命值变化状态。
		/// 每当体力值小于等于最大体力值50%时，获得“狂化”；
		/// 体力值大于最大体力值50%时，获得“理智”。
		/// 每回合开始时，从“骑士”和“邪龙”中选择1项作为自己的形态。
		/// 无法违背的誓约：进入战斗时，从5种“誓言”中选择1项。若在战斗中违背“誓言”，则好感度清0。若遵守“誓言”完成战斗，增加4点好感度。
		/// 到达100好感度时，解锁这个被动，不再需要“誓言”。
		/// <b>兰斯洛特的部分技能只有当等级和好感度达到条件时才能学习。</b>
		/// </summary>
        public static string Character_FairyLancelot = "FairyLancelot";
		/// <summary>
		/// 最后的妖精
		/// 骑士 - 获得 1 层“舞者”。抽取 1 个技能。依据“舞者”的层数：
		/// ①恢复 5 点体力值；
		/// ②使抽取到的技能费用降低 1 点；
		/// ③选择并生成 1 个自己的专属技能。
		/// 邪龙 - 获得 1 层“龙之心”。获得持续 1 回合的“攻击力+1”。依据“龙之心”的层数：
		/// ①额外获得持续 1 回合的“攻击力+1”；
		/// ②额外获得持续 1 回合的“防御穿透+10%”；
		/// ③选择并生成 1 个自己的专属技能。
		/// 好感度10 - 若自身为“理智”：本回合结束时恢复所有友方单位 5 点体力值；
		/// 若自身为“狂化”：本回合结束时生成 1 个“龙鳞”。
		/// </summary>
        public static string Skill_S_FLancelot_0 = "S_FLancelot_0";
		/// <summary>
		/// 好感度
		/// 每10点好感度提高0.5攻击力，每10点好感度提升2点最大体力。
		/// 部分技能根据好感度获得不同强化。
		/// </summary>
        public static string Buff_B_FLancelot_P = "B_FLancelot_P";
		/// <summary>
		/// 狂化
		/// 当前体力值小于等于最大体力值的50%。
		/// </summary>
        public static string Buff_B_FLancelot_P_1 = "B_FLancelot_P_1";
		/// <summary>
		/// 理性
		/// 当前体力值大于最大体力值的50%。
		/// </summary>
        public static string Buff_B_FLancelot_P_2 = "B_FLancelot_P_2";
		/// <summary>
		/// 邪龙
		/// 特殊形态。
		/// 每次使用自身技能时，获得 1 层“龙之心”。
		/// </summary>
        public static string Buff_B_FLancelot_C_1 = "B_FLancelot_C_1";
		/// <summary>
		/// 骑士
		/// 特殊形态。
		/// 每次使用自身技能时，获得 1 层“舞者”。
		/// </summary>
        public static string Buff_B_FLancelot_C_2 = "B_FLancelot_C_2";
		/// <summary>
		/// 龙之心
		/// 持有“舞者”时无法获得。
		/// </summary>
        public static string Buff_B_FLancelot_P_3 = "B_FLancelot_P_3";
		/// <summary>
		/// 舞者
		/// 每层会使自身技能追加攻击 1 次（不触发特殊效果）。持有“龙之心”时无法获得。
		/// </summary>
        public static string Buff_B_FLancelot_P_4 = "B_FLancelot_P_4";
        public static string SkillEffect_SE_T_S_FLancelot_0 = "SE_T_S_FLancelot_0";
		/// <summary>
		/// 妖精剑舞
		/// 骑士 - 获得 1 层“舞者”。
		/// 邪龙 - 获得 1 层“龙之心”。额外造成 &a 伤害(攻击力的70%)。
		/// 好感度30 - 获得“下 1 次使用技能时恢复 1 点法力值”。
		/// </summary>
        public static string Skill_S_FLancelot_1 = "S_FLancelot_1";
        public static string SkillEffect_SE_T_S_FLancelot_1 = "SE_T_S_FLancelot_1";
		/// <summary>
		/// 你已深陷于我
		/// <color=#FF69B4><i>*兰斯洛特等级大于等于3且好感度达到30才可学习*</i></color>
		/// </summary>
        public static string Skill_S_FLancelot_2 = "S_FLancelot_2";
        public static string SkillEffect_SE_T_S_FLancelot_2 = "SE_T_S_FLancelot_2";
		/// <summary>
		/// 你已深陷于我
		/// 只能指定&user为目标。
		/// 受到&user以外的伤害减少50%；受到来自&user的伤害提高50%。
		/// 若被&user击杀，获得100金币，好感度+2。
		/// </summary>
        public static string Buff_B_FLancelot_2 = "B_FLancelot_2";

    }

    public static class ModLocalization
    {

    }
}