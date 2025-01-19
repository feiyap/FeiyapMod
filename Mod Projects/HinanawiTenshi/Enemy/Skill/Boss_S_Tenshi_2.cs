using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
namespace HinanawiTenshi
{
	/// <summary>
	/// 非想「非想非非想之剑」
	/// 指向持有最多增益的调查员。
	/// 目标身上每持有1个增益，这个技能的伤害提升1.1倍。
	/// 使目标持有的所有增益减少1回合持续时间。
	/// </summary>
    public class Boss_S_Tenshi_2: SkillBase_Tenshi
    {
        public override void Init()
        {
            base.Init();
            this.EnemyPreviewNoArrow = true;
        }

        //public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        //{
        //    int kishi = CheckBuffNum2(Target);
        //    int num = (int)(Math.Pow(1.1, kishi) * 100) - 100;
        //    if (num > 0)
        //    {
        //        PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
        //    }
        //}

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int kishi = CheckBuffNum2(Targets[0]);
            int num = (int)(Math.Pow(1.1, kishi) * 100) - 100;

            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.5f * num / 100);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            List<Buff> list = new List<Buff>();
            foreach (Buff buff in hit.Buffs)
            {
                if (!buff.BuffData.Hide && buff.LifeTime >= 2)
                {
                    if (!buff.BuffData.Debuff)
                    {
                        buff.TurnUpdate();
                    }
                    //else if (buff.BuffData.LifeTime != 0f)
                    //{
                    //    for (int i = 0; i < buff.StackInfo.Count; i++)
                    //    {
                    //        buff.StackInfo[i].RemainTime--;
                    //        if (buff.StackInfo[i].RemainTime == 0)
                    //        {
                    //            buff.SelfStackDestroy();
                    //            i--;
                    //        }
                    //    }
                    //}
                }
            }
        }

        public int CheckBuffNum2(BattleChar bc)
        {
            int count = 0;

            count = bc.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;

            return count;
        }
    }
}