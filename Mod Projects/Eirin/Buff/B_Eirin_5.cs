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
namespace Eirin
{
	/// <summary>
	/// 月人/苏活
	/// 下次受到伤害时，恢复&a体力，并对来源发动一次[月人/乱箭]；
	/// 如果处于濒死阶段，抵消该伤害。
	/// </summary>
    public class B_Eirin_5:Buff, IP_DamageTake
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)((float)base.Usestate_F.GetStat.reg * 1.2f)).ToString());
        }
        
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && !resist)
            {
                if (this.BChar.HP <= 0)
                {
                    resist = true;
                }
                BattleSystem.instance.StartCoroutine(this.Heal(this.BChar));

                Skill skill = Skill.TempSkill("S_Eirin_P", base.Usestate_L, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, User));
                
                base.SelfDestroy(false);
            }
        }
        
        public IEnumerator Heal(BattleChar Char)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            this.BChar.Heal(base.Usestate_F, (float)((int)((float)base.Usestate_F.GetStat.reg * 1.2f)), false, false, null);
            yield break;
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
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