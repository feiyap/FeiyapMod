using ChronoArkMod;
namespace Squall
{
    public static class ModItemKeys
    {
        public static string Buff_B_Sqaull_6 = "B_Sqaull_6";
		/// <summary>
		/// 发怒
		/// </summary>
        public static string Buff_B_Sqaull_WeakTaunt = "B_Sqaull_WeakTaunt";
		/// <summary>
		/// 枪刃格挡
		/// 每当敌方释放指向单个友军的技能时，由&user承受攻击。
		/// 承受攻击后该增益减少一层。
		/// </summary>
        public static string Buff_B_Squall_0 = "B_Squall_0";
		/// <summary>
		/// 狮子奋起
		/// 回合开始时，额外获得一层[刃甲]。
		/// </summary>
        public static string Buff_B_Squall_1 = "B_Squall_1";
		/// <summary>
		/// 元素分割
		/// </summary>
        public static string Buff_B_Squall_3 = "B_Squall_3";
		/// <summary>
		/// 逆命者
		/// 自身生命值不会降到1以下。
		/// </summary>
        public static string Buff_B_Squall_7 = "B_Squall_7";
		/// <summary>
		/// 攻击力降低
		/// </summary>
        public static string Buff_B_Squall_LucyD = "B_Squall_LucyD";
		/// <summary>
		/// 刃甲
		/// </summary>
        public static string Buff_B_Squall_P = "B_Squall_P";
		/// <summary>
		/// SeeD的精锐
		/// 每当有指向友军的攻击技能时，&user承受全部伤害。
		/// 如果指向友军的目标有多个，&user替其承受，受到1/2的伤害。
		/// 斯考尔替友军承受伤害时不再获得刃甲。
		/// </summary>
        public static string Buff_B_Squall_Rare_1 = "B_Squall_Rare_1";
        public static string Buff_B_Squall_Rare_1_0 = "B_Squall_Rare_1_0";
		/// <summary>
		/// 狮子之心
		/// [刃甲]的最高层数增加到15。
		/// 每获得一层[刃甲]，增加2%攻击力。
		/// 追加攻击和反击的伤害增加&a点(攻击力的20%)。
		/// </summary>
        public static string Buff_B_Squall_Rare_2 = "B_Squall_Rare_2";
		/// <summary>
		/// 挑衅
		/// 无法攻击&target以外的目标。
		/// 攻击&target后，&target以4段&a伤害进行反击(攻击力的25%)。
		/// 攻击后解除。
		/// </summary>
        public static string Buff_B_Squall_Taunt = "B_Squall_Taunt";
        public static string SkillEffect_SE_S_S_Squall_3 = "SE_S_S_Squall_3";
        public static string SkillEffect_SE_T_S_Squall_0 = "SE_T_S_Squall_0";
        public static string SkillEffect_SE_T_S_Squall_1 = "SE_T_S_Squall_1";
        public static string SkillEffect_SE_T_S_Squall_2 = "SE_T_S_Squall_2";
        public static string SkillEffect_SE_T_S_Squall_2_0 = "SE_T_S_Squall_2_0";
        public static string SkillEffect_SE_T_S_Squall_3 = "SE_T_S_Squall_3";
        public static string SkillEffect_SE_T_S_Squall_4 = "SE_T_S_Squall_4";
        public static string SkillEffect_SE_T_S_Squall_4_0 = "SE_T_S_Squall_4_0";
        public static string SkillEffect_SE_T_S_Squall_6 = "SE_T_S_Squall_6";
        public static string SkillEffect_SE_T_S_Squall_6_1 = "SE_T_S_Squall_6_1";
        public static string SkillEffect_SE_T_S_Squall_6_2 = "SE_T_S_Squall_6_2";
        public static string SkillEffect_SE_T_S_Squall_7 = "SE_T_S_Squall_7";
        public static string SkillEffect_SE_T_S_Squall_LucyD = "SE_T_S_Squall_LucyD";
        public static string SkillEffect_SE_T_S_Squall_P = "SE_T_S_Squall_P";
        public static string SkillEffect_SE_T_S_Squall_Rare_1 = "SE_T_S_Squall_Rare_1";
        public static string SkillEffect_SE_T_S_Squall_Rare_2 = "SE_T_S_Squall_Rare_2";
        public static string SkillEffect_SE_T_S_Squall_Rare_3 = "SE_T_S_Squall_Rare_3";
        public static string SkillEffect_SE_T_S_Squall_Rare_3_0 = "SE_T_S_Squall_Rare_3_0";
		/// <summary>
		/// 斯考尔
		/// Passive:
		/// 回合开始时获得一层[刃甲]。每当斯考尔替队友承受攻击时，获得一层[刃甲]。
		/// 在一个回合内累计承受超过最大生命值25%的物理伤害后，对随机敌人进行4段30%攻击力的反击。
		/// <b>斯考尔从装备中获取的防御力加成转化为等量的百分比最大体力值加成。</b>
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// </summary>
        public static string Character_Squall = "Squall";
		/// <summary>
		/// 枪刃格挡
		/// </summary>
        public static string Skill_S_Squall_0 = "S_Squall_0";
		/// <summary>
		/// 狮子奋起
		/// 可以在<b>无法行动</b>的状态下使用。
		/// 解除自身的<sprite=2>干扰减益。
		/// 使<sprite=1>痛苦减益和<sprite=0>弱化减益的持续时间减少1回合。
		/// 给所有敌人赋予“挑衅”。
		/// </summary>
        public static string Skill_S_Squall_1 = "S_Squall_1";
		/// <summary>
		/// 连续剑•狮子奋迅
		/// 若[刃甲]超过2层，则消耗2层[刃甲]，进行2次追加攻击。
		/// 若[刃甲]超过3层，则额外消耗1层[刃甲]，使追加攻击以暴击形式命中。
		/// </summary>
        public static string Skill_S_Squall_2 = "S_Squall_2";
		/// <summary>
		/// 连续剑•狮子奋迅
		/// </summary>
        public static string Skill_S_Squall_2_0 = "S_Squall_2_0";
		/// <summary>
		/// 元素分割
		/// </summary>
        public static string Skill_S_Squall_3 = "S_Squall_3";
		/// <summary>
		/// 残月轨迹
		/// 消耗最多6层[刃甲]。
		/// 每消耗1层[刃甲]使伤害增加4%，并重复释放1次。
		/// </summary>
        public static string Skill_S_Squall_4 = "S_Squall_4";
		/// <summary>
		/// 残月轨迹
		/// </summary>
        public static string Skill_S_Squall_4_0 = "S_Squall_4_0";
		/// <summary>
		/// G.F.
		/// 丢弃目标技能，获得那个技能费用+1的[刃甲]层数。
		/// 那之后，优先抽取1个自己的技能。
		/// </summary>
        public static string Skill_S_Squall_5 = "S_Squall_5";
		/// <summary>
		/// 静寂裁决
		/// 消耗1层[刃甲]，使目标最先释放的攻击技能立即释放。
		/// 斯考尔替友军承受此技能的总伤害量。
		/// </summary>
        public static string Skill_S_Squall_6 = "S_Squall_6";
		/// <summary>
		/// 静寂裁决
		/// 使1个敌人将会最先释放的攻击技能立即释放，斯考尔替友军承受此技能的总伤害量。
		/// </summary>
        public static string Skill_S_Squall_6_1 = "S_Squall_6_1";
		/// <summary>
		/// 静寂裁决
		/// 使1个敌人本回合中将会最先释放的1个攻击技能延后1回合。
		/// </summary>
        public static string Skill_S_Squall_6_2 = "S_Squall_6_2";
		/// <summary>
		/// 逆命者
		/// </summary>
        public static string Skill_S_Squall_7 = "S_Squall_7";
		/// <summary>
		/// 抽取
		/// 抽取3个技能。
		/// </summary>
        public static string Skill_S_Squall_LucyD = "S_Squall_LucyD";
        public static string Skill_S_Squall_P = "S_Squall_P";
		/// <summary>
		/// SeeD的精锐
		/// </summary>
        public static string Skill_S_Squall_Rare_1 = "S_Squall_Rare_1";
		/// <summary>
		/// 狮子之心
		/// </summary>
        public static string Skill_S_Squall_Rare_2 = "S_Squall_Rare_2";
		/// <summary>
		/// 爆裂禁区
		/// 必定命中。
		/// 额外造成&a的伤害(防御力的50%)。
		/// 重复释放17次。
		/// </summary>
        public static string Skill_S_Squall_Rare_3 = "S_Squall_Rare_3";
		/// <summary>
		/// 爆裂禁区
		/// </summary>
        public static string Skill_S_Squall_Rare_3_0 = "S_Squall_Rare_3_0";
		/// <summary>
		/// 斯考尔拥有[刃甲]时，造成的伤害提升30%。
		/// 攻击技能
		/// </summary>
        public static string SkillExtended_SE_Squall_C_0 = "SE_Squall_C_0";

    }

    public static class ModLocalization
    {

    }
}