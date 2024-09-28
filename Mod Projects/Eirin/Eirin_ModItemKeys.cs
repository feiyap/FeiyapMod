using ChronoArkMod;
namespace Eirin
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 月人/梦蝶
		/// 解除弱化减益。
		/// 无法行动，受到伤害后解除。
		/// </summary>
        public static string Buff_B_Eirin_0 = "B_Eirin_0";
		/// <summary>
		/// 月人/乾坤
		/// 造成的追加攻击/反击的伤害+33%。
		/// </summary>
        public static string Buff_B_Eirin_1 = "B_Eirin_1";
		/// <summary>
		/// 月人/天网
		/// 即使身上没有[月人/新月]也可以触发[月人/乱箭]。
		/// </summary>
        public static string Buff_B_Eirin_12Rare = "B_Eirin_12Rare";
		/// <summary>
		/// 月人/月药
		/// </summary>
        public static string Buff_B_Eirin_2 = "B_Eirin_2";
		/// <summary>
		/// 月人/操神
		/// </summary>
        public static string Buff_B_Eirin_3 = "B_Eirin_3";
		/// <summary>
		/// 月人/月使
		/// 受到的追加攻击/反击伤害增加&a点。
		/// </summary>
        public static string Buff_B_Eirin_3_0 = "B_Eirin_3_0";
		/// <summary>
		/// 月人/苏活
		/// 下次受到伤害时，恢复&a体力，并对来源发动一次[月人/乱箭]；
		/// 如果处于濒死阶段，抵消该伤害。
		/// </summary>
        public static string Buff_B_Eirin_5 = "B_Eirin_5";
		/// <summary>
		/// 月人/狂命
		/// 受到的伤害变为0。
		/// </summary>
        public static string Buff_B_Eirin_6 = "B_Eirin_6";
		/// <summary>
		/// 月人/污秽
		/// </summary>
        public static string Buff_B_Eirin_6_0 = "B_Eirin_6_0";
		/// <summary>
		/// 月人/永琳
		/// 每个回合开始时，随机生成1张附带放逐、一次性的自己的专属技能。
		/// </summary>
        public static string Buff_B_Eirin_8 = "B_Eirin_8";
		/// <summary>
		/// 仙香玉兔
		/// 无法行动。
		/// 回合开始时解除。
		/// 解除时，优先抽取3个自己的技能。
		/// </summary>
        public static string Buff_B_Eirin_LucyD = "B_Eirin_LucyD";
		/// <summary>
		/// 月人/新月
		/// 使用指向单体的攻击技能时，消耗一层[月人/新月]，八意永琳会对目标进行一次[月人/乱箭]，视作追加攻击。
		/// 这个伤害的75%会转化为对自己的连锁治疗。
		/// </summary>
        public static string Buff_B_Eirin_P = "B_Eirin_P";
		/// <summary>
		/// 无缺/月人
		/// 手中的治疗技能可以指向敌人，造成等量伤害，并且附带一次[月人/乱箭]。
		/// </summary>
        public static string Buff_B_Eirin_P_Hide = "B_Eirin_P_Hide";
		/// <summary>
		/// 八意永琳
		/// Passive:
		/// 释放指向友军的治疗技能，或指向自己的技能时，会为目标施加1层[月人/新月]：
		/// 使用指向单体的攻击技能时，消耗一层[月人/新月]，八意永琳会对目标进行一次[月人/乱箭]，视作追加攻击。这个伤害的(10*治疗力)%会转化为对自己的连锁治疗。
		/// </summary>
        public static string Character_Eirin = "Eirin";
        public static string SimpleCampDialogue_CampDial_Eirin_Sizz = "CampDial_Eirin_Sizz";
        public static string SimpleCampDialogue_CampDial_Eirin_SilverStein = "CampDial_Eirin_SilverStein";
        public static string SimpleCampDialogue_CampDial_Eirin_Patchouli = "CampDial_Eirin_Patchouli";
        public static string SimpleCampDialogue_CampDial_Eirin_Mokou = "CampDial_Eirin_Mokou";
        public static string SimpleCampDialogue_CampDial_Eirin_RemiliaScarlet = "CampDial_Eirin_RemiliaScarlet";
        public static string SimpleCampDialogue_CampDial_Eirin_IzayoiSakuya = "CampDial_Eirin_IzayoiSakuya";
        public static string SimpleCampDialogue_CampDial_Eirin_FlandreScarlet = "CampDial_Eirin_FlandreScarlet";
        public static string SimpleCampDialogue_CampDial_Eirin_SatsukiRin = "CampDial_Eirin_SatsukiRin";
        public static string SimpleCampDialogue_CampDial_Eirin_Youmu = "CampDial_Eirin_Youmu";
        public static string SimpleCampDialogue_CampDial_Eirin_TouhouAlice = "CampDial_Eirin_TouhouAlice";
        public static string SimpleCampDialogue_CampDial_Eirin_Reisen = "CampDial_Eirin_Reisen";
		/// <summary>
		/// 若八意永琳在场，释放时根据该技能的费用，八意永琳对目标进行多次[幻象/乱箭]。
		/// 指向单体的攻击技能
		/// </summary>
        public static string SkillExtended_SE_Eirin_0 = "SE_Eirin_0";
		/// <summary>
		/// 使目标获得[月人/月使]：6回合内，受到的追加攻击/反击伤害增加(20%治疗力)点。
		/// 指向单体的攻击技能
		/// </summary>
        public static string SkillExtended_SE_Eirin_1 = "SE_Eirin_1";
		/// <summary>
		/// 无缺/月人
		/// </summary>
        public static string SkillExtended_SE_Eirin_P_Hide = "SE_Eirin_P_Hide";
        public static string SkillEffect_SE_S_S_Eirin_12Rare = "SE_S_S_Eirin_12Rare";
        public static string SkillEffect_SE_S_S_Eirin_8 = "SE_S_S_Eirin_8";
        public static string SkillEffect_SE_Tick_B_Eirin_2 = "SE_Tick_B_Eirin_2";
        public static string SkillEffect_SE_T_S_Eirin_0 = "SE_T_S_Eirin_0";
        public static string SkillEffect_SE_T_S_Eirin_1 = "SE_T_S_Eirin_1";
        public static string SkillEffect_SE_T_S_Eirin_10Rare = "SE_T_S_Eirin_10Rare";
        public static string SkillEffect_SE_T_S_Eirin_11Rare = "SE_T_S_Eirin_11Rare";
        public static string SkillEffect_SE_T_S_Eirin_12Rare = "SE_T_S_Eirin_12Rare";
        public static string SkillEffect_SE_T_S_Eirin_2 = "SE_T_S_Eirin_2";
        public static string SkillEffect_SE_T_S_Eirin_3 = "SE_T_S_Eirin_3";
        public static string SkillEffect_SE_T_S_Eirin_4 = "SE_T_S_Eirin_4";
        public static string SkillEffect_SE_T_S_Eirin_5 = "SE_T_S_Eirin_5";
        public static string SkillEffect_SE_T_S_Eirin_6 = "SE_T_S_Eirin_6";
        public static string SkillEffect_SE_T_S_Eirin_7 = "SE_T_S_Eirin_7";
        public static string SkillEffect_SE_T_S_Eirin_9 = "SE_T_S_Eirin_9";
        public static string SkillEffect_SE_T_S_Eirin_LucyD = "SE_T_S_Eirin_LucyD";
        public static string SkillEffect_SE_T_S_Eirin_P = "SE_T_S_Eirin_P";
		/// <summary>
		/// 药符「蝴蝶梦丸噩梦」
		/// </summary>
        public static string Skill_S_Eirin_0 = "S_Eirin_0";
		/// <summary>
		/// 药符「壶中的大银河」
		/// </summary>
        public static string Skill_S_Eirin_1 = "S_Eirin_1";
		/// <summary>
		/// 天呪「Apollo 13」
		/// 每次使用手中的技能时，或是自身或队友触发追加攻击/反击时，这个技能费用-1。
		/// </summary>
        public static string Skill_S_Eirin_10Rare = "S_Eirin_10Rare";
		/// <summary>
		/// 秘术「天文密葬法」
		/// 消耗场上所有[月人/新月]，每层消耗的[月人/新月]使这个技能额外造成&a(15%)伤害。
		/// 这个技能造成伤害的35%会转化为对自己的连锁治疗。
		/// </summary>
        public static string Skill_S_Eirin_11Rare = "S_Eirin_11Rare";
		/// <summary>
		/// 「天网蛛网捕蝶之法」
		/// </summary>
        public static string Skill_S_Eirin_12Rare = "S_Eirin_12Rare";
		/// <summary>
		/// 天丸「壶中的天地」
		/// 如果目标身上有减益效果，则解除目标身上随机1个减益效果。
		/// 依据解除的减益效果的种类：
		/// 痛苦减益 - 施加[月人/月药]。
		/// 弱化减益 - 施加[月人/乾坤]。
		/// 干扰减益 - 施加[月人/操神]。
		/// </summary>
        public static string Skill_S_Eirin_2 = "S_Eirin_2";
		/// <summary>
		/// 操神「思兼装置」
		/// 改变目标的嘲讽状态。那之后，根据目标当前的嘲讽状态：
		/// 嘲讽 - 使目标获得[月人/月使]。
		/// 非嘲讽 - 使所有友军获得[月人/操神]。
		/// </summary>
        public static string Skill_S_Eirin_3 = "S_Eirin_3";
		/// <summary>
		/// 神脑「思兼之脑」
		/// 消耗场上所有的[月人/新月]，对目标释放[消耗层数+2]次数的[月人/乱箭]。
		/// 依此法释放的[月人/乱箭]无视防御、必定命中。
		/// </summary>
        public static string Skill_S_Eirin_4 = "S_Eirin_4";
		/// <summary>
		/// 苏活「生命游戏 -Life Game-」
		/// </summary>
        public static string Skill_S_Eirin_5 = "S_Eirin_5";
		/// <summary>
		/// 苏生「Rising Game」
		/// </summary>
        public static string Skill_S_Eirin_6 = "S_Eirin_6";
		/// <summary>
		/// 觉神「神话时代的记忆」
		/// 优先抽取1个目标的技能。
		/// 如果抽取的技能为指向单体的攻击技能，为技能的拥有者施加1层[月人/新月]；
		/// 若不是，将这个技能放回牌堆底，再抽取1个技能。
		/// </summary>
        public static string Skill_S_Eirin_7 = "S_Eirin_7";
		/// <summary>
		/// 神符「天人的族谱」
		/// </summary>
        public static string Skill_S_Eirin_8 = "S_Eirin_8";
		/// <summary>
		/// 炼丹「水银之海」
		/// 生成1张随机的通用治疗技能，使其费用-1。
		/// </summary>
        public static string Skill_S_Eirin_9 = "S_Eirin_9";
		/// <summary>
		/// 秘药「仙香玉兔」
		/// </summary>
        public static string Skill_S_Eirin_LucyD = "S_Eirin_LucyD";
		/// <summary>
		/// 月人/乱箭
		/// </summary>
        public static string Skill_S_Eirin_P = "S_Eirin_P";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 唉……为什么事情一定要变成这样呢？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaEirinHideText1 => ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text1");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 污秽、愚蠢的地上的人们啊，我本不想如此……
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaEirinHideText2 => ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text2");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// ……但既然公主大人不在，就请你们死在这里吧。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaEirinHideText3 => ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text3");

    }
}