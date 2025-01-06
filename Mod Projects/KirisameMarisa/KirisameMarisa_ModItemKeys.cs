using ChronoArkMod;
namespace KirisameMarisa
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 危险星空
		/// </summary>
        public static string Buff_B_KirisameMarisa_0 = "B_KirisameMarisa_0";
		/// <summary>
		/// 危险冲刺
		/// </summary>
        public static string Buff_B_KirisameMarisa_1 = "B_KirisameMarisa_1";
		/// <summary>
		/// 危险银河
		/// </summary>
        public static string Buff_B_KirisameMarisa_3 = "B_KirisameMarisa_3";
		/// <summary>
		/// 危险情感
		/// </summary>
        public static string Buff_B_KirisameMarisa_4 = "B_KirisameMarisa_4";
		/// <summary>
		/// 危险信号
		/// 受到攻击后减少一层。
		/// </summary>
        public static string Buff_B_KirisameMarisa_6 = "B_KirisameMarisa_6";
		/// <summary>
		/// 危险空间
		/// 手中的技能无视嘲讽。
		/// 根据当前的攻击力，获得防御力。
		/// 进入濒死状态时解除。
		/// </summary>
        public static string Buff_B_KirisameMarisa_7 = "B_KirisameMarisa_7";
		/// <summary>
		/// 危险突破
		/// </summary>
        public static string Buff_B_KirisameMarisa_7_1 = "B_KirisameMarisa_7_1";
		/// <summary>
		/// 危险改装
		/// 下一个“指向敌人”的技能获得“同时攻击所有敌人；且若目标只有一个，以暴击形式命中”的效果。
		/// </summary>
        public static string Buff_B_KirisameMarisa_8 = "B_KirisameMarisa_8";
		/// <summary>
		/// 危险冲动
		/// 速度大于0时，每多1点提供“+10%暴击率和+10%暴击伤害”，最多5点。
		/// </summary>
        public static string Buff_B_KirisameMarisa_9 = "B_KirisameMarisa_9";
		/// <summary>
		/// 危险本能
		/// 速度低于0时，每少1点提供“+10%暴击率和+10%暴击伤害”，最多5点。
		/// </summary>
        public static string Buff_B_KirisameMarisa_9_1 = "B_KirisameMarisa_9_1";
		/// <summary>
		/// 危险领域
		/// 当体力值降到0点及以下时体力值变成1点。
		/// </summary>
        public static string Buff_B_KirisameMarisa_9_2 = "B_KirisameMarisa_9_2";
		/// <summary>
		/// 危险扳机
		/// <color=#00BFFF>危险等级</color>上限+1。
		/// </summary>
        public static string Buff_B_KirisameMarisa_DangerTrigger = "B_KirisameMarisa_DangerTrigger";
		/// <summary>
		/// <color=#00BFFF>危险等级</color>
		/// </summary>
        public static string Buff_B_KirisameMarisa_P = "B_KirisameMarisa_P";
		/// <summary>
		/// 超绝偷感
		/// 造成暴击时解除。
		/// </summary>
        public static string Buff_B_KirisameMarisa_P_1 = "B_KirisameMarisa_P_1";
		/// <summary>
		/// 危险升空！
		/// 无敌。
		/// </summary>
        public static string Buff_B_KirisameMarisa_Rare_11 = "B_KirisameMarisa_Rare_11";
		/// <summary>
		/// 卫星幻觉
		/// 使用技能时减少一层，造成额外&a点伤害<color=#FF7A33>(攻击力的100%)</color>。
		/// </summary>
        public static string Buff_B_KirisameMarisa_Rare_12 = "B_KirisameMarisa_Rare_12";
		/// <summary>
		/// 开拓星空的八卦炉
		/// 攻击未暴击时，造成的伤害降低80%。
		/// </summary>
        public static string Item_Equip_E_KirisameMarisa_0 = "E_KirisameMarisa_0";
		/// <summary>
		/// 普通的扫帚
		/// 战斗开始时，若放在第一格时，使速度+5；否则使速度-5。
		/// </summary>
        public static string Item_Equip_E_KirisameMarisa_1 = "E_KirisameMarisa_1";
		/// <summary>
		/// 危险扳机
		/// 使一个角色攻击力+3，防御力-15%。
		/// 对雾雨魔理沙使用时，使她在本次轮回中<color=#00BFFF>危险等级</color>上限+1。
		/// </summary>
        public static string Item_Consume_Item_KirisameMarisa_DangerTrigger = "Item_KirisameMarisa_DangerTrigger";
		/// <summary>
		/// 雾雨魔理沙
		/// Passive:
		/// <b>东洋的西洋魔术师</b> - 回合开始时，雾雨魔理沙获得1层[超绝偷感]。
		/// <b><color=#00BFFF>危险等级</color></b> - 雾雨魔理沙每次使用攻击技能时，获得1层<color=#00BFFF>危险等级</color>。进入濒死状态时，失去所有<color=#00BFFF>危险等级</color>。
		/// 每层<color=#00BFFF>危险等级</color>提供2%攻击力和-2%防御力，并会解锁技能的额外效果。
		/// 最多拥有4层<color=#00BFFF>危险等级</color>。
		/// </summary>
        public static string Character_KirisameMarisa = "KirisameMarisa";
        public static string Character_Skin_KirisameMarisaChrist = "KirisameMarisaChrist";
        public static string Character_Skin_KirisameMarisaEclipse = "KirisameMarisaEclipse";
		/// <summary>
		/// 偶遇霖之助
		/// 你们在白色墓地遇到了森近霖之助。他在这里做什么？
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_RE_KirisameMarisa_0 = "RE_KirisameMarisa_0";
		/// <summary>
		/// 黑白魔法使的帽子
		/// 战斗开始时，使所有调查员第一次攻击必定暴击，且这次暴击伤害+100%。
		/// </summary>
        public static string Item_Passive_R_KirisameMarisa_0 = "R_KirisameMarisa_0";
		/// <summary>
		/// 无视防御，造成的伤害翻倍。
		/// </summary>
        public static string SkillExtended_SE_KirisameMarisa_7 = "SE_KirisameMarisa_7";
		/// <summary>
		/// 危险改装
		/// 同时攻击所有敌人；且若目标只有一个，以暴击形式命中。
		/// </summary>
        public static string SkillExtended_SE_KirisameMarisa_8 = "SE_KirisameMarisa_8";
		/// <summary>
		/// 释放时，雾雨魔理沙获得2层<color=#00BFFF>危险等级</color>。
		/// </summary>
        public static string SkillExtended_SE_KirisameMarisa_C_0 = "SE_KirisameMarisa_C_0";
		/// <summary>
		/// 费用+1，同时治疗所有队友。
		/// 指向单体的治疗技能
		/// </summary>
        public static string SkillExtended_SE_KirisameMarisa_C_1 = "SE_KirisameMarisa_C_1";
        public static string SkillEffect_SE_S_S_KirisameMarisa_0_4 = "SE_S_S_KirisameMarisa_0_4";
        public static string SkillEffect_SE_S_S_KirisameMarisa_1 = "SE_S_S_KirisameMarisa_1";
        public static string SkillEffect_SE_S_S_KirisameMarisa_1_3 = "SE_S_S_KirisameMarisa_1_3";
        public static string SkillEffect_SE_S_S_KirisameMarisa_7 = "SE_S_S_KirisameMarisa_7";
        public static string SkillEffect_SE_S_S_KirisameMarisa_7_4 = "SE_S_S_KirisameMarisa_7_4";
        public static string SkillEffect_SE_S_S_KirisameMarisa_8_4 = "SE_S_S_KirisameMarisa_8_4";
        public static string SkillEffect_SE_S_S_KirisameMarisa_Rare_11 = "SE_S_S_KirisameMarisa_Rare_11";
        public static string SkillEffect_SE_S_S_KirisameMarisa_Rare_12 = "SE_S_S_KirisameMarisa_Rare_12";
        public static string SkillEffect_SE_Tick_B_KirisameMarisa_3 = "SE_Tick_B_KirisameMarisa_3";
        public static string SkillEffect_SE_T_S_KirisameMarisa_0 = "SE_T_S_KirisameMarisa_0";
        public static string SkillEffect_SE_T_S_KirisameMarisa_0_4 = "SE_T_S_KirisameMarisa_0_4";
        public static string SkillEffect_SE_T_S_KirisameMarisa_1 = "SE_T_S_KirisameMarisa_1";
        public static string SkillEffect_SE_T_S_KirisameMarisa_1_3 = "SE_T_S_KirisameMarisa_1_3";
        public static string SkillEffect_SE_T_S_KirisameMarisa_2 = "SE_T_S_KirisameMarisa_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_2_2 = "SE_T_S_KirisameMarisa_2_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_2_4 = "SE_T_S_KirisameMarisa_2_4";
        public static string SkillEffect_SE_T_S_KirisameMarisa_3 = "SE_T_S_KirisameMarisa_3";
        public static string SkillEffect_SE_T_S_KirisameMarisa_3_2 = "SE_T_S_KirisameMarisa_3_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_4 = "SE_T_S_KirisameMarisa_4";
        public static string SkillEffect_SE_T_S_KirisameMarisa_4_3 = "SE_T_S_KirisameMarisa_4_3";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5 = "SE_T_S_KirisameMarisa_5";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_1 = "SE_T_S_KirisameMarisa_5_1";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_2 = "SE_T_S_KirisameMarisa_5_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_3 = "SE_T_S_KirisameMarisa_5_3";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_4 = "SE_T_S_KirisameMarisa_5_4";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_5 = "SE_T_S_KirisameMarisa_5_5";
        public static string SkillEffect_SE_T_S_KirisameMarisa_5_5_0 = "SE_T_S_KirisameMarisa_5_5_0";
        public static string SkillEffect_SE_T_S_KirisameMarisa_6 = "SE_T_S_KirisameMarisa_6";
        public static string SkillEffect_SE_T_S_KirisameMarisa_6_0 = "SE_T_S_KirisameMarisa_6_0";
        public static string SkillEffect_SE_T_S_KirisameMarisa_6_2 = "SE_T_S_KirisameMarisa_6_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_8 = "SE_T_S_KirisameMarisa_8";
        public static string SkillEffect_SE_T_S_KirisameMarisa_8_2 = "SE_T_S_KirisameMarisa_8_2";
        public static string SkillEffect_SE_T_S_KirisameMarisa_8_4 = "SE_T_S_KirisameMarisa_8_4";
        public static string SkillEffect_SE_T_S_KirisameMarisa_9_A = "SE_T_S_KirisameMarisa_9_A";
        public static string SkillEffect_SE_T_S_KirisameMarisa_9_B = "SE_T_S_KirisameMarisa_9_B";
        public static string SkillEffect_SE_T_S_KirisameMarisa_9_C = "SE_T_S_KirisameMarisa_9_C";
        public static string SkillEffect_SE_T_S_KirisameMarisa_9_D = "SE_T_S_KirisameMarisa_9_D";
        public static string SkillEffect_SE_T_S_KirisameMarisa_Rare_10 = "SE_T_S_KirisameMarisa_Rare_10";
        public static string SkillEffect_SE_T_S_KirisameMarisa_Rare_11 = "SE_T_S_KirisameMarisa_Rare_11";
		/// <summary>
		/// 魔理沙基类
		/// </summary>
        public static string SkillExtended_SkillBase_KirisameMarisa = "SkillBase_KirisameMarisa";
		/// <summary>
		/// 星符「Meteonic Shower」
		/// 本回合内可重复释放 1 次。
		/// </summary>
        public static string Skill_S_KirisameMarisa_0 = "S_KirisameMarisa_0";
		/// <summary>
		/// 星符「Polaris Unique」
		/// <color=#00BFFF>危险等级4</color> - 本回合内可重复释放 1 次。
		/// </summary>
        public static string Skill_S_KirisameMarisa_0_4 = "S_KirisameMarisa_0_4";
		/// <summary>
		/// 星符「Escape Velocity」
		/// 如果本回合没有受到伤害，以暴击形式命中。
		/// </summary>
        public static string Skill_S_KirisameMarisa_1 = "S_KirisameMarisa_1";
		/// <summary>
		/// 星符「Dragon Meteor」
		/// <color=#00BFFF>危险等级3</color> - 不再持有倒计时1。
		/// 如果本回合没有受到伤害，以暴击形式命中。
		/// </summary>
        public static string Skill_S_KirisameMarisa_1_3 = "S_KirisameMarisa_1_3";
		/// <summary>
		/// 魔符「Stardust Reverie」
		/// 目标每有1点行动倒计时（最多计算5点），这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的20%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_2 = "S_KirisameMarisa_2";
		/// <summary>
		/// 魔符「Illusion Star」
		/// <color=#00BFFF>危险等级2</color> - 目标每有1点行动倒计时（最多计算7点），这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的25%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_2_2 = "S_KirisameMarisa_2_2";
		/// <summary>
		/// 黑魔「Event Horizon」
		/// <color=#00BFFF>危险等级4</color> - 目标每有1点行动倒计时（最多计算9点），这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的30%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_2_4 = "S_KirisameMarisa_2_4";
		/// <summary>
		/// 魔符「Milky Way」
		/// 向随机敌人重复释放 2 次。
		/// </summary>
        public static string Skill_S_KirisameMarisa_3 = "S_KirisameMarisa_3";
		/// <summary>
		/// 魔空「Asteroid Belt」
		/// <color=#00BFFF>危险等级2</color> - 向随机敌人重复释放 2 次。
		/// 速度小于0时，每少1点向随机敌人再额外重复释放 1 次(最多2次)。
		/// </summary>
        public static string Skill_S_KirisameMarisa_3_2 = "S_KirisameMarisa_3_2";
		/// <summary>
		/// 恋符「Non-Directional Laser」
		/// </summary>
        public static string Skill_S_KirisameMarisa_4 = "S_KirisameMarisa_4";
		/// <summary>
		/// 恋风「Starlight Typhoon」
		/// <color=#00BFFF>危险等级3</color> - 击杀敌人时，以一半的伤害量重复释放 1 次。
		/// </summary>
        public static string Skill_S_KirisameMarisa_4_3 = "S_KirisameMarisa_4_3";
		/// <summary>
		/// 恋符「Master Spark」
		/// 速度小于0时，每少1点使这个技能暴击率提升15%。
		/// 当此技能的暴击率超过15%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5 = "S_KirisameMarisa_5";
		/// <summary>
		/// 恋符「Wide Master」
		/// <color=#00BFFF>危险等级1</color> - 速度小于0时，每少1点使这个技能暴击率提升17%。
		/// 当此技能的暴击率超过17%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_1 = "S_KirisameMarisa_5_1";
		/// <summary>
		/// 魔炮「Final Spark」
		/// <color=#00BFFF>危险等级2</color> - 速度小于0时，每少1点使这个技能暴击率提升20%。
		/// 当此技能的暴击率超过20%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_2 = "S_KirisameMarisa_5_2";
		/// <summary>
		/// 妖器「Dark Spark」
		/// <color=#00BFFF>危险等级3</color> - 速度小于0时，每少1点使这个技能暴击率提升22%。
		/// 当此技能的暴击率超过22%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_3 = "S_KirisameMarisa_5_3";
		/// <summary>
		/// 魔炮「Final Spark」
		/// <color=#00BFFF>危险等级4</color> - 速度小于0时，每少1点使这个技能暴击率提升25%。
		/// 当此技能的暴击率超过25%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_4 = "S_KirisameMarisa_5_4";
		/// <summary>
		/// 魔恋「最初也是最后的Master Sparrrrrrrrrrrrk！」
		/// <color=#00BFFF>危险等级5</color> - 速度小于0时，每少1点使这个技能暴击率提升50%。
		/// 当此技能的暴击率超过50%时，技能伤害按照超出暴击率百分比增加。
		/// 命中时以造成的伤害值追加 1 次倒计时1的攻击。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_5 = "S_KirisameMarisa_5_5";
		/// <summary>
		/// 魔恋「最初也是最后的Master Sparrrrrrrrrrrrk！」
		/// <color=#00BFFF>危险等级5</color> - 速度小于0时，每少1点使这个技能暴击率提升50%。
		/// 当此技能的暴击率超过50%时，技能伤害按照超出暴击率百分比增加。
		/// </summary>
        public static string Skill_S_KirisameMarisa_5_5_0 = "S_KirisameMarisa_5_5_0";
		/// <summary>
		/// 星符「Gravity Beat」
		/// 如果目标处于嘲讽状态，解除嘲讽状态，并对其发动追加攻击，造成&a伤害<color=#FF7A33>(攻击力的60%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_6 = "S_KirisameMarisa_6";
		/// <summary>
		/// 星符「Gravity Beat」
		/// </summary>
        public static string Skill_S_KirisameMarisa_6_0 = "S_KirisameMarisa_6_0";
		/// <summary>
		/// 星符「Eccentric Asteroid」
		/// <color=#00BFFF>危险等级2</color> - 如果目标处于嘲讽状态，解除嘲讽状态，并对所有非嘲讽状态的敌人发动追加攻击，造成&a伤害<color=#FF7A33>(攻击力的60%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_6_2 = "S_KirisameMarisa_6_2";
		/// <summary>
		/// 魔开「Open Universe」
		/// 如果自身已经拥有[危险空间]，则解除[危险空间]，抽取1个技能并恢复1点法力值。
		/// </summary>
        public static string Skill_S_KirisameMarisa_7 = "S_KirisameMarisa_7";
		/// <summary>
		/// 魔十字「Grand Cross」
		/// 如果自身已经拥有[危险空间]，则解除[危险空间]，抽取1个技能并恢复1点法力值。
		/// <color=#00BFFF>危险等级4</color> - 确认弃牌库中自己的技能，选择 1 个加入手中。
		/// </summary>
        public static string Skill_S_KirisameMarisa_7_4 = "S_KirisameMarisa_7_4";
		/// <summary>
		/// 仪符「Orrery's Sun」
		/// </summary>
        public static string Skill_S_KirisameMarisa_8 = "S_KirisameMarisa_8";
		/// <summary>
		/// 天仪「Orrery's Solar System」
		/// <color=#00BFFF>危险等级2</color> - 可以指向友军。
		/// </summary>
        public static string Skill_S_KirisameMarisa_8_2 = "S_KirisameMarisa_8_2";
		/// <summary>
		/// 天仪「Orrery's Universe」
		/// <color=#00BFFF>危险等级4</color> - 可以指向友军。
		/// 自身同时获得1层[危险改装]。
		/// </summary>
        public static string Skill_S_KirisameMarisa_8_4 = "S_KirisameMarisa_8_4";
		/// <summary>
		/// 光符「Earth Light Ray」
		/// 选择 - 使一个友军获得“速度+2，速度大于0时，每多1点提供+10%暴击率，+10%暴击伤害，最多5点”的增益，持续3回合；
		/// 或使一个友军获得“速度-2，速度小于0时，每少1点提供+10%暴击率，+10%暴击伤害，最多5点”的增益，持续3回合。
		/// </summary>
        public static string Skill_S_KirisameMarisa_9 = "S_KirisameMarisa_9";
		/// <summary>
		/// 光击「Shoot the Moon」
		/// <color=#00BFFF>危险等级3</color> - 使一个友军获得“速度+2，速度大于0时，每多1点提供+10%暴击率，+10%暴击伤害，最多5点”的增益，持续3回合；
		/// 或使一个友军获得“速度-2，速度小于0时，每少1点提供+10%暴击率，+10%暴击伤害，最多5点”的增益，持续3回合。
		/// 额外使自身获得“本回合内体力值不会降低至1以下”的增益。
		/// </summary>
        public static string Skill_S_KirisameMarisa_9_3 = "S_KirisameMarisa_9_3";
		/// <summary>
		/// 危险冲动
		/// </summary>
        public static string Skill_S_KirisameMarisa_9_A = "S_KirisameMarisa_9_A";
		/// <summary>
		/// 危险本能
		/// </summary>
        public static string Skill_S_KirisameMarisa_9_B = "S_KirisameMarisa_9_B";
		/// <summary>
		/// 危险冲动
		/// </summary>
        public static string Skill_S_KirisameMarisa_9_C = "S_KirisameMarisa_9_C";
		/// <summary>
		/// 危险本能
		/// </summary>
        public static string Skill_S_KirisameMarisa_9_D = "S_KirisameMarisa_9_D";
		/// <summary>
		/// 魔废「Deep Ecological Bomb」
		/// 抽取1个技能。依据当前速度：
		/// 大于0：额外抽取1个技能，恢复1点法力值。
		/// 等于0：额外抽取1个技能。
		/// 小于0：恢复3点法力值。
		/// </summary>
        public static string Skill_S_KirisameMarisa_LucyD = "S_KirisameMarisa_LucyD";
		/// <summary>
		/// 魔炮「Final Master Spark」
		/// 握在手中 1 回合后才可使用。
		/// 从手中释放技能时，根据其消耗的费用减少该技能的费用。
		/// 每减少1点费用，该技能造成的伤害减少一半。
		/// </summary>
        public static string Skill_S_KirisameMarisa_Rare_10 = "S_KirisameMarisa_Rare_10";
		/// <summary>
		/// 彗星「Blazing Star」
		/// 倒计时期间，自身处于无敌状态，但无法行动。
		/// 释放时，速度大于0时，每有1点速度，这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的50%)</color>。
		/// </summary>
        public static string Skill_S_KirisameMarisa_Rare_11 = "S_KirisameMarisa_Rare_11";
		/// <summary>
		/// 星符「Satellite Illusion」
		/// 抽取1个技能。
		/// <i><color=#696969>似乎能和其他稀有符卡共鸣，引发出更加独特的力量……</color></i>
		/// </summary>
        public static string Skill_S_KirisameMarisa_Rare_12 = "S_KirisameMarisa_Rare_12";
		/// <summary>
		/// 超时空「我们的幻想乡！」
		/// <color=#FFD700>*「梦想天生」+星符「Satellite Illusion」*</color>
		/// 从所有《东方project》系列的mod角色的稀有技能中，随机生成1个，并为其选择持有者。
		/// 重复释放，直到手牌达到上限为止。
		/// <i><color=#00BFFF>上啊灵梦！让他们见识一下我们的厉害！</color></i>
		/// <i><color=#FF4500>啊啊！可不能在这里输了！</color></i>
		/// <i><color=#00BFFF>为</color><color=#FF4500>了</color><b><color=#FFD700>辉光闪耀的幻想乡！</color></b></i>
		/// </summary>
        public static string Skill_S_Satellite_Reimu = "S_Satellite_Reimu";

    }

    public static class ModLocalization
    {

    }
}