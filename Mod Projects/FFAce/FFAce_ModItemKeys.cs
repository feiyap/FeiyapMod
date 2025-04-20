using ChronoArkMod;
namespace FFAce
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 赤红之炎
		/// 每层使[红焰轮舞]的伤害增加&a(攻击力的20%)。
		/// 叠加至3层时，生成1张[赤红之炎]（触发时解除）。
		/// </summary>
        public static string Buff_B_FFAce_0 = "B_FFAce_0";
		/// <summary>
		/// 深度灼伤
		/// </summary>
        public static string Buff_B_FFAce_0_Ex = "B_FFAce_0_Ex";
		/// <summary>
		/// 灼魂刻印
		/// 受到来自艾斯的物理伤害量+30%；
		/// 受到深度灼伤的伤害量+25%。
		/// </summary>
        public static string Buff_B_FFAce_1 = "B_FFAce_1";
		/// <summary>
		/// 朱雀之契
		/// 攻击单个敌人时，为目标施加1层[朱雀之怒]（追加攻击和反击不能触发）。
		/// </summary>
        public static string Buff_B_FFAce_2 = "B_FFAce_2";
		/// <summary>
		/// 朱雀之怒
		/// 叠加至3层时，&user攻击该目标后获得1层[赤红之炎]，并额外造成&a点伤害(&user攻击力的150%)，并施加100%成功率的1回合眩晕，然后解除该减益。
		/// </summary>
        public static string Buff_B_FFAce_2_1 = "B_FFAce_2_1";
		/// <summary>
		/// 零式预判
		/// 闪避一次攻击，触发后解除该增益。
		/// 使敌人最先释放的下个攻击技能只能攻击有零式预判的友军。
		/// </summary>
        public static string Buff_B_FFAce_3 = "B_FFAce_3";
		/// <summary>
		/// 计数器
		/// </summary>
        public static string Buff_B_FFAce_3_Count = "B_FFAce_3_Count";
		/// <summary>
		/// 属性提升
		/// </summary>
        public static string Buff_B_FFAce_4 = "B_FFAce_4";
		/// <summary>
		/// 攻击力提升
		/// </summary>
        public static string Buff_B_FFAce_4_1 = "B_FFAce_4_1";
		/// <summary>
		/// 计数器
		/// </summary>
        public static string Buff_B_FFAce_4_Count = "B_FFAce_4_Count";
		/// <summary>
		/// 苍蓝之冰
		/// 攻击单个敌人时，为目标施加1层[霜冻]。
		/// 当[苍蓝之冰]达到4层时，在手中生成1张[苍蓝之冰]并解除该增益。
		/// </summary>
        public static string Buff_B_FFAce_5 = "B_FFAce_5";
		/// <summary>
		/// 霜冻
		/// 达到4层后，再次受到物理攻击时使目标和目标两边的敌人受到&a点伤害(&user攻击力的120%)；
		/// 若只有一个敌人，则受到&b点伤害(&user攻击力的170%)。
		/// 触发后解除该减益。
		/// </summary>
        public static string Buff_B_FFAce_5_1 = "B_FFAce_5_1";
		/// <summary>
		/// 冰冻
		/// 无法行动。
		/// 当受到物理攻击时，受到&a点伤害(&user攻击力的170%)，并解除该减益。
		/// </summary>
        public static string Buff_B_FFAce_5_Ex = "B_FFAce_5_Ex";
		/// <summary>
		/// 冰晶共鸣
		/// 攻击单个敌人时，为目标施加1层[霜冻]（追加攻击和反击不能触发）。
		/// </summary>
        public static string Buff_B_FFAce_6 = "B_FFAce_6";
		/// <summary>
		/// 凛冬之契
		/// 每次受到伤害时将被施加1层[霜冻]（1个回合内最多触发2次）。
		/// </summary>
        public static string Buff_B_FFAce_7 = "B_FFAce_7";
		/// <summary>
		/// 翻牌强化
		/// 下次使用固定能力时可额外查看&a个技能，并触发相应的[翻开]效果。
		/// </summary>
        public static string Buff_B_FFAce_LucyD = "B_FFAce_LucyD";
		/// <summary>
		/// 燎原之契
		/// 受到来自&user的伤害的暴击率+25%，
		/// 受到来自&user的暴击伤害+35%。
		/// </summary>
        public static string Buff_B_FFAce_Rare_1 = "B_FFAce_Rare_1";
        public static string Buff_B_FFAce_Rare_1_0 = "B_FFAce_Rare_1_0";
		/// <summary>
		/// 朱雀刻印
		/// 每个回合首次使用固定能力时，额外翻开一张牌并获得相应的[翻开]效果。
		/// 每个回合开始时，额外获得1层[赤红之炎]。
		/// 生成的[红焰轮舞]和[赤红之炎]的费用减少1点。
		/// 使用[红焰轮舞]和[赤红之炎]时，额外造成&a点伤害(&user攻击力的100%)的追加攻击。
		/// </summary>
        public static string Buff_B_FFAce_Rare_2 = "B_FFAce_Rare_2";
		/// <summary>
		/// 固定能力费用减少
		/// 固定能力的费用减少1点。
		/// </summary>
        public static string Buff_B_FFAce_Rare_2_0 = "B_FFAce_Rare_2_0";
		/// <summary>
		/// 艾斯
		/// Passive:
		/// 固定能力变更为‘翻牌’：
		/// 从牌库和弃牌库中翻出随机1张自己的技能，根据牌上的[翻开]效果获得相应的增益，然后将此技能放回原位；若翻出的技能没有[翻开]效果，则将此技能置入手中。
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// </summary>
        public static string Character_FFAce = "FFAce";
		/// <summary>
		/// 翻开
		/// 因[翻牌]的效果被展示后会触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Draw = "Keyword_Draw";
        public static string SkillEffect_SE_S_S_FFAce_0 = "SE_S_S_FFAce_0";
        public static string SkillEffect_SE_S_S_FFAce_1 = "SE_S_S_FFAce_1";
        public static string SkillEffect_SE_S_S_FFAce_5 = "SE_S_S_FFAce_5";
        public static string SkillEffect_SE_Tick_B_FFAce_0_Ex = "SE_Tick_B_FFAce_0_Ex";
        public static string SkillEffect_SE_T_S_FFAce_0 = "SE_T_S_FFAce_0";
        public static string SkillEffect_SE_T_S_FFAce_0_Ex = "SE_T_S_FFAce_0_Ex";
        public static string SkillEffect_SE_T_S_FFAce_1 = "SE_T_S_FFAce_1";
        public static string SkillEffect_SE_T_S_FFAce_2 = "SE_T_S_FFAce_2";
        public static string SkillEffect_SE_T_S_FFAce_3 = "SE_T_S_FFAce_3";
        public static string SkillEffect_SE_T_S_FFAce_5 = "SE_T_S_FFAce_5";
        public static string SkillEffect_SE_T_S_FFAce_5_Ex = "SE_T_S_FFAce_5_Ex";
        public static string SkillEffect_SE_T_S_FFAce_6 = "SE_T_S_FFAce_6";
        public static string SkillEffect_SE_T_S_FFAce_7 = "SE_T_S_FFAce_7";
        public static string SkillEffect_SE_T_S_FFAce_Rare_1 = "SE_T_S_FFAce_Rare_1";
        public static string SkillEffect_SE_T_S_FFAce_Rare_2 = "SE_T_S_FFAce_Rare_2";
        public static string SkillEffect_SE_T_S_FFAce_Rare_2_0 = "SE_T_S_FFAce_Rare_2_0";
		/// <summary>
		/// 艾斯基类
		/// </summary>
        public static string SkillExtended_SkillBase_Ace = "SkillBase_Ace";
		/// <summary>
		/// 红焰轮舞
		/// 翻开：不将本技能将放回原位，而是置入手中，并获得1层[赤红之炎]。
		/// </summary>
        public static string Skill_S_FFAce_0 = "S_FFAce_0";
		/// <summary>
		/// 赤红之炎
		/// </summary>
        public static string Skill_S_FFAce_0_Ex = "S_FFAce_0_Ex";
		/// <summary>
		/// 灼魂刻印
		/// 使用后，在手中生成1张[红焰轮舞]。
		/// 翻开：不将本技能将放回原位，而是置入手中。可再次使用固定能力。
		/// </summary>
        public static string Skill_S_FFAce_1 = "S_FFAce_1";
		/// <summary>
		/// 朱雀之契
		/// 翻开：获得持续2回合的“攻击力上升15%”增益，并可再次使用固定能力。下次使用固定能力时可额外查看1个技能，并触发相应的[翻开]效果。
		/// </summary>
        public static string Skill_S_FFAce_2 = "S_FFAce_2";
		/// <summary>
		/// 零式预判
		/// 抽到这张牌时，使用这张牌的[翻开]效果。
		/// 翻开：从弃牌库中选择1张调查员的普通技能置入手中并减少1费。1个回合中最多触发2次该效果。
		/// </summary>
        public static string Skill_S_FFAce_3 = "S_FFAce_3";
		/// <summary>
		/// 命运轮抽
		/// 从手中选择丢弃2个技能，然后抽取2个技能：
		/// 若抽到的牌中有攻击牌，则使随机队友获得持续2回合的“攻击力和治疗力+15%”；
		/// 若丢弃的技能中有艾斯的牌，则额外使艾斯获得持续2回合的“攻击力+15%”。
		/// 翻开：展示弃牌库和牌库中所有的自己的普通技能，选择1个技能拿到手中并获得相应的[翻开]效果，1个回合中最多触发1次该效果。
		/// </summary>
        public static string Skill_S_FFAce_4 = "S_FFAce_4";
		/// <summary>
		/// 霜月轮转
		/// 翻开：不再将本技能放回原位置，而是置入手中，并获得1层[苍蓝之冰]。
		/// 可以选择丢弃手中的1个技能并抽取1个技能。
		/// </summary>
        public static string Skill_S_FFAce_5 = "S_FFAce_5";
		/// <summary>
		/// 苍蓝之冰
		/// </summary>
        public static string Skill_S_FFAce_5_Ex = "S_FFAce_5_Ex";
		/// <summary>
		/// 冰晶共鸣
		/// 此技能被丢弃时，拿回手中并使艾斯获得1层[苍蓝之冰]。
		/// 翻开：获得1层[苍蓝之冰]，可再次使用固定能力。
		/// </summary>
        public static string Skill_S_FFAce_6 = "S_FFAce_6";
		/// <summary>
		/// 凛冬之契
		/// 此技能被丢弃时，在手中生成一张[霜月轮转]。
		/// 翻开：选择牌库和手牌中的1张专属技能丢弃，并抽取1个技能。
		/// </summary>
        public static string Skill_S_FFAce_7 = "S_FFAce_7";
		/// <summary>
		/// 共鸣
		/// 抽取2个技能。
		/// 若艾斯的固定能力可使用，恢复1点费用；
		/// 若艾斯的固定能力不可使用，则使艾斯可再次使用固定能力。
		/// 艾斯的下次[翻牌]可额外翻开一张牌并选择1个[翻开]效果使用。
		/// </summary>
        public static string Skill_S_FFAce_LucyD = "S_FFAce_LucyD";
		/// <summary>
		/// 翻牌
		/// 从牌库和弃牌库中翻出随机1张自己的技能。
		/// 根据牌上的[翻开]效果获得相应的效果，然后将该技能放回原位。
		/// 若翻出的技能没有[翻开]效果，则将此技能置入手中。
		/// </summary>
        public static string Skill_S_FFAce_P = "S_FFAce_P";
		/// <summary>
		/// 朱雀百式
		/// 抽到这张牌时，使用这张牌的[翻开]效果。
		/// 使用这张牌后，可以选择手中和牌库中最多3张自己的专属技能丢弃，并获得所有相应的[翻开]效果。
		/// 翻开：对所有敌人施加[燎原之契]，并从牌库和弃牌库中选择1张自己的技能复制，复制的技能带有放逐词条。
		/// </summary>
        public static string Skill_S_FFAce_Rare_1 = "S_FFAce_Rare_1";
		/// <summary>
		/// 朱雀刻印
		/// 在艾斯的所有技能中选择一个生成并获得相应的[抽取]效果。
		/// 可再次使用固定能力。
		/// 翻开：不将本技能将放回原位，而是置入手中。
		/// </summary>
        public static string Skill_S_FFAce_Rare_2 = "S_FFAce_Rare_2";
        public static string Skill_S_FFAce_Rare_2_0 = "S_FFAce_Rare_2_0";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 请选择要触发的[翻开]效果
		/// Chinese-TW:
		/// </summary>
        public static string drawInfo => ModManager.getModInfo("FFAce").localizationInfo.SystemLocalizationUpdate("drawInfo");

    }
}