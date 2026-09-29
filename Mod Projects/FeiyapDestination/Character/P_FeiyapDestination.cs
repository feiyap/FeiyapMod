using System;
using System.Collections;
using System.Collections.Generic;
using ChronoArkMod.Template;
using UnityEngine;

namespace FeiyapDestination
{
    /// <summary>
    /// 终点·绯夜氏：武士自东方来（全被动聚合）
    /// </summary>
    public class P_FeiyapDestination : Passive_Char,
        IP_PlayerTurn,
        IP_BattleStart_Ones,
        IP_BattleEnd,
        IP_WaitButton,
        IP_SkillUse_Target,
        IP_SomeOneDead,
        IP_DamageTakeChange
    {
        public JobMode CurrentJob = JobMode.Offense;
        /// <summary>流风遗韵拦截后的减伤标记。</summary>
        public bool PendingInterceptReduce;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            if (cv != null)
            {
                this.CurrentJob = cv.Job;
            }
            AdvantageSystem.SetBaseAdvantage(FeiyapKeys.Destination, 1, 1, 1);
        }

        public void BattleStart(BattleSystem Ins)
        {
            AdvantageSystem.ClearBattle();
            AdvantageSystem.SetBaseAdvantage(FeiyapKeys.Destination, 1, 1, 1);

            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            if (cv != null)
            {
                this.CurrentJob = cv.Job;
                int stacks = cv.YuanqiStacks;
                for (int i = 0; i < stacks; i++)
                {
                    this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Yuanqi, this.BChar, false, 0, false, -1, false);
                }
            }

