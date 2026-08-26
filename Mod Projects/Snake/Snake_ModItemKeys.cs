using ChronoArkMod;
namespace Snake
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 贪吃蛇硬币
		/// 使用后打开一局贪吃蛇游戏。游戏结束后，获得“得分 x 100”的金币。
		/// </summary>
        public static string Item_Consume_Item_Snake = "Item_Snake";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// OK
		/// Japanese:
		/// Chinese:
		/// 确定
		/// Chinese-TW:
		/// </summary>
        public static string SnakeGameClose => ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate("SnakeGame/Close");
		/// <summary>
		/// Korean:
		/// English:
		/// Arrow keys / WASD to move, Esc to end
		/// Japanese:
		/// Chinese:
		/// 方向键 / WASD 移动，Esc 结束
		/// Chinese-TW:
		/// </summary>
        public static string SnakeGameHint => ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate("SnakeGame/Hint");
		/// <summary>
		/// Korean:
		/// English:
		/// Game Over|Score: {0}|Gold: {1}
		/// Japanese:
		/// Chinese:
		/// 游戏结束|得分：{0}|获得金币：{1}
		/// Chinese-TW:
		/// </summary>
        public static string SnakeGameResult => ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate("SnakeGame/Result");
		/// <summary>
		/// Korean:
		/// English:
		/// Score: {0}
		/// Japanese:
		/// Chinese:
		/// 得分：{0}
		/// Chinese-TW:
		/// </summary>
        public static string SnakeGameScore => ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate("SnakeGame/Score");
		/// <summary>
		/// Korean:
		/// English:
		/// Snake
		/// Japanese:
		/// Chinese:
		/// 贪吃蛇
		/// Chinese-TW:
		/// </summary>
        public static string SnakeGameTitle => ModManager.getModInfo("Snake").localizationInfo.SystemLocalizationUpdate("SnakeGame/Title");

    }
}