using ChronoArkMod;
namespace Parsee
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 他人的不幸甜如蜜
		/// 将伤害的20%转化为体力值。
		/// </summary>
        public static string Buff_B_Parsee_0 = "B_Parsee_0";
		/// <summary>
		/// 对华丽的仁者之嫉妒
		/// 受到下一次攻击的暴击率+100%，受到暴击伤害后解除。
		/// 攻击命中后若目标依然存活，则对目标施加同名诅咒。成功施加诅咒时解除。
		/// </summary>
        public static string Buff_B_Parsee_1 = "B_Parsee_1";
		/// <summary>
		/// 桥姬的裙带菜
		/// 解除时优先抽取自身1个技能。
		/// </summary>
        public static string Buff_B_Parsee_2_0 = "B_Parsee_2_0";
		/// <summary>
		/// 无形怪物的凝视
		/// 根据目标当前的痛苦抵抗率的绝对值，等量增加所受暴击伤害（最多100%）。
		/// 攻击命中后若目标依然存活，则对目标施加同名诅咒。成功施加诅咒时解除。
		/// </summary>
        public static string Buff_B_Parsee_3 = "B_Parsee_3";
		/// <summary>
		/// 超越时间
		/// 下一次出手的该角色的技能费用+2。
		/// </summary>
        public static string Buff_B_Parsee_4 = "B_Parsee_4";
		/// <summary>
		/// 龙宫的秘宝
		/// </summary>
        public static string Buff_B_Parsee_4_0 = "B_Parsee_4_0";
		/// <summary>
		/// 大家的心理咨询师
		/// 每回合开始时生成一个“定期心理诊断”。
		/// </summary>
        public static string Buff_B_Parsee_4_1 = "B_Parsee_4_1";
		/// <summary>
		/// 剪舌雀分身
		/// 闪避一次攻击。
		/// </summary>
        public static string Buff_B_Parsee_5 = "B_Parsee_5";
		/// <summary>
		/// 舌切雀的尖鸣
		/// 受到攻击时反击(50%攻击力)。
		/// </summary>
        public static string Buff_B_Parsee_5_0 = "B_Parsee_5_0";
		/// <summary>
		/// 已逝之人
		/// </summary>
        public static string Buff_B_Parsee_6 = "B_Parsee_6";
		/// <summary>
		/// 死与新生
		/// </summary>
        public static string Buff_B_Parsee_6_0 = "B_Parsee_6_0";
		/// <summary>
		/// 妒火
		/// 叠加到 6 层时，全体敌人与全体友军受到 &a 点痛苦伤害[100%治疗力]。
		/// 那之后，优先抽取帕露西的 1 个技能，然后层数变化为 1 。
		/// </summary>
        public static string Buff_B_Parsee_P = "B_Parsee_P";
		/// <summary>
		/// 祸水
		/// 攻击命中后若目标依然存活，则(100%<sprite=0>)对目标施加1层<sprite=0>诅咒减益。
		/// 成功施加诅咒时减少1层。
		/// </summary>
        public static string Buff_B_Parsee_P_0 = "B_Parsee_P_0";
		/// <summary>
		/// 诅咒
		/// </summary>
        public static string Buff_B_Parsee_P_1 = "B_Parsee_P_1";
		/// <summary>
		/// 妒火重置
		/// </summary>
        public static string Buff_B_Parsee_P_2 = "B_Parsee_P_2";
		/// <summary>
		/// 恨符「丑时参拜第七日」
		/// </summary>
        public static string Buff_B_Parsee_Rare_1 = "B_Parsee_Rare_1";
		/// <summary>
		/// 爱姬
		/// 本次战斗中，妒火层数固定为3。
		/// 每当帕露西使用非生成技能时，自身获得1层“神德”。指向友军时，改为对目标施加1层“润泽”。
		/// 每当露西在内的其他友军使用非生成技能，帕露西获得1层“爱”。
		/// 爱的层数重置后，接下来从手中释放的3个技能的伤害量、恢复量增加33%。
		/// 可以代替濒死友军成为攻击目标。
		/// </summary>
        public static string Buff_B_Parsee_Rare_2 = "B_Parsee_Rare_2";
		/// <summary>
		/// 神德
		/// </summary>
        public static string Buff_B_Parsee_Rare_2_0 = "B_Parsee_Rare_2_0";
		/// <summary>
		/// 润泽
		/// </summary>
        public static string Buff_B_Parsee_Rare_2_1 = "B_Parsee_Rare_2_1";
		/// <summary>
		/// 爱
		/// 叠加到 7 层时，全体友军恢复 &a 的生命值[治疗力的33%]，然后层数变化为 1 。
		/// </summary>
        public static string Buff_B_Parsee_Rare_2_2 = "B_Parsee_Rare_2_2";
		/// <summary>
		/// 爱重置
		/// </summary>
        public static string Buff_B_Parsee_Rare_2_3 = "B_Parsee_Rare_2_3";
		/// <summary>
		/// 水桥帕露西
		/// Passive:
		/// 每当露西外的其他友军使用非生成技能，帕露西点燃1层“妒火”。
		/// 每当帕露西使用非生成技能时，额外对目标施加1层“祸水”。
		/// 妒火层数重置后，帕露西接下来从手中释放的2个技能的伤害量、恢复量增加100％。
		/// </summary>
        public static string Character_Parsee = "Parsee";
		/// <summary>
		/// “此桥不可渡”
		/// 当手中的技能的数量为0或所有者为同一角色时，立即释放“绝对防御”。
		/// 此效果在战斗中仅限触发1次。
		/// <color=#919191>“宇治桥姬，形单影只。”</color>
		/// </summary>
        public static string Item_Passive_R_Parsee_0 = "R_Parsee_0";
		/// <summary>
		/// 费用减少1点。释放时自身受到相当于最大体力值100%的痛苦伤害，等额增加技能伤害量。
		/// 单体攻击技能
		/// </summary>
        public static string SkillExtended_SE_Parsee_C_0 = "SE_Parsee_C_0";
		/// <summary>
		/// 释放时，为未拥有诅咒的敌人施加1层诅咒，为未拥有祸水的友军施加1层祸水(成功率130%)。
		/// 2费及以上
		/// </summary>
        public static string SkillExtended_SE_Parsee_C_1 = "SE_Parsee_C_1";
		/// <summary>
		/// 伤害量、恢复量增加100％。
		/// </summary>
        public static string SkillExtended_SE_Parsee_P_2 = "SE_Parsee_P_2";
		/// <summary>
		/// 伤害量、恢复量增加33％。
		/// </summary>
        public static string SkillExtended_SE_Parsee_Rare_2_3 = "SE_Parsee_Rare_2_3";
        public static string SkillEffect_SE_S_S_Parsee_6 = "SE_S_S_Parsee_6";
        public static string SkillEffect_SE_T_S_Parsee_0 = "SE_T_S_Parsee_0";
        public static string SkillEffect_SE_T_S_Parsee_1 = "SE_T_S_Parsee_1";
        public static string SkillEffect_SE_T_S_Parsee_2 = "SE_T_S_Parsee_2";
        public static string SkillEffect_SE_T_S_Parsee_2_0 = "SE_T_S_Parsee_2_0";
        public static string SkillEffect_SE_T_S_Parsee_3 = "SE_T_S_Parsee_3";
        public static string SkillEffect_SE_T_S_Parsee_4 = "SE_T_S_Parsee_4";
        public static string SkillEffect_SE_T_S_Parsee_4_0 = "SE_T_S_Parsee_4_0";
        public static string SkillEffect_SE_T_S_Parsee_4_1 = "SE_T_S_Parsee_4_1";
        public static string SkillEffect_SE_T_S_Parsee_4_2 = "SE_T_S_Parsee_4_2";
        public static string SkillEffect_SE_T_S_Parsee_5 = "SE_T_S_Parsee_5";
        public static string SkillEffect_SE_T_S_Parsee_5_3 = "SE_T_S_Parsee_5_3";
        public static string SkillEffect_SE_T_S_Parsee_6 = "SE_T_S_Parsee_6";
        public static string SkillEffect_SE_T_S_Parsee_7 = "SE_T_S_Parsee_7";
        public static string SkillEffect_SE_T_S_Parsee_8 = "SE_T_S_Parsee_8";
        public static string SkillEffect_SE_T_S_Parsee_Rare_1 = "SE_T_S_Parsee_Rare_1";
        public static string SkillEffect_SE_T_S_Parsee_Rare_1_0 = "SE_T_S_Parsee_Rare_1_0";
        public static string SkillEffect_SE_T_S_Parsee_Rare_2 = "SE_T_S_Parsee_Rare_2";
		/// <summary>
		/// 他人的不幸甜如蜜
		/// 点燃2层妒火。
		/// </summary>
        public static string Skill_S_Parsee_0 = "S_Parsee_0";
		/// <summary>
		/// 开花爷爷「小白的灰烬」
		/// 每有 1 层妒火，额外恢复 &a 点体力值[10%治疗力]。
		/// </summary>
        public static string Skill_S_Parsee_1 = "S_Parsee_1";
		/// <summary>
		/// 今宵依旧孤枕眠
		/// 生成1张“宇治桥姬入我心”。
		/// 点燃2层妒火。
		/// </summary>
        public static string Skill_S_Parsee_2 = "S_Parsee_2";
		/// <summary>
		/// 宇治桥姬入我心
		/// 熄灭2层妒火。
		/// </summary>
        public static string Skill_S_Parsee_2_0 = "S_Parsee_2_0";
		/// <summary>
		/// 妒符「绿眼怪物」
		/// 释放时，如果妒火层数≥4，则所有敌人持有的痛苦减益、弱化减益持续时间增加1回合；
		/// 如果妒火层数≤2，则所有队员持有的减益持续时间减少1回合。
		/// </summary>
        public static string Skill_S_Parsee_3 = "S_Parsee_3";
		/// <summary>
		/// 「今宵亦在苦候我归的，宇治的桥姬」
		/// 每当队员受到伤害时，该技能的恢复量增加，增加量与所受伤害量相等，最多增加量为自身治疗力的300%。
		/// 倒计时结束后，生成1张“乙姬之恋”。
		/// </summary>
        public static string Skill_S_Parsee_4 = "S_Parsee_4";
		/// <summary>
		/// 乙姬之恋
		/// 所有队员持有的增益持续时间增加 1 回合。
		/// 生成一张“地底桥姬”。
		/// </summary>
        public static string Skill_S_Parsee_4_0 = "S_Parsee_4_0";
		/// <summary>
		/// 地底桥姬
		/// </summary>
        public static string Skill_S_Parsee_4_1 = "S_Parsee_4_1";
		/// <summary>
		/// 定期心理诊断
		/// 解除目标 1 个随机<sprite=2>干扰减益。
		/// </summary>
        public static string Skill_S_Parsee_4_2 = "S_Parsee_4_2";
		/// <summary>
		/// 剪舌麻雀「大葛笼与小葛笼」
		/// 选择：
		/// 对谦虚的富者之记恨 - 获得300金币，点燃3层妒火。
		/// 舌切雀的尖鸣 - 受到攻击时反击(50%攻击力)，持续3回合。抽取1个技能。受到相当于最大体力值50%的痛苦伤害。
		/// </summary>
        public static string Skill_S_Parsee_5 = "S_Parsee_5";
		/// <summary>
		/// 对谦虚的富者之记恨
		/// 获得300金币，点燃3层妒火。
		/// </summary>
        public static string Skill_S_Parsee_5_1 = "S_Parsee_5_1";
		/// <summary>
		/// 舌切雀的尖鸣
		/// 受到攻击时反击(50%攻击力)，持续3回合。抽取1个技能。受到相当于最大体力值50%的痛苦伤害。
		/// </summary>
        public static string Skill_S_Parsee_5_2 = "S_Parsee_5_2";
		/// <summary>
		/// 反击
		/// </summary>
        public static string Skill_S_Parsee_5_3 = "S_Parsee_5_3";
		/// <summary>
		/// 溺亡之忆
		/// 自身受到相当于最大体力值100%的痛苦伤害。
		/// </summary>
        public static string Skill_S_Parsee_6 = "S_Parsee_6";
		/// <summary>
		/// 嫉妒「嫉妒炸弹」
		/// 额外造成&a点伤害[50%治疗力]。
		/// 释放时，每有1层妒火，额外将1张0费迅速的嫉妒炸弹加入手牌，附带放逐、1回合后弃牌。
		/// </summary>
        public static string Skill_S_Parsee_7 = "S_Parsee_7";
		/// <summary>
		/// 怨恨念法「积怨返」
		/// 握在手中时，每当队员受到来自友军的伤害时，该技能的伤害增加，增加量与所受伤害量相等，最多增加量为自身治疗力的600%。
		/// 自身处于濒死状态时，获得迅速。
		/// 所有友军处于濒死状态时，改为指向全体敌人。
		/// 妒火层数≥4时，暴击率+100%。
		/// </summary>
        public static string Skill_S_Parsee_8 = "S_Parsee_8";
		/// <summary>
		/// 面向露西的诅咒学概论
		/// 抽取 2 个技能。
		/// 选择：
		/// - 生成 1 张“痛苦诅咒”。
		/// - 额外抽取 1 个技能，生成 1 张“痛苦诅咒”，生成一张魔女的“痛苦诅咒”。
		/// - 额外抽取 1 个技能，回复 1 点法力值，随机触发血雾诅咒。
		/// </summary>
        public static string Skill_S_Parsee_LucyD = "S_Parsee_LucyD";
		/// <summary>
		/// 魔女之力
		/// 生成 1 张“痛苦诅咒”。
		/// </summary>
        public static string Skill_S_Parsee_LucyD_0 = "S_Parsee_LucyD_0";
		/// <summary>
		/// 诅咒之链
		/// 额外抽取 1 个技能，生成 1 张“痛苦诅咒”，生成 1 张魔女的“痛苦诅咒”。
		/// </summary>
        public static string Skill_S_Parsee_LucyD_1 = "S_Parsee_LucyD_1";
		/// <summary>
		/// 血雾大师
		/// 额外抽取 1 个技能，回复 1 点法力值，随机触发血雾诅咒。
		/// </summary>
        public static string Skill_S_Parsee_LucyD_2 = "S_Parsee_LucyD_2";
		/// <summary>
		/// 恨符「丑时参拜第七日」
		/// 造成 &a 点痛苦伤害[700%治疗力]。该痛苦伤害无法击杀敌人。
		/// 本回合累计获得 14 层及以上的妒火时，改为指向全体敌人。
		/// 倒计时期间，每当队员受到伤害时，该技能的伤害量增加，增加量与所受伤害量相等，上限为治疗力的700%。
		/// 倒计时期间，帕露西受到的伤害量+100%。
		/// 释放后，根据所有敌人和友军的“诅咒”层数对目标追加攻击，每次攻击造成 &b 点伤害[治疗力的40%]。
		/// </summary>
        public static string Skill_S_Parsee_Rare_1 = "S_Parsee_Rare_1";
		/// <summary>
		/// 追击
		/// </summary>
        public static string Skill_S_Parsee_Rare_1_0 = "S_Parsee_Rare_1_0";
		/// <summary>
		/// 爱姬
		/// 抽取时释放。
		/// </summary>
        public static string Skill_S_Parsee_Rare_2 = "S_Parsee_Rare_2";

    }

    public static class ModLocalization
    {

    }
}