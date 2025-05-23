using ChronoArkMod;
namespace PatchouliKnowledge
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 帕秋莉
		/// Passive:
		/// <b>知识与避世的少女</b> - 战斗开始时，在本次战斗期间放逐自己的所有“元素”技能。每个被放逐的“元素”技能会转化为“元素”属性，重复转化的“元素”属性会提升属性的等级。
		/// <b>使用魔法程度的能力</b> - <b>固定能力替换为“元素祈唤”。</b>
		/// 等级到达3级时，每个回合第 1 次释放“元素祈唤”后，重置“元素祈唤”的冷却时间。
		/// 等级到达5级时，“元素祈唤”不再拥有冷却时间。
		/// <color=#919191>- 此被动从1级开始生效。</color>
		/// <color=#919191>- 帕秋莉的技能学习不再拥有上限。</color>
		/// </summary>
        public static string Character_PatchouliKnowledge = "PatchouliKnowledge";
		/// <summary>
		/// 基本元素 - 金
		/// 使用时，在本次战斗期间“金”元素等级提升 1 级。
		/// 每个等级的“金”提供10%痛苦成功率和痛苦抵抗率。
		/// </summary>
        public static string Skill_S_Pachi_E_0 = "S_Pachi_E_0";
		/// <summary>
		/// 基本元素 - 木
		/// 使用时，在本次战斗期间“木”元素等级提升 1 级。
		/// 每个等级的“木”提供10%弱化成功率、干扰成功率和弱化抵抗率、干扰抵抗率。
		/// </summary>
        public static string Skill_S_Pachi_E_1 = "S_Pachi_E_1";
		/// <summary>
		/// 基本元素 - 水
		/// 使用时，在本次战斗期间“水”元素等级提升 1 级。
		/// 每个等级的“水”提供2点治疗力、2%闪避率。
		/// </summary>
        public static string Skill_S_Pachi_E_2 = "S_Pachi_E_2";
		/// <summary>
		/// 基本元素 - 火
		/// 使用时，在本次战斗期间“火”元素等级提升 1 级。
		/// 每个等级的“火”提供2点攻击力、2%暴击率。
		/// </summary>
        public static string Skill_S_Pachi_E_3 = "S_Pachi_E_3";
		/// <summary>
		/// 基本元素 - 土
		/// 使用时，在本次战斗期间“土”元素等级提升 1 级。
		/// 每个等级的“土”提供4%防御力。
		/// </summary>
        public static string Skill_S_Pachi_E_4 = "S_Pachi_E_4";
		/// <summary>
		/// 元素祈唤
		/// 从放逐牌库中选择2种“元素”属性，将其组合后获得对应的符卡技能。
		/// </summary>
        public static string Skill_S_Pachi_P = "S_Pachi_P";
		/// <summary>
		/// 金木符「元素收获者」
		/// </summary>
        public static string Skill_S_Pachi_Sk_0_1 = "S_Pachi_Sk_0_1";
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

    }

    public static class ModLocalization
    {

    }
}