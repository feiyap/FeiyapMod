using ChronoArkMod;
namespace MinamiRio
{
    public static class ModItemKeys
    {
		/// <summary>
		/// <color=#DC143C>皆中</color>
		/// 攻击命中时获得1层<color=#DC143C>皆中</color>。
		/// <color=#48D1CC>单弓</color> - 层数达到上限时，移除该增益并优先抽取1个自己的技能。
		/// <color=#FFD700>和弓</color> - 层数达到上限时，移除该增益并获得[全神贯注]。
		/// </summary>
        public static string Buff_B_MinamiRio_0 = "B_MinamiRio_0";
		/// <summary>
		/// 全神贯注
		/// 使自身下1个2费以上的技能造成的伤害提升25%。
		/// </summary>
        public static string Buff_B_MinamiRio_2 = "B_MinamiRio_2";
		/// <summary>
		/// <color=#54FF9F>风伤</color>
		/// </summary>
        public static string Buff_B_MinamiRio_4 = "B_MinamiRio_4";
		/// <summary>
		/// 莉央
		/// Passive:
		/// <b>锚点</b> - 莉央无法造成暴击，但是升级时获得远超常人的命中率提升。莉央超过100%的那部分命中率转化为50%的<color=#FA8072>穿甲</color>。
		/// <b><color=#FA8072>穿甲</color></b> - 莉央攻击时视作目标减少等量于<color=#FA8072>穿甲</color>的防御力。
		/// <b><color=#48D1CC>单弓</color></b> - 莉央在<color=#48D1CC>单弓</color>形态下手中的攻击技能获得无视嘲讽；且部分技能会触发额外效果。
		/// <b><color=#FFD700>和弓</color></b> - 莉央在<color=#FFD700>和弓</color>形态下增加20%命中率；且部分技能会触发额外效果。
		/// </summary>
        public static string Character_MinamiRio = "MinamiRio";
        public static string SkillEffect_SE_S_S_MinamiRio_0 = "SE_S_S_MinamiRio_0";
        public static string SkillEffect_SE_S_S_MinamiRio_2 = "SE_S_S_MinamiRio_2";
        public static string SkillEffect_SE_S_S_MinamiRio_5 = "SE_S_S_MinamiRio_5";
        public static string SkillEffect_SE_T_S_MinamiRio_1 = "SE_T_S_MinamiRio_1";
        public static string SkillEffect_SE_T_S_MinamiRio_2 = "SE_T_S_MinamiRio_2";
        public static string SkillEffect_SE_T_S_MinamiRio_3 = "SE_T_S_MinamiRio_3";
        public static string SkillEffect_SE_T_S_MinamiRio_4 = "SE_T_S_MinamiRio_4";
        public static string SkillEffect_SE_T_S_MinamiRio_6 = "SE_T_S_MinamiRio_6";
        public static string SkillEffect_SE_T_S_MinamiRio_7 = "SE_T_S_MinamiRio_7";
		/// <summary>
		/// 替弓
		/// 使自身切换<color=#48D1CC>单弓</color>/<color=#FFD700>和弓</color>状态。
		/// 作为固定技能时，<color=#DC143C>皆中</color>解除时变为可以使用的状态。
		/// </summary>
        public static string Skill_S_MinamiRio_0 = "S_MinamiRio_0";
		/// <summary>
		/// 快射
		/// <color=#48D1CC>单弓</color> - 本回合内可再次释放1次。
		/// <color=#FFD700>和弓</color> - 降低1点费用。
		/// </summary>
        public static string Skill_S_MinamiRio_1 = "S_MinamiRio_1";
		/// <summary>
		/// 稳固射击
		/// <color=#48D1CC>单弓</color> - 附带迅速。
		/// <color=#FFD700>和弓</color> - 额外造成&a(35%)伤害。
		/// </summary>
        public static string Skill_S_MinamiRio_2 = "S_MinamiRio_2";
		/// <summary>
		/// 瞄准射击
		/// 从[全神贯注]获得的提升翻倍。
		/// <color=#48D1CC>单弓</color> - 使自身下1个技能降低2点费用。
		/// <color=#FFD700>和弓</color> - 从<color=#FA8072>穿甲</color>获得的提升翻倍。
		/// </summary>
        public static string Skill_S_MinamiRio_3 = "S_MinamiRio_3";
		/// <summary>
		/// 分离
		/// <color=#48D1CC>单弓</color> - 变为指向所有敌人。施加<color=#54FF9F>风伤</color>。
		/// <color=#FFD700>和弓</color> - 额外造成&a(35%)伤害。如果目标拥有嘲讽状态，则同时指定所有非嘲讽状态的敌人。
		/// </summary>
        public static string Skill_S_MinamiRio_4 = "S_MinamiRio_4";
		/// <summary>
		/// 箭越
		/// 选择 - 使所有敌人行动倒计时+1；
		/// 使所有敌人行动倒计时-1。
		/// 那之后，对行动倒计时最低的敌人造成&a(50%)伤害，抽取1个技能，使自身切换<color=#48D1CC>单弓</color>/<color=#FFD700>和弓</color>状态。
		/// </summary>
        public static string Skill_S_MinamiRio_5 = "S_MinamiRio_5";
		/// <summary>
		/// 追踪术
		/// 可以指向不能被指定的单位。
		/// </summary>
        public static string Skill_S_MinamiRio_6 = "S_MinamiRio_6";
		/// <summary>
		/// 百发百中
		/// 抽取1个技能。
		/// </summary>
        public static string Skill_S_MinamiRio_7 = "S_MinamiRio_7";

    }

    public static class ModLocalization
    {

    }
}