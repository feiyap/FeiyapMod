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
namespace Ralmia2
{
	/// <summary>
	/// 遗产的炮击
	/// 每次进行“融合”时，对随机敌人造成 &a 伤害(攻击力的100%)。
	/// </summary>
    public class B_Ralmia2_8:Buff, IP_FusionAfter
    {
        public void FusionAfterCall()
        {
            BattleSystem.DelayInputAfter(this.Ienum());
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Ralmia2_8_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public override string DescExtended()
        {
            int num = 0;
            if (BattleSystem.instance != null)
            {
                num = (int)(this.BChar.GetStat.atk * 1.0f);
            }

            return base.DescExtended().Replace("&a", num.ToString());
        }
    }
}