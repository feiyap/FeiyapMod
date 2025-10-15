using ChronoArkMod;
namespace Letty
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 雪花
		/// 受到的伤害降低为 1 。
		/// 触发后解除。
		/// </summary>
        public static string Buff_B_Letty_0 = "B_Letty_0";
		/// <summary>
		/// 冬夜
		/// 受到敌人攻击时，使攻击者获得 1 层“严寒”。
		/// </summary>
        public static string Buff_B_Letty_1 = "B_Letty_1";
		/// <summary>
		/// 暖阳
		/// </summary>
        public static string Buff_B_Letty_2 = "B_Letty_2";
		/// <summary>
		/// 雪灾
		/// </summary>
        public static string Buff_B_Letty_5 = "B_Letty_5";
		/// <summary>
		/// 寒潮
		/// 受到的减益效果延长 1 回合。
		/// </summary>
        public static string Buff_B_Letty_6 = "B_Letty_6";
		/// <summary>
		/// 新雪
		/// 受到伤害量降低 &a% (&user的防御力的100%)。
		/// </summary>
        public static string Buff_B_Letty_8 = "B_Letty_8";
		/// <summary>
		/// 保护罩
		/// </summary>
        public static string Buff_B_Letty_Barrier = "B_Letty_Barrier";
		/// <summary>
		/// 严寒
		/// 叠加至满层时，转变为“冻僵”。
		/// </summary>
        public static string Buff_B_Letty_P = "B_Letty_P";
		/// <summary>
		/// 冻僵
		/// 无法行动。
		/// 可被延长持续回合。
		/// </summary>
        public static string Buff_B_Letty_P_1 = "B_Letty_P_1";
		/// <summary>
		/// 凛冬
		/// “严寒”的层数上限降低为4。
		/// </summary>
        public static string Buff_B_Letty_Rare_2 = "B_Letty_Rare_2";
		/// <summary>
		/// 冬至
		/// 回合开始时，获得 &a 保护罩(&user最大体力值的25%)。
		/// </summary>
        public static string Buff_B_Letty_Rare_3 = "B_Letty_Rare_3";
		/// <summary>
		/// 蕾蒂
		/// Passive:
		/// 操纵寒冷程度的能力 - 敌人行动时，对其施加 1 层“严寒”：叠加至满层时，转变为“冻僵”。
		/// 冻僵：无法行动，持续 1 回合。可被延长持续回合。
		/// Crystallize Silver - 蕾蒂可在持有“无法行动”减益时使用技能。
		/// </summary>
        public static string Character_Letty = "Letty";
		/// <summary>
		/// 对无法行动的敌人造成的伤害提升40%。
		/// 攻击技能
		/// </summary>
        public static string SkillExtended_SE_Letty_C_0 = "SE_Letty_C_0";
		/// <summary>
		/// 使 1 个随机敌人冻僵 1 回合。
		/// 一次性技能
		/// </summary>
        public static string SkillExtended_SE_Letty_C_1 = "SE_Letty_C_1";
        public static string SkillEffect_SE_S_S_Letty_1 = "SE_S_S_Letty_1";
        public static string SkillEffect_SE_S_S_Letty_Rare_2 = "SE_S_S_Letty_Rare_2";
        public static string SkillEffect_SE_T_S_Letty_0 = "SE_T_S_Letty_0";
        public static string SkillEffect_SE_T_S_Letty_1 = "SE_T_S_Letty_1";
        public static string SkillEffect_SE_T_S_Letty_2 = "SE_T_S_Letty_2";
        public static string SkillEffect_SE_T_S_Letty_4 = "SE_T_S_Letty_4";
        public static string SkillEffect_SE_T_S_Letty_5 = "SE_T_S_Letty_5";
        public static string SkillEffect_SE_T_S_Letty_6 = "SE_T_S_Letty_6";
        public static string SkillEffect_SE_T_S_Letty_7 = "SE_T_S_Letty_7";
        public static string SkillEffect_SE_T_S_Letty_8 = "SE_T_S_Letty_8";
        public static string SkillEffect_SE_T_S_Letty_9 = "SE_T_S_Letty_9";
        public static string SkillEffect_SE_T_S_Letty_Rare_2 = "SE_T_S_Letty_Rare_2";
        public static string SkillEffect_SE_T_S_Letty_Rare_3 = "SE_T_S_Letty_Rare_3";
		/// <summary>
		/// 雪符「完美的冰晶片」
		/// </summary>
        public static string Skill_S_Letty_0 = "S_Letty_0";
		/// <summary>
		/// 寒符「冬雪的长夜」
		/// </summary>
        public static string Skill_S_Letty_1 = "S_Letty_1";
		/// <summary>
		/// 冬符「雪女的叹息」
		/// </summary>
        public static string Skill_S_Letty_2 = "S_Letty_2";
		/// <summary>
		/// 寒符「延长的冬日」
		/// 使所有目标的增益和减益的持续时间延长 1 回合。
		/// </summary>
        public static string Skill_S_Letty_3 = "S_Letty_3";
		/// <summary>
		/// 冬符「花之凋零」
		/// 若目标持有弱化减益，施加“冻僵”。
		/// 若目标持有干扰减益，则使自身获得“雪花”。
		/// </summary>
        public static string Skill_S_Letty_4 = "S_Letty_4";
		/// <summary>
		/// 白符「波状光」
		/// 若只有 1 个目标，重复释放 1 次。
		/// </summary>
        public static string Skill_S_Letty_5 = "S_Letty_5";
		/// <summary>
		/// 寒符「寒潮」
		/// </summary>
        public static string Skill_S_Letty_6 = "S_Letty_6";
		/// <summary>
		/// 冬符「北极的胜利者」
		/// 目标每有1%干扰抵抗率，这个技能增加1%伤害。
		/// </summary>
        public static string Skill_S_Letty_7 = "S_Letty_7";
		/// <summary>
		/// 雪符「新雪」
		/// </summary>
        public static string Skill_S_Letty_8 = "S_Letty_8";
		/// <summary>
		/// 寒符「寒冰刺骨」
		/// 只能指向“无法行动”的敌人。
		/// </summary>
        public static string Skill_S_Letty_9 = "S_Letty_9";
		/// <summary>
		/// 寒符「霜打蔬菜分外甜」
		/// 使目标技能无法使用。
		/// 抽取 2 个技能，恢复 2 点法力值。
		/// </summary>
        public static string Skill_S_Letty_LucyD = "S_Letty_LucyD";
		/// <summary>
		/// 狂冬「暴风雪山庄」
		/// 将总计 4 个回合的“冻僵”效果平均分配给所有敌人。
		/// </summary>
        public static string Skill_S_Letty_Rare_1 = "S_Letty_Rare_1";
		/// <summary>
		/// 「凛冬将至」
		/// </summary>
        public static string Skill_S_Letty_Rare_2 = "S_Letty_Rare_2";
		/// <summary>
		/// 冬彻「银装素裹的世界」
		/// </summary>
        public static string Skill_S_Letty_Rare_3 = "S_Letty_Rare_3";

    }

    public static class ModLocalization
    {

    }
}