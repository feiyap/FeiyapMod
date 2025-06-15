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
		/// 切舍御免
		/// 受到治疗时移除 1 层。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_0 = "B_Feiyap_Boss_0";
        public static string EnemyQueue_Queue_Boss_Feiyap = "Queue_Boss_Feiyap";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_0 = "SE_T_S_Feiyap_Boss_0";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_2 = "SE_T_S_Feiyap_Boss_2";
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
		/// 明镜止水
		/// 若自身持有的减益数量超过 5 个，解除自身所有<sprite=0>弱化减益和<sprite=1>痛苦减益。受到那些减益的剩余伤害量的痛苦伤害。
		/// 移除所有手牌的额外增益效果。
		/// </summary>
        public static string Skill_S_Feiyap_Boss_2 = "S_Feiyap_Boss_2";
		/// <summary>
		/// 孤红之瞥
		/// </summary>
        public static string Skill_S_Feiyap_Boss_3 = "S_Feiyap_Boss_3";
		/// <summary>
		/// 切舍御免
		/// 受到伤害时，直到回合结束前，攻击力增加那个数值的值。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P = "B_Feiyap_Boss_P";
		/// <summary>
		/// 保护体力极限
		/// 每个回合开始时，恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P_1 = "B_Feiyap_Boss_P_1";
		/// <summary>
		/// 雨曾为紫
		/// 受到痛苦伤害时，提升等量的最大体力值。
		/// 每失去30体力值，自身获得“+10%造成伤害量提升”。
		/// </summary>
        public static string Buff_B_Feiyap_Boss_P_2 = "B_Feiyap_Boss_P_2";
        public static string SkillEffect_SE_T_S_Feiyap_Boss_1 = "SE_T_S_Feiyap_Boss_1";

    }

    public static class ModLocalization
    {

    }
}