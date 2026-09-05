namespace BossPhoenix
{
    public class BattleEvent_Phoenix : PassiveBase, IP_BattleEnd
    {
        public void BattleEnd()
        {
            BattleEvent_Phoenix.Boss = null;
            BattleEvent_Phoenix.MainP = null;
        }

        public static BattleChar Boss;

        public static B_BossPhoenix_P MainP;
    }
}
