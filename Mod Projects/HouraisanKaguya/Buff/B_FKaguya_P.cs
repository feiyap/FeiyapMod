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
namespace HouraisanKaguya
{
	/// <summary>
	/// 辉夜/永夜
	/// </summary>
    public class B_FKaguya_P:Buff, IP_BuffAdd
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyList)
            {
                bool flag = battleChar.BuffFind("B_FKaguya_11Rare", false);
                if (flag)
                {
                    bool flag2 = BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_FKaguya_P" && base.StackNum == this.BuffData.MaxStack && BuffUser != this.BChar;
                    if (flag2)
                    {
                        int stackNum = addedbuff.StackNum;
                        this.KaguyaAttack(BuffTaker, stackNum);
                        break;
                    }
                }
            }
        }

        public virtual void KaguyaAttack(BattleChar hit, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Skill skill = Skill.TempSkill("S_FKaguya_11Rare_0", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, hit));
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            this.BChar.ParticleOut(skill, hit);
            yield return null;
            yield break;
        }

        public override void Init()
        {
            this.PlusStat.hit = -3 * StackNum;
        }
        
        public override void BuffStat()
        {
            this.PlusStat.hit = -3 * StackNum;
            base.BuffStat();
        }
    }
}