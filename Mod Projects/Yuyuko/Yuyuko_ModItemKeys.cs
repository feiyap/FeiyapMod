using ChronoArkMod;
namespace Yuyuko
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 轮回蝶
		/// 结算时降低&a最大体力值(&user的攻击力的25%)。
		/// </summary>
        public static string Buff_B_YuyukoF_1 = "B_YuyukoF_1";
		/// <summary>
		/// <color=#4876FF>幽冥蝶</color>
		/// &effect
		/// </summary>
        public static string Buff_B_YuyukoF_Butterfly_M = "B_YuyukoF_Butterfly_M";
		/// <summary>
		/// <color=#FF69B4>人魂蝶</color>
		/// &effect
		/// </summary>
        public static string Buff_B_YuyukoF_Butterfly_R = "B_YuyukoF_Butterfly_R";
		/// <summary>
		/// 死亡的边界
		/// </summary>
        public static string Buff_B_YuyukoF_Die = "B_YuyukoF_Die";
		/// <summary>
		/// <color=#E066FF>唤魂</color>
		/// 当前有<color=#E066FF>&a</color>点<color=#E066FF>亡魂</color>。
		/// </summary>
        public static string Buff_B_YuyukoF_Ghost = "B_YuyukoF_Ghost";
		/// <summary>
		/// 通常
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_1 = "B_YuyukoF_P_1";
		/// <summary>
		/// <color=#FF1493>华胥</color>
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_2 = "B_YuyukoF_P_2";
		/// <summary>
		/// <color=#8B008B>永眠</color>
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_3 = "B_YuyukoF_P_3";
		/// <summary>
		/// <color=#4876FF>幽冥蝶</color>
		/// 可以被转化为<color=#4876FF>幽冥蝶</color>施加在敌人身上。
		/// </summary>
        public static string SkillKeyword_Keyword_ButterflyM = "Keyword_ButterflyM";
		/// <summary>
		/// <color=#FF69B4>人魂蝶</color>
		/// 可以被转化为<color=#FF69B4>人魂蝶</color>施加在敌人身上。
		/// </summary>
        public static string SkillKeyword_Keyword_ButterflyR = "Keyword_ButterflyR";
		/// <summary>
		/// <color=#CAE1FF><b>亡者召还X</b></color>
		/// 从放逐牌库中、费用不超过X的技能中，将随机1个费用最高的技能拿回手中（持有者不为自己的一次性技能除外）。
		/// </summary>
        public static string SkillKeyword_Keyword_DeadRevive = "Keyword_DeadRevive";
		/// <summary>
		/// <color=#E066FF><b>唤魂X</b></color>
		/// 打出技能时，消耗X点<color=#E066FF>亡魂</color>，能够触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Ghost = "Keyword_Ghost";
		/// <summary>
		/// <color=#FF1493>华胥</color>
		/// 在<color=#FF1493>华胥</color>状态下，部分技能获得强化。
		/// </summary>
        public static string SkillKeyword_Keyword_Huaxu = "Keyword_Huaxu";
		/// <summary>
		/// <color=#AB82FF><b>葬送</b></color>
		/// 技能被放逐时，能够触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Ruin = "Keyword_Ruin";
        public static string SkillEffect_SE_T_S_YuyukoF_0 = "SE_T_S_YuyukoF_0";
        public static string SkillEffect_SE_T_S_YuyukoF_1 = "SE_T_S_YuyukoF_1";
        public static string SkillEffect_SE_T_S_YuyukoF_2 = "SE_T_S_YuyukoF_2";
        public static string SkillEffect_SE_T_S_YuyukoF_P_2 = "SE_T_S_YuyukoF_P_2";
		/// <summary>
		/// 亡乡「亡我乡 -宿罪-」
		/// 增加20返魂值。
		/// 华胥 - 超额治疗自己等量于“目标已损失的最大体力值的25%”的体力。
		/// 葬送 - 亡者召还3。
		/// 幽冥蝶 - 回合开始时，降低10%最大体力值。
		/// 人魂蝶 - 可以无视嘲讽状态被选中。
		/// </summary>
        public static string Skill_S_YuyukoF_0 = "S_YuyukoF_0";
		/// <summary>
		/// 死蝶「华胥之永眠」
		/// 增加20返魂值。
		/// 华胥 - 若指向目标拥有冥魂蝶，以暴击形式命中；若指向目标拥有人魂蝶，不再拥有倒计时1。
		/// 唤魂5 - 以倒计时2重复释放1次。
		/// 幽冥蝶 - 受到的非痛苦伤害转化为降低等量的最大体力值。
		/// 人魂蝶 - 受到的痛苦伤害转化为降低等量的最大体力值。
		/// </summary>
        public static string Skill_S_YuyukoF_1 = "S_YuyukoF_1";
		/// <summary>
		/// 幽雅「通向黄泉的诱蛾灯」
		/// 仅能指定同时拥有幽冥蝶和人魂蝶的敌人。
		/// 回引目标的幽冥蝶和人魂蝶。
		/// 唤魂30 - 额外造成&a(300%)伤害。
		/// 华胥 - 额外造成&a(300%)伤害。
		/// 幽冥蝶 - 施加时，触发一次亡者召还1。回引时，触发一次亡者召还1。
		/// 人魂蝶 - 施加时，获得8点亡魂。回引时，获得8点亡魂。
		/// </summary>
        public static string Skill_S_YuyukoF_2 = "S_YuyukoF_2";
		/// <summary>
		/// <color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>
		/// 仅能选择拥有幽冥蝶和人魂蝶关键词的技能。
		/// 放逐目标技能，将其转化为1个技能对应的减益效果施加在任意敌人身上。
		/// 幽冥蝶和人魂蝶各只能存在1只，在回引之前无法再次施加。
		/// </summary>
        public static string Skill_S_YuyukoF_P_1 = "S_YuyukoF_P_1";
		/// <summary>
		/// 转化<color=#4876FF>幽冥蝶</color>
		/// 将目标技能转化为<color=#4876FF>幽冥蝶</color>施加在任意敌人身上。&a
		/// </summary>
        public static string Skill_S_YuyukoF_P_1_1 = "S_YuyukoF_P_1_1";
		/// <summary>
		/// 转化<color=#FF69B4>人魂蝶</color>
		/// 将目标技能转化为<color=#FF69B4>人魂蝶</color>施加在任意敌人身上。&a
		/// </summary>
        public static string Skill_S_YuyukoF_P_1_2 = "S_YuyukoF_P_1_2";
		/// <summary>
		/// <color=#4876FF>亡乡「亡我乡 -自尽-」</color>
		/// 立即获得100返魂值，并进入永眠状态。
		/// </summary>
        public static string Skill_S_YuyukoF_P_2 = "S_YuyukoF_P_2";
		/// <summary>
		/// <color=#8B008B>亡乡「亡我乡 -无道之路-」</color>
		/// 放逐目标技能，并依据放逐技能的费用，每点费用减少50返魂值。
		/// </summary>
        public static string Skill_S_YuyukoF_P_3 = "S_YuyukoF_P_3";
		/// <summary>
		/// 西行寺幽幽子
		/// Passive:
		/// <b>操纵死亡程度的能力</b> - 西行寺幽幽子模糊了生与死的界限，部分技能会增加或减少<color=#FFB6C1>返魂值</color>。西行寺幽幽子的攻击不再造成伤害，而是降低目标等量的最大体力值。每个回合开始时，西行寺幽幽子减少20<color=#FFB6C1>返魂值</color>。
		/// <b><color=#FF1493>幽雅地绽放吧</color>，<color=#8B008B>墨染之樱</color></b> - 当<color=#FFB6C1>返魂值</color>的进度超过50时，西行寺幽幽子进入<color=#FF1493>华胥</color>状态，并从放逐牌库将1个自己的技能放回牌库最上方；
		/// 在<color=#FF1493>华胥</color>状态下，固定技能被替换为<color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>。
		/// 场上同时存在幽冥蝶和人魂蝶时，固定技能被替换为<color=#4876FF>亡乡「亡我乡 -自尽-」</color>。
		/// 当<color=#FFB6C1>返魂值</color>的进度超过100时，西行寺幽幽子进入<color=#8B008B>永眠</color>状态，并使所有敌人失去10%最大体力值、并<color=#8B008B>引爆</color>所有<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>；
		/// 在<color=#8B008B>永眠</color>状态下，固定技能被替换为<color=#8B008B>亡乡「亡我乡 -无道之路-」</color>。
		/// 进入华胥状态、进入永眠状态、解除永眠状态时，可再次使用固定能力。
		/// <color=#E066FF><b>唤魂X</b></color> - 每有1个技能被放逐，西行寺幽幽子获得1点亡魂。打出技能时，消耗X点亡魂，能够触发额外效果。
		/// <color=#AB82FF><b>葬送</b></color> - 技能被放逐时，能够触发额外效果。
		/// <color=#CAE1FF><b>亡者召还X</b></color> - 从放逐牌库将1个费用不超过X的技能拿回手中。
		/// </summary>
        public static string Character_YuyukoF = "YuyukoF";
		/// <summary>
		/// 亡舞「生者必灭之理」
		/// </summary>
        public static string Skill_S_YuyukoF_3 = "S_YuyukoF_3";
		/// <summary>
		/// 冥符「黄泉平坂行路」
		/// 增加20返魂值。
		/// 使所有敌人获得与目标相同的“已损失最大体力值”的值。
		/// 葬送 - 使所有敌人失去&a最大体力值(攻击力的90%)。
		/// 幽冥蝶 - 回引时，造成&a的伤害(&user攻击力的90%)。
		/// 人魂蝶 - 回引时，(100%干扰成功率)眩晕1回合。
		/// </summary>
        public static string Skill_S_YuyukoF_4 = "S_YuyukoF_4";
		/// <summary>
		/// 蝶符「凤蝶纹的死枪」
		/// 目标每损失1点最大体力值，这个技能的伤害提升1%。
		/// 葬送 - 对随机敌人释放这个技能。
		/// 幽冥蝶 - 回引时，造成&a的伤害(&user攻击力的90%)。
		/// 人魂蝶 - 回引时，(100%干扰成功率)眩晕1回合。
		/// </summary>
        public static string Skill_S_YuyukoF_5 = "S_YuyukoF_5";
		/// <summary>
		/// 樱符「完全墨染的樱花」
		/// 增加20返魂值。
		/// 唤魂4 - 亡者召还0。
		/// 华胥 - 改为减少20返魂值。
		/// 幽冥蝶 - 回引时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// 人魂蝶 - 回引时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// </summary>
        public static string Skill_S_YuyukoF_6 = "S_YuyukoF_6";
		/// <summary>
		/// 灵蝶「蝶之羽风暂留此世」
		/// 仅能在无法行动时、或处于永眠状态时使用。
		/// 解除所有干扰减益和永眠状态，抽取1个技能，恢复1点法力值。
		/// 将返魂值设置为50，并进入华胥状态。
		/// 立即获得30点亡魂。回合结束时，移除30点亡魂。
		/// 葬送 - 降低100返魂值。
		/// 幽冥蝶 - 施加时，抽取1个技能。
		/// 人魂蝶 - 施加时，恢复1点法力值。
		/// </summary>
        public static string Skill_S_YuyukoF_7 = "S_YuyukoF_7";
		/// <summary>
		/// 死符「醉人之生，死的梦幻」
		/// 仅能在华胥状态下使用。
		/// 华胥 - 减少20返魂值。
		/// 葬送 - 选择手中1个技能放逐，亡者召还1。
		/// 施加[醉梦蝶]：3回合；受到的伤害降低为0，但自身增加等量于伤害值的返魂值；自身陷入永眠时立即解除。
		/// </summary>
        public static string Skill_S_YuyukoF_8 = "S_YuyukoF_8";
		/// <summary>
		/// 樱花「依恋未酌宴」
		/// </summary>
        public static string Skill_S_YuyukoF_9 = "S_YuyukoF_9";
		/// <summary>
		/// 寿命「通向无寿国的期票」
		/// 放逐目标技能，抽取3个技能。
		/// </summary>
        public static string Skill_S_YuyukoF_LucyD = "S_YuyukoF_LucyD";
		/// <summary>
		/// 「反魂蝶」
		/// 握在手中时，自身每次进入永眠状态时，使这个技能获得：打出时，重复释放1次。
		/// 这个技能最多能重复释放10次。
		/// 葬送 - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
		/// 幽冥蝶 - 
		/// 人魂蝶 - 
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_1 = "S_YuyukoF_Rare_1";
		/// <summary>
		/// 「反魂蝶 - 一分咲」
		/// 重复释放 &a 次。
		/// 握在手中时，自身每次进入永眠状态时，使这个技能获得：打出时，重复释放1次。
		/// 这个技能最多能重复释放10次。
		/// 葬送 - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
		/// 冥魂蝶 - 
		/// 人魂蝶 - 
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_1_0 = "S_YuyukoF_Rare_1_0";
		/// <summary>
		/// 再迷「幻想乡的黄泉归」
		/// 握在手中时，每次有技能被放逐，使这个技能费用降低1点。
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_2 = "S_YuyukoF_Rare_2";
		/// <summary>
		/// 「死蝶浮月」
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_3 = "S_YuyukoF_Rare_3";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 回合开始时，降低10%最大体力值。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_0_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_0_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 可以无视嘲讽状态被选中。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_0_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_0_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=red>场上已经有<color=#4876FF>幽冥蝶</color>了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_P_1_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_P_1_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=red>场上已经有<color=#FF69B4>人魂蝶</color>了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_P_1_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_P_1_2/Text");

    }
}