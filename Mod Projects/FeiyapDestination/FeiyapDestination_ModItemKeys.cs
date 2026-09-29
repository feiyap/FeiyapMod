using ChronoArkMod;
namespace FeiyapDestination
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 百巧手
		/// 每层：攻击力+1，治疗力+1。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Baiqiao = "B_FeiyapDestination_Baiqiao";
		/// <summary>
		/// 体内灼烧
		/// 每回合受到痛苦伤害。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Burn = "B_FeiyapDestination_Burn";
		/// <summary>
		/// 你的血如泪水般涓涓流下
		/// 拥有保护体力极限时，攻击伤害的25%转化为治疗。回合开始时获得最大体力20%的保护罩。痛苦抵抗率+80%。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Inherit_Feiyap = "B_FeiyapDestination_Inherit_Feiyap";
		/// <summary>
		/// 你的法术如过时玩具般无聊透顶
		/// 交替使用攻击与治疗技能时获得百巧手。每场战斗一次濒死抵消伤害。弱化抵抗率+80%。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Inherit_Mage = "B_FeiyapDestination_Inherit_Mage";
		/// <summary>
		/// 你的刀如樱花般凋零消散
		/// 受到伤害时若有自己的技能处于倒计时，本回合攻击力提升该伤害值。每回合一次，丢弃技能时抽 1。干扰抵抗率+80%。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Inherit_Tank = "B_FeiyapDestination_Inherit_Tank";
		/// <summary>
		/// 莲心
		/// 消耗真法力时获得。输出模式下每层提供 10% 暴击伤害；防御模式下可消耗以拦截友军受到的攻击。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Lianxin = "B_FeiyapDestination_Lianxin";
		/// <summary>
		/// 黄金瞳标记
		/// 被标记的敌人受到任意绯夜氏攻击时，消耗标记，其他绯夜氏发起追击。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Mark = "B_FeiyapDestination_Mark";
		/// <summary>
		/// 终点护盾
		/// 保护罩。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Shield = "B_FeiyapDestination_Shield";
		/// <summary>
		/// 缘起
		/// 每层提供 1% 暴击率提升。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Yuanqi = "B_FeiyapDestination_Yuanqi";
		/// <summary>
		/// 诸我自在
		/// 每层使回合开始时过载减少 2 点（可为负）。
		/// </summary>
        public static string Buff_B_FeiyapDestination_Zhuzi = "B_FeiyapDestination_Zhuzi";
		/// <summary>
		/// 终点·绯夜氏
		/// Passive:
		/// <<Any>>
		/// <b>莲心守月</b>
		/// 每个回合开始时，将 1 点法力值变为<color=#00BFFF>真</color>法力值。<color=#00BFFF>真</color>法力值在回合结束时保留，且于普通法力值之后被使用、消耗。每当有 1 点<color=#00BFFF>真</color>法力值被消耗时，绯夜氏获得 1 层<color=#00BFFF>莲心</color>，持续 2 回合。
		/// <</Any>>
		/// <<Offense>>
		/// <b>免许皆传</b>
		/// 每层<color=#00BFFF>莲心</color>还会提供 10% 暴击伤害提升。
		/// <</Offense>>
		/// <<Defense>>
		/// <b>流风遗韵</b>
		/// 当其他角色受到攻击时，消耗 1 层<color=#00BFFF>莲心</color>，绯夜氏拦截此次攻击、使该伤害降低（5x自身等级）点。
		/// <</Defense>>
		/// <<PAGE>>
		/// <<Any>>
		/// <b>立処皆真</b>
		/// 绯夜氏在命中、暴击、闪避上始终持有优势。
		/// <</Any>>
		/// <<Any>>
		/// <b>活殺自在</b>
		/// 在角色界面新增转职按钮：在{OffenseJob}和{DefenseJob}中来回切换。切换时，会生效对应职业的被动能力、而另一个会失效。
		/// <</Any>>
		/// <<Any>>
		/// <b>东方侍缘起</b>
		/// 绯夜氏每与一名角色并肩作战、并完成过循环，战斗开始时获得 1 层“缘起”。每层“缘起”提供 1% 暴击率提升。
		/// <</Any>>
		/// <<PAGE>>
		/// <<Any>>
		/// <b>诸我回响的黄金瞳</b>
		/// 队伍中每有 1 名除自己以外的“绯夜氏”，回合开始时，标记 1 个敌人。所有“绯夜氏”对被标记的敌人发起攻击时，消耗标记，其他“绯夜氏”会对该敌人发起追击。
		/// <</Any>>
		/// <<EighthLocked>>
		/// <b>秘而不宣的第八个文字</b>
		/// 绯夜氏的身上似乎隐藏着更多秘密……（获得金信物时解锁详情。）
		/// <</EighthLocked>>
		/// <<EighthUnlocked>>
		/// <b>第八个绯生之文字</b>
		/// 使用法力进行“等待”时，若手牌最上方的技能持有者为除自己外的“绯夜氏”，立即杀死她。
		/// 杀死其他“绯夜氏”时，或是战斗开始时每有 1 名已死亡的“绯夜氏”，都将获得 1 层“诸我自在”，并且所有持有者为那个“绯夜氏”的技能转移给自己。每有 1 层“诸我自在”，回合开始时过载减少 2 点（可以为负）。
		/// 绯夜氏 / 剑圣·绯夜氏 / 魔女·绯夜氏：分别继承对应的诸我回响效果。
		/// <</EighthUnlocked>>
		/// </summary>
        public static string Character_FeiyapDestination = "FeiyapDestination";
        public static string SkillEffect_SE_Tick_B_FeiyapDestination_Burn = "SE_Tick_B_FeiyapDestination_Burn";
        public static string SkillEffect_SE_T_S_FeiyapDestination_0 = "SE_T_S_FeiyapDestination_0";
        public static string SkillEffect_SE_T_S_FeiyapDestination_Chase_Feiyap = "SE_T_S_FeiyapDestination_Chase_Feiyap";
        public static string SkillEffect_SE_T_S_FeiyapDestination_Chase_Mage = "SE_T_S_FeiyapDestination_Chase_Mage";
        public static string SkillEffect_SE_T_S_FeiyapDestination_Chase_Tank = "SE_T_S_FeiyapDestination_Chase_Tank";
		/// <summary>
		/// 绯生占位
		/// （占位技能。完整技能组后续补全。）
		/// </summary>
        public static string Skill_S_FeiyapDestination_0 = "S_FeiyapDestination_0";
		/// <summary>
		/// 绯夜氏追击
		/// 诸我回响：35%倍率。施加1层体内灼烧。
		/// </summary>
        public static string Skill_S_FeiyapDestination_Chase_Feiyap = "S_FeiyapDestination_Chase_Feiyap";
		/// <summary>
		/// 魔女·绯夜氏追击
		/// 诸我回响：35%倍率。连锁治疗自己伤害量100%的体力。
		/// </summary>
        public static string Skill_S_FeiyapDestination_Chase_Mage = "S_FeiyapDestination_Chase_Mage";
		/// <summary>
		/// 剑圣·绯夜氏追击
		/// 诸我回响：35%倍率，攻击两次。
		/// </summary>
        public static string Skill_S_FeiyapDestination_Chase_Tank = "S_FeiyapDestination_Chase_Tank";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 전직
		/// English:
		/// Switch Job
		/// Japanese:
		/// 転職
		/// Chinese:
		/// 转职
		/// Chinese-TW:
		/// 轉職
		/// </summary>
        public static string UIJobSwitch_Button => ModManager.getModInfo("FeiyapDestination").localizationInfo.SystemLocalizationUpdate("UI/JobSwitch_Button");
		/// <summary>
		/// Korean:
		/// 유풍유운·종점
		/// English:
		/// Ryufu Defense
		/// Japanese:
		/// 流風遺韻・終点
		/// Chinese:
		/// 流风遗韵·终点·绯夜氏
		/// Chinese-TW:
		/// 流風遺韻·終點·緋夜氏
		/// </summary>
        public static string UIJobSwitch_Defense => ModManager.getModInfo("FeiyapDestination").localizationInfo.SystemLocalizationUpdate("UI/JobSwitch_Defense");
		/// <summary>
		/// Korean:
		/// 면역개전·종점
		/// English:
		/// Menkyo Offense
		/// Japanese:
		/// 免許皆伝・終点
		/// Chinese:
		/// 免许皆传·终点·绯夜氏
		/// Chinese-TW:
		/// 免許皆傳·終點·緋夜氏
		/// </summary>
        public static string UIJobSwitch_Offense => ModManager.getModInfo("FeiyapDestination").localizationInfo.SystemLocalizationUpdate("UI/JobSwitch_Offense");
		/// <summary>
		/// Korean:
		/// 다음
		/// English:
		/// Next
		/// Japanese:
		/// 次へ
		/// Chinese:
		/// 下一页
		/// Chinese-TW:
		/// 下一頁
		/// </summary>
        public static string UIPassivePage_Next => ModManager.getModInfo("FeiyapDestination").localizationInfo.SystemLocalizationUpdate("UI/PassivePage_Next");
		/// <summary>
		/// Korean:
		/// 이전
		/// English:
		/// Prev
		/// Japanese:
		/// 前へ
		/// Chinese:
		/// 上一页
		/// Chinese-TW:
		/// 上一頁
		/// </summary>
        public static string UIPassivePage_Prev => ModManager.getModInfo("FeiyapDestination").localizationInfo.SystemLocalizationUpdate("UI/PassivePage_Prev");

    }
}