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
	/// 狂涛蛇颈龙
	/// 每次手中的卡片被交换/丢弃时，对随机敌人造成1倍攻击力伤害，恢复体力百分比最低的队友0.5倍攻击力体力。
	/// </summary>
    public class B_Lumiore_12Rare:Buff, IP_Discard, IP_PlayerTurn
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
            Skill skill = Skill.TempSkill("S_Lumiore_12Rare_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            BattleChar battleChar = null;
            foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar == null)
                {
                    battleChar = battleChar2;
                }
                else if (battleChar != null && battleChar.HP > battleChar2.HP)
                {
                    battleChar = battleChar2;
                }
            }
            if (battleChar != null)
            {
                battleChar.Heal(this.BChar, this.BChar.GetStat.atk * 0.5f, false, false, null);
            }

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}