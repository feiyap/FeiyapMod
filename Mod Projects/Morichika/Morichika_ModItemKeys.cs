using ChronoArkMod;
namespace Morichika
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 发现弱点
		/// </summary>
        public static string Buff_B_Morichika_0 = "B_Morichika_0";
		/// <summary>
		/// 受骗
		/// 攻击改为指向随机其他怪物。
		/// 触发后解除。
		/// </summary>
        public static string Buff_B_Morichika_4 = "B_Morichika_4";
		/// <summary>
		/// 财源滚滚
		/// 场上每有 1 个持有“保修服务”的友军，这个增益额外提供“最大体力值+25%”。
		/// </summary>
        public static string Buff_B_Morichika_6 = "B_Morichika_6";
		/// <summary>
		/// 保修服务
		/// 攻击力、防御力、治疗力提升 &a% (&user最大体力值的25%)。
		/// </summary>
        public static string Buff_B_Morichika_P = "B_Morichika_P";
		/// <summary>
		/// 常客
		/// 每次从&user处获得“保修服务”增益时，都会额外获得 1 个随机增益效果（不会出现持续时间为∞的增益）。
		/// </summary>
        public static string Buff_B_Morichika_Rare_2 = "B_Morichika_Rare_2";
		/// <summary>
		/// 森近霖之助
		/// Passive:
		/// <b>知足不辱的旧货店</b> - 每当使用卷轴时，自身最大体力值 + 1。
		/// <b>判别物品名字和用途程度的能力</b> - 所有卷轴不再需要鉴定。每个区域开始时，获得 1 个“地图制作卷轴”、1 个“鉴定卷轴”、1 个“点金术卷轴”和 1 个“诅咒解除卷轴”。
		/// </summary>
        public static string Character_Morichika = "Morichika";
		/// <summary>
		/// 费用提升 1 点、造成的伤害量/治疗量提升80%。
		/// </summary>
        public static string SkillExtended_SE_Morichika_2 = "SE_Morichika_2";
        public static string SkillEffect_SE_S_S_Morichika_4 = "SE_S_S_Morichika_4";
        public static string SkillEffect_SE_S_S_Morichika_6 = "SE_S_S_Morichika_6";
        public static string SkillEffect_SE_T_S_Morichika_0 = "SE_T_S_Morichika_0";
        public static string SkillEffect_SE_T_S_Morichika_1 = "SE_T_S_Morichika_1";
        public static string SkillEffect_SE_T_S_Morichika_2 = "SE_T_S_Morichika_2";
        public static string SkillEffect_SE_T_S_Morichika_3 = "SE_T_S_Morichika_3";
        public static string SkillEffect_SE_T_S_Morichika_4 = "SE_T_S_Morichika_4";
        public static string SkillEffect_SE_T_S_Morichika_8 = "SE_T_S_Morichika_8";
        public static string SkillEffect_SE_T_S_Morichika_Rare_2 = "SE_T_S_Morichika_Rare_2";
		/// <summary>
		/// 鉴识眼
		/// </summary>
        public static string Skill_S_Morichika_0 = "S_Morichika_0";
		/// <summary>
		/// 奇货可居
		/// 战斗开始时，放在牌库最上方。
		/// 展示牌库中的所有技能。选择并抽取其中 1 个。
		/// 使目标技能的持有者获得“保修服务”。
		/// </summary>
        public static string Skill_S_Morichika_1 = "S_Morichika_1";
		/// <summary>
		/// 溢价
		/// 使目标技能在本场战斗中费用提升 1 点、造成的伤害量/治疗量提升80%。
		/// 使目标技能的持有者获得“保修服务”。
		/// </summary>
        public static string Skill_S_Morichika_2 = "S_Morichika_2";
		/// <summary>
		/// 抵押
		/// 展示牌库中的所有技能。选择并放逐其中 1 个，并恢复 2 点法力值。
		/// 下个回合开始时，将那个技能拿回手中，但失去 1 点法力值。
		/// 使目标技能的持有者获得“保修服务”。
		/// </summary>
        public static string Skill_S_Morichika_3 = "S_Morichika_3";
		/// <summary>
		/// 快速谈判
		/// 只能指向体力值百分比低于自身（当前为：&a%）的敌人。
		/// </summary>
        public static string Skill_S_Morichika_4 = "S_Morichika_4";
		/// <summary>
		/// 售后服务
		/// 使所有友军的“保修服务”增益的持续时间延长 2 回合，并获得“保护体力极限”。
		/// 每有 1 个未持有“保修服务”增益的友军，恢复 1 点法力值。
		/// </summary>
        public static string Skill_S_Morichika_5 = "S_Morichika_5";
		/// <summary>
		/// 门庭若市
		/// </summary>
        public static string Skill_S_Morichika_6 = "S_Morichika_6";
		/// <summary>
		/// 开源节流
		/// 移除所有友军的“保修服务”增益。
		/// 每有 1 个“保修服务”被移除，超额治疗自身 &a (最大体力值的34%)，对所有敌人施加 1 层“发现弱点”，优先抽取 1 个自己的技能，恢复 1 点法力值。
		/// </summary>
        public static string Skill_S_Morichika_7 = "S_Morichika_7";
		/// <summary>
		/// 资产重组
		/// 展示所有弃牌库中持有者为目标的技能。
		/// 从牌库最上方将那个数量的技能送入弃牌库。
		/// 将展示的技能放回牌库随机位置。
		/// </summary>
        public static string Skill_S_Morichika_8 = "S_Morichika_8";
		/// <summary>
		/// 无中生有
		/// 在所选友军的所有技能中选择 1 个，在牌库中和手中各生成 1 个。
		/// </summary>
        public static string Skill_S_Morichika_9 = "S_Morichika_9";
		/// <summary>
		/// 运气真好
		/// 抽取 2 个技能。
		/// 若这是本场战斗第 1 次打出，获得 1 个随机卷轴；否则恢复 1 点法力值。
		/// </summary>
        public static string Skill_S_Morichika_LucyD = "S_Morichika_LucyD";
		/// <summary>
		/// 再利用
		/// 展示背包中的所有卷轴。选择并消耗其中 1 个卷轴（能够触发被动效果），并生成对应效果。
		/// （按Shift查看）
		/// </summary>
        public static string Skill_S_Morichika_Rare_1 = "S_Morichika_Rare_1";
		/// <summary>
		/// 赠品
		/// </summary>
        public static string Skill_S_Morichika_Rare_2 = "S_Morichika_Rare_2";
		/// <summary>
		/// 无理由退换
		/// 这个技能握在手中时，每次使用其他技能会使这个技能费用降低 1 点，同时此技能的 X 回合后弃牌的回合计数将减少 1 。
		/// 使用时，展示目标在本场战斗中使用过的所有非放逐技能。选择其中 4 个，在手中生成其复制，附带放逐。
		/// 若这个技能在费用为 0 时使用，还会使那些技能费用变为 0 。
		/// </summary>
        public static string Skill_S_Morichika_Rare_3 = "S_Morichika_Rare_3";
		/// <summary>
		/// 抵押
		/// 当前抵押的技能是：&skill
		/// </summary>
        public static string Buff_B_Morichika_3 = "B_Morichika_3";

    }

    public static class ModLocalization
    {

    }
}