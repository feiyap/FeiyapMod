namespace BossPhoenix
{
    /// <summary>
    /// 好疼…
    /// 受到痛苦伤害增加100%。
    /// </summary>
    public class B_BossPhoenix_Pain : Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (NODEF)
            {
                return (int)(Dmg * 2f);
            }
            return Dmg;
        }
    }
}
