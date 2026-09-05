using ChronoArkMod;

namespace BossPhoenix
{
    /// <summary>
    /// 编辑器会按 LangSystemDB 的 Key 生成属性名。
    /// 这里补 Loc 和代码里用到的短名，避免被覆盖后再次编不过。
    /// </summary>
    public static partial class ModLocalization
    {
        public static string Loc(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            try
            {
                return ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate(key);
            }
            catch
            {
                return key;
            }
        }

        public static string RiddleCorrect
        {
            get { return BattleDiaBoss_PhoenixCorrect; }
        }

        public static string RiddleFail
        {
            get { return BattleDiaBoss_PhoenixFail; }
        }

        public static string BattleStart1
        {
            get { return BattleDiaBoss_PhoenixText1; }
        }

        public static string BattleStart2
        {
            get { return BattleDiaBoss_PhoenixText2; }
        }

        public static string BattleStart3
        {
            get { return BattleDiaBoss_PhoenixText3; }
        }

        public static string Stubborn
        {
            get { return BattleDiaBoss_PhoenixStubborn; }
        }

        public static string Soothe
        {
            get { return BattleDiaBoss_PhoenixSoothe; }
        }

        public static string SmallWorldExile
        {
            get { return SmallWorldExileSelect; }
        }

        public static string SmallWorldDraw
        {
            get { return SmallWorldDrawSelect; }
        }
    }
}
