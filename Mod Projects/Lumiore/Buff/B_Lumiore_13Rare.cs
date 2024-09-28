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
namespace Lumiore
{
	/// <summary>
	/// 金色威信
	/// 每次手中的技能被交换/丢弃时，对所有敌人造成交换/舍弃的个数x&a伤害。
	/// </summary>
    public class B_Lumiore_13Rare:Buff, IP_Discard, IP_PlayerTurn
    {
        int count;

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void Turn()
        {
            count = 0;
        }

        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (count < 20)
            {
                BattleSystem.DelayInputAfter(this.Ienum());
                count++;
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Lumiore_13Rare_0", this.BChar, this.BChar.MyTeam);
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
            return base.DescExtended().Replace("%a", (this.BChar.GetStat.atk * 2.0f).ToString());
        }
    }
}