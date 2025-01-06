using ChronoArkMod;
namespace HolySaber
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 神威独角兽
		/// 回合结束时，若自己的体力值为3的倍数，对随机敌人造成&a(90%)伤害；
		/// 若自己体力值为4的倍数，抽取1个技能。
		/// </summary>
        public static string Buff_B_HolySaber_0 = "B_HolySaber_0";
		/// <summary>
		/// 虹蛇
		/// 打出带有<color=#4876FF>守护</color>减益的技能时，获得1点进化点。
		/// </summary>
        public static string Buff_B_HolySaber_1 = "B_HolySaber_1";
		/// <summary>
		/// 光灿圣骑
		/// 回合结束时，对随机敌人造成&a(手牌中拥有[守护]减益的技能数 x 75%防御力)的伤害。
		/// </summary>
        public static string Buff_B_HolySaber_3 = "B_HolySaber_3";
		/// <summary>
		/// 完美守护
		/// 受到攻击后解除。
		/// </summary>
        public static string Buff_B_HolySaber_6 = "B_HolySaber_6";
		/// <summary>
		/// 神的告诫
		/// 每回合第1次使用自己的技能时，获得1点进化点。
		/// </summary>
        public static string Buff_B_HolySaber_7 = "B_HolySaber_7";
		/// <summary>
		/// 双炮神罚
		/// 每次使用带有<color=#4876FF>守护</color>减益的技能时，减少1回合持续时间。
		/// 效果解除时，对所有敌人造成&a(150%)伤害，并施加<color=#4876FF>守护</color>。
		/// </summary>
        public static string Buff_B_HolySaber_8 = "B_HolySaber_8";
		/// <summary>
		/// 守护神威
		/// </summary>
        public static string Buff_B_HolySaber_8_0 = "B_HolySaber_8_0";
		/// <summary>
		/// 开眼者
		/// 受到的伤害降低&a点。
		/// </summary>
        public static string Buff_B_HolySaber_9 = "B_HolySaber_9";
		/// <summary>
		/// 一伐枪
		/// </summary>
        public static string Buff_B_HolySaber_9_0 = "B_HolySaber_9_0";
		/// <summary>
		/// <color=#4876FF>守护</color>
		/// 优先攻击&target。
		/// 攻击该目标时解除。
		/// </summary>
        public static string Buff_B_HolySaber_Def = "B_HolySaber_Def";
		/// <summary>
		/// 进化点
		/// <i><color=#FFA500>进化</color>是通向胜利的关键！</i>
		/// </summary>
        public static string Buff_B_HolySaber_P = "B_HolySaber_P";
		/// <summary>
		/// 圣女的号令
		/// 受到的痛苦伤害降低为0。
		/// </summary>
        public static string Buff_B_HolySaber_P_0 = "B_HolySaber_P_0";
		/// <summary>
		/// 尊荣骑士
		/// 当自己受到伤害时，对来源造成&a(50%防御力)的伤害。
		/// </summary>
        public static string Buff_B_HolySaber_Rare_10 = "B_HolySaber_Rare_10";
		/// <summary>
		/// 防御降临
		/// </summary>
        public static string Buff_B_HolySaber_Rare_10_0 = "B_HolySaber_Rare_10_0";
		/// <summary>
		/// 神谕启程
		/// 使抽到的可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
		/// </summary>
        public static string Buff_B_HolySaber_Rare_11 = "B_HolySaber_Rare_11";
		/// <summary>
		/// 光辉现世
		/// 回合结束时，对所有敌人造成&a(当前回合数 x 6)痛苦伤害。
		/// </summary>
        public static string Buff_B_HolySaber_Rare_12 = "B_HolySaber_Rare_12";
		/// <summary>
		/// 拉的信仰
		/// </summary>
        public static string Buff_B_HolySaber_Rare_12_0 = "B_HolySaber_Rare_12_0";
		/// <summary>
		/// 圣辉女剑士
		/// Passive:
		/// <b>进化</b> - 战斗开始时，获得3个<color=#FFA500>进化点</color>。固定能力变更为[进化]：消耗1个<color=#FFA500>进化点</color>，使手中一个可<color=#FFA500>进化</color>的技能触发<color=#FFA500>进化</color>效果。
		/// <b>圣女的号令</b> - 回合开始时，若<color=#FFC125>进化5</color>，将一张[圣女的号令]加入手中。这个效果1场战斗只能触发1次。
		/// <color=#FFC125><b>进化X</b></color> - 本场战斗中，已发动的<color=#FFA500>进化</color>的次数大于X次时，可以触发额外效果。
		/// <color=#4876FF><b>守护X</b></color> - 本场战斗中，已使用过带有<color=#4876FF>守护</color>减益的技能的次数大于X次时，可以触发额外效果。
		/// </summary>
        public static string Character_HolySaber = "HolySaber";
        public static string ImageDatas_HolySaberImage = "HolySaberImage";
		/// <summary>
		/// <color=#4876FF>守护X</color>
		/// 本场战斗中，已使用过带有<color=#4876FF>守护</color>减益的技能的次数大于X次时，可以触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Defend = "Keyword_Defend";
		/// <summary>
		/// <color=#FFC125>进化X</color>
		/// 本场战斗中，已发动的<color=#FFA500>进化</color>的次数大于X次时，可以触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Extend = "Keyword_Extend";
		/// <summary>
		/// 对拥有<color=#4876FF>守护</color>减益的敌人造成的伤害+30%。
		/// 攻击技能
		/// </summary>
        public static string SkillExtended_SE_HolySaber_C_0 = "SE_HolySaber_C_0";
		/// <summary>
		/// 施加<color=#4876FF>守护</color>减益。<i>这个技能被视作带有<color=#4876FF>守护</color>减益的技能。</i>
		/// 攻击技能
		/// </summary>
        public static string SkillExtended_SE_HolySaber_C_1 = "SE_HolySaber_C_1";
		/// <summary>
		/// 根据支付的费用，在手中生成相应数量的[圣骑士]。
		/// </summary>
        public static string SkillExtended_SE_HolySaber_C_2 = "SE_HolySaber_C_2";
		/// <summary>
		/// 守护
		/// </summary>
        public static string SkillExtended_SE_HolySaber_Defend = "SE_HolySaber_Defend";
		/// <summary>
		/// 进化
		/// </summary>
        public static string SkillExtended_SE_HolySaber_Extend = "SE_HolySaber_Extend";
		/// <summary>
		/// 已进化
		/// </summary>
        public static string SkillExtended_SE_HolySaber_Extended = "SE_HolySaber_Extended";
        public static string SkillEffect_SE_S_S_HolySaber_0__Ex = "SE_S_S_HolySaber_0__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_1 = "SE_S_S_HolySaber_1";
        public static string SkillEffect_SE_S_S_HolySaber_1__Ex = "SE_S_S_HolySaber_1__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_3 = "SE_S_S_HolySaber_3";
        public static string SkillEffect_SE_S_S_HolySaber_3__Ex = "SE_S_S_HolySaber_3__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_7 = "SE_S_S_HolySaber_7";
        public static string SkillEffect_SE_S_S_HolySaber_7__Ex = "SE_S_S_HolySaber_7__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_8 = "SE_S_S_HolySaber_8";
        public static string SkillEffect_SE_S_S_HolySaber_8__Ex = "SE_S_S_HolySaber_8__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_9 = "SE_S_S_HolySaber_9";
        public static string SkillEffect_SE_S_S_HolySaber_9__Ex = "SE_S_S_HolySaber_9__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_1 = "SE_S_S_HolySaber_Rare_1";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_1__Ex = "SE_S_S_HolySaber_Rare_1__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_2 = "SE_S_S_HolySaber_Rare_2";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_2__Ex = "SE_S_S_HolySaber_Rare_2__Ex";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_3 = "SE_S_S_HolySaber_Rare_3";
        public static string SkillEffect_SE_S_S_HolySaber_Rare_3__Ex = "SE_S_S_HolySaber_Rare_3__Ex";
        public static string SkillEffect_SE_S_S_Welbert_Rare_1 = "SE_S_S_Welbert_Rare_1";
        public static string SkillEffect_SE_T_S_HolySaber_0 = "SE_T_S_HolySaber_0";
        public static string SkillEffect_SE_T_S_HolySaber_0_0 = "SE_T_S_HolySaber_0_0";
        public static string SkillEffect_SE_T_S_HolySaber_0__Ex = "SE_T_S_HolySaber_0__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_1 = "SE_T_S_HolySaber_1";
        public static string SkillEffect_SE_T_S_HolySaber_1__Ex = "SE_T_S_HolySaber_1__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_2 = "SE_T_S_HolySaber_2";
        public static string SkillEffect_SE_T_S_HolySaber_2__Ex = "SE_T_S_HolySaber_2__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_3 = "SE_T_S_HolySaber_3";
        public static string SkillEffect_SE_T_S_HolySaber_3__Ex = "SE_T_S_HolySaber_3__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_4 = "SE_T_S_HolySaber_4";
        public static string SkillEffect_SE_T_S_HolySaber_4__Ex = "SE_T_S_HolySaber_4__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_5 = "SE_T_S_HolySaber_5";
        public static string SkillEffect_SE_T_S_HolySaber_5_0 = "SE_T_S_HolySaber_5_0";
        public static string SkillEffect_SE_T_S_HolySaber_5__Ex = "SE_T_S_HolySaber_5__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_6 = "SE_T_S_HolySaber_6";
        public static string SkillEffect_SE_T_S_HolySaber_6__Ex = "SE_T_S_HolySaber_6__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_7__Ex = "SE_T_S_HolySaber_7__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_8_0 = "SE_T_S_HolySaber_8_0";
        public static string SkillEffect_SE_T_S_HolySaber_9 = "SE_T_S_HolySaber_9";
        public static string SkillEffect_SE_T_S_HolySaber_9__Ex = "SE_T_S_HolySaber_9__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_P_0 = "SE_T_S_HolySaber_P_0";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_1 = "SE_T_S_HolySaber_Rare_1";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_1_0 = "SE_T_S_HolySaber_Rare_1_0";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_1__Ex = "SE_T_S_HolySaber_Rare_1__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_2 = "SE_T_S_HolySaber_Rare_2";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_2__Ex = "SE_T_S_HolySaber_Rare_2__Ex";
        public static string SkillEffect_SE_T_S_HolySaber_Rare_3_0 = "SE_T_S_HolySaber_Rare_3_0";
        public static string SkillEffect_SE_T_S_HolySaber_Token = "SE_T_S_HolySaber_Token";
        public static string SkillEffect_SE_T_S_HolySaber_Token__Ex = "SE_T_S_HolySaber_Token__Ex";
        public static string SkillEffect_SE_T_S_Welbert_3 = "SE_T_S_Welbert_3";
        public static string SkillEffect_SE_T_S_Welbert_3__Ex = "SE_T_S_Welbert_3__Ex";
        public static string SkillEffect_SE_T_S_Welbert_Rare_1 = "SE_T_S_Welbert_Rare_1";
		/// <summary>
		/// 圣辉女剑士
		/// </summary>
        public static string SkillExtended_SkillExtended_HolySaber = "SkillExtended_HolySaber";
		/// <summary>
		/// 神威独角兽
		/// <color=#FFA500>进化</color> - 额外造成&a(50%)伤害。获得[神威独角兽]。
		/// </summary>
        public static string Skill_S_HolySaber_0 = "S_HolySaber_0";
		/// <summary>
		/// 神威独角兽
		/// </summary>
        public static string Skill_S_HolySaber_0_0 = "S_HolySaber_0_0";
		/// <summary>
		/// <color=#FFA500>神威独角兽</color>
		/// </summary>
        public static string Skill_S_HolySaber_0__Ex = "S_HolySaber_0__Ex";
		/// <summary>
		/// 虹蛇
		/// <color=#FFA500>进化</color> - 额外造成&a(50%)伤害。额外施加<color=#4876FF>守护</color>。
		/// </summary>
        public static string Skill_S_HolySaber_1 = "S_HolySaber_1";
		/// <summary>
		/// <color=#FFA500>虹蛇</color>
		/// </summary>
        public static string Skill_S_HolySaber_1__Ex = "S_HolySaber_1__Ex";
		/// <summary>
		/// 着魔的圣战士
		/// <color=#FFA500>进化</color> - 依据这个回合中从手中打出的拥有<color=#4876FF>守护</color>减益的技能数，抽取那个数量的技能。
		/// </summary>
        public static string Skill_S_HolySaber_2 = "S_HolySaber_2";
		/// <summary>
		/// <color=#FFA500>着魔的圣战士</color>
		/// 依据这个回合中从手中打出的拥有<color=#4876FF>守护</color>减益的技能数，抽取那个数量的技能。
		/// </summary>
        public static string Skill_S_HolySaber_2__Ex = "S_HolySaber_2__Ex";
		/// <summary>
		/// 光灿圣骑士·维尔伯特
		/// 生成1个[圣骑士]。
		/// <color=#4876FF>守护5</color> - 使手中这个技能<color=#FFA500>进化</color>。
		/// <color=#4876FF>守护10</color> - 额外获得[光灿圣骑]。
		/// <color=#FFA500>
		/// 进化</color> - 附带无视嘲讽。额外造成&a(50%)伤害。
		/// </summary>
        public static string Skill_S_HolySaber_3 = "S_HolySaber_3";
		/// <summary>
		/// <color=#FFA500>光灿圣骑士·维尔伯特</color>
		/// 生成1个[圣骑士]。
		/// <color=#4876FF>守护10</color> - 额外获得[光灿圣骑]。
		/// </summary>
        public static string Skill_S_HolySaber_3__Ex = "S_HolySaber_3__Ex";
		/// <summary>
		/// 圣辉女剑士
		/// <b><color=red>无法使用进化点<color=#FFA500>进化</color>。</b></color>
		/// <color=#FFC125>进化5</color> - 恢复2点法力值。
		/// <color=#FFC125>进化10</color> - 将一张[圣女的号令]加入手中。
		/// <color=#FFA500>进化</color> - 额外造成&a(200%)伤害。
		/// </summary>
        public static string Skill_S_HolySaber_4 = "S_HolySaber_4";
		/// <summary>
		/// <color=#FFA500>圣辉女剑士</color>
		/// <color=#FFC125>进化5</color> - 恢复2点法力值。
		/// <color=#FFC125>进化10</color> - 将一张[圣女的号令]加入手中。
		/// </summary>
        public static string Skill_S_HolySaber_4__Ex = "S_HolySaber_4__Ex";
		/// <summary>
		/// 狐耳圣骑士
		/// 生成2个[圣骑士]。
		/// <color=#4876FF>守护5</color> - 使生成的[圣骑士]<color=#FFA500>进化</color>。
		/// <color=#4876FF>守护10</color> - 使生成的[圣骑士]附带无视嘲讽和致命。
		/// <color=#FFA500>进化</color> - 额外造成&a(50%)伤害。
		/// </summary>
        public static string Skill_S_HolySaber_5 = "S_HolySaber_5";
		/// <summary>
		/// 光灿圣骑
		/// </summary>
        public static string Skill_S_HolySaber_5_0 = "S_HolySaber_5_0";
		/// <summary>
		/// <color=#FFA500>狐耳圣骑士</color>
		/// 生成2个[圣骑士]。
		/// <color=#4876FF>守护5</color> - 使生成的[圣骑士]<color=#FFA500>进化</color>。
		/// <color=#4876FF>守护10</color> - 使生成的[圣骑士]附带无视嘲讽和致命。
		/// </summary>
        public static string Skill_S_HolySaber_5__Ex = "S_HolySaber_5__Ex";
		/// <summary>
		/// 导引之钟·叮咚天使
		/// 抽取1个技能。
		/// <color=#FFA500>进化</color> - 额外抽取1个技能。
		/// </summary>
        public static string Skill_S_HolySaber_6 = "S_HolySaber_6";
		/// <summary>
		/// <color=#FFA500>导引之钟·叮咚天使</color>
		/// 抽取2个技能。
		/// </summary>
        public static string Skill_S_HolySaber_6__Ex = "S_HolySaber_6__Ex";
		/// <summary>
		/// 亚必迭
		/// <color=#FFA500>进化</color> - 指定一个敌人，对其造成&a(150%)伤害，并施加<color=#4876FF>守护</color>。
		/// </summary>
        public static string Skill_S_HolySaber_7 = "S_HolySaber_7";
		/// <summary>
		/// <color=#FFA500>亚必迭</color>
		/// </summary>
        public static string Skill_S_HolySaber_7__Ex = "S_HolySaber_7__Ex";
		/// <summary>
		/// 双炮神罚·安维特
		/// <i>这个技能被视作带有<color=#4876FF>守护</color>减益的技能。</i>
		/// <color=#FFA500>进化</color> - 额外获得[守护神威]。
		/// </summary>
        public static string Skill_S_HolySaber_8 = "S_HolySaber_8";
		/// <summary>
		/// 双炮神罚
		/// </summary>
        public static string Skill_S_HolySaber_8_0 = "S_HolySaber_8_0";
		/// <summary>
		/// <color=#FFA500>双炮神罚·安维特</color>
		/// <i>这个技能被视作带有<color=#4876FF>守护</color>减益的技能。</i>
		/// </summary>
        public static string Skill_S_HolySaber_8__Ex = "S_HolySaber_8__Ex";
		/// <summary>
		/// 开眼者·乌诺
		/// <color=#FFC125>进化5</color> - 额外施加[开眼者]。
		/// <color=#FFA500>进化</color> - 额外施加[一伐枪]。
		/// </summary>
        public static string Skill_S_HolySaber_9 = "S_HolySaber_9";
		/// <summary>
		/// <color=#FFA500>开眼者·乌诺</color>
		/// <color=#FFC125>进化5</color> - 额外施加[开眼者]。
		/// </summary>
        public static string Skill_S_HolySaber_9__Ex = "S_HolySaber_9__Ex";
		/// <summary>
		/// 悖理盾·杰诺
		/// 抽取2个技能。
		/// 若圣辉女剑士存活，生成1个持有者为圣辉女剑士的[圣骑士]。
		/// <color=#696969><i>——这世间是泪水，啜泣之海。</i></color>
		/// </summary>
        public static string Skill_S_HolySaber_LucyD = "S_HolySaber_LucyD";
		/// <summary>
		/// 进化
		/// 拥有<color=#FFA500>进化点</color>时才可使用。
		/// 消耗1个<color=#FFA500>进化点</color>，使手中一个可<color=#FFA500>进化</color>的技能触发<color=#FFA500>进化</color>效果。
		/// </summary>
        public static string Skill_S_HolySaber_P = "S_HolySaber_P";
		/// <summary>
		/// 圣女的号令
		/// 使手中所有可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
		/// <i><color=#FFA500>见识一下吧！这就是真实的我！</color></i>
		/// </summary>
        public static string Skill_S_HolySaber_P_0 = "S_HolySaber_P_0";
		/// <summary>
		/// 尊荣骑士·维尔伯特
		/// 生成2个[圣骑士]。
		/// <color=#FFA500>进化</color> - 额外获得[防御降临]。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_1 = "S_HolySaber_Rare_1";
		/// <summary>
		/// 尊荣骑士
		/// </summary>
        public static string Skill_S_HolySaber_Rare_1_0 = "S_HolySaber_Rare_1_0";
		/// <summary>
		/// <color=#FFA500>尊荣骑士·维尔伯特</color>
		/// 生成2个[圣骑士]。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_1__Ex = "S_HolySaber_Rare_1__Ex";
		/// <summary>
		/// 神谕的启程·贞德
		/// 握在手中时，使用2个技能，会使这个技能<color=#FFA500>进化</color>。
		/// <color=#FFA500>进化</color> - 使手中所有可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_2 = "S_HolySaber_Rare_2";
		/// <summary>
		/// <color=#FFA500>神谕的启程·贞德</color>
		/// 使手中所有可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_2__Ex = "S_HolySaber_Rare_2__Ex";
		/// <summary>
		/// 光辉现世·拉
		/// <color=#FFA500>进化</color> - 使当前回合数+2。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_3 = "S_HolySaber_Rare_3";
		/// <summary>
		/// 拉的神罚
		/// </summary>
        public static string Skill_S_HolySaber_Rare_3_0 = "S_HolySaber_Rare_3_0";
		/// <summary>
		/// <color=#FFA500>光辉现世·拉</color>
		/// 使当前回合数+2。
		/// </summary>
        public static string Skill_S_HolySaber_Rare_3__Ex = "S_HolySaber_Rare_3__Ex";
		/// <summary>
		/// 圣骑士
		/// <color=#FFA500>进化</color> - 额外造成&a(50%)伤害。
		/// </summary>
        public static string Skill_S_HolySaber_Token = "S_HolySaber_Token";
		/// <summary>
		/// <color=#FFA500>圣骑士</color>
		/// </summary>
        public static string Skill_S_HolySaber_Token__Ex = "S_HolySaber_Token__Ex";
        public static string Skill_S_Welbert_3 = "S_Welbert_3";
        public static string Skill_S_Welbert_3__Ex = "S_Welbert_3__Ex";
        public static string Skill_S_Welbert_4 = "S_Welbert_4";
        public static string Skill_S_Welbert_4__Ex = "S_Welbert_4__Ex";
		/// <summary>
		/// 英雄的号令
		/// </summary>
        public static string Skill_S_Welbert_P_0 = "S_Welbert_P_0";
        public static string Character_Skin_Wilbert = "Wilbert";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 英雄的号令
		/// Chinese-TW:
		/// </summary>
        public static string BuffWilbert_P_0_Name => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Buff/Wilbert_P_0_Name");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <b>进化</b> - 战斗开始时，获得3个<color=#FFA500>进化点</color>。固定能力变更为[进化]：消耗1个<color=#FFA500>进化点</color>，使手中一个可<color=#FFA500>进化</color>的技能触发<color=#FFA500>进化</color>效果。
		/// <b>圣女的号令</b> - 回合开始时，若<color=#FFC125>进化5</color>，将一张[圣女的号令]加入手中。这个效果1场战斗只能触发1次。
		/// <color=#FFC125><b>进化X</b></color> - 本场战斗中，已发动的<color=#FFA500>进化</color>的次数大于X次时，可以触发额外效果。
		/// <color=#4876FF><b>守护X</b></color> - 本场战斗中，已使用过带有<color=#4876FF>守护</color>减益的技能的次数大于X次时，可以触发额外效果。
		/// Chinese-TW:
		/// </summary>
        public static string CharacterHolySaber_PassiveDes => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveDes");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 进化
		/// Chinese-TW:
		/// </summary>
        public static string CharacterHolySaber_PassiveName => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/HolySaber_PassiveName");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// WilbertBattleFace.png
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbertBattleFace => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertBattleFace");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// WilbertCollectionSprite_Cover.png
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbertCollectionSprite_Cover => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertCollectionSprite_Cover");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// WilbertCollectionSprite_SkillFace.png
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbertCollectionSprite_SkillFace => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertCollectionSprite_SkillFace");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// WilbertPassiveIcon.png
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbertPassiveIcon => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/WilbertPassiveIcon");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 不容许此身拥有任何幸福。吾不允许。
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbert_CampSelectWord => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_CampSelectWord");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 维尔伯特
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbert_Name => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_Name");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <b>进化</b> - 战斗开始时，获得3个<color=#FFA500>进化点</color>。固定能力变更为[进化]：消耗1个<color=#FFA500>进化点</color>，使手中一个可<color=#FFA500>进化</color>的技能触发<color=#FFA500>进化</color>效果。
		/// <b>英雄的号令</b> - 回合开始时，若<color=#FFC125>进化5</color>，将一张[英雄的号令]加入手中。这个效果1场战斗只能触发1次。
		/// <color=#FFC125><b>进化X</b></color> - 本场战斗中，已发动的<color=#FFA500>进化</color>的次数大于X次时，可以触发额外效果。
		/// <color=#4876FF><b>守护X</b></color> - 本场战斗中，已使用过带有<color=#4876FF>守护</color>减益的技能的次数大于X次时，可以触发额外效果。
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbert_PassiveDes => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveDes");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 进化
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbert_PassiveName => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_PassiveName");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 维尔伯特是精通多种嘲讽技巧的防御型角色。
		/// 维尔伯特的大部分技能附带“守护”减益，被命中的敌人无法选择他之外的调查员作为攻击目标。除此之外，维尔伯特拥有独特的进化技能的能力。在每个回合，他能够进化手中的技能，使技能发挥更强大的效果；在累计进化数次后，部分技能还会解锁额外效果。
		/// 以此身为盾，斩落敌人吧！
		/// Chinese-TW:
		/// </summary>
        public static string CharacterWilbert_SelectInfo => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Character/Wilbert_SelectInfo");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 使手中所有可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
		/// <i><color=#4876FF>不容许此身拥有任何幸福。吾不允许。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string SkillWilbert_P_0_Desc => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Skill/Wilbert_P_0_Desc");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 英雄的号令
		/// Chinese-TW:
		/// </summary>
        public static string SkillWilbert_P_0_Name => ModManager.getModInfo("HolySaber").localizationInfo.SystemLocalizationUpdate("Skill/Wilbert_P_0_Name");

    }
}