using ChronoArkMod;
namespace Boss_Junko
{
    public static class ModItemKeys
    {
        public static string Enemy_Boss_Junko = "Boss_Junko";
		/// <summary>
		/// 纯狐被动
		/// 总被动
		/// </summary>
        public static string Buff_B_FJunko_P = "B_FJunko_P";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 不共戴天之敌，嫦娥啊。你在看着吗！？
		/// Chinese-TW:
		/// </summary>
        public static string BattleDiaFJunkoBattleStartText1 => ModManager.getModInfo("Boss_Junko").localizationInfo.SystemLocalizationUpdate("BattleDia/FJunkoBattleStart/Text1");

    }
}