using System.Collections;
using System.Collections.Generic;

namespace BossPhoenix
{
    /// <summary>
    /// 小世界现象
    /// 放逐目标技能，再按「仅有一项相同」连锁放逐并拿到手中。
    /// </summary>
    public class S_Lucy_SmallWorld : Skill_Extended
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            return ExceptSkill == this.MySkill;
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);
            if (Targets == null || Targets.Count == 0 || Targets[0] == null)
            {
                return;
            }

            Skill first = Targets[0];
            this.ExileSkill(first);
            BattleSystem.DelayInput(this.Co_SmallWorld(first));
        }

        private IEnumerator Co_SmallWorld(Skill firstExiled)
        {
            List<Skill> firstPool = new List<Skill>();
            firstPool.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            firstPool.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
            List<Skill> firstMatches = PhoenixSkillUtil.FilterExactlyOneMatch(firstPool, firstExiled);

            Skill second = null;
            if (firstMatches.Count > 0)
            {
                yield return BattleSystem.I_OtherSkillSelect(firstMatches, delegate (SkillButton btn)
                {
                    second = btn.Myskill;
                }, PhoenixLoc.SmallWorldExile, false, true, true, false, true);
            }

            if (second == null)
            {
                yield break;
            }

            this.ExileSkill(second);

            List<Skill> secondPool = new List<Skill>();
            secondPool.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            secondPool.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
            List<Skill> secondMatches = PhoenixSkillUtil.FilterExactlyOneMatch(secondPool, second);
            if (secondMatches.Count == 0)
            {
                yield break;
            }

            Skill drawn = null;
            yield return BattleSystem.I_OtherSkillSelect(secondMatches, delegate (SkillButton btn)
            {
                drawn = btn.Myskill;
            }, PhoenixLoc.SmallWorldDraw, false, true, true, false, true);

            if (drawn != null)
            {
                BattleSystem.instance.AllyTeam.Skills_Deck.Remove(drawn);
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(drawn);
                BattleSystem.instance.AllyTeam.Add(drawn, true);
            }
            yield break;
        }

        private void ExileSkill(Skill skill)
        {
            if (skill == null)
            {
                return;
            }
            skill.isExcept = true;
            if (BattleSystem.instance.AllyTeam.Skills.Contains(skill))
            {
                BattleSystem.instance.AllyTeam.Skills.Remove(skill);
                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
            }
            BattleSystem.instance.AllyTeam.Skills_Deck.Remove(skill);
            BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(skill);
        }
    }
}
