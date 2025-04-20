using ChronoArkMod;
namespace Feiyap
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 血似刃流
		/// 回合结束时，移除 1 层增益效果。
		/// </summary>
        public static string Buff_B_Feiyap_0 = "B_Feiyap_0";
		/// <summary>
		/// 体内灼烧
		/// </summary>
        public static string Buff_B_Feiyap_1 = "B_Feiyap_1";
		/// <summary>
		/// 孤燕之瞥
		/// 不会被施加任何来自其他单位的治疗效果。
		/// </summary>
        public static string Buff_B_Feiyap_5 = "B_Feiyap_5";
		/// <summary>
		/// 化身成神
		/// 释放自身的技能时不需要消耗法力值。
		/// </summary>
        public static string Buff_B_Feiyap_6 = "B_Feiyap_6";
		/// <summary>
		/// 镜花水月
		/// 闪避下 1 次受到的攻击。
		/// 触发闪避时，进行一次反击，造成&a伤害(攻击力的100%)，并施加 1 层“体内灼烧”。
		/// 触发后解除。
		/// </summary>
        public static string Buff_B_Feiyap_7 = "B_Feiyap_7";
		/// <summary>
		/// 另一种可能性
		/// 被动“绯夜流”的效果变更为：自身拥有保护体力极限时，攻击造成非痛苦伤害时(<sprite=1>100%)施加<sprite name="Feiyap_blood"><color=#FF3030>绯夜</color>。
		/// </summary>
        public static string Buff_B_Feiyap_Rare_1 = "B_Feiyap_Rare_1";
		/// <summary>
		/// 热寂
		/// </summary>
        public static string Buff_B_Feiyap_Rare_2 = "B_Feiyap_Rare_2";
		/// <summary>
		/// <sprite name="Feiyap_blood"><color=#FF3030>绯夜</color>
		/// 结算伤害时，造成伤害的25%将会超额治疗&user。
		/// </summary>
        public static string Buff_B_RemiliaScarlet_0 = "B_RemiliaScarlet_0";
		/// <summary>
		/// 绯生一文字
		/// </summary>
        public static string Item_Equip_E_Feiyap_0 = "E_Feiyap_0";
		/// <summary>
		/// 绯夜氏
		/// Passive:
		/// 自身拥有保护体力极限时，攻击造成伤害的25%转化为对自身的治疗。
		/// </summary>
        public static string Character_Feiyap = "Feiyap";
        public static string Character_Skin_FeiyapCoffee = "FeiyapCoffee";
        public static string Character_Skin_FeiyapMaster = "FeiyapMaster";
		/// <summary>
		/// 施加持续2回合的保护体力极限。
		/// 指向队友的治疗技能
		/// </summary>
        public static string SkillExtended_SE_Feiyap_C_0 = "SE_Feiyap_C_0";
		/// <summary>
		/// 若目标持有痛苦减益，恢复 1 点法力值。
		/// 指向敌人的攻击技能
		/// </summary>
        public static string SkillExtended_SE_Feiyap_C_1 = "SE_Feiyap_C_1";
        public static string SkillEffect_SE_S_S_FeiyapCoffee_6 = "SE_S_S_FeiyapCoffee_6";
        public static string SkillEffect_SE_S_S_Feiyap_0 = "SE_S_S_Feiyap_0";
        public static string SkillEffect_SE_S_S_Feiyap_2_1 = "SE_S_S_Feiyap_2_1";
        public static string SkillEffect_SE_S_S_Feiyap_5 = "SE_S_S_Feiyap_5";
        public static string SkillEffect_SE_S_S_Feiyap_6 = "SE_S_S_Feiyap_6";
        public static string SkillEffect_SE_S_S_Feiyap_7 = "SE_S_S_Feiyap_7";
        public static string SkillEffect_SE_Tick_B_Feiyap_1 = "SE_Tick_B_Feiyap_1";
        public static string SkillEffect_SE_Tick_B_Feiyap_Rare_2 = "SE_Tick_B_Feiyap_Rare_2";
        public static string SkillEffect_SE_Tick_B_RemiliaScarlet_0 = "SE_Tick_B_RemiliaScarlet_0";
        public static string SkillEffect_SE_T_S_FeiyapMaster_4 = "SE_T_S_FeiyapMaster_4";
        public static string SkillEffect_SE_T_S_FeiyapMaster_5 = "SE_T_S_FeiyapMaster_5";
        public static string SkillEffect_SE_T_S_Feiyap_0 = "SE_T_S_Feiyap_0";
        public static string SkillEffect_SE_T_S_Feiyap_1 = "SE_T_S_Feiyap_1";
        public static string SkillEffect_SE_T_S_Feiyap_2 = "SE_T_S_Feiyap_2";
        public static string SkillEffect_SE_T_S_Feiyap_2_1 = "SE_T_S_Feiyap_2_1";
        public static string SkillEffect_SE_T_S_Feiyap_2_2 = "SE_T_S_Feiyap_2_2";
        public static string SkillEffect_SE_T_S_Feiyap_3 = "SE_T_S_Feiyap_3";
        public static string SkillEffect_SE_T_S_Feiyap_4 = "SE_T_S_Feiyap_4";
        public static string SkillEffect_SE_T_S_Feiyap_5 = "SE_T_S_Feiyap_5";
        public static string SkillEffect_SE_T_S_Feiyap_7_0 = "SE_T_S_Feiyap_7_0";
        public static string SkillEffect_SE_T_S_Feiyap_LucyD_1 = "SE_T_S_Feiyap_LucyD_1";
        public static string SkillEffect_SE_T_S_Feiyap_LucyD_2 = "SE_T_S_Feiyap_LucyD_2";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_1 = "SE_T_S_Feiyap_Rare_1";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_2 = "SE_T_S_Feiyap_Rare_2";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_2_0 = "SE_T_S_Feiyap_Rare_2_0";
        public static string VFXSkill_S_FeiyapCoffee_6_Skin = "S_FeiyapCoffee_6_Skin";
        public static string VFXSkill_S_FeiyapMaster_4_Skin = "S_FeiyapMaster_4_Skin";
        public static string VFXSkill_S_FeiyapMaster_5_Skin = "S_FeiyapMaster_5_Skin";
		/// <summary>
		/// 绯夜流·一式
		/// 若自身拥有保护体力极限，额外造成&a点伤害(攻击力的50%)。
		/// </summary>
        public static string Skill_S_Feiyap_0 = "S_Feiyap_0";
		/// <summary>
		/// 里绯夜流·逆鳞斩
		/// 若自身拥有保护体力极限，对目标造成 1 次痛苦伤害，伤害量等于目标持有的减益的每回合伤害量。
		/// </summary>
        public static string Skill_S_Feiyap_1 = "S_Feiyap_1";
		/// <summary>
		/// 未完成的一文字
		/// 选择 - 自身获得 1 层“血似刃流”；
		/// 对目标施加 1 层“体内灼烧”。
		/// </summary>
        public static string Skill_S_Feiyap_2 = "S_Feiyap_2";
		/// <summary>
		/// 未完成的一文字·血
		/// </summary>
        public static string Skill_S_Feiyap_2_1 = "S_Feiyap_2_1";
		/// <summary>
		/// 未完成的一文字·刃
		/// </summary>
        public static string Skill_S_Feiyap_2_2 = "S_Feiyap_2_2";
		/// <summary>
		/// 天市右垣七
		/// 展示牌库和弃牌库中所有自己的技能。选择其中 1 个拿回手中。
		/// </summary>
        public static string Skill_S_Feiyap_3 = "S_Feiyap_3";
		/// <summary>
		/// 幽壑千灯
		/// 自身每有 1 点体力损伤（绿血），这个技能额外造成 2 点伤害。
		/// 目标每有 1 层痛苦减益，这个技能额外造成10%伤害。
		/// </summary>
        public static string Skill_S_Feiyap_4 = "S_Feiyap_4";
		/// <summary>
		/// 孤燕之瞥
		/// </summary>
        public static string Skill_S_Feiyap_5 = "S_Feiyap_5";
		/// <summary>
		/// 化身成神
		/// 使所有手中的技能获得随机<color=yellow>强化</color>。
		/// 如果这个技能拥有任意<color=yellow>强化</color>，额外使所有牌库中的技能获得随机<color=yellow>强化</color>。
		/// </summary>
        public static string Skill_S_Feiyap_6 = "S_Feiyap_6";
		/// <summary>
		/// 明镜止水
		/// 解除所有<sprite=1>痛苦减益和<sprite=2>干扰减益。
		/// </summary>
        public static string Skill_S_Feiyap_7 = "S_Feiyap_7";
		/// <summary>
		/// 镜花水月
		/// </summary>
        public static string Skill_S_Feiyap_7_0 = "S_Feiyap_7_0";
		/// <summary>
		/// 短休
		/// 移除目标所有过载。
		/// 每移除 1 层过载，恢复 1 点法力值。
		/// </summary>
        public static string Skill_S_Feiyap_8 = "S_Feiyap_8";
		/// <summary>
		/// 于午后的咖啡厅偶遇
		/// 抽取2个技能。若目标拥有保护体力极限，额外抽取 1 个技能。
		/// </summary>
        public static string Skill_S_Feiyap_LucyD_1 = "S_Feiyap_LucyD_1";
		/// <summary>
		/// 于午夜的篝火守夜
		/// 抽取2个技能。
		/// </summary>
        public static string Skill_S_Feiyap_LucyD_2 = "S_Feiyap_LucyD_2";
		/// <summary>
		/// 红现实
		/// 战斗开始时，放在牌库最上方。
		/// <i><color=#FF4500>[响亮的金属撞击爆炸，随之而来的是噼啪噪音声]</color></i>
		/// <i><color=#FF4500>五年，十一个月，二十一天。</color></i>
		/// </summary>
        public static string Skill_S_Feiyap_Rare_1 = "S_Feiyap_Rare_1";
		/// <summary>
		/// 无声星陨
		/// 若自身拥有保护体力极限，生成“星天陨辍”。
		/// </summary>
        public static string Skill_S_Feiyap_Rare_2 = "S_Feiyap_Rare_2";
		/// <summary>
		/// 星天陨辍
		/// 对目标造成 1 次痛苦伤害，伤害量为被移除的所有痛苦减益剩余总伤害的值。
		/// 持续时间为永久的痛苦减益在计算时被视为6回合。
		/// </summary>
        public static string Skill_S_Feiyap_Rare_2_0 = "S_Feiyap_Rare_2_0";
		/// <summary>
		/// 秘奥义·绯樱狱华落
		/// </summary>
        public static string Skill_S_Feiyap_Rare_3 = "S_Feiyap_Rare_3";

    }

    public static class ModLocalization
    {

    }
}