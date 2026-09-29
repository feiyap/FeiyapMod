using System.Collections;
using System.Collections.Generic;
using ChronoArkMod.Template;

namespace FeiyapDestination
{
    /// <summary>
    /// 莲心：输出模式提供暴伤；防御模式可拦截。
    /// </summary>
    public class B_FeiyapDestination_Lianxin : Buff, IP_TargetedAlly
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusCriDmg = 0;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            P_FeiyapDestination passive = this.BChar.Info.Passive as P_FeiyapDestination;
            if (passive != null && passive.CurrentJob == JobMode.Offense)
            {
                this.PlusStat.PlusCriDmg = 10 * this.StackNum;
            }
            else
            {
                this.PlusStat.PlusCriDmg = 0;
            }
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            P_FeiyapDestination passive = this.BChar.Info.Passive as P_FeiyapDestination;
            if (passive == null || passive.CurrentJob != JobMode.Defense)
            {
                yield break;
            }
            if (this.StackNum < 1)
            {
                yield break;
            }
            bool selfTargeted = false;
            for (int i = 0; i < SaveTargets.Count; i++)
            {
                if (SaveTargets[i] == this.BChar)
                {
                    selfTargeted = true;
                    break;
                }
            }
            if (selfTargeted)
            {
                yield break;
            }
            for (int j = 0; j < SaveTargets.Count; j++)
            {
                if (SaveTargets[j] != null && SaveTargets[j] != this.BChar && SaveTargets[j].Info != null && SaveTargets[j].Info.Ally)
                {
                    SaveTargets[j] = this.BChar;
                    EffectView.TextOutSimple(this.BChar, this.BuffData.Name);
                    passive.PendingInterceptReduce = true;
                    this.SelfStackDestroy();
                    yield break;
                }
            }
            yield break;
        }
    }
}
