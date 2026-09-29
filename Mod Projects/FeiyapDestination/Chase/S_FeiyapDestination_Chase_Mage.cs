using ChronoArkMod.Template;

namespace FeiyapDestination
{
    public class S_FeiyapDestination_Chase_Mage : Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            if (DMG > 0 && this.BChar != null)
            {
                this.BChar.Heal(this.BChar, (float)DMG, false, false, null);
            }
        }
    }
}
