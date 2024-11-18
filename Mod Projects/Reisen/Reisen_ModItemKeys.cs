using ChronoArkMod;
namespace Reisen
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 幻象/怠波
		/// </summary>
        public static string Buff_B_Reisen_1 = "B_Reisen_1";
		/// <summary>
		/// 幻象/狂梦
		/// 不会减少<color=#FF00FF>狂气</color>的层数。
		/// </summary>
        public static string Buff_B_Reisen_11Rare = "B_Reisen_11Rare";
		/// <summary>
		/// 国士无双
		/// 叠加4层后对自己和所有敌人造成100%最大体力值的伤害。
		/// </summary>
        public static string Buff_B_Reisen_12Rare = "B_Reisen_12Rare";
		/// <summary>
		/// 幻象/懒冻
		/// 无法行动。
		/// </summary>
        public static string Buff_B_Reisen_1_0 = "B_Reisen_1_0";
		/// <summary>
		/// 幻象/调律
		/// [幻象/乱弹]对目标的命中率提升100%。
		/// </summary>
        public static string Buff_B_Reisen_2 = "B_Reisen_2";
		/// <summary>
		/// 幻象/狂视
		/// [幻象/乱弹]对目标的暴击率提升100%。
		/// </summary>
        public static string Buff_B_Reisen_2_0 = "B_Reisen_2_0";
		/// <summary>
		/// 幻象/花冠
		/// 造成的追加攻击/反击伤害+&a(33%)。
		/// </summary>
        public static string Buff_B_Reisen_3 = "B_Reisen_3";
		/// <summary>
		/// 幻象/丧心
		/// </summary>
        public static string Buff_B_Reisen_4 = "B_Reisen_4";
		/// <summary>
		/// 幻象/疮痍
		/// </summary>
        public static string Buff_B_Reisen_4_0 = "B_Reisen_4_0";
		/// <summary>
		/// 幻象/视差
		/// 闪避下1次受到的伤害。
		/// </summary>
        public static string Buff_B_Reisen_5 = "B_Reisen_5";
		/// <summary>
		/// <color=#FF0000>幻象/望月</color>
		/// 每次触发<color=#B22222>幻象/乱弹</color>时失去1层<color=#FF00FF>狂气</color>，使<color=#B22222>幻象/乱弹</color>的伤害提升为&a(75%)，命中率提升为100%。
		/// 当<color=#FF00FF>狂气</color>层数归零时，<color=#FF0000>幻象/望月</color>状态解除。
		/// </summary>
        public static string Buff_B_Reisen_6 = "B_Reisen_6";
		/// <summary>
		/// 真实/幻象
		/// 每个回合开始时，获得3颗<sprite name="Reisen_bullet"><color=#B22222>子弹</color>。
		/// </summary>
        public static string Buff_B_Reisen_7 = "B_Reisen_7";
		/// <summary>
		/// 幻象/幻爆
		/// </summary>
        public static string Buff_B_Reisen_8 = "B_Reisen_8";
		/// <summary>
		/// 幻象/胧月
		/// </summary>
        public static string Buff_B_Reisen_9 = "B_Reisen_9";
		/// <summary>
		/// <color=#FF4500>幻象/赤月</color>
		/// 每次触发<color=#B22222>幻象/乱弹</color>时失去1层<color=#FF00FF>狂气</color>，使<color=#B22222>幻象/乱弹</color>的命中率提升为100%。
		/// 当<color=#FF00FF>狂气</color>层数归零时、或是按下[等待]按钮时，<color=#FF4500>幻象/赤月</color>状态解除。
		/// </summary>
        public static string Buff_B_Reisen_P = "B_Reisen_P";
		/// <summary>
		/// <color=#B22222>子弹</color>
		/// 消耗<color=#B22222>子弹</color>来触发<color=#B22222>幻象/乱弹</color>。
		/// <i><color=#CDC9C9>开枪需要消耗子弹。这是常识。</color></i>
		/// </summary>
        public static string Buff_B_Reisen_P_Bullet = "B_Reisen_P_Bullet";
		/// <summary>
		/// <color=#FF00FF>狂气</color>
		/// 消耗<color=#FF00FF>狂气</color>来加强技能的效果。
		/// <i><color=#CDC9C9>究竟是铃仙控制了狂气，还是狂气控制了铃仙？</color></i>
		/// </summary>
        public static string Buff_B_Reisen_P_Insane = "B_Reisen_P_Insane";
		/// <summary>
		/// 幻象/狂气
		/// 在[幻象/赤月]状态或[幻象/望月]状态下，技能能够触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Insane = "Keyword_Insane";
		/// <summary>
		/// 铃仙
		/// Passive:
		/// <b><color=#B22222>幻象/乱弹</color></b> - 战斗开始时，获得6颗<color=#B22222>子弹</color>。每次按下[等待]按钮时，获得1颗<color=#B22222>子弹</color>。
		/// 铃仙使用攻击技能指向单个敌人时，自动消耗1颗<color=#B22222>子弹</color>，对目标进行1次<color=#B22222>幻象/乱弹</color>的追加攻击。
		/// <b><color=#FF00FF>幻象/狂气</color></b> - 战斗开始时，获得4层<color=#FF00FF>幻象/狂气</color>。每个回合开始时，获得1层<color=#FF00FF>幻象/狂气</color>。
		/// 铃仙的固定技能被替换为[长视「赤月下(Infrared Moon)」]：消耗1层<color=#FF00FF>幻象/狂气</color>，进入<color=#FF4500>幻象/赤月</color>状态。
		/// <b><color=#FF4500>幻象/赤月</color></b> - 在这个状态下，铃仙的<color=#B22222>幻象/乱弹</color>和手中的技能获得增强和额外效果，但使用技能时会消耗<color=#FF00FF>幻象/狂气</color>的层数。<color=#FF00FF>幻象/狂气</color>层数清空时退出<color=#FF4500>幻象/赤月</color>状态。
		/// </summary>
        public static string Character_Reisen = "Reisen";
        public static string Character_Skin_ReisenEVO = "ReisenEVO";
        public static string Character_Skin_ReisenShooter = "ReisenShooter";
        public static string SimpleCampDialogue_CampDial_Reisen_Hein = "CampDial_Reisen_Hein";
        public static string SimpleCampDialogue_CampDial_Reisen_SilverStein = "CampDial_Reisen_SilverStein";
        public static string SimpleCampDialogue_CampDial_Reisen_Patchouli = "CampDial_Reisen_Patchouli";
        public static string SimpleCampDialogue_CampDial_Reisen_Mokou = "CampDial_Reisen_Mokou";
        public static string SimpleCampDialogue_CampDial_Reisen_IzayoiSakuya = "CampDial_Reisen_IzayoiSakuya";
        public static string SimpleCampDialogue_CampDial_Reisen_FlandreScarlet = "CampDial_Reisen_FlandreScarlet";
        public static string SimpleCampDialogue_CampDial_Reisen_SatsukiRin = "CampDial_Reisen_SatsukiRin";
        public static string SimpleCampDialogue_CampDial_Reisen_Youmu = "CampDial_Reisen_Youmu";
        public static string SimpleCampDialogue_CampDial_Reisen_RemiliaScarlet = "CampDial_Reisen_RemiliaScarlet";
        public static string SimpleCampDialogue_CampDial_Reisen_TouhouAlice = "CampDial_Reisen_TouhouAlice";
        public static string SimpleCampDialogue_CampDial_Reisen_Eirin = "CampDial_Reisen_Eirin";
		/// <summary>
		/// 兔肉火锅
		/// 战斗结束后，超额治疗所有队员6点体力值。
		/// </summary>
        public static string Item_Passive_R_Reisen_0 = "R_Reisen_0";
		/// <summary>
		/// 若铃仙在场，释放时根据该技能的费用，铃仙对目标进行多次[幻象/乱弹]。
		/// 单体目标攻击技能
		/// </summary>
        public static string SkillExtended_SE_Reisen_0 = "SE_Reisen_0";
        public static string SkillEffect_SE_S_S_Reisen_0 = "SE_S_S_Reisen_0";
        public static string SkillEffect_SE_S_S_Reisen_10Rare = "SE_S_S_Reisen_10Rare";
        public static string SkillEffect_SE_S_S_Reisen_11Rare = "SE_S_S_Reisen_11Rare";
        public static string SkillEffect_SE_S_S_Reisen_12Rare = "SE_S_S_Reisen_12Rare";
        public static string SkillEffect_SE_S_S_Reisen_2 = "SE_S_S_Reisen_2";
        public static string SkillEffect_SE_S_S_Reisen_3 = "SE_S_S_Reisen_3";
        public static string SkillEffect_SE_S_S_Reisen_4 = "SE_S_S_Reisen_4";
        public static string SkillEffect_SE_S_S_Reisen_5 = "SE_S_S_Reisen_5";
        public static string SkillEffect_SE_S_S_Reisen_6 = "SE_S_S_Reisen_6";
        public static string SkillEffect_SE_S_S_Reisen_7 = "SE_S_S_Reisen_7";
        public static string SkillEffect_SE_S_S_Reisen_8 = "SE_S_S_Reisen_8";
        public static string SkillEffect_SE_S_S_Reisen_P = "SE_S_S_Reisen_P";
        public static string SkillEffect_SE_T_S_Reisen_0 = "SE_T_S_Reisen_0";
        public static string SkillEffect_SE_T_S_Reisen_1 = "SE_T_S_Reisen_1";
        public static string SkillEffect_SE_T_S_Reisen_10Rare = "SE_T_S_Reisen_10Rare";
        public static string SkillEffect_SE_T_S_Reisen_12Rare = "SE_T_S_Reisen_12Rare";
        public static string SkillEffect_SE_T_S_Reisen_12Rare_0 = "SE_T_S_Reisen_12Rare_0";
        public static string SkillEffect_SE_T_S_Reisen_2 = "SE_T_S_Reisen_2";
        public static string SkillEffect_SE_T_S_Reisen_3 = "SE_T_S_Reisen_3";
        public static string SkillEffect_SE_T_S_Reisen_3_0 = "SE_T_S_Reisen_3_0";
        public static string SkillEffect_SE_T_S_Reisen_3_1 = "SE_T_S_Reisen_3_1";
        public static string SkillEffect_SE_T_S_Reisen_4 = "SE_T_S_Reisen_4";
        public static string SkillEffect_SE_T_S_Reisen_5 = "SE_T_S_Reisen_5";
        public static string SkillEffect_SE_T_S_Reisen_7 = "SE_T_S_Reisen_7";
        public static string SkillEffect_SE_T_S_Reisen_8 = "SE_T_S_Reisen_8";
        public static string SkillEffect_SE_T_S_Reisen_9 = "SE_T_S_Reisen_9";
        public static string SkillEffect_SE_T_S_Reisen_P = "SE_T_S_Reisen_P";
        public static string SkillEffect_SE_T_S_Reisen_P_0 = "SE_T_S_Reisen_P_0";
        public static string SkillEffect_SE_T_S_Reisen_P_1 = "SE_T_S_Reisen_P_1";
        public static string SkillEffect_SE_T_S_Reisen_P_2 = "SE_T_S_Reisen_P_2";
		/// <summary>
		/// 波符「赤眼催眠(Mind Shaker)」
		/// <color=#FF00FF>幻象/狂气</color> - 必定暴击。
		/// </summary>
        public static string Skill_S_Reisen_0 = "S_Reisen_0";
		/// <summary>
		/// 懒符「生神停止(Idling Wave)」
		/// 获得1次[等待]次数。施加[幻象/怠波]。
		/// <color=#FF00FF>幻象/狂气</color> - 额外获得1次[等待]次数。改为施加[幻象/懒冻]。
		/// </summary>
        public static string Skill_S_Reisen_1 = "S_Reisen_1";
		/// <summary>
		/// 「幻胧月睨(Lunatic Red Eyes)」
		/// 必定命中。
		/// 使用这个技能击杀敌人时，从牌库和弃牌堆挑选1张自己的技能加入手中。
		/// </summary>
        public static string Skill_S_Reisen_10Rare = "S_Reisen_10Rare";
		/// <summary>
		/// 狂梦「疯狂的梦(Dream World)」
		/// 如果有[幻象/赤月]状态，解除[幻象/赤月]状态。
		/// <i>怎么有人在卡牌游戏拿枪指着我的头？</i>
		/// </summary>
        public static string Skill_S_Reisen_11Rare = "S_Reisen_11Rare";
		/// <summary>
		/// 生药「国士无双之药」
		/// </summary>
        public static string Skill_S_Reisen_12Rare = "S_Reisen_12Rare";
		/// <summary>
		/// 爆炸！
		/// </summary>
        public static string Skill_S_Reisen_12Rare_0 = "S_Reisen_12Rare_0";
		/// <summary>
		/// 狂符「幻视调律(Visionary Tuning)」
		/// 获得1次[等待]次数。施加[幻象/调律]。
		/// <color=#FF00FF>幻象/狂气</color> - 额外施加[幻象/狂视]。
		/// </summary>
        public static string Skill_S_Reisen_2 = "S_Reisen_2";
		/// <summary>
		/// 惑视「离圆花冠(Corolla Vision)」
		/// </summary>
        public static string Skill_S_Reisen_3 = "S_Reisen_3";
		/// <summary>
		/// 惑视「离圆花冠(Corolla Vision)」
		/// </summary>
        public static string Skill_S_Reisen_3_0 = "S_Reisen_3_0";
		/// <summary>
		/// 幻惑「花冠视线(Crown Vision)」
		/// </summary>
        public static string Skill_S_Reisen_3_1 = "S_Reisen_3_1";
		/// <summary>
		/// 弱心「丧心丧意(Demotivation)」
		/// 施加[幻象/丧心]。
		/// <color=#FF00FF>幻象/狂气</color> - 额外施加[幻象/疮痍]。
		/// </summary>
        public static string Skill_S_Reisen_4 = "S_Reisen_4";
		/// <summary>
		/// 幻弹「幻想视差(Bluff Barrage)」
		/// 受到<color=purple>&a(20%最大体力值)的痛苦伤害</color>。
		/// <color=#FF00FF>幻象/狂气</color> - 抽取1个自己的技能。
		/// </summary>
        public static string Skill_S_Reisen_5 = "S_Reisen_5";
		/// <summary>
		/// 赤眼「望见圆月(Lunatic Blast)」
		/// 如果有<color=#FF4500>幻象/赤月</color>状态，解除<color=#FF4500>幻象/赤月</color>状态。
		/// </summary>
        public static string Skill_S_Reisen_6 = "S_Reisen_6";
		/// <summary>
		/// 散符「真实之月(Invisible Full Moon)」
		/// </summary>
        public static string Skill_S_Reisen_7 = "S_Reisen_7";
		/// <summary>
		/// 幻爆「近眼花火(Mind Star Mine)」
		/// </summary>
        public static string Skill_S_Reisen_8 = "S_Reisen_8";
		/// <summary>
		/// 散符「胧月花栞(Rocket in Mist)」
		/// 改变敌人的嘲讽状态。
		/// </summary>
        public static string Skill_S_Reisen_9 = "S_Reisen_9";
		/// <summary>
		/// 波符「幻之月(Invisible Half Moon)」
		/// 抽取2个技能。
		/// 使目标身上所有可堆叠的增益效果增加1层。
		/// 使目标身上所有可堆叠的减益效果减少1层。
		/// </summary>
        public static string Skill_S_Reisen_LucyD = "S_Reisen_LucyD";
		/// <summary>
		/// 长视「赤月下(Infrared Moon)」
		/// 每当使用手中的技能时，可再次使用此技能。
		/// 在<color=#FF4500>幻象/赤月</color>或<color=#FF0000>幻象/望月</color>状态下使用时，或是<color=#FF00FF>狂气</color>层数等于0时使用时，不再造成伤害，改为解除<color=#FF4500>幻象/赤月</color>状态或<color=#FF0000>幻象/望月</color>状态，并获得2层<color=#FF00FF>狂气</color>。
		/// </summary>
        public static string Skill_S_Reisen_P = "S_Reisen_P";
		/// <summary>
		/// 幻象/乱弹
		/// </summary>
        public static string Skill_S_Reisen_P_0 = "S_Reisen_P_0";
		/// <summary>
		/// 幻象/乱弹
		/// </summary>
        public static string Skill_S_Reisen_P_1 = "S_Reisen_P_1";
		/// <summary>
		/// 幻象/乱弹
		/// </summary>
        public static string Skill_S_Reisen_P_2 = "S_Reisen_P_2";

    }

    public static class ModLocalization
    {

    }
}