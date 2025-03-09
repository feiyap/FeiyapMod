using ChronoArkMod;
namespace FFAce
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 赤红之炎
		/// 每层使[红焰轮舞]的伤害增加&a(攻击力的40%)。
		/// 叠加至3层时，生成1张[赤红之炎]（触发时解除）。
		/// </summary>
        public static string Buff_B_FFAce_0 = "B_FFAce_0";
		/// <summary>
		/// 艾斯
		/// Passive:
		/// <b>固定能力变更为‘翻牌’。</b>
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// </summary>
        public static string Character_FFAce = "FFAce";
		/// <summary>
		/// 翻开
		/// 因[翻牌]的效果被展示后会触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Draw = "Keyword_Draw";
        public static string SkillEffect_SE_S_S_FFAce_0 = "SE_S_S_FFAce_0";
        public static string SkillEffect_SE_T_S_FFAce_0 = "SE_T_S_FFAce_0";
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
		/// 翻牌
		/// 从牌库和弃牌库中翻出随机1张自己的技能。
		/// 根据牌上的[翻开]效果获得相应的效果，然后将牌放回原位。
		/// 若翻出的技能没有[翻开]效果，则将此技能置入手中。
		/// </summary>
        public static string Skill_S_FFAce_P = "S_FFAce_P";
		/// <summary>
		/// 赤红之炎
		/// </summary>
        public static string Skill_S_FFAce_0_Ex = "S_FFAce_0_Ex";
        public static string SkillEffect_SE_T_S_FFAce_0_Ex = "SE_T_S_FFAce_0_Ex";
		/// <summary>
		/// 深度灼伤
		/// </summary>
        public static string Buff_B_FFAce_0_Ex = "B_FFAce_0_Ex";
        public static string SkillEffect_SE_Tick_B_FFAce_0_Ex = "SE_Tick_B_FFAce_0_Ex";
		/// <summary>
		/// 灼魂刻印
		/// 使用后，在手中生成1张[红焰轮舞]。
		/// 翻开：不将本技能将放回原位，而是置入手中。可再次使用固定能力。
		/// </summary>
        public static string Skill_S_FFAce_1 = "S_FFAce_1";
        public static string SkillEffect_SE_T_S_FFAce_1 = "SE_T_S_FFAce_1";
        public static string SkillEffect_SE_S_S_FFAce_1 = "SE_S_S_FFAce_1";
		/// <summary>
		/// 灼魂刻印
		/// 受到来自艾斯的物理伤害量+30%；
		/// 受到深度灼伤的伤害量+25%。
		/// </summary>
        public static string Buff_B_FFAce_1 = "B_FFAce_1";

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