using ChronoArkMod;
namespace CirnoBlizzard
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 琪露诺=暴风雪
		/// </summary>
        public static string Enemy_Boss_CirnoBlizzard = "Boss_CirnoBlizzard";
		/// <summary>
		/// 完美冻结
		/// 无法行动。
		/// 受到攻击后解除。
		/// </summary>
        public static string Buff_B_Boss_Cirno_Freeze = "B_Boss_Cirno_Freeze";
		/// <summary>
		/// 渐强的暴风雪
		/// 回合开始时，获得“攻击力+9%”。
		/// 每释放 6 个非生成技能，琪露诺=暴风雪会追加释放一次“冰冻新星”。每回合仅会触发 1 次。
		/// 剩余技能次数：&a
		/// </summary>
        public static string Buff_B_Boss_Cirno_P = "B_Boss_Cirno_P";
		/// <summary>
		/// 冻疮
		/// </summary>
        public static string Buff_B_Boss_Cirno_P1_2 = "B_Boss_Cirno_P1_2";
		/// <summary>
		/// 冰霜
		/// 每当自身被施加减益时，受到 &a 点痛苦伤害(攻击力的25%/每层)。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P2_0 = "B_Boss_Cirno_P2_0";
		/// <summary>
		/// 附骨之疽
		/// 受到治疗后解除。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P2_7 = "B_Boss_Cirno_P2_7";
		/// <summary>
		/// 圣洁之心
		/// 回合结束时，体力值变为0，失去所有体力极限，并抽取 1 个自己的技能。
		/// 使用自己的技能时解除，并获得持续 1 回合的“治疗力+10%，防御力+10%”。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P3_0 = "B_Boss_Cirno_P3_0";
		/// <summary>
		/// 污秽之心
		/// 回合结束时，体力值变为0，失去所有体力极限，并抽取 1 个自己的技能。
		/// 受到自身以外的治疗时解除，并获得持续 1 回合的“攻击力+10%”。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P3_0_1 = "B_Boss_Cirno_P3_0_1";
		/// <summary>
		/// 治疗力上升
		/// </summary>
        public static string Buff_B_Boss_Cirno_P3_0_2 = "B_Boss_Cirno_P3_0_2";
		/// <summary>
		/// 攻击力上升
		/// </summary>
        public static string Buff_B_Boss_Cirno_P3_0_3 = "B_Boss_Cirno_P3_0_3";
		/// <summary>
		/// 枯萎冻结之心
		/// 受到攻击时，进行一次 &a 伤害的反击(攻击力的25%)。
		/// 回合结束时，对所有单位造成 &b 痛苦伤害(攻击力的50%)。
		/// 仅有一次，体力值不会低于&c。触发时，转变为“刺痛流泪之心”。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P_1 = "B_Boss_Cirno_P_1";
		/// <summary>
		/// 刺痛流泪之心
		/// 每受到125伤害，生成 1 个“破碎的心”。每回合最多触发 3 次。
		/// 触发 3 次后，这个增益的“攻击力+50%”会转变为“受到伤害量+20%”，持续到回合结束。
		/// 仅有一次，体力值不会低于999。触发时，转变为“爱与妖精之心”。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P_2 = "B_Boss_Cirno_P_2";
		/// <summary>
		/// 爱与妖精之心
		/// 受到攻击时，恢复自身 &a 体力值(治疗力的39%)。
		/// 每次受到治疗时，获得“受到治疗量-5%”。
		/// 当自身受到治疗量低于0%时，追加释放“冰花恋曲”，并移除“受到治疗量降低”的效果。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P_3 = "B_Boss_Cirno_P_3";
		/// <summary>
		/// 暂时冻结
		/// 暂时冻结所有法力水晶。
		/// </summary>
        public static string Buff_B_Boss_Cirno_P_3_0 = "B_Boss_Cirno_P_3_0";
		/// <summary>
		/// 恸哭与冰之心
		/// 每个回合开始时，冻结最后 1 颗可用的法力水晶：这颗法力水晶不再可用。
		/// 每个回合中，最多能恢复 9 点法力值。超出时，清空所有法力值，并在本回合内暂时冻结所有法力水晶。
		/// 本回合还能恢复的法力值：&a
		/// </summary>
        public static string Buff_B_Boss_Cirno_P_3_1 = "B_Boss_Cirno_P_3_1";
		/// <summary>
		/// 冰封魔印
		/// 琪露诺=暴风雪释放技能后，“冰封魔印”会依次以倒计时1、2、3重复释放，然后消失。
		/// 被调查员击破时，在手中生成 1 个“雪符「完美的冰晶片」” （一次性的完美防御）。
		/// “冰封魔印”会优先攻击治疗力最高的单位。受到攻击后，会改为以最后一次的攻击者为优先攻击的目标。
		/// 当前锁定的攻击目标：&target
		/// </summary>
        public static string Buff_B_Sigil_P = "B_Sigil_P";
		/// <summary>
		/// 冰封魔印
		/// </summary>
        public static string Enemy_Enemy_Sigil = "Enemy_Sigil";
        public static string EnemyQueue_Queue_Boss_CirnoBlizzard = "Queue_Boss_CirnoBlizzard";
        public static string SkillEffect_SE_Tick_B_Boss_Cirno_P2_0 = "SE_Tick_B_Boss_Cirno_P2_0";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P1_2 = "SE_T_S_Boss_Cirno_P1_2";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P1_3 = "SE_T_S_Boss_Cirno_P1_3";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_0 = "SE_T_S_Boss_Cirno_P2_0";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_2 = "SE_T_S_Boss_Cirno_P2_2";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_3 = "SE_T_S_Boss_Cirno_P2_3";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_4 = "SE_T_S_Boss_Cirno_P2_4";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_5 = "SE_T_S_Boss_Cirno_P2_5";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_6 = "SE_T_S_Boss_Cirno_P2_6";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P2_7 = "SE_T_S_Boss_Cirno_P2_7";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P3_0 = "SE_T_S_Boss_Cirno_P3_0";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P3_1 = "SE_T_S_Boss_Cirno_P3_1";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P3_3 = "SE_T_S_Boss_Cirno_P3_3";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P3_4 = "SE_T_S_Boss_Cirno_P3_4";
        public static string SkillEffect_SE_T_S_Boss_Cirno_P3_5 = "SE_T_S_Boss_Cirno_P3_5";
		/// <summary>
		/// 破碎的心
		/// 优先抽取 1 个目标的技能。
		/// </summary>
        public static string Skill_S_Boss_Cirno_Lucy_0 = "S_Boss_Cirno_Lucy_0";
		/// <summary>
		/// 我心如冰
		/// 什么都不做……。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P1_0 = "S_Boss_Cirno_P1_0";
		/// <summary>
		/// 思念
		/// 什么都不做……。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P1_1 = "S_Boss_Cirno_P1_1";
		/// <summary>
		/// 冰冻新星
		/// </summary>
        public static string Skill_S_Boss_Cirno_P1_2 = "S_Boss_Cirno_P1_2";
		/// <summary>
		/// 反击
		/// </summary>
        public static string Skill_S_Boss_Cirno_P1_3 = "S_Boss_Cirno_P1_3";
		/// <summary>
		/// 绝对零度
		/// 这个技能造成痛苦伤害。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_0 = "S_Boss_Cirno_P2_0";
		/// <summary>
		/// 冰封魔印
		/// 召唤三个“冰封魔印”。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_1 = "S_Boss_Cirno_P2_1";
		/// <summary>
		/// 烈冰之斩
		/// 无视防御。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_2 = "S_Boss_Cirno_P2_2";
		/// <summary>
		/// 烈冰之刺
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_3 = "S_Boss_Cirno_P2_3";
		/// <summary>
		/// 钻石星辰
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_4 = "S_Boss_Cirno_P2_4";
		/// <summary>
		/// 烈冰之环
		/// 攻击目标以外的所有调查员。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_5 = "S_Boss_Cirno_P2_5";
		/// <summary>
		/// 烈冰之赐
		/// 攻击目标以及相邻的调查员。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_6 = "S_Boss_Cirno_P2_6";
		/// <summary>
		/// 破败冰霜之心
		/// 优先攻击未持有“完美冻结”的敌人。
		/// 若目标未持有“完美冻结”，则施加“完美冻结”。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P2_7 = "S_Boss_Cirno_P2_7";
		/// <summary>
		/// 圣洁之心
		/// 使所有非“输出”职业的调查员获得“圣洁之心”。
		/// 使所有“输出”职业的调查员获得“污秽之心”。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_0 = "S_Boss_Cirno_P3_0";
		/// <summary>
		/// 冰花之舞
		/// <b>无法闪避</b>
		/// 将伤害分摊给非濒死状态的所有调查员。
		/// 若全部处于濒死状态，则击杀所有调查员。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_1 = "S_Boss_Cirno_P3_1";
		/// <summary>
		/// 冰封魔印
		/// 召唤一个“冰封魔印”。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_2 = "S_Boss_Cirno_P3_2";
		/// <summary>
		/// 狂冬暴风雪
		/// 选择最左侧或最右侧的调查员承受这个技能。
		/// 释放之后，向右侧或左侧依次释放三次，但造成的伤害逐次降低25%。
		/// 只对前两个目标施加“疯狂之冬”。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_3 = "S_Boss_Cirno_P3_3";
		/// <summary>
		/// 浅冬
		/// 攻击目标以及相邻的调查员。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_4 = "S_Boss_Cirno_P3_4";
		/// <summary>
		/// 深冬
		/// 攻击目标以外的所有调查员。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_5 = "S_Boss_Cirno_P3_5";
		/// <summary>
		/// 冰花恋曲
		/// 使手中第 9 个技能添加“九连环”。
		/// 每次推进倒计时，都会使“九连环”爆炸，对技能的持有者造成 12 痛苦伤害，并向上移动 1 个技能位置。
		/// 按下回合结束按钮时，立即结算剩余所有的“九连环”效果和伤害。
		/// </summary>
        public static string Skill_S_Boss_Cirno_P3_S = "S_Boss_Cirno_P3_S";

    }

    public static class ModLocalization
    {

    }
}