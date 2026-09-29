using System.Collections.Generic;
using ChronoArkMod.Template;

namespace FeiyapDestination
{
    public class S_FeiyapDestination_Chase_Feiyap : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets == null)
            {
                return;
            }
            foreach (BattleChar t in Targets)
            {
                if (t != null && !t.IsDead)
                {
                    t.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Burn, this.BChar, false, 0, false, -1, false);
                }
            }
        }
    }
}
