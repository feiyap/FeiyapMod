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
namespace Ralmia
{
	/// <summary>
	/// 绝高无上
	/// 回合结束时，会对随机敌人造成「本次对战中已被打出的创造物种类数量」*攻击力的伤害。
	/// </summary>
    public class B_Ralmia_11Rare:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            int count = 0;
            if (this.BChar.BuffFind("B_Ralmia_3", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_4", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_5", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_6", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_7", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_8", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_9", false))
            {
                count++;
            }
            for (int i = 0; i < count; i++)
            {
                BattleSystem.DelayInputAfter(this.Ienum());
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Ralmia_11Rare_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }
    }
}