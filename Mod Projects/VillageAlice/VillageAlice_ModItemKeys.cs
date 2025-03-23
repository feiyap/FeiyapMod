using ChronoArkMod;
namespace VillageAlice
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 噩梦
		/// 无法行动。
		/// 返回[现实]时，受到125%攻击力的混乱伤害，然后减少一层。
		/// </summary>
        public static string Buff_B_FVAlice_0 = "B_FVAlice_0";
		/// <summary>
		/// 美梦
		/// 攻击时有概率&a(60%-干扰抵抗率)攻击自己。
		/// 进入[梦境]时，受到50%+1攻击力的混乱伤害，然后减少一层。
		/// </summary>
        public static string Buff_B_FVAlice_1 = "B_FVAlice_1";
		/// <summary>
		/// 失重
		/// </summary>
        public static string Buff_B_FVAlice_5 = "B_FVAlice_5";
		/// <summary>
		/// 沉没
		/// 效果消失时，获得1层【噩梦】、1层【美梦】。
		/// </summary>
        public static string Buff_B_FVAlice_5_0 = "B_FVAlice_5_0";
		/// <summary>
		/// 现实
		/// 在[现实]中，自身所属技能将【童话】化。
		/// </summary>
        public static string Buff_B_FVAlice_P = "B_FVAlice_P";
		/// <summary>
		/// 梦境
		/// 在[梦境]中释放未被【童话】的技能将返回[现实]。
		/// </summary>
        public static string Buff_B_FVAlice_P_1 = "B_FVAlice_P_1";
		/// <summary>
		/// 童话
		/// 现实中时，技能内容不可视。释放【童话】技能后，将进入[梦境]。
		/// </summary>
        public static string SkillKeyword_Keyword_Dreamland = "Keyword_Dreamland";
        public static string SkillEffect_SE_T_S_FVAlice_0 = "SE_T_S_FVAlice_0";
        public static string SkillEffect_SE_T_S_FVAlice_1 = "SE_T_S_FVAlice_1";
        public static string SkillEffect_SE_T_S_FVAlice_2 = "SE_T_S_FVAlice_2";
        public static string SkillEffect_SE_T_S_FVAlice_3 = "SE_T_S_FVAlice_3";
        public static string SkillEffect_SE_T_S_FVAlice_4 = "SE_T_S_FVAlice_4";
        public static string SkillEffect_SE_T_S_FVAlice_4_0 = "SE_T_S_FVAlice_4_0";
        public static string SkillEffect_SE_T_S_FVAlice_5 = "SE_T_S_FVAlice_5";
        public static string SkillEffect_SE_T_S_FVAlice_5_0 = "SE_T_S_FVAlice_5_0";
        public static string SkillEffect_SE_T_S_FVAlice_6 = "SE_T_S_FVAlice_6";
        public static string SkillEffect_SE_T_S_FVAlice_7 = "SE_T_S_FVAlice_7";
		/// <summary>
		/// 童话
		/// 释放后，进入[梦境]。
		/// </summary>
        public static string SkillExtended_SkillExtended_Fairytale = "SkillExtended_Fairytale";
		/// <summary>
		/// 梦境信件
		/// 处于[梦境]时，再次释放一次此技能。
		/// 【童话】：手牌中随机一个调查队员的技能被【童话】化。
		/// </summary>
        public static string Skill_S_FVAlice_0 = "S_FVAlice_0";
		/// <summary>
		/// 美梦闹铃
		/// 【童话】：造成混乱伤害。
		/// </summary>
        public static string Skill_S_FVAlice_1 = "S_FVAlice_1";
		/// <summary>
		/// 焦糖味封蜡
		/// 将目标拥有的所有弱化、痛苦减益给予“每层弱化/痛苦减益，每回合造成30%+1的混乱伤害。”
		/// 【童话】：此技能法力值消耗增加2。
		/// </summary>
        public static string Skill_S_FVAlice_2 = "S_FVAlice_2";
		/// <summary>
		/// 邮票
		/// 【童话】：反转手牌中所有技能的【童话】化状态。
		/// </summary>
        public static string Skill_S_FVAlice_3 = "S_FVAlice_3";
		/// <summary>
		/// 梦境速递
		/// 根据处于梦境的目标数量追加攻击。追加攻击造成混乱伤害。每次追加攻击造成&a点伤害(攻击力的50%)。
		/// 【童话】：消耗法力值并释放&user的固定能力。
		/// </summary>
        public static string Skill_S_FVAlice_4 = "S_FVAlice_4";
        public static string Skill_S_FVAlice_4_0 = "S_FVAlice_4_0";
		/// <summary>
		/// 梦境失重
		/// 命中时，额外造成&a点混乱伤害(攻击力的100%)。
		/// 【童话】：附加一次性。必定命中。
		/// </summary>
        public static string Skill_S_FVAlice_5 = "S_FVAlice_5";
		/// <summary>
		/// 潮汐失重
		/// 当“梦境失重”被给予[盐渍]时丢弃原技能，将一张“潮汐失重”加入手牌中。
		/// 这个技能不会被【童话】。
		/// 这个技能造成 1 次普通伤害，1 次痛苦伤害，1 次混乱伤害。
		/// </summary>
        public static string Skill_S_FVAlice_5_0 = "S_FVAlice_5_0";
		/// <summary>
		/// 德洛丽丝摇篮曲
		/// 进入或离开[梦境]时，法力值消耗减少1。
		/// 【童话】：触发一次目标拥有的噩梦cc或美梦cc，不减少层数。
		/// </summary>
        public static string Skill_S_FVAlice_6 = "S_FVAlice_6";
		/// <summary>
		/// 掉进兔子洞
		/// 这个技能释放后，到目标行动时将一张“掉进兔子洞”加入手牌中。
		/// 释放后的此技能倒计时减少时，给予目标(<sprite=2>85%)1层美梦。
		/// </summary>
        public static string Skill_S_FVAlice_7 = "S_FVAlice_7";
		/// <summary>
		/// 爱丽丝
		/// Passive:
		/// 战斗开始时，进入[现实]。
		/// 在[现实]中，自身所属技能将【童话】化。
		/// 释放【童话】技能后，将进入[梦境]，在[梦境]中释放未被【童话】的技能将返回[现实]。
		/// </summary>
        public static string Character_VillageAlice = "VillageAlice";

    }

    public static class ModLocalization
    {

    }
}