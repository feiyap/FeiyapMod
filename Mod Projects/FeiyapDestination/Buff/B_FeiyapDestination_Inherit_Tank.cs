using ChronoArkMod.Template;

namespace FeiyapDestination
{
    /// <summary>继承剑圣：倒计时受伤转攻击 / 丢弃抽牌 / 干扰抗</summary>
    public class B_FeiyapDestination_Inherit_Tank : Buff, IP_DamageTake, IP_PlayerTurn, IP_Discard
    {
        private int _turnAtkBonus;
        private bool _discardUsed;

        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_CC = 80;
        }

        public void Turn()
        {
            this._turnAtkBonus = 0;
            this.PlusStat.atk = 0;
            this._discardUsed = false;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg <= 0 || !this.HasCastingSkill())
            {
                return;
            }
            this._turnAtkBonus += Dmg;
            this.PlusStat.atk = this._turnAtkBonus;
        }

        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (this._discardUsed || skill == null || skill.Master != this.BChar)
            {
                return;
            }
            this._discardUsed = true;
            if (BattleSystem.instance != null)
            {
                BattleSystem.instance.AllyTeam.Draw(1);
            }
        }

        private bool HasCastingSkill()
        {
            if (BattleSystem.instance == null || BattleSystem.instance.CastSkills == null)
            {
                return false;
            }
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs != null && cs.skill != null && cs.skill.Master == this.BChar)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
