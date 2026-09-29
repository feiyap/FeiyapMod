using ChronoArkMod.Template;

namespace FeiyapDestination
{
    /// <summary>继承绯夜氏：吸血 / 护盾 / 痛苦抗</summary>
    public class B_FeiyapDestination_Inherit_Feiyap : Buff, IP_DealDamage, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_DOT = 80;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1 && this.BChar.GetStat.Strength && !IsDot)
            {
                this.BChar.Heal(this.BChar, (float)((int)(Damage * 0.25f)), false, false, null);
            }
        }

        public void Turn()
        {
            int shield = (int)(this.BChar.GetStat.maxhp * 0.2f);
            if (shield > 0)
            {
                Buff b = this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Shield, this.BChar, false, 0, false, -1, false);
                if (b != null)
                {
                    b.BarrierHP += shield;
                }
            }
        }
    }
}
