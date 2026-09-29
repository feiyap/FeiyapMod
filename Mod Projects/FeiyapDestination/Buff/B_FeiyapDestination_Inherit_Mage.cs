using ChronoArkMod.Template;

namespace FeiyapDestination
{
    /// <summary>继承魔女：攻疗交替百巧手 / 濒死免伤 / 弱化抗</summary>
    public class B_FeiyapDestination_Inherit_Mage : Buff, IP_SkillUseHand_Team, IP_DamageTake
    {
        private enum LastKind
        {
            None,
            Attack,
            Heal
        }

        private LastKind _last = LastKind.None;
        private bool _nearDeathSaved;

        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_DEBUFF = 80;
            this._nearDeathSaved = false;
            this._last = LastKind.None;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill == null || skill.Master != this.BChar)
            {
                return;
            }
            LastKind kind = LastKind.None;
            if (skill.IsDamage)
            {
                kind = LastKind.Attack;
            }
            else if (skill.IsHeal)
            {
                kind = LastKind.Heal;
            }
            if (kind == LastKind.None)
            {
                return;
            }
            if (this._last != LastKind.None && this._last != kind)
            {
                this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Baiqiao, this.BChar, false, 0, false, -1, false);
            }
            this._last = kind;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (this._nearDeathSaved || Dmg <= 0)
            {
                return;
            }
            if (this.BChar.HP > 0 && this.BChar.HP <= Dmg)
            {
                this._nearDeathSaved = true;
                resist = true;
                EffectView.TextOutSimple(this.BChar, this.BuffData.Name);
            }
        }
    }
}
