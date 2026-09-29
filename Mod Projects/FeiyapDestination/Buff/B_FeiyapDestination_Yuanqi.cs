using ChronoArkMod.Template;

namespace FeiyapDestination
{
    public class B_FeiyapDestination_Yuanqi : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = this.StackNum;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.cri = this.StackNum;
        }
    }
}