            // 战斗开始：每名已死亡的其他绯夜氏 → 诸我自在 + 技能转移 + 继承
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.Chars)
            {
                if (bc == null || bc == this.BChar || bc.Info == null)
                {
                    continue;
                }
                if (FeiyapKeys.IsOtherFeiyap(bc.Info.KeyData) && bc.IsDead)
                {
                    this.GainZhuziFrom(bc);
                }
            }

            this.RefreshJobBuffs();
        }

        public void BattleEnd()
        {
            // 并肩完成战斗（循环推进的最小实现）：记录同队角色
            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            if (cv == null || BattleSystem.instance == null)
            {
                return;
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.Chars)
            {
                if (bc == null || bc.Info == null || bc == this.BChar)
                {
                    continue;
                }
                if (bc.Info.Ally && !string.IsNullOrEmpty(bc.Info.KeyData) && bc.Info.KeyData != "Lucy")
                {
                    cv.AddYuanqiAlly(bc.Info.KeyData);
                }
            }
            cv.Job = this.CurrentJob;
        }

        public void Turn()
        {
            // 莲心守月：1 普通 → 真
            TrueAp.ConvertNormalToTrue(1);

            // 诸我自在：过载 -2/层
            if (this.BChar.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Zhuzi, false))
            {
                Buff zhuzi = this.BChar.BuffReturn(ModItemKeys.Buff_B_FeiyapDestination_Zhuzi, false);
                if (zhuzi != null)
                {
                    this.BChar.Overload -= 2 * zhuzi.StackNum;
                }
            }

            // 黄金瞳：每名其他存活绯夜，标记 1 敌
            int siblingCount = 0;
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (bc != null && bc != this.BChar && bc.Info != null && FeiyapKeys.IsOtherFeiyap(bc.Info.KeyData))
                {
                    siblingCount++;
                }
            }
            List<BattleChar> enemies = new List<BattleChar>(BattleSystem.instance.EnemyTeam.AliveChars);
            for (int i = 0; i < siblingCount && enemies.Count > 0; i++)
            {
                BattleChar target = enemies.Random(this.BChar.GetRandomClass().Main);
                if (target != null)
                {
                    target.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Mark, this.BChar, false, 0, false, -1, false);
                    enemies.Remove(target);
                }
            }

            this.RefreshJobBuffs();
        }

        public void RefreshJobBuffs()
        {
            // 莲心 Buff 自身根据 CurrentJob 刷新暴伤；拦截由 Lianxin Buff 的 IP_TargetedAlly 判断职业
            if (this.BChar.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Lianxin, false))
            {
                Buff lx = this.BChar.BuffReturn(ModItemKeys.Buff_B_FeiyapDestination_Lianxin, false);
                if (lx != null)
                {
                    lx.BuffStatUpdate();
                }
            }
        }

        public void ToggleJob()
        {
            this.CurrentJob = this.CurrentJob == JobMode.Offense ? JobMode.Defense : JobMode.Offense;
            CV_FeiyapDestination cv = CV_FeiyapDestination.Instance;
            if (cv != null)
            {
                cv.Job = this.CurrentJob;
            }
            this.RefreshJobBuffs();
            EffectView.TextOutSimple(this.BChar, this.CurrentJob == JobMode.Offense
                ? "免许皆传·终点·绯夜氏"
                : "流风遗韵·终点·绯夜氏");
        }

        /// <summary>第八文字：耗法力等待 → 杀顶牌其他绯夜</summary>
        public void UseWaitButton()
        {
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return;
            }
            int totalAp = BattleSystem.instance.AllyTeam.AP + TrueAp.TrueAP;
            if (totalAp < 1)
            {
                return;
            }
            BattleAlly selfAlly = this.BChar as BattleAlly;
            if (selfAlly == null)
            {
                return;
            }
            int trueSpent = TrueAp.SpendApNormalThenTrue(selfAlly, 1);
            TrueAp.OnTrueApConsumed(trueSpent);

            if (BattleSystem.instance.AllyTeam.Skills == null || BattleSystem.instance.AllyTeam.Skills.Count == 0)
            {
                return;
            }
            Skill top = BattleSystem.instance.AllyTeam.Skills[0];
            if (top == null || top.Master == null || top.Master == this.BChar || top.Master.Info == null)
            {
                return;
            }
            if (!FeiyapKeys.IsOtherFeiyap(top.Master.Info.KeyData))
            {
                return;
            }
            BattleChar victim = top.Master;
            this.KillAndInherit(victim);
        }

        public void SomeOneDead(BattleChar DeadChar)
        {
            if (DeadChar == null || DeadChar == this.BChar || DeadChar.Info == null)
            {
                return;
            }
            if (FeiyapKeys.IsOtherFeiyap(DeadChar.Info.KeyData))
            {
                this.GainZhuziFrom(DeadChar);
            }
        }

        public void KillAndInherit(BattleChar victim)
        {
            if (victim == null || victim.IsDead)
            {
                return;
            }
            this.TransferSkills(victim);
            victim.Dead(false, false);
            this.GainZhuziFrom(victim);
        }

        public void GainZhuziFrom(BattleChar victim)
        {
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Zhuzi, this.BChar, false, 0, false, -1, false);
            this.TransferSkills(victim);
            FeiyapVariant v = FeiyapKeys.Classify(victim.Info.KeyData);
            switch (v)
            {
                case FeiyapVariant.Feiyap:
                    if (!this.BChar.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Feiyap, false))
                    {
                        this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Feiyap, this.BChar, false, 0, false, -1, false);
                    }
                    break;
                case FeiyapVariant.FeiyapTank:
                    if (!this.BChar.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Tank, false))
                    {
                        this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Tank, this.BChar, false, 0, false, -1, false);
                    }
                    break;
                case FeiyapVariant.FeiyapMage:
                    if (!this.BChar.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Mage, false))
                    {
                        this.BChar.BuffAdd(ModItemKeys.Buff_B_FeiyapDestination_Inherit_Mage, this.BChar, false, 0, false, -1, false);
                    }
                    break;
            }
        }

        public void TransferSkills(BattleChar from)
        {
            if (from == null || BattleSystem.instance == null)
            {
                return;
            }
            BattleTeam team = BattleSystem.instance.AllyTeam;
            Action<List<Skill>> transfer = list =>
            {
                if (list == null)
                {
                    return;
                }
                foreach (Skill s in list)
                {
                    if (s != null && s.Master == from)
                    {
                        s.Master = this.BChar;
                    }
                }
            };
            transfer(team.Skills);
            transfer(team.Skills_Deck);
            transfer(team.Skills_UsedDeck);
            transfer(team.ALLSKILLLIST);
        }

        /// <summary>黄金瞳：攻击标记目标 → 其他绯夜追击</summary>
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            Advantage_HitRoll_Patch.CurrentAttacker = null;
            if (hit == null || hit.Info == null || hit.Info.Ally)
            {
                return;
            }
            if (SP == null || SP.SkillData == null || SP.SkillData.PlusHit)
            {
                return;
            }
            if (!hit.BuffFind(ModItemKeys.Buff_B_FeiyapDestination_Mark, false))
            {
                return;
            }
            // 攻击者须为绯夜家族
            BattleChar attacker = SP.SkillData.Master;
            if (attacker == null || attacker.Info == null || !FeiyapKeys.IsFeiyapFamily(attacker.Info.KeyData))
            {
                return;
            }

            hit.BuffReturn(ModItemKeys.Buff_B_FeiyapDestination_Mark, false).SelfDestroy();

            foreach (BattleChar ally in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (ally == null || ally == attacker || ally.Info == null)
                {
                    continue;
                }
                if (!FeiyapKeys.IsFeiyapFamily(ally.Info.KeyData))
                {
                    continue;
                }
                FeiyapVariant variant = FeiyapKeys.Classify(ally.Info.KeyData);
                if (variant == FeiyapVariant.Destination)
                {
                    variant = FeiyapVariant.Feiyap;
                }
                string skillKey = FeiyapKeys.ChaseSkillKey(variant);
                Skill chase = Skill.TempSkill(skillKey, ally, ally.MyTeam);
                chase.PlusHit = true;
                BattleSystem.DelayInput(this.CoChase(ally, chase, hit, variant));
            }
        }

        private IEnumerator CoChase(BattleChar user, Skill skill, BattleChar target, FeiyapVariant variant)
        {
            yield return new WaitForSecondsRealtime(0.15f);
            if (target == null || target.IsDead || user == null || user.IsDead)
            {
                yield break;
            }
            if (variant == FeiyapVariant.FeiyapTank)
            {
                user.ParticleOut(skill, target);
                yield return new WaitForSecondsRealtime(0.1f);
                if (!target.IsDead)
                {
                    Skill chase2 = Skill.TempSkill(ModItemKeys.Skill_S_FeiyapDestination_Chase_Tank, user, user.MyTeam);
                    chase2.PlusHit = true;
                    user.ParticleOut(chase2, target);
                }
            }
            else
            {
                user.ParticleOut(skill, target);
            }
            yield break;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.SelectedSkill != null
                && BattleSystem.instance.SelectedSkill.Master == this.BChar)
            {
                Advantage_HitRoll_Patch.CurrentAttacker = this.BChar;
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF, bool NOEFFECT, bool Preview)
        {
            if (!this.PendingInterceptReduce || Hit != this.BChar)
            {
                return Dmg;
            }
            this.PendingInterceptReduce = false;
            int reduce = 5 * this.BChar.Info.LV;
            int result = Dmg - reduce;
            return result < 0 ? 0 : result;
        }
    }
}
