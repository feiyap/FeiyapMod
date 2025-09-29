using ChronoArkMod;
namespace Feiyap
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 血似刃流
		/// 回合结束时，移除 1 层该增益效果。
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
		/// 不会因为受到<color=purple>痛苦伤害</color>导致死亡。
		/// 释放自身的技能不消耗法力值，但会受到<color=purple> &a 点痛苦伤害</color>。每次触发使该痛苦伤害翻倍。
		/// </summary>
        public static string Buff_B_Feiyap_6 = "B_Feiyap_6";
		/// <summary>
		/// 镜花水月
		/// 闪避下 1 次受到的攻击。
		/// 触发闪避时，进行一次反击，造成&a伤害<color=#FF7A33>(攻击力的100%)</color>，并施加 1 层“体内灼烧”。
		/// 触发后解除。
		/// </summary>
        public static string Buff_B_Feiyap_7 = "B_Feiyap_7";
		/// <summary>
		/// 渴血症
		/// 其他友军被选定为敌方技能的目标时，使目标改为指向自己。
		/// 增益持续期间，被动“绯夜流”的效果翻倍。
		/// 增益解除时，依据增益期间自身受到伤害的次数，对随机敌人追加攻击，每次造成&a伤害<color=#FF7A33>(攻击力的100%)</color>。
		/// 当前受到伤害的次数：&b
		/// </summary>
        public static string Buff_B_Feiyap_Rare_1 = "B_Feiyap_Rare_1";
		/// <summary>
		/// 热寂
		/// </summary>
        public static string Buff_B_Feiyap_Rare_2 = "B_Feiyap_Rare_2";
		/// <summary>
		/// 神之力量
		/// 根据已损失的体力值百分比，获得攻击力提升。最多提升300%。
		/// <color=#919191><i>向无冕之王致敬。</i></color>
		/// </summary>
        public static string Buff_B_Feiyap_Rare_3 = "B_Feiyap_Rare_3";
        public static string SimpleCampDialogue_CampDia_Feiyap_Azar = "CampDia_Feiyap_Azar";
        public static string SimpleCampDialogue_CampDia_Feiyap_Caron = "CampDia_Feiyap_Caron";
        public static string SimpleCampDialogue_CampDia_Feiyap_Control = "CampDia_Feiyap_Control";
        public static string SimpleCampDialogue_CampDia_Feiyap_Hein = "CampDia_Feiyap_Hein";
        public static string SimpleCampDialogue_CampDia_Feiyap_Huz = "CampDia_Feiyap_Huz";
        public static string SimpleCampDialogue_CampDia_Feiyap_Ilya = "CampDia_Feiyap_Ilya";
        public static string SimpleCampDialogue_CampDia_Feiyap_Joey = "CampDia_Feiyap_Joey";
        public static string SimpleCampDialogue_CampDia_Feiyap_Leryn = "CampDia_Feiyap_Leryn";
        public static string SimpleCampDialogue_CampDia_Feiyap_Lian = "CampDia_Feiyap_Lian";
        public static string SimpleCampDialogue_CampDia_Feiyap_Mement = "CampDia_Feiyap_Mement";
        public static string SimpleCampDialogue_CampDia_Feiyap_MissChainh = "CampDia_Feiyap_MissChainh";
        public static string SimpleCampDialogue_CampDia_Feiyap_Momori = "CampDia_Feiyap_Momori";
        public static string SimpleCampDialogue_CampDia_Feiyap_Phoenix = "CampDia_Feiyap_Phoenix";
        public static string SimpleCampDialogue_CampDia_Feiyap_Priest = "CampDia_Feiyap_Priest";
        public static string SimpleCampDialogue_CampDia_Feiyap_Prime = "CampDia_Feiyap_Prime";
        public static string SimpleCampDialogue_CampDia_Feiyap_SilverStein = "CampDia_Feiyap_SilverStein";
        public static string SimpleCampDialogue_CampDia_Feiyap_Sizz = "CampDia_Feiyap_Sizz";
        public static string SimpleCampDialogue_CampDia_Feiyap_Trisha = "CampDia_Feiyap_Trisha";
        public static string SimpleCampDialogue_CampDia_Feiyap_TWBlue = "CampDia_Feiyap_TWBlue";
        public static string SimpleCampDialogue_CampDia_Feiyap_TWRed = "CampDia_Feiyap_TWRed";
		/// <summary>
		/// 绯生一文字
		/// </summary>
        public static string Item_Equip_E_Feiyap_0 = "E_Feiyap_0";
		/// <summary>
		/// 镇魂石
		/// 每个回合结束时，该装备提供的属性-5%/-5%/-5%。
		/// 黑雾回合到来时，装备属性重置。
		/// <color=#919191><i>再次鼓起失去的勇气。</i></color>
		/// </summary>
        public static string Item_Equip_E_Feiyap_1 = "E_Feiyap_1";
		/// <summary>
		/// 绯夜氏
		/// Passive:
		/// 自身拥有保护体力极限时，攻击造成伤害的25%转化为对自身的治疗。
		/// </summary>
        public static string Character_Feiyap = "Feiyap";
        public static string Character_Skin_FeiyapCoffee = "FeiyapCoffee";
        public static string Character_Skin_FeiyapMaid = "FeiyapMaid";
        public static string Character_Skin_FeiyapMaster = "FeiyapMaster";
		/// <summary>
		/// 施加持续 2 回合的保护体力极限。
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
        public static string SkillEffect_SE_T_S_Feiyap_Rare_1_0 = "SE_T_S_Feiyap_Rare_1_0";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_2 = "SE_T_S_Feiyap_Rare_2";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_2_0 = "SE_T_S_Feiyap_Rare_2_0";
        public static string SkillEffect_SE_T_S_Feiyap_Rare_3 = "SE_T_S_Feiyap_Rare_3";
        public static string VFXSkill_S_FeiyapCoffee_6_Skin = "S_FeiyapCoffee_6_Skin";
        public static string VFXSkill_S_FeiyapMaid_0_Skin = "S_FeiyapMaid_0_Skin";
        public static string VFXSkill_S_FeiyapMaid_5_Skin = "S_FeiyapMaid_5_Skin";
        public static string VFXSkill_S_FeiyapMaid_8_Skin = "S_FeiyapMaid_8_Skin";
        public static string VFXSkill_S_FeiyapMaster_4_Skin = "S_FeiyapMaster_4_Skin";
        public static string VFXSkill_S_FeiyapMaster_5_Skin = "S_FeiyapMaster_5_Skin";
		/// <summary>
		/// 绯夜流·一式
		/// 若自身拥有保护体力极限，额外造成&a点伤害<color=#FF7A33>(攻击力的50%)</color>。
		/// 否则额外获得 1 层“血似刃流”。
		/// </summary>
        public static string Skill_S_Feiyap_0 = "S_Feiyap_0";
		/// <summary>
		/// 里绯夜流·逆鳞斩
		/// 若自身拥有保护体力极限，对目标造成 2 次痛苦伤害，伤害量等于目标持有的减益的每回合伤害量。
		/// 否则额外施加 1 层“体内灼烧”。
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
		/// 展示牌库和弃牌库中所有自己的技能（“天市右垣七”除外）。选择其中 1 个拿回手中。
		/// </summary>
        public static string Skill_S_Feiyap_3 = "S_Feiyap_3";
		/// <summary>
		/// 幽壑千灯
		/// 自身每有 1 点体力损伤（绿血），这个技能额外造成 &a 点伤害<color=#FF7A33>(攻击力的10%)</color>。
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
		/// 使自身体力值变为 0 ，解除自身所有<sprite=0>弱化减益。
		/// 解除所有目标的<sprite=1>痛苦减益和<sprite=2>干扰减益。
		/// </summary>
        public static string Skill_S_Feiyap_7 = "S_Feiyap_7";
		/// <summary>
		/// 镜花水月
		/// </summary>
        public static string Skill_S_Feiyap_7_0 = "S_Feiyap_7_0";
		/// <summary>
		/// 短休
		/// 将目标的体力极限恢复至体力上限，并移除目标所有过载。
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
		/// 抽取 2 个技能。
		/// </summary>
        public static string Skill_S_Feiyap_LucyD_2 = "S_Feiyap_LucyD_2";
		/// <summary>
		/// 渴血症
		/// </summary>
        public static string Skill_S_Feiyap_Rare_1 = "S_Feiyap_Rare_1";
        public static string Skill_S_Feiyap_Rare_1_0 = "S_Feiyap_Rare_1_0";
		/// <summary>
		/// 无声星陨
		/// 若自身拥有保护体力极限，生成“星天陨辍”。
		/// </summary>
        public static string Skill_S_Feiyap_Rare_2 = "S_Feiyap_Rare_2";
		/// <summary>
		/// 星天陨辍
		/// 对目标造成 1 次痛苦伤害，伤害量为持有的所有痛苦减益剩余总伤害的值。
		/// 持续时间为永久的痛苦减益在计算时被视为 6 回合。
		/// </summary>
        public static string Skill_S_Feiyap_Rare_2_0 = "S_Feiyap_Rare_2_0";
		/// <summary>
		/// 神之力量
		/// 抽取 1 个自己的技能。
		/// </summary>
        public static string Skill_S_Feiyap_Rare_3 = "S_Feiyap_Rare_3";

    }

    public static class ModLocalization
    {

    }
}