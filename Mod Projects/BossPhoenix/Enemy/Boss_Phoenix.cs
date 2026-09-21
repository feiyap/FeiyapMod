using System.Collections.Generic;

namespace BossPhoenix
{
    public class Boss_Phoenix : AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            if (this.BChar.Skills == null || this.BChar.Skills.Count == 0)
            {
                return base.SkillSelect(ActionCount);
            }

            if (ActionCount == 0)
            {
                return this.BChar.Skills[0];
            }
            if (ActionCount == 1 && this.BChar.Skills.Count > 1)
            {
                return this.BChar.Skills[1];
            }
            if (this.BChar.Skills.Count > 2)
            {
                return this.BChar.Skills[2];
            }
            return this.BChar.Skills[0];
        }

        public override int SpeedChange(Skill skill, int ActionCount, int OriginSpeed)
        {
            if (ActionCount == 0)
            {
                return 1;
            }
            if (ActionCount == 1)
            {
                return 3;
            }
            if (ActionCount == 2)
            {
                return 5;
            }
            return base.SpeedChange(skill, ActionCount, OriginSpeed);
        }

        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            return base.TargetSelect(SelectedSkill);
        }
    }
}
