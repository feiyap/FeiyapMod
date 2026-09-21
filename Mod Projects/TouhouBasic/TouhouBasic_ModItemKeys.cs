using ChronoArkMod;

namespace TouhouBasic
{
    public static class ModItemKeys
    {
        public static string CharRole_Role_Sage = "Role_Sage";

        /// <summary>
        /// 基础术
        /// 贤者职业的占位默认技能。
        /// </summary>
        public static string Skill_S_Sage_Default = "S_Sage_Default";

        public static string SkillEffect_SE_T_S_Sage_Default = "SE_T_S_Sage_Default";
    }

    public static class ModLocalization
    {
        /// <summary>
        /// 贤者
        /// </summary>
        public static string SystemCharacterRoleRole_Sage => ModManager.getModInfo("TouhouBasic").localizationInfo.SystemLocalizationUpdate("System/Character/Role/Role_Sage");
    }
}
