using ChronoArkMod.Template;

namespace FeiyapDestination
{
    public class B_FeiyapDestination_Baiqiao : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = this.StackNum;
            this.PlusStat.reg = this.StackNum;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.atk = this.StackNum;
            this.PlusStat.reg = this.StackNum;
        }
    }
}
