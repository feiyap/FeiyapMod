using ChronoArkMod;
namespace FeiyapBoss
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 绯夜氏
		/// </summary>
        public static string Enemy_Boss_Feiyap = "Boss_Feiyap";
		/// <summary>
		/// 体内灼烧
		/// </summary>
        public static string Buff_B_Feiyap_Boss_1 = "B_Feiyap_Boss_1";
		/// <summary>
		/// 热寂
		/// 每次触发时，使这个减益的每回合伤害量提升5点。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_5 = "B_Feiyap_Boss_5";
		/// <summary>
		/// 切舍御免
		/// 受到伤害时，直到回合结束前，攻击力增加那个数值的值。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P = "B_Feiyap_Boss_P";
		/// <summary>
		/// 保护体力极限
		/// 每个回合开始时，恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
		/// 当前回合受到过的最高伤害：<color=#FFA500>&a</color>
		/// 上个回合受到过的最高伤害：<color=#FFA500>&b</color>
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P_1 = "B_Feiyap_Boss_P_1";
		/// <summary>
		/// 雨曾为紫
		/// 受到痛苦伤害时，提升等量的最大体力值。
		/// 每失去6体力值，自身获得“+1%攻击力”。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P_2 = "B_Feiyap_Boss_P_2";
		/// <summary>
		/// 烤全鸭
		/// 恢复友军100%的体力值，同时解除无法战斗状态。
		/// </summary>
        public static string Item_Consume_Item_BurnFullDuck = "Item_BurnFullDuck";
        public static string EnemyQueue_Queue_Boss_Feiyap = "Queue_Boss_Feiyap";
		/// <summary>
		/// 无名剑冢
		/// 在漫长到看不见尽头的平原之上，立着无数「剑」的尸体，以及铸造它们的铁匠的墓碑。
		/// 无名的剑冢中央，伫立着一名少女。
		/// 在她背后，破碎的星球残片化作沉默的王冕高悬于空，昭示着你们所有人的结局。
		/// 「胜利，否则毁灭。」——少女如此宣告道。
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_RE_Feiyap_Boss = "RE_Feiyap_Boss";
        public static string SkillEffect_SE_Tick_B_Feiyap_Boss_1 = "SE_Tick_B_Feiyap_Boss_1";
        public static string SkillEffect_SE_Tick_B_Feiyap_Boss_5 = "SE_Tick_B_Feiyap_Boss_5";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_0 = "SE_T_S_Feiyap_Boss_0";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_1 = "SE_T_S_Feiyap_Boss_1";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_2 = "SE_T_S_Feiyap_Boss_2";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_3 = "SE_T_S_Feiyap_Boss_3";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_4 = "SE_T_S_Feiyap_Boss_4";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_5 = "SE_T_S_Feiyap_Boss_5";
		/// <summary>
		/// 烤全鸭
		/// </summary>
        public static string Skill_S_BurnFullDuck = "S_BurnFullDuck";
		/// <summary>
		/// 绯夜流·一式
		/// 若目标拥有保护体力极限，额外造成 &a 伤害(攻击力的50%)。
		/// 否则立即恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_0 = "S_Feiyap_Boss_0";
		/// <summary>
		/// 里绯夜流·逆鳞斩
		/// 若目标拥有保护体力极限，使目标体力值变为 1。
		/// 否则额外施加 1 层“体内灼烧”。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_1 = "S_Feiyap_Boss_1";
		/// <summary>
		/// 天市右垣七
		/// 展示手牌中目标的所有技能。选择其中 1 个放逐。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_2 = "S_Feiyap_Boss_2";
		/// <summary>
		/// 幽壑千灯
		/// 这个技能额外造成「上个回合中，自己受到过的最高的单次伤害值」的一半的伤害。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_3 = "S_Feiyap_Boss_3";
		/// <summary>
		/// 明镜止水
		/// 解除自身所有<sprite=1>痛苦减益。受到那些减益的剩余伤害量的痛苦伤害。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_4 = "S_Feiyap_Boss_4";
		/// <summary>
		/// 星天陨辍
		/// 立即恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_5 = "S_Feiyap_Boss_5";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Oh? Isn't this Lucy?
		/// Japanese:
		/// Chinese:
		/// 哦呀？这不是露西吗？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText1 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text1");
		/// <summary>
		/// Korean:
		/// English:
		/// Hm? You mean the Time Shade? I’ve already defeated this stage’s boss—of course I have it.
		/// Japanese:
		/// Chinese:
		/// 嗯？你说时光之影？我已经干掉这关的BOSS了，当然在我手上。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText2 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text2");
		/// <summary>
		/// Korean:
		/// English:
		/// If you want it… then you have to take it!
		/// Japanese:
		/// Chinese:
		/// 如果你想要……那就自己来拿吧！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText3 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text3");
		/// <summary>
		/// Korean:
		/// English:
		/// Star Killer… This is the power of a version of me from a parallel world.
		/// Japanese:
		/// Chinese:
		/// 「斩星官」……这就是某个平行世界的我的力量。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText4 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text4");
		/// <summary>
		/// Korean:
		/// English:
		/// If you can’t even surpass me, you’ll never defeat the bosses that lie ahead.
		/// Japanese:
		/// Chinese:
		/// 如果连我都无法跨越的话，是无法击败之后的BOSS的。
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText5 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text5");
		/// <summary>
		/// Korean:
		/// English:
		/// A trial… is about overcoming your past, weaker self! Come at me, Lucy!
		/// Japanese:
		/// Chinese:
		/// 所谓「试炼」……就是战胜过去不成熟的自己！来吧，露西！
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaBoss_FeiyapText6 => ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text6");

    }
}