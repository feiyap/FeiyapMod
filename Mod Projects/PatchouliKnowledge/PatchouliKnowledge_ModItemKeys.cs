using ChronoArkMod;
namespace PatchouliKnowledge
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 赝造龙鳞
		/// 攻击改为指向自己。触发后移除。
		/// </summary>
        public static string Buff_B_Pachi_0_0 = "B_Pachi_0_0";
		/// <summary>
		/// 金属疲劳
		/// </summary>
        public static string Buff_B_Pachi_0_0_1 = "B_Pachi_0_0_1";
		/// <summary>
		/// 元素异常
		/// </summary>
        public static string Buff_B_Pachi_0_1 = "B_Pachi_0_1";
		/// <summary>
		/// 元素紊乱
		/// 攻击有 &a% 概率失效。
		/// 触发后移除。
		/// </summary>
        public static string Buff_B_Pachi_0_1_1 = "B_Pachi_0_1_1";
		/// <summary>
		/// 元素纠缠
		/// 结算时，自身每有 1 层痛苦减益，使这个减益增加 1 点每回合伤害。
		/// </summary>
        public static string Buff_B_Pachi_0_1_2 = "B_Pachi_0_1_2";
		/// <summary>
		/// 生命涌现
		/// </summary>
        public static string Buff_B_Pachi_0_2 = "B_Pachi_0_2";
		/// <summary>
		/// 巨石护卫
		/// 抵挡友军未能抵抗的干扰减益或弱化减益。触发后，或受到&a点伤害(&user防御力的50%)后减少 1 层。
		/// </summary>
        public static string Buff_B_Pachi_0_4 = "B_Pachi_0_4";
		/// <summary>
		/// 森林大火
		/// </summary>
        public static string Buff_B_Pachi_1_1 = "B_Pachi_1_1";
		/// <summary>
		/// 活水之精
		/// </summary>
        public static string Buff_B_Pachi_1_2 = "B_Pachi_1_2";
		/// <summary>
		/// 活体护甲
		/// 回合结束时恢复 &a 点体力值(&user防御力的50%)。
		/// 受到伤害时生成 &a 保护罩(&user防御力的50%)，并减少 1 层。
		/// </summary>
        public static string Buff_B_Pachi_1_4 = "B_Pachi_1_4";
		/// <summary>
		/// 石至名归
		/// </summary>
        public static string Buff_B_Pachi_4_4 = "B_Pachi_4_4";
		/// <summary>
		/// 元素保护罩
		/// </summary>
        public static string Buff_B_Pachi_Barrier = "B_Pachi_Barrier";
		/// <summary>
		/// 元素精华
		/// 当前元素等级：
		/// 金 - &a
		/// 木 - &b
		/// 水 - &c
		/// 火 - &d
		/// 土 - &e
		/// 日 - &f
		/// 月 - &g
		/// </summary>
        public static string Buff_B_Pachi_P = "B_Pachi_P";
		/// <summary>
		/// 元素充盈
		/// 释放「元素祈唤」时重置冷却时间。
		/// 触发后减少 1 层。
		/// </summary>
        public static string Buff_B_Pachi_P_1 = "B_Pachi_P_1";
		/// <summary>
		/// 帕秋莉
		/// Passive:
		/// <b>知识与避世的少女</b> - 战斗开始时，在本次战斗期间放逐自己的所有“元素”技能。每个被放逐的“元素”技能会转化为“元素”属性，重复转化的“元素”属性会提升属性的等级。
		/// <b>使用魔法程度的能力</b> - <b>固定能力替换为「元素祈唤」。</b>
		/// 等级到达3级时，每个回合第 1 次释放「元素祈唤」后，重置「元素祈唤」的冷却时间。
		/// 等级到达5级时，每回合重置次数提升至 2 次。
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// <color=#919191>- 帕秋莉的普通技能学习不再拥有上限。</color>
		/// </summary>
        public static string Character_PatchouliKnowledge = "PatchouliKnowledge";
        public static string CharRole_Role_Mage = "Role_Mage";
        public static string SkillEffect_SE_Tick_B_Pachi_0_1_2 = "SE_Tick_B_Pachi_0_1_2";
        public static string SkillEffect_SE_Tick_B_Pachi_0_2 = "SE_Tick_B_Pachi_0_2";
        public static string SkillEffect_SE_Tick_B_Pachi_1_1 = "SE_Tick_B_Pachi_1_1";
        public static string SkillEffect_SE_Tick_B_Pachi_1_2 = "SE_Tick_B_Pachi_1_2";
        public static string SkillEffect_SE_T_S_Pachi_Sk_0_0 = "SE_T_S_Pachi_Sk_0_0";
        public static string SkillEffect_SE_T_S_Pachi_Sk_0_1 = "SE_T_S_Pachi_Sk_0_1";
        public static string SkillEffect_SE_T_S_Pachi_Sk_0_2 = "SE_T_S_Pachi_Sk_0_2";
        public static string SkillEffect_SE_T_S_Pachi_Sk_0_3 = "SE_T_S_Pachi_Sk_0_3";
        public static string SkillEffect_SE_T_S_Pachi_Sk_0_4 = "SE_T_S_Pachi_Sk_0_4";
        public static string SkillEffect_SE_T_S_Pachi_Sk_1_1 = "SE_T_S_Pachi_Sk_1_1";
        public static string SkillEffect_SE_T_S_Pachi_Sk_1_2 = "SE_T_S_Pachi_Sk_1_2";
        public static string SkillEffect_SE_T_S_Pachi_Sk_1_3 = "SE_T_S_Pachi_Sk_1_3";
        public static string SkillEffect_SE_T_S_Pachi_Sk_1_4 = "SE_T_S_Pachi_Sk_1_4";
        public static string SkillEffect_SE_T_S_Pachi_Sk_2_2 = "SE_T_S_Pachi_Sk_2_2";
        public static string SkillEffect_SE_T_S_Pachi_Sk_2_3 = "SE_T_S_Pachi_Sk_2_3";
        public static string SkillEffect_SE_T_S_Pachi_Sk_2_4 = "SE_T_S_Pachi_Sk_2_4";
        public static string SkillEffect_SE_T_S_Pachi_Sk_3_3 = "SE_T_S_Pachi_Sk_3_3";
        public static string SkillEffect_SE_T_S_Pachi_Sk_3_4 = "SE_T_S_Pachi_Sk_3_4";
        public static string SkillEffect_SE_T_S_Pachi_Sk_4_4 = "SE_T_S_Pachi_Sk_4_4";
		/// <summary>
		/// 基本元素 - <color=#FFD700>金</color>
		/// 象征<color=#FFD700>控制</color>的权能。
		/// 使用时，在本次战斗期间<color=#FFD700>金</color>元素等级提升 1 级。
		/// 每个等级的<color=#FFD700>金</color>提供5%弱化成功率、干扰成功率和弱化抵抗率、干扰抵抗率。
		/// </summary>
        public static string Skill_S_Pachi_E_0 = "S_Pachi_E_0";
		/// <summary>
		/// 基本元素 - <color=#228B22>木</color>
		/// 象征<color=#228B22>持续</color>的权能。
		/// 使用时，在本次战斗期间<color=#228B22>木</color>元素等级提升 1 级。
		/// 每个等级的<color=#228B22>木</color>提供5%痛苦成功率和痛苦抵抗率。
		/// </summary>
        public static string Skill_S_Pachi_E_1 = "S_Pachi_E_1";
		/// <summary>
		/// 基本元素 - <color=#00BFFF>水</color>
		/// 象征<color=#00BFFF>治疗</color>的权能。
		/// 使用时，在本次战斗期间<color=#00BFFF>水</color>元素等级提升 1 级。
		/// 每个等级的<color=#00BFFF>水</color>提供1点治疗力、1%闪避率。
		/// </summary>
        public static string Skill_S_Pachi_E_2 = "S_Pachi_E_2";
		/// <summary>
		/// 基本元素 - <color=#FF4500>火</color>
		/// 象征<color=#FF4500>进攻</color>的权能。
		/// 使用时，在本次战斗期间<color=#FF4500>火</color>元素等级提升 1 级。
		/// 每个等级的<color=#FF4500>火</color>提供1点攻击力、1%暴击率。
		/// </summary>
        public static string Skill_S_Pachi_E_3 = "S_Pachi_E_3";
		/// <summary>
		/// 基本元素 - <color=#8B7355>土</color>
		/// 象征<color=#8B7355>保护</color>的权能。
		/// 使用时，在本次战斗期间<color=#8B7355>土</color>元素等级提升 1 级。
		/// 每个等级的<color=#8B7355>土</color>提供4%防御力。
		/// </summary>
        public static string Skill_S_Pachi_E_4 = "S_Pachi_E_4";
		/// <summary>
		/// 高级元素 - <color=#FFA500>日</color>
		/// 象征<color=#FFA500>财富</color>的权能。
		/// 使用时，在本次战斗期间<color=#FFA500>日</color>元素等级提升 1 级。
		/// 每个等级的<color=#FFA500>日</color>提供每回合额外抽取1个技能。
		/// </summary>
        public static string Skill_S_Pachi_E_5 = "S_Pachi_E_5";
		/// <summary>
		/// 高级元素 - <color=#6A5ACD>月</color>
		/// 象征<color=#6A5ACD>权力</color>的权能。
		/// 使用时，在本次战斗期间<color=#6A5ACD>月</color>元素等级提升 1 级。
		/// 每个等级的<color=#6A5ACD>月</color>提供1点额外最大法力值。
		/// </summary>
        public static string Skill_S_Pachi_E_6 = "S_Pachi_E_6";
		/// <summary>
		/// <color=#FFD700>金</color><color=#228B22>木</color><color=#00BFFF>水</color><color=#FF4500>火</color><color=#8B7355>土</color>符「贤者之石」
		/// 战斗开始时，放在牌库最上方。
		/// 抽取 1 个技能。获得<color=#FFD700>金</color>、<color=#228B22>木</color>、<color=#00BFFF>水</color>、<color=#FF4500>火</color>、<color=#8B7355>土</color>每种元素各 1 级。
		/// </summary>
        public static string Skill_S_Pachi_E_7 = "S_Pachi_E_7";
		/// <summary>
		/// 元素祈唤
		/// 从放逐牌库中选择2种“元素”属性，将其组合后获得对应的符卡技能。
		/// </summary>
        public static string Skill_S_Pachi_P = "S_Pachi_P";
		/// <summary>
		/// 金符「银龙」
		/// 每个等级的“金”额外施加 1 层“金属疲劳”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_0 = "S_Pachi_Sk_0_0";
		/// <summary>
		/// 金木符「元素收获者」
		/// 每个等级的“金”额外施加1层“元素异常”和“元素紊乱”。
		/// 每个等级的“木”额外施加1层“元素纠缠”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_1 = "S_Pachi_Sk_0_1";
		/// <summary>
		/// 金水符「水银之毒」
		/// 每个等级的“水”使这个技能额外治疗&a点体力(治疗力的10%)。
		/// 每个等级的“金”额外施加1层“生命涌现”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_2 = "S_Pachi_Sk_0_2";
		/// <summary>
		/// 火金符「圣爱尔摩火柱」
		/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的10%)。
		/// 每个等级的“金”额外施加1层“金属疲劳”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_3 = "S_Pachi_Sk_0_3";
		/// <summary>
		/// 土金符「翡翠巨石」
		/// 施加 &a 点保护罩(防御力的50%)。
		/// 每个等级的“金”额外施加1层“巨石护卫”。
		/// 每个等级的“土”额外施加&b点保护罩(防御力的10%)。
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_4 = "S_Pachi_Sk_0_4";
		/// <summary>
		/// 木符「风灵的角笛」
		/// 使目标持有的所有痛苦减益扩散至其他敌人。
		/// 指向敌人时，若只存在 1 个敌人，使目标持有的所有痛苦减益持续时间翻倍。
		/// 每个等级的“木”额外施加1层“森林大火”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_1_1 = "S_Pachi_Sk_1_1";
		/// <summary>
		/// 水木符「水精灵」
		/// 释放时，同时对目标右边的角色释放。
		/// 每个等级的“水”使这个技能额外治疗&a点体力(治疗力的10%)。
		/// 每个等级的“木”额外施加1层“活水之精”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_1_2 = "S_Pachi_Sk_1_2";
		/// <summary>
		/// 木火符「森林大火」
		/// 释放时对所有敌人造成痛苦伤害，伤害量等于目标持有的减益的每回合伤害量。
		/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的10%)。
		/// 每个等级的“木”额外施加1层“森林大火”。
		/// </summary>
        public static string Skill_S_Pachi_Sk_1_3 = "S_Pachi_Sk_1_3";
		/// <summary>
		/// 土木符「活体护甲」
		/// 每个等级的“木”使“活体护甲”的防御力提升额外增加10%。
		/// 每个等级的“土”使“活体护甲”的治疗和保护罩提升 &a (防御力的10%)。
		/// </summary>
        public static string Skill_S_Pachi_Sk_1_4 = "S_Pachi_Sk_1_4";
		/// <summary>
		/// 水符「湖葬」
		/// 如果目标无法受到治疗，则改为使目标的生命值提升 &a 点(治疗力的130%)。
		/// 每个等级的“水”使这个技能额外治疗或提升&b点体力(治疗力的20%)。
		/// </summary>
        public static string Skill_S_Pachi_Sk_2_2 = "S_Pachi_Sk_2_2";
		/// <summary>
		/// 水火符「燃素之雨」
		/// 重复释放 &c 次(1 + &e)。
		/// 每次释放时，恢复体力值最低的友军 &a 点体力值(治疗力的45%)。
		/// 每个等级的“火”使这个技能额外造成&b点伤害(攻击力的5%)、额外治疗&d点体力(治疗力的5%)。
		/// 每个等级的“水”额外重复释放 1 次。
		/// </summary>
        public static string Skill_S_Pachi_Sk_2_3 = "S_Pachi_Sk_2_3";
		/// <summary>
		/// 土水符「诺亚的大洪水」
		/// 随机解除目标持有的 1 个减益效果。每解除 1 个减益效果，施加 &a 保护罩(治疗力的20%)。
		/// 每个等级的“水”使这个技能额外治疗&a点体力(治疗力的10%)。
		/// 每个等级的“土”额外解除 1 个减益效果。
		/// </summary>
        public static string Skill_S_Pachi_Sk_2_4 = "S_Pachi_Sk_2_4";
		/// <summary>
		/// 火符「火神之光」
		/// 这个技能无视防御。
		/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的20%)。
		/// </summary>
        public static string Skill_S_Pachi_Sk_3_3 = "S_Pachi_Sk_3_3";
		/// <summary>
		/// 火土符「环状熔岩带」
		/// 同时攻击与技能目标嘲讽状态相同的所有敌人。
		/// 造成伤害的30%转化为自身的保护罩。
		/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的10%)。
		/// 每个等级的“土”使保护罩转化倍率提升20%。
		/// </summary>
        public static string Skill_S_Pachi_Sk_3_4 = "S_Pachi_Sk_3_4";
		/// <summary>
		/// 土符「慵懒三石塔」
		/// 生成 &a 防护墙(防御力的100%)。
		/// 每个等级的“土”使生成的防护墙提升 &a (防御力的20%)。
		/// </summary>
        public static string Skill_S_Pachi_Sk_4_4 = "S_Pachi_Sk_4_4";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 魔女
		/// English:
		/// 魔女
		/// Japanese:
		/// 魔女
		/// Chinese:
		/// 魔女
		/// Chinese-TW:
		/// </summary>
        public static string SystemCharacterRoleRole_Mage => ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("System/Character/Role/Role_Mage");
		/// <summary>
		/// Korean:
		/// 选择想要组合的元素：
		/// English:
		/// 选择想要组合的元素：
		/// Japanese:
		/// 选择想要组合的元素：
		/// Chinese:
		/// 选择想要组合的元素：
		/// Chinese-TW:
		/// </summary>
        public static string selectElement => ModManager.getModInfo("PatchouliKnowledge").localizationInfo.SystemLocalizationUpdate("selectElement");

    }
}