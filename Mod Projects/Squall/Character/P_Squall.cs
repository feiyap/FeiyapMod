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
namespace Squall
{
	/// <summary>
	/// 斯考尔
	/// Passive:
	/// 回合开始时获得一层[刃甲]。每当斯考尔替队友承受攻击时，获得一层[刃甲]。
	/// 在一个回合内累计承受超过最大生命值25%的物理伤害后，消耗3层[刃甲]，对随机敌人进行4段30%攻击力的反击。
	/// 装备不再为斯考尔增加防御力。
	/// </summary>
    public class P_Squall:Passive_Char, IP_PlayerTurn, IP_DamageTake, IP_SaveTargets
    {
        public bool trigger = false;
        public int dmgtake = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.BChar.BuffAdd("B_Squall_P", this.BChar);
            this.trigger = false;
            dmgtake = 0;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                dmgtake += Dmg;
            }
            
            if (dmgtake >= this.BChar.GetStat.maxhp * 0.25 && this.BChar.BuffReturn("B_Squall_P")?.StackNum >= 3 && !trigger)
            {
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();
                this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();

                for (int i = 0; i < 4; i++)
                {
                    BattleSystem.DelayInputAfter(this.Attack());
                }
                trigger = true;
            }
        }

        public IEnumerator Attack()
        {
            yield return new WaitForSecondsRealtime(0.25f);

            Skill skill = Skill.TempSkill("S_Squall_P", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            yield break;
        }

        public void SaveTargets()
        {
            if (this.BChar.BuffFind("B_Squall_Rare_1"))
            {
                return;
            }

            this.BChar.BuffAdd("B_Squall_P", this.BChar);
        }
    }

    public interface IP_SaveTargets
    {
        void SaveTargets();
    }
}