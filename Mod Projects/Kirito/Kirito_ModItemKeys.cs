using ChronoArkMod;
namespace Kirito
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 亚丝娜1
		/// </summary>
        public static string Buff_B_Asuna_1 = "B_Asuna_1";
		/// <summary>
		/// 亚丝娜1_0
		/// </summary>
        public static string Buff_B_Asuna_1_0 = "B_Asuna_1_0";
		/// <summary>
		/// 切换
		/// 桐人会以一半的效果重复释放打出的技能。
		/// </summary>
        public static string Buff_B_Asuna_7 = "B_Asuna_7";
		/// <summary>
		/// 切换中……
		/// 无法使用手中的技能。
		/// </summary>
        public static string Buff_B_Asuna_7_0 = "B_Asuna_7_0";
		/// <summary>
		/// 亚丝娜
		/// 每使用3个技能后优先抽1个桐人的技能，恢复1点法力值。回合结束时，获得1层[准备开饭]：回合开始时，消耗1层恢复5点体力。
		/// </summary>
        public static string Buff_B_Asuna_P = "B_Asuna_P";
		/// <summary>
		/// 准备开饭
		/// 回合开始时，消耗1层恢复5点体力。
		/// </summary>
        public static string Buff_B_Asuna_P_0 = "B_Asuna_P_0";
		/// <summary>
		/// 星爆气流
		/// 受到痛苦伤害翻倍。
		/// </summary>
        public static string Buff_B_Eugeo_11Rare = "B_Eugeo_11Rare";
		/// <summary>
		/// 音速
		/// </summary>
        public static string Buff_B_Eugeo_3 = "B_Eugeo_3";
		/// <summary>
		/// 嘲讽
		/// </summary>
        public static string Buff_B_Eugeo_7 = "B_Eugeo_7";
		/// <summary>
		/// 切换
		/// 受到攻击时随机释放手中的技能。
		/// </summary>
        public static string Buff_B_Eugeo_7_0 = "B_Eugeo_7_0";
		/// <summary>
		/// 尤吉欧
		/// 战斗开始时，获得[蓝蔷薇之剑]：对敌人造成伤害时附加1层[冻伤]。
		/// 回合结束时，根据场上[冻伤]层数恢复2x层数体力。7层时清空所有冻伤，将1张[绽放吧！蓝蔷薇]加入手中。
		/// 如果桐人进入濒死状态，[蓝蔷薇之剑]转变为[血色蔷薇之剑]：攻击力+40%。每次攻击恢复100%攻击力体力。
		/// </summary>
        public static string Buff_B_Eugeo_P = "B_Eugeo_P";
		/// <summary>
		/// 蓝蔷薇之剑
		/// 对敌人造成伤害时附加1层[冻伤]。
		/// </summary>
        public static string Buff_B_Eugeo_P_0 = "B_Eugeo_P_0";
		/// <summary>
		/// 冻伤
		/// </summary>
        public static string Buff_B_Eugeo_P_0_0 = "B_Eugeo_P_0_0";
		/// <summary>
		/// 血色蔷薇之剑
		/// 攻击力+40%。每次攻击恢复100%攻击力体力。
		/// </summary>
        public static string Buff_B_Eugeo_P_1 = "B_Eugeo_P_1";
		/// <summary>
		/// 二刀流
		/// 攻击额外附带1次伤害。
		/// </summary>
        public static string Buff_B_Kirito_12Rare = "B_Kirito_12Rare";
		/// <summary>
		/// 还没结束
		/// 濒死时，攻击力+50%。
		/// </summary>
        public static string Buff_B_Kirito_13Rare = "B_Kirito_13Rare";
		/// <summary>
		/// 十字格挡
		/// 受到攻击时反击。
		/// </summary>
        public static string Buff_B_Kirito_9 = "B_Kirito_9";
		/// <summary>
		/// 我还能更快
		/// </summary>
        public static string Buff_B_Kirito_P = "B_Kirito_P";
		/// <summary>
		/// 子弹上膛
		/// 下个[狙击支援]伤害提升10%。
		/// </summary>
        public static string Buff_B_Shino_0 = "B_Shino_0";
		/// <summary>
		/// 锁定
		/// </summary>
        public static string Buff_B_Shino_1 = "B_Shino_1";
		/// <summary>
		/// 影光G4
		/// </summary>
        public static string Buff_B_Shino_7 = "B_Shino_7";
		/// <summary>
		/// 诗乃
		/// 获得+10%暴击率和+10%暴击伤害。每使用3个技能后触发1次[狙击支援]，并获得1层[刀劈子弹]：闪避1次攻击。
		/// </summary>
        public static string Buff_B_Shino_P = "B_Shino_P";
		/// <summary>
		/// 刀劈子弹
		/// 闪避1次攻击。
		/// </summary>
        public static string Buff_B_Shino_P_0 = "B_Shino_P_0";
		/// <summary>
		/// 黑卡蒂II
		/// 触发暴击时，消耗1层，恢复1点法力值。
		/// </summary>
        public static string Buff_B_Shino_P_1 = "B_Shino_P_1";
		/// <summary>
		/// 桐谷和人
		/// Passive:
		/// 我还能更快：每次使用自己的技能（治疗气息除外），手中自己的技能费用-1。
		/// 后宫团：战斗开始时，从下列效果中选择1个触发：
		/// -亚丝娜：获得+10%命中率。每使用3次技能后优先抽1张自己的技能，恢复1点法力值。回合结束时，获得1层[准备开饭]：回合开始时，消耗1层恢复5点体力。
		/// -诗乃：获得+10%暴击率+10%暴击伤害。每使用3次技能后触发1次[狙击支援]，并获得1层[刀劈子弹]：闪避1次攻击。
		/// -尤吉欧：获得+40%无法战斗抵抗。战斗开始时，获得[蓝蔷薇之剑]：对敌人造成伤害时附加1层[冻伤]。回合结束时，根据场上[冻伤]层数恢复2x层数体力。7层时清空所有冻伤，将1张[绽放吧！蓝蔷薇]加入手中。；如果桐人进入濒死状态，[蓝蔷薇之剑]转变为[血色蔷薇之剑]：攻击力+40%。每次攻击恢复100%攻击力体力。
		/// </summary>
        public static string Character_Kirito = "Kirito";
		/// <summary>
		/// 剩余使用次数
		/// 剩余 &a 次
		/// </summary>
        public static string SkillExtended_SE_Kirito_6 = "SE_Kirito_6";
		/// <summary>
		/// 诗乃5
		/// </summary>
        public static string SkillExtended_SE_Shino_5 = "SE_Shino_5";
        public static string SkillEffect_SE_S_S_Asuna_P = "SE_S_S_Asuna_P";
        public static string SkillEffect_SE_S_S_Eugeo_P = "SE_S_S_Eugeo_P";
        public static string SkillEffect_SE_S_S_Kirito_12Rare = "SE_S_S_Kirito_12Rare";
        public static string SkillEffect_SE_S_S_Kirito_13Rare = "SE_S_S_Kirito_13Rare";
        public static string SkillEffect_SE_S_S_Shino_P = "SE_S_S_Shino_P";
        public static string SkillEffect_SE_Tick_B_Eugeo_P_0_0 = "SE_Tick_B_Eugeo_P_0_0";
        public static string SkillEffect_SE_T_S_Eugeo_0 = "SE_T_S_Eugeo_0";
        public static string SkillEffect_SE_T_S_Kirito_0 = "SE_T_S_Kirito_0";
        public static string SkillEffect_SE_T_S_Kirito_1 = "SE_T_S_Kirito_1";
        public static string SkillEffect_SE_T_S_Kirito_10Rare = "SE_T_S_Kirito_10Rare";
        public static string SkillEffect_SE_T_S_Kirito_11Rare = "SE_T_S_Kirito_11Rare";
        public static string SkillEffect_SE_T_S_Kirito_11Rare_0 = "SE_T_S_Kirito_11Rare_0";
        public static string SkillEffect_SE_T_S_Kirito_2 = "SE_T_S_Kirito_2";
        public static string SkillEffect_SE_T_S_Kirito_3 = "SE_T_S_Kirito_3";
        public static string SkillEffect_SE_T_S_Kirito_4 = "SE_T_S_Kirito_4";
        public static string SkillEffect_SE_T_S_Kirito_5 = "SE_T_S_Kirito_5";
        public static string SkillEffect_SE_T_S_Kirito_9 = "SE_T_S_Kirito_9";
        public static string SkillEffect_SE_T_S_Kirito_9_0 = "SE_T_S_Kirito_9_0";
        public static string SkillEffect_SE_T_S_Kirito_P = "SE_T_S_Kirito_P";
        public static string SkillEffect_SE_T_S_Shino_0 = "SE_T_S_Shino_0";
		/// <summary>
		/// 亚丝娜
		/// </summary>
        public static string Skill_S_Asuna_P = "S_Asuna_P";
        public static string Skill_S_Azar_6 = "S_Azar_6";
        public static string Skill_S_Azar_8 = "S_Azar_8";
		/// <summary>
		/// 绽放吧！蓝蔷薇
		/// 依据自身最大体力值，额外造成&a(300%)伤害。自己会受到数值一半的痛苦伤害，这个伤害不会让自己致死。
		/// </summary>
        public static string Skill_S_Eugeo_0 = "S_Eugeo_0";
		/// <summary>
		/// 尤吉欧
		/// </summary>
        public static string Skill_S_Eugeo_P = "S_Eugeo_P";
		/// <summary>
		/// 斜斩
		/// 抽取1个技能。依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：附加迅速。
		/// -诗乃：获得1层[子弹上膛]：下个[狙击支援]伤害提升10%。
		/// -尤吉欧：额外施加1层[冻伤]。
		/// </summary>
        public static string Skill_S_Kirito_0 = "S_Kirito_0";
		/// <summary>
		/// 水平四方斩
		/// 依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：重复释放一次。不会触发[后宫团]效果。
		/// -诗乃：施加1层[锁定]：受到暴击率+10%，受到暴击伤害+10%。2回合。
		/// -尤吉欧：如果只有1个目标，额外施加2层[冻伤]。
		/// </summary>
        public static string Skill_S_Kirito_1 = "S_Kirito_1";
		/// <summary>
		/// 星爆气流斩
		/// 重复造成一共16次伤害。依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：使用时如果是0费，生成1张5费的[星爆气流斩]加入手中。
		/// -诗乃：抽取1个技能。触发3次[狙击支援]。
		/// -尤吉欧：抽取2个技能。施加[星爆气流]：受到痛苦伤害翻倍。
		/// </summary>
        public static string Skill_S_Kirito_11Rare = "S_Kirito_11Rare";
		/// <summary>
		/// 星爆气流斩
		/// </summary>
        public static string Skill_S_Kirito_11Rare_0 = "S_Kirito_11Rare_0";
		/// <summary>
		/// 二刀流
		/// 所有攻击额外造成1次伤害。
		/// 随机生成2张附带放逐的自己的技能。
		/// </summary>
        public static string Skill_S_Kirito_12Rare = "S_Kirito_12Rare";
		/// <summary>
		/// 还没结束
		/// </summary>
        public static string Skill_S_Kirito_13Rare = "S_Kirito_13Rare";
		/// <summary>
		/// 垂直弧形斩
		/// 依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：下个出手的技能附加迅速。
		/// -诗乃：击杀敌人时，会触发一次额外的[狙击支援]。
		/// -尤吉欧：所有敌人获得目标身上等量的冻伤层数。
		/// </summary>
        public static string Skill_S_Kirito_2 = "S_Kirito_2";
		/// <summary>
		/// 音速冲击
		/// 当存在[嘲讽]敌人时，攻击非嘲讽敌人时暴击率+100%。依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：攻击嘲讽敌人时抽取1个技能。
		/// -诗乃：攻击嘲讽敌人时暴击率+100%。
		/// -尤吉欧：获得1层[音速]：最大生命值+20%。
		/// </summary>
        public static string Skill_S_Kirito_3 = "S_Kirito_3";
		/// <summary>
		/// 愤怒刺击
		/// 如果是本回合第1个使用的技能，费用-2。击杀敌人后抽取1张自己的技能。
		/// </summary>
        public static string Skill_S_Kirito_4 = "S_Kirito_4";
		/// <summary>
		/// 绝命重击
		/// 每使用1张自己的技能，倒计时-1。依据选择的后宫团成员获得额外效果：
		/// -亚丝娜：降低1点费用。打出时选择1张手中的技能，生成一张附带放逐的复制，放入牌堆最上方。
		/// -诗乃：触发1次100%暴击的[狙击支援]，并且溢出的暴击率转化成额外爆伤。。
		/// -尤吉欧：生成1张[绽放吧！蓝蔷薇]加入手中，恢复1点法力值。
		/// </summary>
        public static string Skill_S_Kirito_5 = "S_Kirito_5";
		/// <summary>
		/// 攻略开始
		/// <b>每场战斗使用2次后放逐</b>
		/// 选择：优先抽取1张自己的稀有技能；或者生成3张自身技能、附带放逐。
		/// </summary>
        public static string Skill_S_Kirito_6 = "S_Kirito_6";
		/// <summary>
		/// 稀有抽取
		/// </summary>
        public static string Skill_S_Kirito_6_0 = "S_Kirito_6_0";
		/// <summary>
		/// 普通抽取
		/// </summary>
        public static string Skill_S_Kirito_6_1 = "S_Kirito_6_1";
		/// <summary>
		/// 切换
		/// 使用此技能不会发动[我还能更快]的被动效果。
		/// -亚丝娜：选择一名其他队友获得1回合BUFF[切换]：重复释放该队友释放的技能。但此回合自己无法行动。
		/// -诗乃：自身获得1回合BUFF[影光G4]：+50%无视防御。
		/// -尤吉欧：嘲讽所有敌人1回合。此回合自身受到攻击后随机使用手牌中的普通技能。
		/// </summary>
        public static string Skill_S_Kirito_7 = "S_Kirito_7";
		/// <summary>
		/// 羁绊
		/// 生成2张所选友军的随机2个技能加入手中。
		/// </summary>
        public static string Skill_S_Kirito_8 = "S_Kirito_8";
		/// <summary>
		/// 十字格挡
		/// </summary>
        public static string Skill_S_Kirito_9 = "S_Kirito_9";
		/// <summary>
		/// 反击
		/// </summary>
        public static string Skill_S_Kirito_9_0 = "S_Kirito_9_0";
		/// <summary>
		/// 给我十秒钟时间
		/// 选择：抽取2个技能，附带迅速；
		/// 或者恢复3点法力值。
		/// </summary>
        public static string Skill_S_Kirito_LucyD = "S_Kirito_LucyD";
		/// <summary>
		/// 抽2
		/// </summary>
        public static string Skill_S_Kirito_LucyD_0 = "S_Kirito_LucyD_0";
		/// <summary>
		/// 回3
		/// </summary>
        public static string Skill_S_Kirito_LucyD_1 = "S_Kirito_LucyD_1";
		/// <summary>
		/// 剑技连携
		/// 根据本回合释放的技能数量，重复释放本技能(&a次)。最大不超过10次。
		/// </summary>
        public static string Skill_S_Kirito_P = "S_Kirito_P";
		/// <summary>
		/// 狙击支援
		/// </summary>
        public static string Skill_S_Shino_0 = "S_Shino_0";
		/// <summary>
		/// 诗乃
		/// </summary>
        public static string Skill_S_Shino_P = "S_Shino_P";

    }

    public static class ModLocalization
    {

    }
}