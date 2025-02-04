using ChronoArkMod;
namespace HinanawiTenshi
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 气焰万丈
		/// </summary>
        public static string Buff_Boss_B_Tenshi_0 = "Boss_B_Tenshi_0";
		/// <summary>
		/// 无念无想
		/// </summary>
        public static string Buff_Boss_B_Tenshi_4 = "Boss_B_Tenshi_4";
		/// <summary>
		/// 天人之体
		/// 受到任何不小于2回合的减益效果时，该效果持续时间降低1回合。
		/// 受到单次超过100的伤害时，该伤害以对数降低。每次触发这个效果时，自身获得5个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// 当自身没有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>时，受到的伤害降低90%。
		/// 免疫秒杀。
		/// </summary>
        public static string Buff_Boss_B_Tenshi_P = "Boss_B_Tenshi_P";
		/// <summary>
		/// 灵想「镇守大地之石」
		/// 回合开始时，自身获得5个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// 受到伤害时，将1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>转移至伤害来源。
		/// 当同时拥有20个<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>时，天子将进入天人姿态。
		/// </summary>
        public static string Buff_Boss_B_Tenshi_Phase_1 = "Boss_B_Tenshi_Phase_1";
		/// <summary>
		/// 天人之姿
		/// 天子解放<color=#B22222>十</color><color=#00BFFF>之</color><color=#00FF7F>权</color><color=#FFD700>能</color>。
		/// 免疫所有减益。
		/// 每回合行动次数+1。
		/// <color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>的持续时间变为永久。
		/// 在战斗中牌库洗牌时，若需要洗牌的技能数为20及以上，则使当前回合数+1。
		/// </summary>
        public static string Buff_Boss_B_Tenshi_Phase_2 = "Boss_B_Tenshi_Phase_2";
		/// <summary>
		/// 剑技「气焰万丈之剑」
		/// </summary>
        public static string Skill_Boss_S_Tenshi_0 = "Boss_S_Tenshi_0";
		/// <summary>
		/// 地符「不让土壤之剑」
		/// 攻击后，若目标不是濒死状态，则再次攻击目标。
		/// 每次命中获得1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_Boss_S_Tenshi_1 = "Boss_S_Tenshi_1";
		/// <summary>
		/// 非想「非想非非想之剑」
		/// 指向持有最多增益的调查员。
		/// 目标身上每持有1个增益，这个技能的伤害提升1.1倍。
		/// 使目标持有的所有增益减少1回合持续时间。
		/// </summary>
        public static string Skill_Boss_S_Tenshi_2 = "Boss_S_Tenshi_2";
		/// <summary>
		/// 天气「绯想天促」
		/// 每次命中获得1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_Boss_S_Tenshi_3 = "Boss_S_Tenshi_3";
		/// <summary>
		/// 气符「无念无想的境界」
		/// 解除自己持有的痛苦、弱化减益。
		/// 依据解除的减益数量，获得等量的<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_Boss_S_Tenshi_4 = "Boss_S_Tenshi_4";
		/// <summary>
		/// 「全人类的绯想天」
		/// 丢弃所有技能。抽取等量的技能。
		/// </summary>
        public static string Skill_Boss_S_Tenshi_5 = "Boss_S_Tenshi_5";
		/// <summary>
		/// 比那名居天子
		/// </summary>
        public static string Enemy_Boss_Tenshih = "Boss_Tenshih";
		/// <summary>
		/// 天气 - 快晴
		/// </summary>
        public static string Buff_B_Tenki_1 = "B_Tenki_1";
		/// <summary>
		/// 天气 - 疏雨
		/// 手中的稀有技能的费用降低1点。
		/// </summary>
        public static string Buff_B_Tenki_10 = "B_Tenki_10";
		/// <summary>
		/// 天气 - 风雨
		/// </summary>
        public static string Buff_B_Tenki_11 = "B_Tenki_11";
		/// <summary>
		/// 天气 - 晴岚
		/// 追加攻击/反击造成的伤害提升33%。
		/// </summary>
        public static string Buff_B_Tenki_12 = "B_Tenki_12";
		/// <summary>
		/// 天气 - 川雾
		/// 使手中的技能获得“无视嘲讽”。
		/// </summary>
        public static string Buff_B_Tenki_13 = "B_Tenki_13";
		/// <summary>
		/// 天气 - 台风
		/// </summary>
        public static string Buff_B_Tenki_14 = "B_Tenki_14";
		/// <summary>
		/// 天气 - 极光
		/// 获得随机天气的面板属性。每次使用技能后改变。
		/// 当前生效的天气为：&a
		/// </summary>
        public static string Buff_B_Tenki_15 = "B_Tenki_15";
		/// <summary>
		/// 天气 - 凪
		/// 回合结束时，治疗10点体力。
		/// </summary>
        public static string Buff_B_Tenki_16 = "B_Tenki_16";
		/// <summary>
		/// 天气 - 钻石尘
		/// </summary>
        public static string Buff_B_Tenki_17 = "B_Tenki_17";
		/// <summary>
		/// 天气 - 黄沙
		/// </summary>
        public static string Buff_B_Tenki_18 = "B_Tenki_18";
		/// <summary>
		/// 天气 - 烈日
		/// </summary>
        public static string Buff_B_Tenki_19 = "B_Tenki_19";
		/// <summary>
		/// 天气 - 雾雨
		/// </summary>
        public static string Buff_B_Tenki_2 = "B_Tenki_2";
		/// <summary>
		/// 天气 - 梅雨
		/// </summary>
        public static string Buff_B_Tenki_20 = "B_Tenki_20";
		/// <summary>
		/// 天气 - 云天
		/// 使手中最上方和最下方的技能的伤害量或治疗量提升6点。
		/// </summary>
        public static string Buff_B_Tenki_3 = "B_Tenki_3";
		/// <summary>
		/// 天气 - 苍天
		/// 本回合内每使用1个技能，获得“攻击力+1%、暴击率+1%、命中率+1%”。
		/// </summary>
        public static string Buff_B_Tenki_4 = "B_Tenki_4";
		/// <summary>
		/// 天气 - 雹
		/// </summary>
        public static string Buff_B_Tenki_5 = "B_Tenki_5";
		/// <summary>
		/// 天气 - 花云
		/// </summary>
        public static string Buff_B_Tenki_6 = "B_Tenki_6";
		/// <summary>
		/// 天气 - 浓雾
		/// 造成伤害的10%治疗自己。
		/// </summary>
        public static string Buff_B_Tenki_7 = "B_Tenki_7";
		/// <summary>
		/// 天气 - 雪
		/// </summary>
        public static string Buff_B_Tenki_8 = "B_Tenki_8";
		/// <summary>
		/// 天气 - 太阳雨
		/// 使固定技能附带基本功。
		/// </summary>
        public static string Buff_B_Tenki_9 = "B_Tenki_9";
		/// <summary>
		/// <color=#97FFFF>气质</color>显现
		/// </summary>
        public static string Buff_B_Tenshi_1 = "B_Tenshi_1";
		/// <summary>
		/// 气候操纵
		/// 下个回合开始时，展示所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，选择并获得其中一个。
		/// </summary>
        public static string Buff_B_Tenshi_4 = "B_Tenshi_4";
		/// <summary>
		/// 无念无想
		/// </summary>
        public static string Buff_B_Tenshi_7 = "B_Tenshi_7";
		/// <summary>
		/// 气焰万丈
		/// </summary>
        public static string Buff_B_Tenshi_8 = "B_Tenshi_8";
		/// <summary>
		/// 勇气凛凛
		/// 获得增益时抽取1个技能（最多触发4次）。
		/// </summary>
        public static string Buff_B_Tenshi_LucyD = "B_Tenshi_LucyD";
		/// <summary>
		/// 天人之体
		/// 当前拥有的<color=#97FFFF><color=#97FFFF>气质</color></color>：&a
		/// </summary>
        public static string Buff_B_Tenshi_P = "B_Tenshi_P";
		/// <summary>
		/// 天气 - 绯想天
		/// 手中的技能附加迅速。
		/// </summary>
        public static string Buff_B_Tenshi_Rare_3 = "B_Tenshi_Rare_3";
		/// <summary>
		/// 绯想天
		/// 每个回合开始时，为所有友军施加随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Buff_B_Tenshi_Rare_3_1 = "B_Tenshi_Rare_3_1";
		/// <summary>
		/// 绯想之剑
		/// 回合开始时，获得3个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Item_Equip_E_Tenshi_0 = "E_Tenshi_0";
		/// <summary>
		/// 比那名居天子
		/// Passive:
		/// <b>幼小的有顶天</b> - 当自己身上没有减益效果时，造成的伤害提升10%。
		/// <b>操纵大地程度的能力</b> - 自身被施加增益效果时，比那名居天子会获得1点<color=#97FFFF><color=#97FFFF>气质</color></color>。
		/// <b>天人之姿</b> - 受到的伤害降低1点。
		/// <b><color=#97FFFF>天启X</color></b> - 比那名居天子身上拥有的<color=#97FFFF><color=#97FFFF>气质</color></color>超过X点时，释放技能会消耗X点<color=#97FFFF><color=#97FFFF>气质</color></color>，触发额外效果。
		/// <b><color=#B22222>十</color><color=#00BFFF>之</color><color=#00FF7F>权</color><color=#FFD700>能</color></b> - 比那名居天子仍然在修行之中，尚未解放真正的力量……
		/// </summary>
        public static string Character_HinanawiTenshi = "HinanawiTenshi";
        public static string EnemyQueue_Queue_Boss_Tenshi = "Queue_Boss_Tenshi";
		/// <summary>
		/// 奇怪的博丽神社
		/// 你们来到了“博丽神社”……不，只能说形似“博丽神社”的地方。方舟中不可能真的存在博丽神社，那这里究竟是什么地方？
		/// 就在你们思考的时候，在神社中看到了一位独自屹立在鸟居之下的少女。
		/// ——按照幻想乡的默认规则，一场恶战看来是无法避免了。
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_RE_Tenshi_Boss = "RE_Tenshi_Boss";
		/// <summary>
		/// 天空之要石
		/// 使调查员获得的不低于2回合的增益持续时间延长1回合；
		/// 使调查员获得的不低于2回合的减益持续时间降低1回合。
		/// </summary>
        public static string Item_Passive_R_Tenshi_0 = "R_Tenshi_0";
        public static string SkillEffect_SE_S_Boss_S_Tenshi_0 = "SE_S_Boss_S_Tenshi_0";
        public static string SkillEffect_SE_S_Boss_S_Tenshi_4 = "SE_S_Boss_S_Tenshi_4";
        public static string SkillEffect_SE_S_S_Tenki_1 = "SE_S_S_Tenki_1";
        public static string SkillEffect_SE_S_S_Tenki_10 = "SE_S_S_Tenki_10";
        public static string SkillEffect_SE_S_S_Tenki_11 = "SE_S_S_Tenki_11";
        public static string SkillEffect_SE_S_S_Tenki_12 = "SE_S_S_Tenki_12";
        public static string SkillEffect_SE_S_S_Tenki_13 = "SE_S_S_Tenki_13";
        public static string SkillEffect_SE_S_S_Tenki_14 = "SE_S_S_Tenki_14";
        public static string SkillEffect_SE_S_S_Tenki_15 = "SE_S_S_Tenki_15";
        public static string SkillEffect_SE_S_S_Tenki_16 = "SE_S_S_Tenki_16";
        public static string SkillEffect_SE_S_S_Tenki_17 = "SE_S_S_Tenki_17";
        public static string SkillEffect_SE_S_S_Tenki_18 = "SE_S_S_Tenki_18";
        public static string SkillEffect_SE_S_S_Tenki_19 = "SE_S_S_Tenki_19";
        public static string SkillEffect_SE_S_S_Tenki_2 = "SE_S_S_Tenki_2";
        public static string SkillEffect_SE_S_S_Tenki_20 = "SE_S_S_Tenki_20";
        public static string SkillEffect_SE_S_S_Tenki_3 = "SE_S_S_Tenki_3";
        public static string SkillEffect_SE_S_S_Tenki_4 = "SE_S_S_Tenki_4";
        public static string SkillEffect_SE_S_S_Tenki_5 = "SE_S_S_Tenki_5";
        public static string SkillEffect_SE_S_S_Tenki_6 = "SE_S_S_Tenki_6";
        public static string SkillEffect_SE_S_S_Tenki_7 = "SE_S_S_Tenki_7";
        public static string SkillEffect_SE_S_S_Tenki_8 = "SE_S_S_Tenki_8";
        public static string SkillEffect_SE_S_S_Tenki_9 = "SE_S_S_Tenki_9";
        public static string SkillEffect_SE_S_S_Tenshi_7 = "SE_S_S_Tenshi_7";
        public static string SkillEffect_SE_S_S_Tenshi_Rare_3 = "SE_S_S_Tenshi_Rare_3";
		/// <summary>
		/// 云天
		/// </summary>
        public static string SkillExtended_SE_Tenki_3 = "SE_Tenki_3";
		/// <summary>
		/// 费用-1，使目标获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// 指向队友
		/// </summary>
        public static string SkillExtended_SE_Tenshi_C_0 = "SE_Tenshi_C_0";
		/// <summary>
		/// 抽取到手中时，根据技能的费用，自身和比那名居天子获得相同数量的随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string SkillExtended_SE_Tenshi_C_1 = "SE_Tenshi_C_1";
		/// <summary>
		/// 绯想天
		/// </summary>
        public static string SkillExtended_SE_Tenshi_Rare_3 = "SE_Tenshi_Rare_3";
        public static string SkillEffect_SE_T_Boss_S_Tenshi_1 = "SE_T_Boss_S_Tenshi_1";
        public static string SkillEffect_SE_T_Boss_S_Tenshi_2 = "SE_T_Boss_S_Tenshi_2";
        public static string SkillEffect_SE_T_Boss_S_Tenshi_3 = "SE_T_Boss_S_Tenshi_3";
        public static string SkillEffect_SE_T_S_Tenshi_0 = "SE_T_S_Tenshi_0";
        public static string SkillEffect_SE_T_S_Tenshi_1 = "SE_T_S_Tenshi_1";
        public static string SkillEffect_SE_T_S_Tenshi_2 = "SE_T_S_Tenshi_2";
        public static string SkillEffect_SE_T_S_Tenshi_3 = "SE_T_S_Tenshi_3";
        public static string SkillEffect_SE_T_S_Tenshi_4 = "SE_T_S_Tenshi_4";
        public static string SkillEffect_SE_T_S_Tenshi_6 = "SE_T_S_Tenshi_6";
        public static string SkillEffect_SE_T_S_Tenshi_8 = "SE_T_S_Tenshi_8";
        public static string SkillEffect_SE_T_S_Tenshi_LucyD = "SE_T_S_Tenshi_LucyD";
        public static string SkillEffect_SE_T_S_Tenshi_Rare_1 = "SE_T_S_Tenshi_Rare_1";
        public static string SkillEffect_SE_T_S_Tenshi_Rare_2 = "SE_T_S_Tenshi_Rare_2";
        public static string SkillEffect_SE_T_S_Tenshi_Rare_3 = "SE_T_S_Tenshi_Rare_3";
        public static string SkillEffect_SE_T_S_Tenshi_Rare_4 = "SE_T_S_Tenshi_Rare_4";
		/// <summary>
		/// 天子基类
		/// </summary>
        public static string SkillExtended_SkillBase_Tenshi = "SkillBase_Tenshi";
		/// <summary>
		/// 天气 - 快晴
		/// </summary>
        public static string Skill_S_Tenki_1 = "S_Tenki_1";
		/// <summary>
		/// 天气 - 疏雨
		/// </summary>
        public static string Skill_S_Tenki_10 = "S_Tenki_10";
		/// <summary>
		/// 天气 - 风雨
		/// </summary>
        public static string Skill_S_Tenki_11 = "S_Tenki_11";
		/// <summary>
		/// 天气 - 晴岚
		/// </summary>
        public static string Skill_S_Tenki_12 = "S_Tenki_12";
		/// <summary>
		/// 天气 - 川雾
		/// </summary>
        public static string Skill_S_Tenki_13 = "S_Tenki_13";
		/// <summary>
		/// 天气 - 台风
		/// </summary>
        public static string Skill_S_Tenki_14 = "S_Tenki_14";
		/// <summary>
		/// 天气 - 极光
		/// </summary>
        public static string Skill_S_Tenki_15 = "S_Tenki_15";
		/// <summary>
		/// 天气 - 凪
		/// </summary>
        public static string Skill_S_Tenki_16 = "S_Tenki_16";
		/// <summary>
		/// 天气 - 钻石尘
		/// </summary>
        public static string Skill_S_Tenki_17 = "S_Tenki_17";
		/// <summary>
		/// 天气 - 黄沙
		/// </summary>
        public static string Skill_S_Tenki_18 = "S_Tenki_18";
		/// <summary>
		/// 天气 - 烈日
		/// </summary>
        public static string Skill_S_Tenki_19 = "S_Tenki_19";
		/// <summary>
		/// 天气 - 雾雨
		/// </summary>
        public static string Skill_S_Tenki_2 = "S_Tenki_2";
		/// <summary>
		/// 天气 - 梅雨
		/// </summary>
        public static string Skill_S_Tenki_20 = "S_Tenki_20";
		/// <summary>
		/// 天气 - 云天
		/// </summary>
        public static string Skill_S_Tenki_3 = "S_Tenki_3";
		/// <summary>
		/// 天气 - 苍天
		/// </summary>
        public static string Skill_S_Tenki_4 = "S_Tenki_4";
		/// <summary>
		/// 天气 - 雹
		/// </summary>
        public static string Skill_S_Tenki_5 = "S_Tenki_5";
		/// <summary>
		/// 天气 - 花云
		/// </summary>
        public static string Skill_S_Tenki_6 = "S_Tenki_6";
		/// <summary>
		/// 天气 - 浓雾
		/// </summary>
        public static string Skill_S_Tenki_7 = "S_Tenki_7";
		/// <summary>
		/// 天气 - 雪
		/// </summary>
        public static string Skill_S_Tenki_8 = "S_Tenki_8";
		/// <summary>
		/// 天气 - 太阳雨
		/// </summary>
        public static string Skill_S_Tenki_9 = "S_Tenki_9";
		/// <summary>
		/// 天符「天道是非之剑」
		/// 自身获得3个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// <color=#97FFFF>天启8</color> - 使所有队友获得3个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_S_Tenshi_0 = "S_Tenshi_0";
		/// <summary>
		/// 地符「不让土壤之剑」
		/// 如果自己身上有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，消耗1个<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，使目标获得“受到伤害量+15%”，持续3回合。
		/// <color=#97FFFF>天启5</color> - 重复释放1次。
		/// </summary>
        public static string Skill_S_Tenshi_1 = "S_Tenshi_1";
		/// <summary>
		/// 非想「非想非非想之剑」
		/// 消耗自身所有<color=#97FFFF>气质</color>。每点消耗的<color=#97FFFF>气质</color>使这个技能造成的伤害提升1.1倍。
		/// 当前提升的倍数为：&a
		/// 当前造成的伤害为：&b
		/// </summary>
        public static string Skill_S_Tenshi_2 = "S_Tenshi_2";
		/// <summary>
		/// 天气「绯想天促」
		/// 同时对目标左右的单位释放，造成一半的伤害。
		/// 命中时，自身获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// <color=#97FFFF>天启7</color> - 如果场上的敌人数量大于1，改为指向“所有敌人”。
		/// </summary>
        public static string Skill_S_Tenshi_3 = "S_Tenshi_3";
		/// <summary>
		/// 气符「天启气象之剑」
		/// 展示所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，选择并获得其中一个。
		/// <color=#97FFFF>天启4</color> - 下个回合开始时，展示所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，选择并获得其中一个。
		/// </summary>
        public static string Skill_S_Tenshi_4 = "S_Tenshi_4";
		/// <summary>
		/// 要石「天空之灵石」
		/// 施加1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// 如果自己身上有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，消耗1个<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，额外施加1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// <color=#97FFFF>天启1</color> - 额外施加1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_S_Tenshi_5 = "S_Tenshi_5";
		/// <summary>
		/// 地符「一击震乾坤」
		/// 依据自身持有的增益数量，每个提升10%暴击率。
		/// <color=#97FFFF>天启6</color> - 额外造成&a点伤害<color=#FF7A33>(攻击力的70%)</color>。
		/// </summary>
        public static string Skill_S_Tenshi_6 = "S_Tenshi_6";
		/// <summary>
		/// 气符「无念无想的境界」
		/// 依据自身持有的增益数量，获得那个数量的<color=#97FFFF>气质</color>。
		/// <color=#97FFFF>天启3</color> - 解除自己持有的痛苦、弱化减益。
		/// </summary>
        public static string Skill_S_Tenshi_7 = "S_Tenshi_7";
		/// <summary>
		/// 剑技「气焰万丈之剑」
		/// <color=#97FFFF>天启2</color> - 将自己持有的所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>施加给其他队友。获得那个数量的<color=#97FFFF>气质</color>。
		/// </summary>
        public static string Skill_S_Tenshi_8 = "S_Tenshi_8";
		/// <summary>
		/// 气性「勇气凛凛之剑」
		/// </summary>
        public static string Skill_S_Tenshi_LucyD = "S_Tenshi_LucyD";
		/// <summary>
		/// 「全人类的绯想天」
		/// 消耗所有<color=#97FFFF>气质</color>，每点消耗的<color=#97FFFF>气质</color>使这个技能向随机敌人重复释放 1 次。
		/// 每次释放，自身获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
		/// </summary>
        public static string Skill_S_Tenshi_Rare_1 = "S_Tenshi_Rare_1";
		/// <summary>
		/// 地震「先忧后乐之剑」
		/// <color=#97FFFF>天启9</color> - 改为指向所有敌人。
		/// </summary>
        public static string Skill_S_Tenshi_Rare_2 = "S_Tenshi_Rare_2";
		/// <summary>
		/// 天地「俯瞰世界的遥远的大地啊」
		/// 战斗开始时，放在牌库最上方。
		/// </summary>
        public static string Skill_S_Tenshi_Rare_3 = "S_Tenshi_Rare_3";
		/// <summary>
		/// ＊大气圈尽在吾之手中＊
		/// <color=#97FFFF>天启10</color> - 获得所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，并且持续时间变为永久。
		/// <color=#696969><i>在第一颗星的下方，神给予了无二的启示。
		/// 面对再三再四造下罪业的人类， 要予以宽恕而非制裁。
		/// 她颔首，并向神发誓将献上自己的五识。
		/// 这个世界是神所创造出的巨大双六棋盘，而她是背负着七丈光芒的一颗渺小棋子。
		/// 当八灾与试炼降临之际，闪烁的九曜星将予以指引，
		/// 克服旅途中的一切苦难后，她最终可得十全之权能。</i></color>
		/// </summary>
        public static string Skill_S_Tenshi_Rare_4 = "S_Tenshi_Rare_4";
        public static string UnlockWindow_Unlock_HinanawiTenshi = "Unlock_HinanawiTenshi";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 哦呀，居然还有人能顺利到达这里。
		/// English:
		/// 哦呀，居然还有人能顺利到达这里。
		/// Japanese:
		/// おや、ここまで来る人がいるなんて。 
		/// Chinese:
		/// 哦呀，居然还有人能顺利到达这里。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText1 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text1");
		/// <summary>
		/// Korean:
		/// 正好！吾在这里停留得也有些闷了。
		/// English:
		/// 正好！吾在这里停留得也有些闷了。
		/// Japanese:
		/// ちょうどいいわ！ここに居るのは少し飽きてきたのよ。 
		/// Chinese:
		/// 正好！吾在这里停留得也有些闷了。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText2 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text2");
		/// <summary>
		/// Korean:
		/// 就用你们来解解闷吧！
		/// English:
		/// 就用你们来解解闷吧！
		/// Japanese:
		/// 退屈しのぎにあなた達にも付き合ってもらうわ！ 
		/// Chinese:
		/// 就用你们来解解闷吧！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText3 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text3");
		/// <summary>
		/// Korean:
		/// 雕虫小技！就凭这种歪门邪道也想战胜吾？
		/// English:
		/// 雕虫小技！就凭这种歪门邪道也想战胜吾？
		/// Japanese:
		/// この程度で！ こんな小細工で私に勝てると思っているのですか？
		/// Chinese:
		/// 雕虫小技！就凭这种歪门邪道也想战胜吾？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText4 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text4");
		/// <summary>
		/// Korean:
		/// 脚踏实地一决胜负吧！
		/// English:
		/// 脚踏实地一决胜负吧！
		/// Japanese:
		/// 地に足をつけて戦おうじゃないか！ 
		/// Chinese:
		/// 脚踏实地一决胜负吧！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText5 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text5");
		/// <summary>
		/// Korean:
		/// 秒杀抵抗！
		/// English:
		/// 秒杀抵抗！
		/// Japanese:
		/// 即死レジスト！
		/// Chinese:
		/// 秒杀抵抗！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_TenshiText6 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text6");
		/// <summary>
		/// Korean:
		/// 灵梦！总算等到你了哇。你来的也太慢了！
		/// English:
		/// 灵梦！总算等到你了哇。你来的也太慢了！
		/// Japanese:
		/// 霊夢！待ってたわ。遅すぎる！ 
		/// Chinese:
		/// 灵梦！总算等到你了哇。你来的也太慢了！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText1 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text1");
		/// <summary>
		/// Korean:
		/// ——啊哈哈！什么呀，灵梦！你明明知道答案的不对吗？！
		/// English:
		/// ——啊哈哈！什么呀，灵梦！你明明知道答案的不对吗？！
		/// Japanese:
		/// あははは！何だこれ、霊夢！答えが間違っていることはわかってるよね？ 
		/// Chinese:
		/// ——啊哈哈！什么呀，灵梦！你明明知道答案的不对吗？！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText10 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text10");
		/// <summary>
		/// Korean:
		/// 想要从吾这里得到这个，就先战胜吾吧！
		/// English:
		/// 想要从吾这里得到这个，就先战胜吾吧！
		/// Japanese:
		/// これを望むのならば、まず私を倒してみなさい！ 
		/// Chinese:
		/// 想要从吾这里得到这个，就先战胜吾吧！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText11 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text11");
		/// <summary>
		/// Korean:
		/// …………唉，我就知道会是这样啊……
		/// English:
		/// …………唉，我就知道会是这样啊……
		/// Japanese:
		/// …………ああ、こうなるとは思っていた…… 
		/// Chinese:
		/// …………唉，我就知道会是这样啊……
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText12 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text12");
		/// <summary>
		/// Korean:
		/// 露西，我们要应战了！
		/// English:
		/// 露西，我们要应战了！
		/// Japanese:
		/// ルシー、戦う準備はできています！ 
		/// Chinese:
		/// 露西，我们要应战了！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText13 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text13");
		/// <summary>
		/// Korean:
		/// 什么……？天子？为什么你会在这里……
		/// English:
		/// 什么……？天子？为什么你会在这里……
		/// Japanese:
		/// あれ……？天子？どうしてここにいるの……
		/// Chinese:
		/// 什么……？天子？为什么你会在这里……
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText2 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text2");
		/// <summary>
		/// Korean:
		/// 吾在这里看到了很像博丽神社的地方，想着幻想乡的同伴会不会也来这里，于是一直在这里等着呢。
		/// English:
		/// 吾在这里看到了很像博丽神社的地方，想着幻想乡的同伴会不会也来这里，于是一直在这里等着呢。
		/// Japanese:
		/// 博麗神社によく似た場所があったので、幻想郷の仲間もここに来ると思い、待っていました。 
		/// Chinese:
		/// 吾在这里看到了很像博丽神社的地方，想着幻想乡的同伴会不会也来这里，于是一直在这里等着呢。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText3 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text3");
		/// <summary>
		/// Korean:
		/// 跟在你后边的这个小女孩是……？
		/// English:
		/// 跟在你后边的这个小女孩是……？
		/// Japanese:
		/// あなたについてくる少女は誰......？
		/// Chinese:
		/// 跟在你后边的这个小女孩是……？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText4 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text4");
		/// <summary>
		/// Korean:
		/// 她是我的朋友，露西。我们正在寻找时光之影，你有什么头绪吗？
		/// English:
		/// 她是我的朋友，露西。我们正在寻找时光之影，你有什么头绪吗？
		/// Japanese:
		/// 彼女は友達のルシー。タイムシェイドを探しているのだけど、手がかりはない？
		/// Chinese:
		/// 她是我的朋友，露西。我们正在寻找时光之影，你有什么头绪吗？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText5 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text5");
		/// <summary>
		/// Korean:
		/// 时光之影……不会是这个东西吧？吾在神社里捡到的怪东西呢。
		/// English:
		/// 时光之影……不会是这个东西吧？吾在神社里捡到的怪东西呢。
		/// Japanese:
		/// タイムシェイド……もしかしてこれだろうか？神社で見つけた不思議なものです。 
		/// Chinese:
		/// 时光之影……不会是这个东西吧？吾在神社里捡到的怪东西呢。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText6 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text6");
		/// <summary>
		/// Korean:
		/// ………………
		/// English:
		/// ………………
		/// Japanese:
		/// ………………
		/// Chinese:
		/// ………………
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText7 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text7");
		/// <summary>
		/// Korean:
		/// ……虽然很多余，但还是容我询问一下。天子，你能把那个东西给我吗？
		/// English:
		/// ……虽然很多余，但还是容我询问一下。天子，你能把那个东西给我吗？
		/// Japanese:
		/// ……余計なお世話だと思うけど一応聞くわ。 天子、それを渡して？
		/// Chinese:
		/// ……虽然很多余，但还是容我询问一下。天子，你能把那个东西给我吗？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText8 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text8");
		/// <summary>
		/// Korean:
		/// ……
		/// English:
		/// ……
		/// Japanese:
		/// ……
		/// Chinese:
		/// ……
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_Tenshi_ReimuText9 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text9");
		/// <summary>
		/// Korean:
		/// 自一至十，吾已完美！
		/// English:
		/// 自一至十，吾已完美！
		/// Japanese:
		/// 一にして全、私は完璧！
		/// Chinese:
		/// 自一至十，吾已完美！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaS_Tenshi_Rare_4Text1 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text1");
		/// <summary>
		/// Korean:
		/// 吾即剑，吾即天，吾即是十全十美之天人！
		/// English:
		/// 吾即剑，吾即天，吾即是十全十美之天人！
		/// Japanese:
		/// 我は剣、我は天、我は十全十美の天人なり！
		/// Chinese:
		/// 吾即剑，吾即天，吾即是十全十美之天人！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaS_Tenshi_Rare_4Text2 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text2");
		/// <summary>
		/// Korean:
		/// 迎接天光闪耀的力量吧！
		/// English:
		/// 迎接天光闪耀的力量吧！
		/// Japanese:
		/// 輝く天の力を受けなさい！
		/// Chinese:
		/// 迎接天光闪耀的力量吧！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaS_Tenshi_Rare_4Text3 => ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text3");

    }
}