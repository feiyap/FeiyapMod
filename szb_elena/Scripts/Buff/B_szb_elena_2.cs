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
namespace szb_elena
{
    /// <summary>
    /// 圣弓使役
    /// 当自己回复生命值时，对所有敌人造成&a(攻击力的60%)伤害（1回合最多触发10次）。
    /// </summary>
    public class B_szb_elena_2 : Buff,IP_Healed
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.Usestate_F.GetStat.atk * 0.6f)).ToString());
        }

        public int TurnUsedNum;
        public override void Init()
        {
            base.Init();
            this.TurnUsedNum = 0;
        }
        public void Turn()
        {
            this.TurnUsedNum = 0;
        }
        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (TurnUsedNum < 10)
            {
                foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
                {
                    for (int i = 0; i < base.StackNum; i++)
                    {
                        //battleEnemy.Damage(this.BChar, (int)(this.BChar.GetStat.atk * 0.6), false, false, false, 0, false, false, false);
                        Skill skill = Skill.TempSkill("S_szb_elena_2_0", base.Usestate_L, this.BChar.MyTeam);
                        skill.PlusHit = true;
                        BattleSystem.DelayInput(this.DDK(skill, battleEnemy));
                    }
                }
                TurnUsedNum++;
            }

        }

        public IEnumerator DDK(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (!hit.IsDead)
            {
                base.Usestate_L.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                base.Usestate_L.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                base.Usestate_L.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}