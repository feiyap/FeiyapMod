using ChronoArkMod;
namespace Mokou
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 迷途竹林
		/// 一片茂密的竹林，竹子都倾斜地生长着。扭曲之地里怎么会有怎么一片竹林存在？
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_Bamboo_Forest = "Bamboo_Forest";
		/// <summary>
		/// Lunatic
		/// </summary>
        public static string Buff_B_Kaguya_Lunatic = "B_Kaguya_Lunatic";
		/// <summary>
		/// 竹取飞翔
		/// 自身体力值每次归0时，进入下一个阶段。
		/// 当前阶段（&a/5）：
		/// &b
		/// 每个阶段开始时，将一张&c置入手牌中；每个回合开始时，如果手牌中没有&c，置入手中一张。
		/// </summary>
        public static string Buff_B_Kaguya_P = "B_Kaguya_P";
		/// <summary>
		/// 蓬莱之躯
		/// 生命值无法降低到1以下。每当生命值降到1时，本回合内免疫伤害。
		/// </summary>
        public static string Buff_B_Kaguya_P_0 = "B_Kaguya_P_0";
		/// <summary>
		/// 辉夜的五难题
		/// 当前难题：&a
		/// 当前阶段难题完成次数：&b
		/// 当前阶段难题未完成次数：&c
		/// 辉夜改变阶段时，如果完成次数大于未完成次数，全体友方获得提升5%攻击力与治疗力的增益；反之，辉夜获得提升10%攻击力与治疗力的增益。
		/// </summary>
        public static string Buff_B_Kaguya_P_1 = "B_Kaguya_P_1";
		/// <summary>
		/// 「不灭赤魂」
		/// 每重生一次，层数+1。每拥有一层「不灭赤魂」，生命上限+12；攻击力、治疗力+1；受到的伤害-1；命中率、暴击率、debuff成功率、抵抗率+5%；回合结束时对所有敌人施加赤魂层数的烧伤。
		/// </summary>
        public static string Buff_B_Mokou_0 = "B_Mokou_0";
		/// <summary>
		/// 火焰身躯
		/// 被击中时给双方施加2层<color=purple>烧伤痛苦减益（&a%）</color>。
		/// </summary>
        public static string Buff_B_Mokou_S_2 = "B_Mokou_S_2";
		/// <summary>
		/// 正直者的试炼
		/// 如果倒计时内没有受到攻击，则将一张aoe攻击置入手中；如果受到攻击，对双方施加2层烧伤（&a%）。
		/// </summary>
        public static string Buff_B_Mokou_S_3 = "B_Mokou_S_3";
		/// <summary>
		/// 「蓬莱人形」
		/// 如果自身有烧伤，保护体力极限。
		/// </summary>
        public static string Buff_B_Mokou_S_5 = "B_Mokou_S_5";
		/// <summary>
		/// 妹红的保护
		/// </summary>
        public static string Buff_B_Mokou_S_5_0 = "B_Mokou_S_5_0";
		/// <summary>
		/// 轮回「徐福时空」
		/// </summary>
        public static string Buff_B_Mokou_S_6 = "B_Mokou_S_6";
		/// <summary>
		/// 「燃烧殆尽吧！」
		/// 每回合结束时，对所有敌人施加3次<color=purple>烧伤痛苦减益</color>，每次1层。
		/// 每次敌人被施加超过层数上限的烧伤时，立刻造成1次<color=purple>&a点痛苦伤害</color>。
		/// </summary>
        public static string Buff_B_Mokou_S_R_1 = "B_Mokou_S_R_1";
		/// <summary>
		/// 「不死鸟重生」
		/// </summary>
        public static string Buff_B_Mokou_S_R_2 = "B_Mokou_S_R_2";
		/// <summary>
		/// 「涅槃重生」
		/// </summary>
        public static string Buff_B_Mokou_S_R_2_1 = "B_Mokou_S_R_2_1";
		/// <summary>
		/// 符卡冷却
		/// 解除时，将一张不死「火鸟 -凤翼天翔-」加入手牌中。
		/// </summary>
        public static string Buff_B_Mokou_S_R_3 = "B_Mokou_S_R_3";
		/// <summary>
		/// 灭罪
		/// 无法攻击藤原妹红以外的目标
		/// 攻击目标时解除。
		/// </summary>
        public static string Buff_B_Mokou_T_2 = "B_Mokou_T_2";
		/// <summary>
		/// 火焰萃取
		/// 行动时，自身每拥有1层烧伤痛苦减益，治疗妹红3%最大体力值的体力值。
		/// </summary>
        public static string Buff_B_Mokou_T_9 = "B_Mokou_T_9";
		/// <summary>
		/// 难题
		/// 由辉夜所布下的难题。每回合结束时，如果完成了难题，我方获得增益；如果没有完成难题，辉夜获得增益。
		/// </summary>
        public static string SkillKeyword_conundrum = "conundrum";
		/// <summary>
		/// 过热
		/// 自身拥有标识层数的烧伤时，结算并移除标识层数的烧伤，触发后续的额外效果。
		/// </summary>
        public static string SkillKeyword_exburn = "exburn";
		/// <summary>
		/// 蓬莱山辉夜
		/// </summary>
        public static string Enemy_Kaguya = "Kaguya";
		/// <summary>
		/// 藤原妹红
		/// Passive:
		/// 每次被击中时，如果受到伤害大于1，获得1层<color=purple>烧伤痛苦减益</color>。
		/// 每次体力低于0受到致命伤害时，无效此伤害，清除自身所有DEBUFF并提升全属性，然后恢复全部生命值，一场战斗最多生效等级除以2（向上取整）的次数。
		/// </summary>
        public static string Character_Mokou = "Mokou";
		/// <summary>
		/// 绀珠之药
		/// 瓶子中装着不明颜色的药水，据说喝下之后就可以预见未来，规避死亡的结局。
		/// 当友军受到致命伤害时，免疫此次伤害。（每场战斗最多触发2次）
		/// </summary>
        public static string Item_Passive_Mokou_Legacy = "Mokou_Legacy";
		/// <summary>
		/// 不死鸟之尾
		/// 受到的伤害-2
		/// 被击中时给予攻击者1层<color=purple>烧伤痛苦减益（100%）</color>。如果装备者是藤原妹红，额外给予攻击者和自身1层<color=purple>烧伤痛苦减益（100%）</color>。
		/// 根据装备角色的<color=purple>痛苦成功率</color>增加概率。
		/// </summary>
        public static string Item_Equip_Mokou_Plume = "Mokou_Plume";
        public static string EnemyQueue_Queue_Kaguya = "Queue_Kaguya";
        public static string SkillEffect_SE_Mokou_TBT_1 = "SE_Mokou_TBT_1";
        public static string SkillEffect_SE_S_S_Mokou_2 = "SE_S_S_Mokou_2";
        public static string SkillEffect_SE_S_S_Mokou_5 = "SE_S_S_Mokou_5";
        public static string SkillEffect_SE_S_S_Mokou_6 = "SE_S_S_Mokou_6";
        public static string SkillEffect_SE_S_S_Mokou_7 = "SE_S_S_Mokou_7";
        public static string SkillEffect_SE_S_S_Mokou_8 = "SE_S_S_Mokou_8";
        public static string SkillEffect_SE_S_S_Mokou_8_0 = "SE_S_S_Mokou_8_0";
        public static string SkillEffect_SE_S_S_Mokou_R_1 = "SE_S_S_Mokou_R_1";
        public static string SkillEffect_SE_S_S_Mokou_R_2 = "SE_S_S_Mokou_R_2";
        public static string SkillEffect_SE_S_S_Mokou_R_3 = "SE_S_S_Mokou_R_3";
        public static string SkillEffect_SE_T_S_Kaguya_1 = "SE_T_S_Kaguya_1";
        public static string SkillEffect_SE_T_S_Kaguya_1_0 = "SE_T_S_Kaguya_1_0";
        public static string SkillEffect_SE_T_S_Kaguya_1_1 = "SE_T_S_Kaguya_1_1";
        public static string SkillEffect_SE_T_S_Kaguya_1_2 = "SE_T_S_Kaguya_1_2";
        public static string SkillEffect_SE_T_S_Kaguya_1_Left = "SE_T_S_Kaguya_1_Left";
        public static string SkillEffect_SE_T_S_Kaguya_1_Right = "SE_T_S_Kaguya_1_Right";
        public static string SkillEffect_SE_T_S_Kaguya_6 = "SE_T_S_Kaguya_6";
        public static string SkillEffect_SE_T_S_Mokou_2 = "SE_T_S_Mokou_2";
        public static string SkillEffect_SE_T_S_Mokou_3 = "SE_T_S_Mokou_3";
        public static string SkillEffect_SE_T_S_Mokou_3_0 = "SE_T_S_Mokou_3_0";
        public static string SkillEffect_SE_T_S_Mokou_4 = "SE_T_S_Mokou_4";
        public static string SkillEffect_SE_T_S_Mokou_7 = "SE_T_S_Mokou_7";
        public static string SkillEffect_SE_T_S_Mokou_8_0 = "SE_T_S_Mokou_8_0";
        public static string SkillEffect_SE_T_S_Mokou_9 = "SE_T_S_Mokou_9";
        public static string SkillEffect_SE_T_S_Mokou_R_3 = "SE_T_S_Mokou_R_3";
		/// <summary>
		/// <color=orange>过热2：——抽取1个技能，回复1点法力值。</color>
		/// 2费及以下的技能
		/// </summary>
        public static string SkillExtended_SkillEn_Mokou_0 = "SkillEn_Mokou_0";
		/// <summary>
		/// 妹红每拥有1层赤魂，造成的伤害增加20%。
		/// 1费及以上的攻击技能
		/// </summary>
        public static string SkillExtended_SkillEn_Mokou_1 = "SkillEn_Mokou_1";
		/// <summary>
		/// 操控永远程度的能力
		/// </summary>
        public static string Skill_SP_Kaguya_ChangePhase = "SP_Kaguya_ChangePhase";
        public static string Skill_S_Kaguya_1_0 = "S_Kaguya_1_0";
        public static string Skill_S_Kaguya_1_1 = "S_Kaguya_1_1";
        public static string Skill_S_Kaguya_1_2 = "S_Kaguya_1_2";
		/// <summary>
		/// 神宝「耀眼的龙玉」
		/// 使用后，继续对目标左边的角色使用此技能，但是技能倍率减少25%，重复3次。
		/// </summary>
        public static string Skill_S_Kaguya_1_Left = "S_Kaguya_1_Left";
		/// <summary>
		/// 神宝「耀眼的龙玉」
		/// 使用后，继续对目标右边的角色使用此技能，但是技能倍率减少25%，重复3次。
		/// </summary>
        public static string Skill_S_Kaguya_1_Right = "S_Kaguya_1_Right";
		/// <summary>
		/// 难题「龙颈之玉　-五色的弹丸-」
		/// 每回合结束时，如果至少一半的角色没有体力极限（向上取整），恢复所有友方5点体力值；反之，下一回合开始时辉夜恢复10%最大生命值。
		/// </summary>
        public static string Skill_S_Kaguya_1_S = "S_Kaguya_1_S";
		/// <summary>
		/// 玉弹
		/// </summary>
        public static string Skill_S_Kaguya_6 = "S_Kaguya_6";
		/// <summary>
		/// Normal难度
		/// 面向一般人的难度模式。
		/// 将面对相当于普通难度弹幕的程度的辉夜的攻击。
		/// </summary>
        public static string Skill_S_Kaguya_Difficulty_0 = "S_Kaguya_Difficulty_0";
		/// <summary>
		/// Lunatic难度
		/// 不推荐给任何人尝试程度的难度。
		/// 将面对相当于疯狂难度弹幕的程度的辉夜的攻击，在如潮水一般的攻击下生存下来吧！
		/// </summary>
        public static string Skill_S_Kaguya_Difficulty_1 = "S_Kaguya_Difficulty_1";
		/// <summary>
		/// 妹红与辉夜的对决
		/// 妹红将独自与辉夜决斗，除了妹红以外的调查员仅在这场战斗中无法战斗。（Lunatic难度）
		/// 在这场战斗中，妹红的赤魂上限+1，复活次数不再受等级限制。
		/// </summary>
        public static string Skill_S_Kaguya_Difficulty_2 = "S_Kaguya_Difficulty_2";
		/// <summary>
		/// 焰符「自灭火焰大旋风」
		/// <color=orange>过热：2——恢复一点费用</color>
		/// 使用时对自己造成<color=purple>&a点痛苦伤害</color>。使用后本回合内可再释放一次。
		/// </summary>
        public static string Skill_S_Mokou_1 = "S_Mokou_1";
		/// <summary>
		/// 焰符「自灭火焰大旋风」
		/// 过热：2——恢复一点费用
		/// 使用时对自己造成<color=purple>&a点痛苦伤害</color>。使用后本回合内可再释放一次。
		/// </summary>
        public static string Skill_S_Mokou_1_0 = "S_Mokou_1_0";
        public static string SkillEffect_SE_Mokou_1_T = "SE_Mokou_1_T";
		/// <summary>
		/// 烧伤
		/// </summary>
        public static string Buff_B_Mokou_T_1 = "B_Mokou_T_1";
		/// <summary>
		/// 藤原「灭罪寺院伤」
		/// <color=orange>过热：3——对具有烧伤的目标施加‘灭罪’而非‘发怒！’。两回合内，如果自身有烧伤，获得体力极限保护。</color>
		/// 给所有敌人赋予‘发怒！’（持续3回合）。
		/// </summary>
        public static string Skill_S_Mokou_2 = "S_Mokou_2";
		/// <summary>
		/// 灭罪「正直者之死」
		/// 使用时，给予目标‘发怒！’。如果倒计时内没有受到攻击，则将一张本回合内0费，指向所有敌人的附带迅速的灭罪「正直者之死」置入手中，附带一回合后放逐；如果受到攻击，则对双方施加3层烧伤（仅生效一次）。
		/// </summary>
        public static string Skill_S_Mokou_3 = "S_Mokou_3";
		/// <summary>
		/// 灭罪「正直者之死」
		/// </summary>
        public static string Skill_S_Mokou_3_0 = "S_Mokou_3_0";
		/// <summary>
		/// 不灭「不死鸟之尾」
		/// <color=orange>过热：4——每重复释放一次，抽一张牌。</color>
		/// 根据自身的赤魂层数重复释放此技能。
		/// 重复释放的不灭「不死鸟之尾」造成一半伤害。
		/// </summary>
        public static string Skill_S_Mokou_4 = "S_Mokou_4";
		/// <summary>
		/// 「蓬莱人形」
		/// <color=orange>过热：3——给予全队2回合的体力极限保护。</color>
		/// 对自身施加&a（赤魂层数+1）层数的烧伤，连锁治疗自身&b%（（赤魂层数+1）*16%）的最大体力值（&c）。
		/// </summary>
        public static string Skill_S_Mokou_5 = "S_Mokou_5";
		/// <summary>
		/// 不死「徐福时空」
		/// <color=orange></color>使用后，不灭赤魂层数减少1层（可以再次复活1次）。
		/// </summary>
        public static string Skill_S_Mokou_6 = "S_Mokou_6";
		/// <summary>
		/// 咒符「无差别放火之符」
		/// <color=orange>过热：3——所有敌人的痛苦减益持续时间增加1回合。</color>
		/// 自身有剩余体力极限时，多施加1层烧伤痛苦减益。
		/// </summary>
        public static string Skill_S_Mokou_7 = "S_Mokou_7";
		/// <summary>
		/// 惜命「不死之身的舍身击」
		/// <color=orange>过热：2——额外加入一张「不死之身的舍身击」加入手牌。</color>
		/// 给予自身2层<color=purple>烧伤痛苦减益</color>，将一张「不死之身的舍身击」加入手牌。
		/// </summary>
        public static string Skill_S_Mokou_8 = "S_Mokou_8";
		/// <summary>
		/// 「不死之身的舍身击」
		/// 造成相当于自身最大体力值50%（&a）的额外伤害。
		/// </summary>
        public static string Skill_S_Mokou_8_0 = "S_Mokou_8_0";
		/// <summary>
		/// 不死「凯风快晴飞翔蹴」
		/// <color=orange>过热：1——将一张一回合后放逐的这张牌置入手中。</color>
		/// </summary>
        public static string Skill_S_Mokou_9 = "S_Mokou_9";
		/// <summary>
		/// 烈火汲取
		/// <color=orange>过热：2——抽取1个技能并恢复1点法力值。</color>
		/// 抽取1个技能并恢复1点法力值。
		/// </summary>
        public static string Skill_S_Mokou_LucyD_1 = "S_Mokou_LucyD_1";
		/// <summary>
		/// 「这不知是第几次的生命，燃烧殆尽吧」
		/// </summary>
        public static string Skill_S_Mokou_R_1 = "S_Mokou_R_1";
		/// <summary>
		/// 「不死鸟重生」
		/// 赤魂层数归0（可以再次重生）。
		/// 直到下一回合开始前，受到的伤害减少50%。
		/// 本次战斗中，最大生命值提升10点。
		/// </summary>
        public static string Skill_S_Mokou_R_2 = "S_Mokou_R_2";
		/// <summary>
		/// 不死「火鸟 -凤翼天翔-」
		/// 使用后立即触发一次重生，如果自身已经无法继续重生，则无法释放。
		/// 自身每受到一次伤害，手中的此卡减少1点费用。
		/// 这张卡只造成25%的伤害，并对所有敌人施加无法抵抗的眩晕。
		/// </summary>
        public static string Skill_S_Mokou_R_3 = "S_Mokou_R_3";
		/// <summary>
		/// 难题完成
		/// </summary>
        public static string Buff_B_Kaguya_Achieve = "B_Kaguya_Achieve";
		/// <summary>
		/// 难题未完成
		/// </summary>
        public static string Buff_B_Kaguya_Fail = "B_Kaguya_Fail";
		/// <summary>
		/// 难题完成
		/// 成功完成了辉夜的难题，全体友方获得增益。
		/// </summary>
        public static string Buff_B_Kaguya_S_Achieve = "B_Kaguya_S_Achieve";
		/// <summary>
		/// 难题未完成
		/// 未成功完成了辉夜的难题，辉夜获得增益。
		/// </summary>
        public static string Buff_B_Kaguya_S_Fail = "B_Kaguya_S_Fail";

    }

    public static class ModLocalization
    {

    }
}