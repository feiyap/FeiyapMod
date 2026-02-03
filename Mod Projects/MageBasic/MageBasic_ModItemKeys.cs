using ChronoArkMod;
namespace MageBasic
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 魔女保护罩
		/// </summary>
        public static string Buff_B_Mage_Barrier = "B_Mage_Barrier";
		/// <summary>
		/// 魔女的药水
		/// 只能对魔女型角色使用。
		/// 出示所选友军的所有专属技能，选择其中的1个技能生成。
		/// </summary>
        public static string Item_Potions_Potion_Mage = "Potion_Mage";
        public static string CharRole_Role_Mage = "Role_Mage";
        public static string SkillEffect_SE_T_S_Mage_Default = "SE_T_S_Mage_Default";
		/// <summary>
		/// 技能书 - 魔女定式
		/// 只能对魔女型角色使用。
		/// 从所选友军的 5 个专属技能中选择 1 个学习。
		/// 再重复 1 次。
		/// </summary>
        public static string Item_Consume_SkillBookMage = "SkillBookMage";
		/// <summary>
		/// 基础法术
		/// 无法弱化或强化。
		/// 指向敌人时，造成 &a 伤害<color=#FF7A33>(攻击力的90%)</color>；
		/// 指向友军时，治疗 &b 体力<color=#48D1CC>(治疗力的80%)</color>并给予 &b 保护罩<color=#48D1CC>(治疗力的80%)</color>。
		/// </summary>
        public static string Skill_S_Mage_Default = "S_Mage_Default";
		/// <summary>
		/// 魔女的药水
		/// </summary>
        public static string Skill_S_Mage_Potion = "S_Mage_Potion";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 마녀
		/// English:
		/// Mage
		/// Japanese:
		/// 魔女
		/// Chinese:
		/// 魔女
		/// Chinese-TW:
		/// 魔女
		/// </summary>
        public static string SystemCharacterRoleRole_Mage => ModManager.getModInfo("MageBasic").localizationInfo.SystemLocalizationUpdate("System/Character/Role/Role_Mage");

    }
}